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

using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using Plotter;
using System.Resources;
using System.Reflection;
using System.Diagnostics;
using VPKSoft.LangLib;
using VPKSoft.PosLib;

namespace SMap
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : DBLangEngineWinforms
    {
        string NoHelpFile = string.Empty;

        public string DataPath;

        DateTime DrawDt = DateTime.Now;
        public int DrawMode;

        public CharacterExplanations Merkit = null;

        public SettingsConfig Config;
        public static double UTCBias = 0;

        public static string OpDir = "";

        public StarDataHolder SData;

        string[] ConsNames = null;

        public double GetOffSet()
        {
            if (pbStarMap.Width > pbStarMap.Height) return (double)pbStarMap.Height / 2; else return (double)pbStarMap.Width / 2;
        }


        public MainForm()
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

            DataPath = Path.GetDirectoryName(Application.ExecutablePath);


            OpDir = DataPath;

            Config = new SettingsConfig();
            SettingCfg Cfg = Config.Cfg;
            InitLanguage(Cfg.StarNameIndex);
            CheckForFiles(DataPath);

            SData = new StarDataHolder(DataPath);


            switch (Cfg.StarDBIndex)
            {
                case 0:
                    SData.LoadYaleSmall();
                    break;
                case 1:
                    SData.LoadHyg();
                    break;
                case 2:
                    SData.LoadYale();
                    break;
                case 3:
                    SData.LoadGliese();
                    break;
            }

            pbStarMap.SizeMode = PictureBoxSizeMode.CenterImage;
            DrawDt = DateTime.Now;
            DrawMode = 0;
            tmUpdateChart.Enabled = true;

            // Allow transparency
            lbEast.Parent = pbStarMap;
            //lbNorth.Parent = pbStarMap;
            lbWest.Parent = pbStarMap;
            //lbSouth.Parent = pbStarMap;
            lbMouseDebug.Visible = debugMode; // 06.11.17
        }

        void InitConsNames(int Index)
        {
            if (Index == 0)
            {
                ConsNames = DBLangEngine.GetMessage("msgShortConstNames", "And;Ant;Aps;Aql;Aqr;Ara;Ari;Aur;Boo;Cae;Cam;Cap;Car;Cas;Cen;Cep;Cet;Cha;Cir;CMa;CMi;Cnc;Col;Com;CrA;CrB;Crt;Cru;Crv;CVn;Cyg;Del;Dor;Dra;Equ;Eri;For;Gem;Gru;Her;Hor;Hya;Hyi;Ind;Lac;Leo;Lep;Lib;LMi;Lup;Lyn;Lyr;Men;Mic;Mon;Mus;Nor;Oct;Oph;Ori;Pav;Peg;Per;Phe;Pic;PsA;Psc;Pup;Pyx;Ret;Scl;Sco;Sct;SeC;Ser;Sex;Sge;Sgr;Tau;Tel;TrA;Tri;Tuc;UMa;UMi;Vel;Vir;Vol;Vul|Short constellation names").Split(';');
            }
            else if (Index == 1)
            {
                ConsNames = DBLangEngine.GetMessage("msgLongConstNames", "Andromeda;Antlia;Apus;Aquila;Aquarius;Ara;Aries;Auriga;Boötes;Caelum;Camelopardalis;Capricornus;Carina;Cassiopeia;Centaurus;Cepheus;Cetus;Chamaeleon;Circinus;Canis Major;Canis Minor;Cancer;Columba;Coma Berenices;Corona Australis;Corona Borealis;Crater;Crux;Corvus;Canes Venatici;Cygnus;Delphinus;Dorado;Draco;Equuleus;Eridanus;Fornax;Gemini;Grus;Hercules;Horologium;Hydra;Hydrus;Indus;Lacerta;Leo;Lepus;Libra;Leo Minor;Lupus;Lynx;Lyra;Mensa;Microscopium;Monoceros;Musca;Norma;Octans;Ophiuchus;Orion;Pavo;Pegasus;Perseus;Phoenix;Pictor;Pisces Austrinus;Pisces;Puppis;Pyxis;Reticulum;Sculptor;Scorpius;Scutum;Serpens Cauda;Serpens Caput;Sextans;Sagitta;Sagittarius;Taurus;Telescopium;Triangulum Australe;Triangulum;Tucana;Ursa Major;Ursa Minor;Vela;Virgo;Volans;Vulpecula|Long constellation names").Split(';');
            }
            else
            {
                ConsNames = DBLangEngine.GetMessage("msgShortConstNames", "And;Ant;Aps;Aql;Aqr;Ara;Ari;Aur;Boo;Cae;Cam;Cap;Car;Cas;Cen;Cep;Cet;Cha;Cir;CMa;CMi;Cnc;Col;Com;CrA;CrB;Crt;Cru;Crv;CVn;Cyg;Del;Dor;Dra;Equ;Eri;For;Gem;Gru;Her;Hor;Hya;Hyi;Ind;Lac;Leo;Lep;Lib;LMi;Lup;Lyn;Lyr;Men;Mic;Mon;Mus;Nor;Oct;Oph;Ori;Pav;Peg;Per;Phe;Pic;PsA;Psc;Pup;Pyx;Ret;Scl;Sco;Sct;SeC;Ser;Sex;Sge;Sgr;Tau;Tel;TrA;Tri;Tuc;UMa;UMi;Vel;Vir;Vol;Vul|Short constellation names").Split(';');
            }
        }

        public void InitLanguage(int CNamesIndex)
        {
            NoHelpFile = DBLangEngine.GetMessage("msgHelpFileNotFound", "Help file \"{0}\" can not be found.|The file containing help for the software was not found");
            InitConsNames(CNamesIndex);
        }


        public bool CheckForFiles(string FileBaseDir)
        {
            bool RetVal = true;
            string FName;
            FName = FileBaseDir + @"/Data/Images/Planet00.bmp";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/Images/Planet01.bmp";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/Images/Planet02.bmp";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/Images/Planet03.bmp";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/Images/Planet04.bmp";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/Images/Planet05.bmp";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/Images/Planet06.bmp";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/Images/Planet07.bmp";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/Images/Planet08.bmp";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/Images/Planet09.bmp";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/StarData/cnames_bin.dat";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/StarData/conlines_bin.dat";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/StarData/Cons2D.txt";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/StarData/gliese3_bin.dat";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/StarData/hyg_bin.dat";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/StarData/yalesmall_bin.dat";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            FName = FileBaseDir + @"/Data/StarData/yale_bin.dat";
            if (!File.Exists(FName))
            {
                RetVal = false;
                ReportMissingFile(FName);
            }
            return RetVal;
        }

        public void ReportMissingFile(string FName)
        {
            MessageBox.Show(DBLangEngine.GetMessage("msgFileNotFound", "File \" {0} \" can not be found.{1}Because the file is missing the program might not operate well.|A file is missing and may affect the programs behaviour", FName, Environment.NewLine), DBLangEngine.GetMessage("msgFileMissing", "Missing file|A required file is missing"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private int imageOffsetX = 0, imageOffsetY = 0; // The ima is not the size of the PictureBox !! (28.10.17)

        public void DrawMap(DateTime Dt)
        {
            Plot P = new Plot(DataPath, Config.Cfg.UseConventionalCelestial);

            ColStruct Cs = new ColStruct();

            SettingCfg Cfg = Config.Cfg;

            Cs.LineCol = Color.FromArgb(Cfg.ConsLineCol);
            Cs.TextCol = Color.FromArgb(Cfg.ConsNameCol);
            Cs.StarCol = Color.FromArgb(Cfg.StarCol);
            Cs.BackCol = Color.FromArgb(Cfg.StarMapCol);
            Cs.RounCol = BackColor;

            Image Bm;


            P.PlotSkyMap(Cfg.Latitude, Cfg.Longitude, Plot.NoDayLight(Dt), out Bm, Cfg.FlipX, Cfg.FlipY, ref SData, Cfg.MagLimit, Cfg.NoSolSys, Cfg.NoConsLines, ConsNames, GetOffSet(), GetOffSet() - 15, ref Cs);

            lbEast.Text = Cfg.FlipX ? DBLangEngine.GetMessage("msgWest", "WEST|As the west as in compass point") :
                                        DBLangEngine.GetMessage("msgEast", "EAST|As the east as in compass point");

            lbWest.Text = Cfg.FlipX ? DBLangEngine.GetMessage("msgEast", "EAST|As the east as in compass point") :
                                        DBLangEngine.GetMessage("msgWest", "WEST|As the west as in compass point");

            lbNorth.Text = Cfg.FlipY ? DBLangEngine.GetMessage("msgSouth", "SOUTH|As the south as in compass point") :
                                       DBLangEngine.GetMessage("msgNorth", "NORTH|As the north as in compass point");

            lbSouth.Text = Cfg.FlipY ? DBLangEngine.GetMessage("msgNorth", "NORTH|As the north as in compass point") :
                                       DBLangEngine.GetMessage("msgSouth", "SOUTH|As the south as in compass point");

            pbStarMap.Image = Bm;

            imageOffsetX = pbStarMap.Width - Bm.Width;
            imageOffsetY = pbStarMap.Height - Bm.Height;

            imageOffsetX /= 2;
            imageOffsetY /= 2;

            slTime.Text = DBLangEngine.GetMessage("msgDateAndTime", "Date and time: {0}|A formatted date and time", Dt.ToString());
            slStarTime.Text = DBLangEngine.GetMessage("msgStarTime", "Sidereal time: {0:F2} h.|As in sidereal time", Plot.SiderealTime(Dt, Cfg.Longitude));
            slMagnitudeLimit.Text = DBLangEngine.GetMessage("msgMagnitudeLimit", "magl:{0:F1}|Magnitude limit in very short form", Cfg.MagLimit);
            slLocation.Text = Cfg.PlaceName;
            slLatLong.Text = DBLangEngine.GetMessage("msgLatLon", "Latitude: {0:F2} °, Longitude: {1:F2} °|Latitude and longitude in degrees", Cfg.Latitude, Cfg.Longitude);
        }

        void Timer1Tick(object sender, System.EventArgs e)
        {
            if (!Visible || WindowState == FormWindowState.Minimized)
            {
                return;
            }
            if (DrawMode == 0)
            {
                DrawDt = DateTime.Now;
                slSpeed.Text = ">";
            }
            else if (DrawMode == 1)
            {
                DrawDt = DrawDt.AddHours(1);
                slSpeed.Text = ">>";
            }
            else if (DrawMode == 2)
            {
                DrawDt = DrawDt.AddDays(1);
                slSpeed.Text = ">>>";
            }
            else if (DrawMode == 3)
            {
                double addVal;
                if (!double.TryParse(tbSpeedupAmount.Text, out addVal))
                {
                    addVal = 1;
                }
                switch (cmbSpeedUpType.SelectedIndex)
                {
                    case 0: DrawDt = DrawDt.AddSeconds(addVal); break;
                    case 1: DrawDt = DrawDt.AddMinutes(addVal); break;
                    case 2: DrawDt = DrawDt.AddHours(addVal); break;
                    case 3: DrawDt = DrawDt.AddDays(addVal); break;
                    case 4: DrawDt = DrawDt.AddMonths((int)addVal); break;
                    case 5: DrawDt = DrawDt.AddYears((int)addVal); break;
                    default: DrawDt = DrawDt.AddHours(addVal); break;
                }
                slSpeed.Text = ">>";
            }
            else if (DrawMode == 4) // 07.11.17
            {
                double addVal;
                if (!double.TryParse(tbSpeedupAmount.Text, out addVal))
                {
                    addVal = 1;
                }
                switch (cmbSpeedUpType.SelectedIndex)
                {
                    case 0: DrawDt = DrawDt.AddSeconds(-addVal); break;
                    case 1: DrawDt = DrawDt.AddMinutes(-addVal); break;
                    case 2: DrawDt = DrawDt.AddHours(-addVal); break;
                    case 3: DrawDt = DrawDt.AddDays(-addVal); break;
                    case 4: DrawDt = DrawDt.AddMonths(-(int)addVal); break;
                    case 5: DrawDt = DrawDt.AddYears(-(int)addVal); break;
                    default: DrawDt = DrawDt.AddHours(-addVal); break;
                }
                slSpeed.Text = "<<";
            }
            else
            {
                return;
            }
            DrawMap(DrawDt);
        }


        void TiedostoDrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Rectangle rc = new Rectangle(e.Bounds.X + 1, e.Bounds.Y + 1, e.Bounds.Width - 5, e.Bounds.Height - 1);
            e.Graphics.FillRectangle(new SolidBrush(BackColor), rc);
            MenuItem s = (MenuItem)sender;
            string s1 = s.Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(s1, new Font("Tahoma", 10), new SolidBrush(Color.Black), rc, sf);
            Console.WriteLine(e.State.ToString());
            if (e.State == (DrawItemState.NoAccelerator | DrawItemState.Selected) ||
            e.State == (DrawItemState.NoAccelerator | DrawItemState.HotLight))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.CornflowerBlue), rc);
                e.Graphics.DrawString(s1, new Font("Tahoma", 10), new SolidBrush(Color.Black), rc, sf);
                //				e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rc );
            }
            e.DrawFocusRectangle();
            //e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2 ), rc );		
        }

        void MainFormResize(object sender, System.EventArgs e)
        {
            lbWest.Top = pbStarMap.Height / 2;
            lbEast.Top = pbStarMap.Height / 2;
        }


        void TiedostoMeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {
            MenuItem s = (MenuItem)sender;
            SizeF Sz = e.Graphics.MeasureString(s.Text, new Font("Tahoma", 10));
            e.ItemWidth = (int)Sz.Width;
            e.ItemHeight = 25;
        }

        void AsetuksetDrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            int OffSet = 25;
            Rectangle rc = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            e.Graphics.FillRectangle(new SolidBrush(Color.White), rc);
            MenuItem s = (MenuItem)sender;
            string s1 = s.Text;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            sf.LineAlignment = StringAlignment.Center;
            StringFormat sf2 = new StringFormat();
            sf2.Alignment = StringAlignment.Far;
            sf2.LineAlignment = StringAlignment.Center;
            Rectangle rcText = rc;
            rcText.Width -= (5 + OffSet);
            rcText.Location = new Point(rcText.Left + OffSet, rcText.Top);

            string ShortCutText = "";
            if (s.Shortcut != Shortcut.None)
            {
                ShortCutText = s.Shortcut.ToString();
                ShortCutText = ShortCutText.Replace("Ctrl", "Ctrl+");
                ShortCutText = ShortCutText.Replace("Shift", "Shift+");
                ShortCutText = ShortCutText.Replace("Alt", "Alt+");
            }

            if (s1 == "-")
            {
                e.Graphics.DrawLine(new Pen(Color.Gray, 1), rc.Left, rc.Top + 10, rc.Right, rc.Top + 10);
            }
            else
            {
                e.Graphics.DrawString(s1, new Font("Tahoma", 10), new SolidBrush(Color.Blue), rcText, sf);
                if (ShortCutText.Length > 0)
                {
                    e.Graphics.DrawString(ShortCutText, new Font("Tahoma", 10), new SolidBrush(Color.Blue), rcText, sf2);
                }
            }
            //			e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.LightGray)), rc );

            if (e.State == (DrawItemState.NoAccelerator | DrawItemState.Selected))
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.CornflowerBlue), rc);
                if (s1 == "-")
                {
                    e.Graphics.DrawLine(new Pen(Color.Gray, 1), rc.Left, rc.Top + 10, rc.Right, rc.Top + 10);
                }
                else
                {
                    e.Graphics.DrawString(s1, new Font("Tahoma", 10), new SolidBrush(Color.Yellow), rcText, sf);
                    if (ShortCutText.Length > 0)
                    {
                        e.Graphics.DrawString(ShortCutText, new Font("Tahoma", 10), new SolidBrush(Color.Yellow), rcText, sf2);
                    }
                }
                //				e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), rc );
                e.DrawFocusRectangle();
            }
        }

        void ApuClick(object sender, System.EventArgs e)
        {
            SettingCfg Cfg = Config.Cfg;
            string HelpFile = OpDir + "/Data/Help-" + Cfg.Language + ".CHM";
            if (File.Exists(HelpFile))
            {
                Help.ShowHelp(this, HelpFile);
            }
            else
            {
                MessageBox.Show(String.Format(NoHelpFile, HelpFile));
            }
        }

        private void mnuSettings_Click(object sender, EventArgs e)
        {
            tmUpdateChart.Enabled = false;
            if (ConfigForm.Execute(ref Config, this) == DialogResult.OK)
            {
                SettingCfg Cfg = Config.Cfg;
                InitLanguage(Cfg.StarNameIndex);
                DrawMap(DrawDt);
            }
            tmUpdateChart.Enabled = true;
        }

        private void mnuJumpToTime_Click(object sender, EventArgs e)
        {
            MainForm MainF = this;
            JumpToTime.Execute(ref MainF, Config.Cfg.Longitude);
        }

        private void mnuBrowseStarDB_Click(object sender, EventArgs e)
        {
            tmUpdateChart.Enabled = false;
            BrowseDatabase Bd = new BrowseDatabase();
            Bd.ShowDialog();
            tmUpdateChart.Enabled = true;
        }

        private void mnuQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuSolInfo_Click(object sender, EventArgs e)
        {
            tmUpdateChart.Enabled = false;
            PlanetInfo Pd = new PlanetInfo();
            Pd.ShowDialog();
            tmUpdateChart.Enabled = true;
        }

        private void mnuSolSys_Click(object sender, EventArgs e)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.GetType() == typeof(SolarSystem))
                {
                    frm.BringToFront();
                    return;
                }
            }
            new SolarSystem().Show();
        }

        private void mnuCompass_Click(object sender, EventArgs e)
        {
            tmUpdateChart.Enabled = false;
            Compass.Execute(ref Config);
            tmUpdateChart.Enabled = true;
        }

        private void mnuConstellations_Click(object sender, EventArgs e)
        {
            tmUpdateChart.Enabled = false;
            ConstellationView.Execute();
            tmUpdateChart.Enabled = true;
        }

        private void mnuMarksInfo_Click(object sender, EventArgs e)
        {
            if (Merkit == null)
            {
                Merkit = new CharacterExplanations();
                Merkit.Show();
            }
            else
            {
                Merkit.Show();
            }
        }

        private void mnuCopyToClipboard_Click(object sender, EventArgs e)
        {
            tmUpdateChart.Enabled = false;
            Clipboard.SetDataObject(pbStarMap.Image, true);
            tmUpdateChart.Enabled = true;
        }

        private void mnuShowRaDec_Click(object sender, EventArgs e)
        {
            tmUpdateChart.Enabled = false;
            ShowRaDec.Execute(Config.Cfg, (float)GetOffSet(), ref pbStarMap);
            tmUpdateChart.Enabled = true;
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            new VPKSoft.About.FormAbout(this, "GPL", "https://www.gnu.org/licenses/lgpl.txt");
        }

        private void tsbSpeedNormal_Click(object sender, EventArgs e)
        {
            DrawMode = 0;
            DrawMap(DateTime.Now);
        }

        private void tbsSpeedHigh_Click(object sender, EventArgs e)
        {
            DrawMode = 3;
//            DrawMode = 1;
        }

        private void tbsSpeedUltra_Click(object sender, EventArgs e)
        {
            DrawMode = 2;
        }

        private void tbsSpeedPause_Click(object sender, EventArgs e)
        {
            DrawMode = -1;
        }

        private void mnuCalculations_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("http://www.stjarnhimlen.se/comp/ppcomp.html"));
