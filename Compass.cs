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
    /// Description of Kompassi.
    /// </summary>
    public partial class Compass : DBLangEngineWinforms
    {

        string CompassText = string.Empty;
        string ShortNorthText = string.Empty;
        string ShortEastText = string.Empty;
        string ShortSouthText = string.Empty;
        string ShortWestText = string.Empty;
        string ShortNorthEastText = string.Empty;
        string ShortNorthWestText = string.Empty;
        string ShortSouthEastText = string.Empty;
        string ShortSouthWestText = string.Empty;
        string FromNorthToClockwiseText = string.Empty;
        string ClockObjectNoonDirectionText = string.Empty;
        string ClockSunNoonDirectionText = string.Empty;
        string ClockMoonNoonDirectionText = string.Empty;
        string PrecisePointOfTheCompassSunText = string.Empty;
        string PrecisePointOfTheCompassMoonText = string.Empty;
        string PrecisePointOfTheCompassObjectText = string.Empty;
        string ObjectNotVisibleText = string.Empty;
        string SunNotVisibleText = string.Empty;
        string MoonNotVisibleText = string.Empty;

        string FromEastText = string.Empty;
        string FromNorthEastText = string.Empty;
        string FromNorthText = string.Empty;
        string FromNorthWestText = string.Empty;
        string FromSouthEastText = string.Empty;
        string FromSouthText = string.Empty;
        string FromSouthWestText = string.Empty;
        string FromWestText = string.Empty;

        string ToEastText = string.Empty;
        string ToNorthEastText = string.Empty;
        string ToNorthText = string.Empty;
        string ToNorthWestText = string.Empty;
        string ToSouthEastText = string.Empty;
        string ToSouthText = string.Empty;
        string ToSouthWestText = string.Empty;
        string ToWestText = string.Empty;

        string NorthLongText = string.Empty;
        string EastLongText = string.Empty;
        string SouthLongText = string.Empty;
        string WestLongText = string.Empty;
        string NorthEastLongText = string.Empty;
        string NorthWestLongText = string.Empty;
        string SouthEastLongText = string.Empty;
        string SouthWestLongText = string.Empty;
        string ErrorDialogCaptionErrorText = string.Empty;

        string OtherObjectsInfoCouldNotBeSavedErrorText = string.Empty;

        static SettingCfg conf;
        public Compass()
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
            MaximizeBox = false;
            MinimizeBox = false;
            InitLanguage();
            ObjName.Text = conf.CompassObjName;
            ObjRA.Text = Convert.ToString(conf.CompassObjRA);
            ObjDec.Text = Convert.ToString(conf.CompassObjDec);
            Draw();
            timer1.Enabled = true;
        }

        void InitLanguage()
        {
            CompassText = DBLangEngine.GetMessage("msgCompass", "Compass   [{0}]|The window title with a clock on it");

            ShortNorthText = DBLangEngine.GetMessage("msgNorthShortUpper", "N|North upper case");
            ShortEastText = DBLangEngine.GetMessage("msgEastShortUpper", "E|East upper case");
            ShortSouthText = DBLangEngine.GetMessage("msgSouthShortUpper", "S|South upper case");
            ShortWestText = DBLangEngine.GetMessage("msgWestShortUpper", "W|West upper case");
            ShortNorthEastText = DBLangEngine.GetMessage("msgNorthEastShortUpper", "NE|North-East upper case");
            ShortNorthWestText = DBLangEngine.GetMessage("msgNorthWestShortUpper", "NW|North-West upper case");
            ShortSouthEastText = DBLangEngine.GetMessage("msgSouthEastShortUpper", "SE|South-East upper case");
            ShortSouthWestText = DBLangEngine.GetMessage("msgSouthWestShortUpper", "SW|South-West upper case");
            FromNorthToClockwiseText = DBLangEngine.GetMessage("msgFromNorthToClockwise", "{0:F1} ° from north to clockwise|Degrees from north to clockwise");
            ClockObjectNoonDirectionText = DBLangEngine.GetMessage("msgClockObjectNoonDirection", "When the clock's {0}. min. points to object, hour 12 points to north|These are clock wheel's hours and minutes");
            ClockSunNoonDirectionText = DBLangEngine.GetMessage("msgClockSunNoonDirection", "When the clock's {0}. min. points to sun, hour 12 points to north|These are clock wheel's hours and minutes");
            ClockMoonNoonDirectionText = DBLangEngine.GetMessage("msgClockMoonNoonDirection", "When the clock's {0}. min. points to moon, hour 12 points to north|These are clock wheel's hours and minutes");
            PrecisePointOfTheCompassSunText = DBLangEngine.GetMessage("msgPrecisePointOfTheCompassSun", "Sun's precise point of the compass (±1°)");
            PrecisePointOfTheCompassMoonText = DBLangEngine.GetMessage("msgPrecisePointOfTheCompassMoon", "Moon's precise point of the compass (±1°)");
            PrecisePointOfTheCompassObjectText = DBLangEngine.GetMessage("msgPrecisePointOfTheCompassObject", "Precise point of the compass (±1°)");
            ObjectNotVisibleText = DBLangEngine.GetMessage("msgObjectNotVisible", "Object is not visible|The object is not visible");
            SunNotVisibleText = DBLangEngine.GetMessage("msgSunNotVisible", "Sun is not visible|Sun is not visible");
            MoonNotVisibleText = DBLangEngine.GetMessage("msgMoonNotVisible", "Moon is not visible|Moon is not visible");

            FromEastText = DBLangEngine.GetMessage("msgFromEast", "from east|As in from the east");
            FromNorthEastText = DBLangEngine.GetMessage("msgFromNorthEast", "from northeast|As in from the northeast");
            FromNorthText = DBLangEngine.GetMessage("msgFromNorth", "from north|As in from the north");
            FromNorthWestText = DBLangEngine.GetMessage("msgFromNorthWest", "from northwest|As in from the northwest");
            FromSouthEastText = DBLangEngine.GetMessage("msgFromSouthEast", "from southeast|As in from the southeast");
            FromSouthText = DBLangEngine.GetMessage("msgFromSouth", "from south|As in from the south");
            FromSouthWestText = DBLangEngine.GetMessage("msgFromSouthWest", "from southwest|As in from the southwest");
            FromWestText = DBLangEngine.GetMessage("msgFromWest", "from west|As in from the west");

            ToEastText = DBLangEngine.GetMessage("msgToEast", "to east|As in to the east");
            ToNorthEastText = DBLangEngine.GetMessage("msgToNorthEast", "to northeast|As in to the northeast");
            ToNorthText = DBLangEngine.GetMessage("msgToNorth", "to north|As in to the north");
            ToNorthWestText = DBLangEngine.GetMessage("msgToNorthWest", "to northwest|As in to the northwest");
            ToSouthEastText = DBLangEngine.GetMessage("msgToSouthEast", "to southeast|As in to the southeast");
            ToSouthText = DBLangEngine.GetMessage("msgToSouth", "to south|As in to the south");
            ToSouthWestText = DBLangEngine.GetMessage("msgToSouthWest", "to southwest|As in to the southwest");
            ToWestText = DBLangEngine.GetMessage("msgToWest", "to west|As in to the west");

            NorthLongText = DBLangEngine.GetMessage("msgNorthLong", "north|north as long text");
            EastLongText = DBLangEngine.GetMessage("msgEastLong", "east|east as long text");
            SouthLongText = DBLangEngine.GetMessage("msgSouthLong", "south|south as long text");
            WestLongText = DBLangEngine.GetMessage("msgWestLong", "west|west as long text");
            NorthEastLongText = DBLangEngine.GetMessage("msgNorthEastLong", "northeast|northeast as long text");
            NorthWestLongText = DBLangEngine.GetMessage("msgNorthWestLong", "northwest|northwest as long text");
            SouthEastLongText = DBLangEngine.GetMessage("msgSouthEastLong", "southeast|southeast as long text");
            SouthWestLongText = DBLangEngine.GetMessage("msgSouthWestLong", "southwest|southwest as long text");

            OtherObjectsInfoCouldNotBeSavedErrorText = DBLangEngine.GetMessage("msgOtherObjectsInfoCouldNotBeSavedError", "Information of the other object couldn't be saved.|The object info save failed.");

            ErrorDialogCaptionErrorText = DBLangEngine.GetMessage("msgErrorDialogCaption", "Error|As in an error occurred.");

            gbSun.Text = DBLangEngine.GetMessage("msgNameSun", "Sun|The sun");
            gbMoon.Text = DBLangEngine.GetMessage("msgNameMoon", "Moon|The moon");
            gbOther.Text = DBLangEngine.GetMessage("msgOtherObject", "Other object|As in the third object after the sun and the moon for the compass.");
            lbSun5.Text = DBLangEngine.GetMessage("msgDirectionLineColorSun", "Sun's direction line color|The color of sun's direction line in the compass.") + ":";
            lbMoon5.Text = DBLangEngine.GetMessage("msgDirectionLineColorMoon", "Moon's direction line color|The color of moon's direction line in the compass.") + ":";
            lbObj5.Text = DBLangEngine.GetMessage("msgDirectionLineColorObject", "Custom objects's direction line color|The color of the custom object's direction line in the compass.") + ":";
            lbName.Text = DBLangEngine.GetMessage("msgObjectName", "Name|A string referring to a name word of the object.");
            lbRA.Text = DBLangEngine.GetMessage("msgObjectRA", "RA|Right ascension");
            lbDec.Text = DBLangEngine.GetMessage("msgObjectDeclination", "Declination|As in declination");
        }

        public void PaintCompass(DateTime Dt, ref Bitmap Bm, SettingCfg Cfg)
        {
            Text = String.Format(CompassText, Dt.ToString());
            Plot.NoDayLight(ref Dt);
            SolidBrush Br = new SolidBrush(Color.White);
            float W = Bm.Width;
            float H = Bm.Height;
            float CX = W / 2;
            float CY = H / 2;
            float BorderW = 20;

            Plot Pc = new Plot(MainForm.OpDir, Cfg.UseConventionalCelestial);

            Graphics Gr = Graphics.FromImage(Bm);

            Gr.FillRectangle(Br, 0, 0, W, H);

            Pen P = new Pen(Color.Black, 1);

            Gr.DrawEllipse(P, BorderW, BorderW, W - BorderW * 2, H - BorderW * 2);

            float R = (W - 2 * BorderW) / 2;

            for (int i = 0; i < 360; i += 5)
            {
                Gr.DrawLine(P, CX + (float)DegreeMath.cosd((double)i) * (R - 5), CY + (float)DegreeMath.sind((double)i) * (R - 5), CX + (float)DegreeMath.cosd((double)i) * R, CY + (float)DegreeMath.sind((double)i) * R);
            }

            // Ristikko
            Gr.DrawLine(P, W / 2, 0, W / 2, H);
            Gr.DrawLine(P, 0, H / 2, W, H / 2);
            Gr.DrawLine(P, BorderW, BorderW, W - BorderW, H - BorderW);
            Gr.DrawLine(P, W - BorderW, BorderW, BorderW, H - BorderW);

            Font F = new Font("Arial", 8);
            Br = new SolidBrush(Color.Black);

            // Nuoli,luode
            Gr.DrawLine(P, BorderW, BorderW, BorderW + 5, BorderW);
            Gr.DrawLine(P, BorderW, BorderW, BorderW, BorderW + 5);
            Gr.DrawString(ShortNorthWestText, F, Br, BorderW + 5, BorderW + 5);

            // Nuoli,kaakko
            Gr.DrawLine(P, W - BorderW, H - BorderW, W - BorderW - 5, H - BorderW);
            Gr.DrawLine(P, W - BorderW, H - BorderW, W - BorderW, H - BorderW - 5);
            Gr.DrawString(ShortSouthEastText, F, Br, W - BorderW - 20, H - BorderW - 20);

            // Nuoli,koillinen
            Gr.DrawLine(P, W - BorderW, BorderW, W - BorderW, BorderW + 5);
            Gr.DrawLine(P, W - BorderW, BorderW, W - BorderW - 5, BorderW);
            Gr.DrawString(ShortNorthEastText, F, Br, W - BorderW - 20, BorderW + 5);

            // Nuoli,lounas
            Gr.DrawLine(P, BorderW, H - BorderW, BorderW, H - BorderW - 5);
            Gr.DrawLine(P, BorderW, H - BorderW, BorderW + 5, H - BorderW);
            Gr.DrawString(ShortSouthWestText, F, Br, BorderW + 5, H - BorderW - 20);

            // Nuoli,pohjoinen
            Gr.DrawLine(P, W / 2, 0, W / 2 - 5, 5);
            Gr.DrawLine(P, W / 2, 0, W / 2 + 5, 5);
            Gr.DrawString(ShortNorthText, F, Br, W / 2 - 3, 5);

            // Nuoli,itä
            Gr.DrawLine(P, W - 1, H / 2, W - 1 - 5, H / 2 - 5);
            Gr.DrawLine(P, W - 1, H / 2, W - 1 - 5, H / 2 + 5);
            Gr.DrawString(ShortEastText, F, Br, W - 1 - 5 - 3, H / 2 - 6);

            // Nuoli,etelä
            Gr.DrawLine(P, W / 2, H - 1, W / 2 - 5, H - 1 - 5);
            Gr.DrawLine(P, W / 2, H - 1, W / 2 + 5, H - 1 - 5);
            Gr.DrawString(ShortSouthText, F, Br, W / 2 - 3, H - 1 - 5 - 13);

            // Nuoli,länsi
            Gr.DrawLine(P, 0, H / 2, 5, H / 2 - 5);
            Gr.DrawLine(P, 0, H / 2, 5, H / 2 + 5);
            Gr.DrawString(ShortWestText, F, Br, 5 + 1, H / 2 - 6);


            Pc.FillOrbElements(Dt);
            double r, d, x = 0, y = 0;
            double SidTime = Plot.SiderealTime(Dt, Cfg.Longitude);
            Pc.CalculateRaDecPlanet(Plot.SUN, Dt, out r, out d);
            Plot.StereographicProjection(1, Cfg.Latitude, Cfg.Longitude, ref x, ref y, SidTime, r, d);

            if (CorrectCoords(x, y))
            {
                lbSun1.Visible = true;
                lbSun2.Visible = true;
                lbSun3.Visible = true;
                lbSun4.Visible = true;
                lbSun5.Visible = true;
                pnSunC.Visible = true;
                string S1, S2, TempStr;

                double SunAngle = CountAngle(x, y);
                TempStr = String.Format(FromNorthToClockwiseText, SunAngle);
                lbSun0.Text = TempStr;

                SunAngle = CountAngle(x, y);
                CalDirection(ref SunAngle, out S1, out S2);
                TempStr = String.Format("{0:F1} °", SunAngle);
                lbSun1.Text = TempStr + " " + S1 + " " + S2;

                SunAngle = CountAngle(x, y);
                CalDirectionFull(ref SunAngle, out S1, out S2);
                TempStr = String.Format("{0:F1} °", SunAngle);
                lbSun2.Text = TempStr + " " + S1 + " " + S2;

                SunAngle = CountAngle(x, y);

                TempStr = String.Format(ClockSunNoonDirectionText, (int)(SunAngle / 6));
                lbSun3.Text = TempStr;

                S1 = CalPreciseDirection(SunAngle);
                if (S1.Length != 0)
                {
                    lbSun4.Text = PrecisePointOfTheCompassSunText + ": " + S1;
                }
                else
                {
                    lbSun4.Text = PrecisePointOfTheCompassSunText + ": -";
                }

                P = new Pen(Color.Yellow, 2);

                Gr.DrawLine(P, CX, CY, CX + R * (float)DegreeMath.cosd(SunAngle - 90), CY + R * (float)DegreeMath.sind(SunAngle - 90));
            }
            else
            {
                lbSun0.Text = SunNotVisibleText;
                lbSun1.Visible = false;
                lbSun2.Visible = false;
                lbSun3.Visible = false;
                lbSun4.Visible = false;
                lbSun5.Visible = false;
                pnSunC.Visible = false;
            }

            Pc.CalculateRaDecPlanet(Plot.MOON, Dt, out r, out d);
            Plot.StereographicProjection(1, Cfg.Latitude, Cfg.Longitude, ref x, ref y, SidTime, r, d);

            if (CorrectCoords(x, y))
            {
                lbMoon1.Visible = true;
                lbMoon2.Visible = true;
                lbMoon3.Visible = true;
                lbMoon4.Visible = true;
                lbMoon5.Visible = true;
                pnMoonC.Visible = true;
                string S1, S2, TempStr;

                double MoonAngle = CountAngle(x, y);
                TempStr = String.Format(FromNorthToClockwiseText, MoonAngle);
                lbMoon0.Text = TempStr;

                MoonAngle = CountAngle(x, y);
                CalDirection(ref MoonAngle, out S1, out S2);
                TempStr = String.Format("{0:F1} °", MoonAngle);
                lbMoon1.Text = TempStr + " " + S1 + " " + S2;

                MoonAngle = CountAngle(x, y);
                CalDirectionFull(ref MoonAngle, out S1, out S2);
                TempStr = String.Format("{0:F1} °", MoonAngle);
                lbMoon2.Text = TempStr + " " + S1 + " " + S2;

                MoonAngle = CountAngle(x, y);

                TempStr = String.Format(ClockMoonNoonDirectionText, (int)(MoonAngle / 6));
                lbMoon3.Text = TempStr;

                S1 = CalPreciseDirection(MoonAngle);
                if (S1.Length != 0)
                {
                    lbMoon4.Text = PrecisePointOfTheCompassMoonText + ": " + S1;
                }
                else
                {
                    lbMoon4.Text = PrecisePointOfTheCompassMoonText + ": -";
                }

                P = new Pen(Color.Gray, 2);

                Gr.DrawLine(P, CX, CY, CX + R * (float)DegreeMath.cosd(MoonAngle - 90), CY + R * (float)DegreeMath.sind(MoonAngle - 90));
            }
            else
            {
                lbMoon0.Text = MoonNotVisibleText;
                lbMoon1.Visible = false;
                lbMoon2.Visible = false;
                lbMoon3.Visible = false;
                lbMoon4.Visible = false;
                lbMoon5.Visible = false;
                pnMoonC.Visible = false;
            }

            bool ObjSuccess = true;

            try
            {
                r = Convert.ToDouble(ObjRA.Text);
                d = Convert.ToDouble(ObjDec.Text);
                Plot.StereographicProjection(1, Cfg.Latitude, Cfg.Longitude, ref x, ref y, SidTime, r, d);
            }
            catch
            {
                ObjSuccess = false;
            }

            if (CorrectCoords(x, y) && ObjSuccess)
            {
                lbObj1.Visible = true;
                lbObj2.Visible = true;
                lbObj3.Visible = true;
                lbObj4.Visible = true;
                lbObj5.Visible = true;
                pnObjC.Visible = true;
                string S1, S2, TempStr;

                double ObjAngle = CountAngle(x, y);
                TempStr = String.Format(FromNorthToClockwiseText, ObjAngle);
                lbObj0.Text = TempStr;

                ObjAngle = CountAngle(x, y);
                CalDirection(ref ObjAngle, out S1, out S2);
                TempStr = String.Format("{0:F1} °", ObjAngle);
                lbObj1.Text = TempStr + " " + S1 + " " + S2;

                ObjAngle = CountAngle(x, y);
                CalDirectionFull(ref ObjAngle, out S1, out S2);
                TempStr = String.Format("{0:F1} °", ObjAngle);
                lbObj2.Text = TempStr + " " + S1 + " " + S2;

                ObjAngle = CountAngle(x, y);

                TempStr = String.Format(ClockObjectNoonDirectionText, (int)(ObjAngle / 6));
                lbObj4.Text = TempStr;

                S1 = CalPreciseDirection(ObjAngle);
                if (S1.Length != 0)
                {
                    lbObj3.Text = PrecisePointOfTheCompassObjectText + ": " + S1;
                }
                else
                {
                    lbObj3.Text = PrecisePointOfTheCompassObjectText + ": -";
                }

                P = new Pen(Color.DodgerBlue, 2);

                Gr.DrawLine(P, CX, CY, CX + R * (float)DegreeMath.cosd(ObjAngle - 90), CY + R * (float)DegreeMath.sind(ObjAngle - 90));
            }
            else
            {
                lbObj0.Text = ObjectNotVisibleText;
                lbObj1.Visible = false;
                lbObj2.Visible = false;
                lbObj3.Visible = false;
                lbObj4.Visible = false;
                lbObj5.Visible = false;
                pnObjC.Visible = false;
            }
        }

        public bool CorrectCoords(double x, double y)
        {
            if (x < -1 || x > 1) return false;
            if (y < -1 || y > 1) return false;
            double Alfa = Math.Atan(y / x);
            double Radii = x / Math.Cos(Alfa);
            if (Math.Abs(Radii) > 1) return false;
            return true;
        }

        public void CalDirection(ref double Degree, out string IS1, out string IS2)
        {
            Degree = Plot.NormalizeDegree(Degree);
            if (Degree > 0 && Degree <= 90)
            {
                IS1 = FromNorthText;
                IS2 = ToEastText;
            }
            else
                if (Degree > 90 && Degree <= 180)
                {
                    IS1 = FromEastText;
                    IS2 = ToSouthText;
                    Degree -= 90;
                }
                else
                    if (Degree > 180 && Degree <= 270)
                    {
                        IS1 = FromSouthText;
                        IS2 = ToWestText;
                        Degree -= 180;
                    }
                    else
                        if (Degree > 270 && Degree <= 360)
                        {
                            IS1 = FromWestText;
                            IS2 = ToNorthText;
                            Degree -= 270;
                        }
                        else
                        {
                            IS1 = "";
                            IS2 = "";
                        }
        }

        public void CalDirectionFull(ref double Degree, out string IS1, out string IS2)
        {
            Degree = Plot.NormalizeDegree(Degree);
            if (Degree > 0 && Degree <= 45)
            {
                IS1 = FromNorthText;
                IS2 = ToNorthEastText;
            }
            else
                if (Degree > 45 && Degree <= 90)
                {
                    IS1 = FromNorthEastText;
                    IS2 = ToEastText;
                    Degree -= 45;
                }
                else
                    if (Degree > 90 && Degree <= 135)
                    {
                        IS1 = FromEastText;
                        IS2 = ToSouthEastText;
                        Degree -= 90;
                    }
                    else
                        if (Degree > 135 && Degree <= 180)
                        {
                            IS1 = FromSouthEastText;
                            IS2 = ToSouthText;
                            Degree -= 135;
                        }
                        else
                            if (Degree > 180 && Degree <= 225)
                            {
                                IS1 = FromSouthText;
                                IS2 = ToSouthWestText;
                                Degree -= 180;
                            }
                            else
                                if (Degree > 225 && Degree <= 270)
                                {
                                    IS1 = FromSouthWestText;
                                    IS2 = ToWestText;
                                    Degree -= 225;
                                }
                                else
                                    if (Degree > 270 && Degree <= 315)
                                    {
                                        IS1 = FromWestText;
                                        IS2 = ToNorthWestText;
                                        Degree -= 270;
                                    }
                                    else
                                        if (Degree > 315 && Degree <= 360)
                                        {
                                            IS1 = FromNorthWestText;
                                            IS2 = ToNorthText;
                                            Degree -= 315;
                                        }
                                        else
                                        {
                                            IS1 = "";
                                            IS2 = "";
                                        }
        }

        public string CalPreciseDirection(double Degree)
        {
            Degree = Plot.NormalizeDegree(Degree);
            double KO = 45, IT = 90, KA = 135, ET = 180, LO = 225, LA = 270, LU = 315;
            if ((Degree < 1 && Degree > 0) || (Degree < 360 && Degree > 359)) return NorthLongText;

            if (Degree < KO + 1 && Degree > KO - 1) return NorthEastLongText;
            if (Degree < IT + 1 && Degree > IT - 1) return EastLongText;
            if (Degree < KA + 1 && Degree > KA - 1) return SouthEastLongText;
            if (Degree < ET + 1 && Degree > ET - 1) return SouthLongText;
            if (Degree < LO + 1 && Degree > LO - 1) return SouthWestLongText;
            if (Degree < LA + 1 && Degree > LA - 1) return WestLongText;
            if (Degree < LU + 1 && Degree > LU - 1) return NorthWestLongText;
            return "";
        }

        public double CountAngle(double x, double y)
        {
            if (y < 0 && x > 0) return Plot.NormalizeDegree(DegreeMath.RadToDeg(Math.Atan(y / x)) + 90 + 180);
            if (y > 0 && x > 0) return Plot.NormalizeDegree(DegreeMath.RadToDeg(Math.Atan(y / x)) + 90 + 180);
            return Plot.NormalizeDegree(DegreeMath.RadToDeg(Math.Atan(y / x)) + 90);
        }


        public static void Execute(ref SettingsConfig config)
        {
            conf = config.Cfg;
            Compass Kp = new Compass();
            Kp.ShowDialog();
            config.Cfg = conf;
            config.Save();
        }
        void Timer1Tick(object sender, System.EventArgs e)
        {
            Draw();
        }

        public void Draw()
        {
            Bitmap Bm = new Bitmap(pbCompass.Width, pbCompass.Height);
            PaintCompass(DateTime.Now, ref Bm, conf);
            pbCompass.Image = Bm;
        }

        void KompassiClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                conf.CompassObjDec = Convert.ToDouble(ObjDec.Text);
                conf.CompassObjRA = Convert.ToDouble(ObjRA.Text);
                conf.CompassObjName = ObjName.Text;
            }
            catch
            {
                MessageBox.Show(OtherObjectsInfoCouldNotBeSavedErrorText, ErrorDialogCaptionErrorText, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    }
}
