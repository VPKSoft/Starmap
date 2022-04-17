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
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.IO;
using VPKSoft.LangLib;


namespace SMap
{
    /// <summary>
    /// Description of ShowRaDec.
    /// </summary>
    public partial class ShowRaDec : DBLangEngineWinforms
    {
        private static SettingCfg Config;
        private static float OffSet;
        private static Graphics DGraph;
        string ErrorInvalidRaDecValues = string.Empty;
        string ErrorDialogCaption = string.Empty;
        public ShowRaDec()
        {
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
            ShowSelectedIm();
            InitLanguage();
        }

        void InitLanguage()
        {
            ErrorInvalidRaDecValues = DBLangEngine.GetMessage("msgErrorInvalidRaDecValues", "Invalid Ra/Dec values (\"{0}\").|The values of right ascension / declination are invalid");
            ErrorDialogCaption = DBLangEngine.GetMessage("msgErrorDialogCaptionError", "Error|A standard caption for an error dialog");
        }


        void Button3Click(object sender, System.EventArgs e)
        {
            Close();
        }

        public static void Execute(SettingCfg Cfg, float OffS, ref PictureBox PBox)
        {
            Config = Cfg;
            OffSet = OffS;
            //			DGraph = Gr;
            PicBox = PBox;
            DGraph = Graphics.FromImage(PicBox.Image);
            ShowRaDec SRD = new ShowRaDec();
            SRD.ShowDialog();
        }

        void Button1Click(object sender, System.EventArgs e)
        {
            double Ra, Dec;
            try
            {
                Ra = Convert.ToDouble(textBox1.Text);
                Dec = Convert.ToDouble(textBox2.Text);
                DrawObj(Ra, Dec, (int)nudUseSign.Value);
                PicBox.Refresh();
            }
            catch (Exception E)
            {
                MessageBox.Show(string.Format(ErrorInvalidRaDecValues, E.Message), ErrorDialogCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void DrawObj(double Ra, double Dec, int ImIndex)
        {
            DrawStellarObject(Config.Latitude, Config.Longitude, DateTime.Now, Config.FlipX, Config.FlipY, OffSet, OffSet - 15, Ra, Dec, ImIndex);
        }

        public void DrawStellarObject(double Latid, double Longit, DateTime Dt, bool FlipX, bool FlipY, float offset, float scale, double Ra, double Dec, int ImIndex)
        {
            double SidTime = Plot.SiderealTime(Dt, Longit);
            double x = 0, y = 0;
            Plot.StereographicProjection(1, Latid, Longit, ref x, ref y, SidTime, Ra, Dec);
            if (!FlipY) y *= -1;
            if (!FlipX) x *= -1;
            locationMarks.Draw(DGraph, new Point((int)(scale * x + offset - 7), (int)(scale * y + offset - 7)), ImIndex);
        }

        public void ShowSelectedIm()
        {
            Bitmap Bm = new Bitmap(15, 15);
            Graphics Gr = Graphics.FromImage(Bm);
            Gr.FillRectangle(Brushes.Black, 0, 0, 15, 15);
            locationMarks.Draw(Gr, new Point(0, 0), (int)nudUseSign.Value);
            pbSign.Image = Bm;
        }

        private void nudUseSign_ValueChanged(object sender, EventArgs e)
        {
            ShowSelectedIm();
        }
    }
}