//            FormHTMLView.Execute(VPKSoft.Utils.Paths.AppInstallDir + "ppcomp.html", "http://www.stjarnhimlen.se/comp/ppcomp.html"); // Let's not use an "internal" browser..
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            cmbSpeedUpType.Items.Clear();
            cmbSpeedUpType.Items.Add(DBLangEngine.GetMessage("msgSeconds", "Seconds|In a combo box selection list"));
            cmbSpeedUpType.Items.Add(DBLangEngine.GetMessage("msgMinutes", "Minutes|In a combo box selection list"));
            cmbSpeedUpType.Items.Add(DBLangEngine.GetMessage("msgHours", "Hours|In a combo box selection list"));
            cmbSpeedUpType.Items.Add(DBLangEngine.GetMessage("msgDays", "Days|In a combo box selection list"));
            cmbSpeedUpType.Items.Add(DBLangEngine.GetMessage("msgMonths", "Months|In a combo box selection list"));
            cmbSpeedUpType.Items.Add(DBLangEngine.GetMessage("msgYears", "Years|In a combo box selection list"));
            cmbSpeedUpType.SelectedIndex = 1;
            tbSpeedupAmount.Text = "1.0";
        }

        private bool debugMode = false;

        private void HandlePlanetClick(PictureBox pbSender, MouseEventArgs e, bool click)
        {
            bool found = false;

            if (debugMode)
            {
                lbMouseDebug.Text = string.Format("X = {0}, Y = {1}", e.X, e.Y);
            }


            foreach (Plot.PlanetPlot pLoc in Plot.LastPlotLocations)
            {
                Point p = new Point(e.X - imageOffsetX, e.Y - imageOffsetY);

                if (Plot.MouseOverPlanet(pLoc, p.X, p.Y))
                {
                    if (click)
                    {
                        pbSender.Cursor = Cursors.Cross;
                        PlanetInfo.Execute(pLoc.Planet);
                        return;
                    }

                    pbSender.Cursor = Cursors.Hand;
                    found = true;
                    break;
                }
            }

            if (!found && pbSender.Cursor == Cursors.Hand)
            {
                pbSender.Cursor = Cursors.Cross;
            }

        }

        private void pbStarMap_MouseMove(object sender, MouseEventArgs e)
        {
            HandlePlanetClick((PictureBox)sender, e, false);
        }

        private void pbStarMap_MouseClick(object sender, MouseEventArgs e)
        {
            HandlePlanetClick((PictureBox)sender, e, true);
        }

        private void tbsSpeedHighBackward_Click(object sender, EventArgs e)
        {
            DrawMode = 4; // 07.11.17
        }
    }
}
