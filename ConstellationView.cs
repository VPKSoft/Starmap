#region License
/*
Starmap

A 2D star map program.
Copyright © 2017 VPKSoft, Petteri Kautonen

Contact: vpksoft@vpksoft.net

This file is part of Starmap.

Starmap is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Starmap is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Starmap.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using Plotter;
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using VPKSoft.LangLib;
using VPKSoft.PosLib;

namespace SMap
{
    /// <summary>
    /// Description of ConstellationView.
    /// </summary>

    public struct CoordPair
    {
        public float X1, Y1, X2, Y2;
        public string Name1, Name2;
    }

    public struct ConItem
    {
        public string Name;
        public CoordPair[] Coords;
    }
    public partial class ConstellationView : DBLangEngineWinforms
    {
        private bool CanDraw = false;

        public ConItem[] ConItems = new ConItem[89];
        public ConItem LastItem = new ConItem();

        string[] ConsNamesShort = new string[89];
        string[] ConsNamesLong = new string[89];
        string CanNotReadConstellationDataText = string.Empty;
        string ErrorDialogCaptionErrorText = string.Empty;
        string CanNorReadDataText = string.Empty;
        string CaptionText = string.Empty;

        public ConstellationView()
        {
            PositionForms.Add(this, PositionCore.SizeChangeMode.MoveTopLeft);
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            if (Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("SMap.Messages", Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }
            DBLangEngine.InitalizeLanguage("SMap.Messages");

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //

            CaptionText = Text;

            InitLanguage();
            ReadConsDataAll();
            CanDraw = true;
            DrawCons(cmbConstellations.Text, (double)tbConstellationAngle.Value);
        }

        void InitLanguage()
        {
            SettingsConfig Config = new SettingsConfig();
            SettingCfg Cfg = Config.Cfg;
            string LanguageSetting = Cfg.Language;

            cmbConstellations.Items.Clear();

            ConsNamesShort = DBLangEngine.GetMessage("msgShortConstNames", "And;Ant;Aps;Aql;Aqr;Ara;Ari;Aur;Boo;Cae;Cam;Cap;Car;Cas;Cen;Cep;Cet;Cha;Cir;CMa;CMi;Cnc;Col;Com;CrA;CrB;Crt;Cru;Crv;CVn;Cyg;Del;Dor;Dra;Equ;Eri;For;Gem;Gru;Her;Hor;Hya;Hyi;Ind;Lac;Leo;Lep;Lib;LMi;Lup;Lyn;Lyr;Men;Mic;Mon;Mus;Nor;Oct;Oph;Ori;Pav;Peg;Per;Phe;Pic;PsA;Psc;Pup;Pyx;Ret;Scl;Sco;Sct;SeC;Ser;Sex;Sge;Sgr;Tau;Tel;TrA;Tri;Tuc;UMa;UMi;Vel;Vir;Vol;Vul|Short constellation names", CultureInfo.CreateSpecificCulture(LanguageSetting)).Split(';');
            ConsNamesLong = DBLangEngine.GetMessage("msgLongConstNames", "Andromeda;Antlia;Apus;Aquila;Aquarius;Ara;Aries;Auriga;Boötes;Caelum;Camelopardalis;Capricornus;Carina;Cassiopeia;Centaurus;Cepheus;Cetus;Chamaeleon;Circinus;Canis Major;Canis Minor;Cancer;Columba;Coma Berenices;Corona Australis;Corona Borealis;Crater;Crux;Corvus;Canes Venatici;Cygnus;Delphinus;Dorado;Draco;Equuleus;Eridanus;Fornax;Gemini;Grus;Hercules;Horologium;Hydra;Hydrus;Indus;Lacerta;Leo;Lepus;Libra;Leo Minor;Lupus;Lynx;Lyra;Mensa;Microscopium;Monoceros;Musca;Norma;Octans;Ophiuchus;Orion;Pavo;Pegasus;Perseus;Phoenix;Pictor;Pisces Austrinus;Pisces;Puppis;Pyxis;Reticulum;Sculptor;Scorpius;Scutum;Serpens Cauda;Serpens Caput;Sextans;Sagitta;Sagittarius;Taurus;Telescopium;Triangulum Australe;Triangulum;Tucana;Ursa Major;Ursa Minor;Vela;Virgo;Volans;Vulpecula|Long constellation names", CultureInfo.CreateSpecificCulture(LanguageSetting)).Split(';');

            for (int i = 0; i < ConsNamesShort.Length; i++)
            {
                cmbConstellations.Items.Add(ConsNamesShort[i] + " / " + ConsNamesLong[i]);
            }
            cmbConstellations.SelectedIndex = 0;
        }


        private float XYSizeMin // 06.11.17
        {
            get
            {
                return pbConstellation.Width > pbConstellation.Height ? pbConstellation.Height : pbConstellation.Width;
            }
        }

        private float XYSizeMinHalf // 06.11.17
        {
            get
            {
                return XYSizeMin / 2;
            }
        }

        private float XYSizeMultiplier // 06.11.17
        {
            get
            {
                return XYSizeMin / 400; // Number 400 is from the file Cons2D.txt as it was designed to be plotted on an 400x400 bitmap..
            }
        }

        public float CenterAdjustX // 06.11.17
        {
            get
            {
                return (pbConstellation.Width - XYSizeMin) / 2;
            }
        }

        public float CenterAdjustY // 06.11.17
        {
            get
            {
                return (pbConstellation.Height - XYSizeMin) / 2;
            }
        }


        public void DrawCons(String ConName, double RotAngle)
        {
            ConName = ConName.Substring(0, 3).ToUpper();
            int ConIndex = 0;
            for (int i = 0; i < 89; i++)
            {
                if (ConItems[i].Name == ConName)
                {
                    ConIndex = i;
                }
            }



            ConItem Con = new ConItem();
            ConItem Con2 = ConItems[ConIndex];
            Con.Coords = new CoordPair[Con2.Coords.Length];

            Bitmap Bm = new Bitmap(pbConstellation.Width, pbConstellation.Height);
            Graphics Gr = Graphics.FromImage(Bm);

            SolidBrush Br = new SolidBrush(Color.White);
            Pen P = new Pen(Color.Black, 1);

            Gr.FillRectangle(Br, 0, 0, Bm.Width, Bm.Height);
            Br = new SolidBrush(Color.Black);

            Font F = new Font("Arial", 8);

            double X, Y, Z;
            for (int i = 0; i < Con.Coords.Length; i++)
            {

                Con.Coords[i].Name1 = Con2.Coords[i].Name1;
                Con.Coords[i].Name2 = Con2.Coords[i].Name2;
                Con.Coords[i].X1 = Con2.Coords[i].X1;
                Con.Coords[i].X2 = Con2.Coords[i].X2;
                Con.Coords[i].Y1 = Con2.Coords[i].Y1;
                Con.Coords[i].Y2 = Con2.Coords[i].Y2;

                Con.Coords[i].X1 *= XYSizeMultiplier; // 06.11.17
                Con.Coords[i].Y1 *= XYSizeMultiplier; // 06.11.17
                Con.Coords[i].X2 *= XYSizeMultiplier; // 06.11.17
                Con.Coords[i].Y2 *= XYSizeMultiplier; // 06.11.17

                Con.Coords[i].Name1 = FormatStarName(Con.Coords[i].Name1);
                Con.Coords[i].Name2 = FormatStarName(Con.Coords[i].Name2);

                if (cbMirror.Checked)
                {
                    Con.Coords[i].X1 = XYSizeMin - Con.Coords[i].X1;
                    Con.Coords[i].X2 = XYSizeMin - Con.Coords[i].X2;
                }

                Con.Coords[i].X1 -= XYSizeMinHalf;
                Con.Coords[i].Y1 -= XYSizeMinHalf;
                Con.Coords[i].X2 -= XYSizeMinHalf;
                Con.Coords[i].Y2 -= XYSizeMinHalf;

                Z = 0;
                X = Con.Coords[i].X1;
                Y = Con.Coords[i].Y1;
                Plot.RotateZ(RotAngle, ref X, ref Y, ref Z);
                Con.Coords[i].X1 = (float)X;
                Con.Coords[i].Y1 = (float)Y;

                Z = 0;
                X = Con.Coords[i].X2;
                Y = Con.Coords[i].Y2;
                Plot.RotateZ(RotAngle, ref X, ref Y, ref Z);
                Con.Coords[i].X2 = (float)X;
                Con.Coords[i].Y2 = (float)Y;

                Con.Coords[i].X1 += XYSizeMinHalf;
                Con.Coords[i].Y1 += XYSizeMinHalf;
                Con.Coords[i].X2 += XYSizeMinHalf;
                Con.Coords[i].Y2 += XYSizeMinHalf;

                Con.Coords[i].X1 += CenterAdjustX; // 06.11.17
                Con.Coords[i].Y1 += CenterAdjustY; // 06.11.17
                Con.Coords[i].X2 += CenterAdjustX; // 06.11.17
                Con.Coords[i].Y2 += CenterAdjustY; // 06.11.17

                Gr.DrawLine(P, Con.Coords[i].X1, Con.Coords[i].Y1, Con.Coords[i].X2, Con.Coords[i].Y2);
            }

            P = new Pen(Color.Blue, 1);

            Br = new SolidBrush(Color.Green);

            for (int i = 0; i < Con.Coords.Length; i++)
            {
                Gr.DrawEllipse(P, Con.Coords[i].X1 - 1, Con.Coords[i].Y1 - 1, 3, 3);
                Gr.DrawEllipse(P, Con.Coords[i].X2 - 1, Con.Coords[i].Y2 - 1, 3, 3);
                if (!cbHideSNames.Checked) Gr.DrawString(Con.Coords[i].Name1, F, Br, Con.Coords[i].X1, Con.Coords[i].Y1);
                if (!cbHideSNames.Checked) Gr.DrawString(Con.Coords[i].Name2, F, Br, Con.Coords[i].X2, Con.Coords[i].Y2);
            }
            LastItem = Con;
            pbConstellation.Image = Bm;
        }

        public static void Execute()
        {
            ConstellationView Cw = new ConstellationView();
            Cw.ShowDialog();
        }

        public void ReadConsDataAll()
        {
            for (int i = 0; i < 89; i++)
            {
                if (!ReadConsData(ConsNamesShort[i], out ConItems[i]))
                {
                    MessageBox.Show(string.Format(CanNotReadConstellationDataText, ConsNamesLong[i]), ErrorDialogCaptionErrorText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        public string FormatStarName(string StarName)
        {
            if (StarName == null)
            {
                return "";
            }
            if (StarName.Length == 0)
            {
                return "";
            }
            try
            {
                string SName = StarName.Trim();
                if (SName[SName.Length - 1] == '/')
                {
                    SName = SName.Substring(0, SName.Length - 2);
                }
                return SName;
            }
            catch
            {
                return "";
            }
        }

        bool CoordsInStar(float X, float Y, out string StarName)
        {
            float SSize = 2;
            for (int i = 0; i < LastItem.Coords.Length; i++)
            {
                if (LastItem.Coords[i].X1 <= X + SSize && LastItem.Coords[i].X1 >= X - SSize && LastItem.Coords[i].Y1 >= Y - SSize && LastItem.Coords[i].Y1 <= Y + SSize)
                {
                    StarName = LastItem.Coords[i].Name1;
                    return true;
                }
                if (LastItem.Coords[i].X2 <= X + SSize && LastItem.Coords[i].X2 >= X - SSize && LastItem.Coords[i].Y2 >= Y - SSize && LastItem.Coords[i].Y2 <= Y + SSize)
                {
                    StarName = LastItem.Coords[i].Name2;
                    return true;
                }
            }
            StarName = "";
            return false;
        }

        public bool ReadConsData(string ConsName, out ConItem CI)
        {
            try
            {
                NumberFormatInfo nfi = new NumberFormatInfo();
                nfi.NumberDecimalSeparator = ".";

                int ConItemCount = 0;
                string ConStart = "#" + ConsName.Substring(0, 3).ToUpper();
                string ConEnd = "#END_" + ConsName.Substring(0, 3).ToUpper();
                StreamReader sr = new StreamReader(MainForm.OpDir + @"/Data/StarData/Cons2D.txt", System.Text.Encoding.UTF8);


                String RLine = sr.ReadLine();
                while (RLine != ConStart)
                {
                    RLine = sr.ReadLine();
                }

                RLine = sr.ReadLine();
                while (RLine != ConEnd)
                {
                    ConItemCount++;
                    RLine = sr.ReadLine();
                }

                sr.Close();
                sr = new StreamReader(MainForm.OpDir + @"/Data/StarData/Cons2D.txt", System.Text.Encoding.UTF8);

                CI = new ConItem();
                CI.Name = ConsName.Substring(0, 3).ToUpper();
                CI.Coords = new CoordPair[ConItemCount / 4];

                int CoIndex = 0;
                string TempStr;

                RLine = sr.ReadLine();
                while (RLine != ConStart)
                {
                    RLine = sr.ReadLine();
                }

                for (int i = 0; i < ConItemCount / 4; i++)
                {
                    CI.Coords[CoIndex].Name1 = sr.ReadLine();
                    TempStr = sr.ReadLine();
                    CI.Coords[CoIndex].X1 = Convert.ToSingle(TempStr.Substring(0, 8), nfi);
                    CI.Coords[CoIndex].Y1 = Convert.ToSingle(TempStr.Substring(9, 8), nfi);
                    CI.Coords[CoIndex].Name2 = sr.ReadLine();
                    TempStr = sr.ReadLine();
                    CI.Coords[CoIndex].X2 = Convert.ToSingle(TempStr.Substring(0, 8), nfi);
                    CI.Coords[CoIndex].Y2 = Convert.ToSingle(TempStr.Substring(9, 8), nfi);
                    CoIndex++;
                }


            }
            catch (Exception e)
            {
                MessageBox.Show(string.Format(CanNorReadDataText, e.Message), ErrorDialogCaptionErrorText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CI = new ConItem();
                return false;
            }
            return true;
        }
        void ComboBox1SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (CanDraw) DrawCons(cmbConstellations.SelectedItem.ToString(), (double)tbConstellationAngle.Value);
        }

        void HideSNamesCheckedChanged(object sender, System.EventArgs e)
        {
            if (CanDraw) DrawCons(cmbConstellations.SelectedItem.ToString(), (double)tbConstellationAngle.Value);
        }

        void PictureBox1MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            string Name;
            if (CoordsInStar(e.X, e.Y, out Name))
            {
                Text = string.Format(CaptionText + " [ {0} ]", Name);
            }
            else
            {
                Text = CaptionText;
            }
        }

        void CAngleScroll(object sender, System.EventArgs e)
        {
            if (CanDraw) DrawCons(cmbConstellations.SelectedItem.ToString(), (double)tbConstellationAngle.Value);
        }

        private void ConstellationView_Resize(object sender, EventArgs e)
        {
            if (CanDraw) DrawCons(cmbConstellations.SelectedItem.ToString(), (double)tbConstellationAngle.Value);
        }

    }
}
