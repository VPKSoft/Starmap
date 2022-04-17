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

using Stellar;
using Plotter;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.IO;
using VPKSoft.LangLib;
using System.Collections.Generic;
using VPKSoft.PosLib;

namespace SMap
{
    /// <summary>
    /// Description of Aurinkokunta.
    /// </summary>
    public partial class SolarSystem : DBLangEngineWinforms
    {

        private double AngZ = 0;
        private double AngX = 0;
        private double AngY = 0;
        private double ZoomPercentage = 100;
        private int ShowType = 0;
        Point[] PlanetCoords = new Point[11];
        double SunRadiusRel = 0;
        double[] RadiusRel = new double[11];
        Plot Pc = new Plot(MainForm.OpDir, true);
        string CaptionText = string.Empty;
        string StoppedText = string.Empty;
        string SolDistText = string.Empty;
        string TimeGText = string.Empty;
        string TimeUTCText = string.Empty;
        //		string EarthDistText = string.Empty;

        DateTime DrawDt = DateTime.Now;

        public SolarSystem()
        {
            PositionForms.Add(this, PositionCore.SizeChangeMode.MoveTopLeft);
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

//            PositionForms.Add(this, PositionCore.SizeChangeMode.MoveTopLeft);

            if (Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("SMap.Messages", Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }
            DBLangEngine.InitalizeLanguage("SMap.Messages");

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            ZoomPercentage = 100;
            InitLanguage();
            tmPlot.Enabled = true;
            MinimizeBox = false;
            lbSolDist.Parent = pbSolSys;

            this.MouseWheel += SolarSystem_MouseWheel;
        }

        void SolarSystem_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta >= 0)
            {
                ZoomPercentage += 5;
            }
            else
            {
                ZoomPercentage -= 5;
                if (ZoomPercentage < 0)
                {
                    ZoomPercentage = 0;
                }
            }
            DrawSys(DrawDt);
        }

        void InitLanguage()
        {
            CaptionText = DBLangEngine.GetMessage("msgSolarSystemCaption", "Solar system | Zoom: {0:F0}  X: {1:F1}°,Y: {2:F1}°,Z: {3:F1}° | Ratio: {4:F1}:{5:F1}|As in the caption of the solar system window");
            StoppedText = DBLangEngine.GetMessage("msgStopped", "Stopped|As in stopped");
            SolDistText = DBLangEngine.GetMessage("msgDistanceFromTheSunXYZkm", "Width(x), height(y) and distance to sun (z) (km): {0:F1}|A distance to the sun, area width and height");
            TimeGText = DBLangEngine.GetMessage("msgTime", "Time|As in time");
            TimeUTCText = DBLangEngine.GetMessage("msgUTC", "UTC|As Univeral Coordinated Time");

            cmbTimeSpeedUp.Items.Clear();
            cmbTimeSpeedUp.Items.Add(DBLangEngine.GetMessage("msgYear", "Year|As in year of time"));
            cmbTimeSpeedUp.Items.Add(DBLangEngine.GetMessage("msgMonth", "Month|As in month of time"));
            cmbTimeSpeedUp.Items.Add(DBLangEngine.GetMessage("msgDay", "Day|As in day of time"));
            cmbTimeSpeedUp.Items.Add(DBLangEngine.GetMessage("msgHour", "Hour|As in hour of time"));
            cmbTimeSpeedUp.SelectedIndex = 0;

            cmbZoomPreset.Items.Clear();
            // TODO::!!
            cmbZoomPreset.Items.Add(DBLangEngine.GetMessage("msgInnerSolSys", "Inner solar system|Zoom to the inner solar system"));
            cmbZoomPreset.Items.Add(DBLangEngine.GetMessage("msgWholeSolSys", "Whole solar system|Zoom so the whole solar system is visible"));
            cmbZoomPreset.Items.Add(DBLangEngine.GetMessage("msgEarthAndMoon1x", "Earth and moon|Zoomed to the earth and moon"));
            cmbZoomPreset.Items.Add(DBLangEngine.GetMessage("msgEarthAndMoon2x", "Earth and moon x 2|Zoomed to the earth and moon by 2x"));

            for (int i = 200; i <= 1000; i += 100)
            {
                cmbZoomPreset.Items.Add(DBLangEngine.GetMessage("msgZoomPercentage", "{0} %|As in zoom in n %", i));
            }

            cmbZoomPreset.SelectedIndex = 0;

            //LangResources.GetString("");
        }

        public double GetDimensionY()
        {
            return (double)pbSolSys.Height;
        }

        public double GetDimensionX()
        {
            return (double)pbSolSys.Width;
        }

        public int GetDimensionIntY()
        {
            return pbSolSys.Height;
        }

        public int GetDimensionIntX()
        {
            return pbSolSys.Width;
        }

        public void DrawSys(DateTime Dt)
        {
            tslTime.Text = TimeGText + ": " + Dt.ToString();
            tslUTC.Text = TimeUTCText + ": " + Dt.ToUniversalTime().ToString();
            Plot.NoDayLight(ref Dt);
            string TempStr;
            TempStr = String.Format(CaptionText, ZoomPercentage, AngX, AngY, AngZ, GetDimensionX() / GetDimensionX(), GetDimensionY() / GetDimensionX());
            Text = TempStr;
            switch (ShowType)
            {
                case 0: tslState.Text = StoppedText; break;
                case 1: tslState.Text = ">"; break;
                case 2: tslState.Text = "<<"; break;
                case 3: tslState.Text = ">>"; break;
            };

            Bitmap Bm = new Bitmap(GetDimensionIntX(), GetDimensionIntY());
            pbSolSys.Image = Bm;


            CreateSolSys(Dt, AngX, AngY, AngZ, GetDimensionX() - 70.0, GetDimensionY() - 70.0, GetDimensionX() / 2.0, GetDimensionY() / 2.0, 12000, ref Bm, Color.Blue, ZoomPercentage);
            pbSolSys.Refresh();
        }


        public Color GetPlanetColor(int Planet)
        {
            switch (Planet)
            {
                case Plot.SUN: return Color.Yellow;
                case Plot.MOON: return Color.Gray;
                case Plot.MERCURY: return Color.FromArgb(0xf4, 0xf3, 0xed);
                case Plot.VENUS: return Color.FromArgb(0xdc, 0x9c, 0xc9);
                case Plot.MARS: return Color.FromArgb(0xe6, 0xac, 0x6c);
                case Plot.JUPITER: return Color.FromArgb(0xd2, 0xb0, 0xa2);
                case Plot.SATURN: return Color.FromArgb(0xff, 0xf6, 0xa2);
                case Plot.URANUS: return Color.FromArgb(0x8e, 0xed, 0x7b);
                case Plot.NEPTUNE: return Color.FromArgb(0x4d, 0x67, 0x98);
                case Plot.PLUTO: return Color.FromArgb(0x6b, 0xbe, 0x5a);
                case Plot.EARTH: return Color.FromArgb(0x62, 0x78, 0xe8);
            }
            return Color.White;
        }


        public void CreateSolSys(DateTime Dt, double LR, double UD, double ZA, double XScale, double YScale, double CenterX, double CenterY, double SolSysDimensionAU, ref Bitmap Bm, Color Col, double ZoomP)
        {
            SolSysDimensionAU = SolSysDimensionAU * (100.0 / ZoomP);
            SolidBrush Br = new SolidBrush(Color.Black);
            Graphics Gr = Graphics.FromImage(Bm);
            Gr.FillRectangle(Br, 0, 0, (float)(CenterX * 2), (float)(CenterY * 2));

            lbSolDist.Text = String.Format(SolDistText, 12000.0 * (100.0 / ZoomPercentage) * 1.0e6);
            Pc.FillOrbElements(Dt);


            CreateOrbits(Dt, LR, UD, ZA, XScale, YScale, CenterX, CenterY, SolSysDimensionAU, ref Bm, Col, ZoomP, cbEartchC.Checked);
            CreatePlanets(Dt, LR, UD, ZA, XScale, YScale, CenterX, CenterY, SolSysDimensionAU, ref Bm, Col, ZoomP, cbEartchC.Checked);
        }

        public void CreatePlanets(DateTime Dt, double LR, double UD, double ZA, double XScale, double YScale, double CenterX, double CenterY, double SolSysDimensionAU, ref Bitmap Bm, Color Col, double ZoomP, bool EarthCentered)
        {
            SolSysDimensionAU = SolSysDimensionAU * (100 / ZoomP);
            OrbElementExt OeE = new OrbElementExt();
            OrbElementExt OeE2 = new OrbElementExt();
            StaticOrbElementInfo SOEI;

            Pen P = new Pen(Color.Yellow, 1);
            SolidBrush Br = new SolidBrush(Color.Yellow);

            double SunRadii = 6.960e5 * 2;
            SunRadii /= (SolSysDimensionAU * 1e5);
            SunRadii *= XScale;
            if (SunRadii < 6) SunRadii = 6;

            SunRadiusRel = SunRadii / 2;
            //        	PlanetCoords[0].X=(int)CenterX;
            //        	PlanetCoords[0].Y=(int)CenterY;

            Graphics Gr = Graphics.FromImage(Bm);

            //	        Gr.FillEllipse(Br,(float)(CenterX-SunRadii/2),(float)(CenterY-SunRadii/2),(float)SunRadii,(float)SunRadii);
            RadiusRel[0] = SunRadiusRel;
            for (int i = Plot.SUN; i <= Plot.EARTH; i++)
            {
                Col = GetPlanetColor(i);
                Br = new SolidBrush(Col);
                P = new Pen(Col, 1);
                if (i == Plot.SUN)
                {
                    Pc.GetSunData(Dt, ref OeE2);
                }
                else if (i == Plot.MOON)
                {
                    Pc.GetSunData(Dt, ref OeE2);
                    OeE2.x *= -1; OeE2.y *= -1; OeE2.z *= -1;
                    Pc.GetPlanetData(Plot.MOON, Dt, ref OeE);
                    OeE.x *= 6378.140 / (Plot.AU * 1e6);
                    OeE.y *= 6378.140 / (Plot.AU * 1e6);
                    OeE.z *= 6378.140 / (Plot.AU * 1e6);
                    OeE.x += OeE2.x;
                    OeE.y += OeE2.y;
                    OeE.z += OeE2.z;
                }
                else if (i == Plot.EARTH)
                {
                    Pc.GetSunData(Dt, ref OeE);
                    OeE.x *= -1; OeE.y *= -1; OeE.z *= -1;
                }
                else
                {
                    Pc.GetPlanetData(i, Dt, ref OeE);
                }
                Pc.GetPlanetDataStatic(i, out SOEI);

                SOEI.Radius *= XScale * 2;
                if (EarthCentered && ZoomP > 1500)
                {
                    SOEI.Radius /= (SolSysDimensionAU * 1e5);
                }
                else
                {
                    SOEI.Radius /= (SolSysDimensionAU * 1e3);
                    if (SOEI.Radius < 6) SOEI.Radius = 6;
                }

                if (i == Plot.SUN)
                {
                    SOEI.Radius = SunRadii;
                }

                RadiusRel[i - 1] = SOEI.Radius / 2;


                if (EarthCentered)
                {
                    Pc.GetSunData(Dt, ref OeE2);
                    OeE2.x *= -1; OeE2.y *= -1; OeE2.z *= -1;
                    OeE.x -= OeE2.x;
                    OeE.y -= OeE2.y;
                    OeE.z -= OeE2.z;
                }

                Plot.RotateX(UD, ref OeE.x, ref OeE.y, ref OeE.z);
                Plot.RotateY(LR, ref OeE.x, ref OeE.y, ref OeE.z);
                Plot.RotateZ(ZA, ref OeE.x, ref OeE.y, ref OeE.z);

                OeE.x = OeE.x * Plot.AU * XScale / SolSysDimensionAU;
                OeE.y = OeE.y * Plot.AU * YScale / SolSysDimensionAU;
                OeE.z *= Plot.AU;

                OeE.x += CenterX;
                OeE.y += CenterY;
                PlanetCoords[i - 1].X = (int)OeE.x;
                PlanetCoords[i - 1].Y = (int)OeE.y;
                Gr.FillEllipse(Br, (float)(OeE.x - SOEI.Radius / 2), (float)(OeE.y - SOEI.Radius / 2), (float)SOEI.Radius, (float)SOEI.Radius);
            }
        }

        public void CreateOrbits(DateTime Dt, double LR, double UD, double ZA, double XScale, double YScale, double CenterX, double CenterY, double SolSysDimensionAU, ref Bitmap Bm, Color Col, double ZoomP, bool EarthCentered)
        {
            SolSysDimensionAU = SolSysDimensionAU * (100 / ZoomP);
            OrbElementExt OeE = new OrbElementExt();
            OrbElementExt OeE2 = new OrbElementExt();
            StaticOrbElementInfo SOEI = new StaticOrbElementInfo();

            Graphics Gr = Graphics.FromImage(Bm);
            Pen P = new Pen(Col, 1);

            for (int i = Plot.MOON; i <= Plot.EARTH; i++)
            {
                if (i == Plot.MOON)
                {
                    Pc.GetSunData(Dt, ref OeE2);
                    OeE2.x *= -1; OeE2.y *= -1; OeE2.z *= -1;
                    Pc.GetPlanetData(Plot.MOON, Dt, ref OeE);
                    OeE.x *= 6378.140 / (Plot.AU * 1e6);
                    OeE.y *= 6378.140 / (Plot.AU * 1e6);
                    OeE.z *= 6378.140 / (Plot.AU * 1e6);
                    OeE.x += OeE2.x;
                    OeE.y += OeE2.y;
                    OeE.z += OeE2.z;
                }
                else if (i == Plot.EARTH)
                {
                    Pc.GetSunData(Dt, ref OeE);
                    OeE.x *= -1; OeE.y *= -1; OeE.z *= -1;
                }
                else
                {
                    Pc.GetPlanetData(i, Dt, ref OeE);
                }
                Pc.GetPlanetDataStatic(i, out SOEI);
                double KPlus = SOEI.SiderealTimeLen / 360;

                if (EarthCentered)
                {
                    Pc.GetSunData(Dt, ref OeE2);
                    OeE2.x *= -1; OeE2.y *= -1; OeE2.z *= -1;
                    OeE.x -= OeE2.x;
                    OeE.y -= OeE2.y;
                    OeE.z -= OeE2.z;
                }

                Plot.RotateX(UD, ref OeE.x, ref OeE.y, ref OeE.z);
                Plot.RotateY(LR, ref OeE.x, ref OeE.y, ref OeE.z);
                Plot.RotateZ(ZA, ref OeE.x, ref OeE.y, ref OeE.z);

                OeE.x = ((OeE.x * Plot.AU) / SolSysDimensionAU) * XScale;
                OeE.y = ((OeE.y * Plot.AU) / SolSysDimensionAU) * YScale;
                OeE.z *= Plot.AU;

                OeE.x += CenterX;
                OeE.y += CenterY;


                float StartPointX = (float)OeE.x;
                float StartPointY = (float)OeE.y;
                float OriginalStartPointX = (float)OeE.x;
                float OriginalStartPointY = (float)OeE.y;
                float EndPointX = 0;
                float EndPointY = 0;

                for (double k = 0; k <= SOEI.SiderealTimeLen; k += KPlus)
                {
                    if (i == Plot.MOON)
                    {
                        //	                		Pc.GetSunData( Dt.AddDays(k), ref OeE2 );
                        Pc.GetSunData(Dt, ref OeE2);
                        OeE2.x *= -1; OeE2.y *= -1; OeE2.z *= -1;
                        Pc.GetPlanetData(Plot.MOON, Dt.AddDays(k), ref OeE);
                        OeE.x *= 6378.140 / (Plot.AU * 1e6);
                        OeE.y *= 6378.140 / (Plot.AU * 1e6);
                        OeE.z *= 6378.140 / (Plot.AU * 1e6);
                        OeE.x += OeE2.x;
                        OeE.y += OeE2.y;
                        OeE.z += OeE2.z;
                    }
                    else if (i == Plot.EARTH)
                    {
                        Pc.GetSunData(Dt.AddDays(k), ref OeE);
                        OeE.x *= -1; OeE.y *= -1; OeE.z *= -1;
                    }
                    else
                    {
                        Pc.GetPlanetData(i, Dt.AddDays(k), ref OeE);
                    }

                    if (EarthCentered)
                    {
                        Pc.GetSunData(Dt, ref OeE2);
                        OeE2.x *= -1; OeE2.y *= -1; OeE2.z *= -1;
                        OeE.x -= OeE2.x;
                        OeE.y -= OeE2.y;
                        OeE.z -= OeE2.z;
                    }


                    Plot.RotateX(UD, ref OeE.x, ref OeE.y, ref OeE.z);
                    Plot.RotateY(LR, ref OeE.x, ref OeE.y, ref OeE.z);
                    Plot.RotateZ(ZA, ref OeE.x, ref OeE.y, ref OeE.z);


                    OeE.x = OeE.x * Plot.AU * XScale / SolSysDimensionAU;
                    OeE.y = OeE.y * Plot.AU * YScale / SolSysDimensionAU;
                    OeE.z *= Plot.AU;


                    OeE.x += CenterX;
                    OeE.y += CenterY;
                    EndPointX = (float)OeE.x;
                    EndPointY = (float)OeE.y;
                    Gr.DrawLine(P, StartPointX, StartPointY, (float)OeE.x, (float)OeE.y);
                    StartPointX = (float)OeE.x;
                    StartPointY = (float)OeE.y;
                }
                Gr.DrawLine(P, OriginalStartPointX, OriginalStartPointY, EndPointX, EndPointY);
            }
        }

        void AurinkokuntaKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 'w')
            {
                AngX += 1;
                tbXAxisRotation.Value = (int)Plot.NormalizeDegree(AngX);
                DrawSys(DrawDt);
            }
            else if (e.KeyChar == 's')
            {
                AngX -= 1;
                tbXAxisRotation.Value = (int)Plot.NormalizeDegree(AngX);
                DrawSys(DrawDt);
            }
            else if (e.KeyChar == 'a')
            {
                AngY -= 1;
                tbYAxisRotation.Value = (int)Plot.NormalizeDegree(AngY);
                DrawSys(DrawDt);
            }
            else if (e.KeyChar == 'd')
            {
                AngY += 1;
                tbYAxisRotation.Value = (int)Plot.NormalizeDegree(AngY);
                DrawSys(DrawDt);
            }
            else if (e.KeyChar == 'q')
            {
                AngZ -= 1;
                tbZAxisRotation.Value = (int)Plot.NormalizeDegree(AngZ);
                DrawSys(DrawDt);
            }
            else if (e.KeyChar == 'e')
            {
                AngZ += 1;
                tbZAxisRotation.Value = (int)Plot.NormalizeDegree(AngZ);
                DrawSys(DrawDt);
            }
            else if (e.KeyChar == '-')
            {
                if (ZoomPercentage - 10 > 0)
                    ZoomPercentage -= 10;
                DrawSys(DrawDt);
            }
            else if (e.KeyChar == '+')
            {
                ZoomPercentage += 10;
                DrawSys(DrawDt);
            }

            switch (e.KeyChar)
            {
                case 'q':
                case 'w':
                case 'e':
                case 'a':
                case 's':
                case 'd':
                case '+':
                case '-': e.Handled = true; break;
            }

        }

        void tmPlotTick(object sender, System.EventArgs e)
        {
            switch (ShowType)
            {
                case 0:
                    {
                        return;
                    }
                case 1:
                    {
                        DrawDt = DateTime.Now;
                        DrawSys(DrawDt);
                    }
                    break;
                case 2:
                    {
                        switch (cmbTimeSpeedUp.SelectedIndex)
                        {
                            case 0:
                                {
                                    DrawDt = DrawDt.AddYears(-1);
                                }
                                break;
                            case 1:
                                {
                                    DrawDt = DrawDt.AddMonths(-1);
                                }
                                break;
                            case 2:
                                {
                                    DrawDt = DrawDt.AddDays(-1);
                                }
                                break;
                            case 3:
                                {
                                    DrawDt = DrawDt.AddHours(-1);
                                }
                                break;
                        }
                        DrawSys(DrawDt);
                    }
                    break;
                case 3:
                    {
                        switch (cmbTimeSpeedUp.SelectedIndex)
                        {
                            case 0:
                                {
                                    DrawDt = DrawDt.AddYears(1);
                                }
                                break;
                            case 1:
                                {
                                    DrawDt = DrawDt.AddMonths(1);
                                }
                                break;
                            case 2:
                                {
                                    DrawDt = DrawDt.AddDays(1);
                                }
                                break;
                            case 3:
                                {
                                    DrawDt = DrawDt.AddHours(1);
                                }
                                break;
                        }
                        DrawSys(DrawDt);
                    }
                    break;
            }
        }

        public int CoordOnPlanet(int X, int Y)
        {
            int minx, miny, maxx, maxy;
            for (int i = 0; i < 11; i++)
            {
                if (i + 1 == Plot.MOON && ZoomPercentage < 1500) continue;
                minx = PlanetCoords[i].X - (int)RadiusRel[i];
                miny = PlanetCoords[i].Y - (int)RadiusRel[i];
                maxx = PlanetCoords[i].X + (int)RadiusRel[i];
                maxy = PlanetCoords[i].Y + (int)RadiusRel[i];
                if ((X >= minx && X <= maxx) && (Y > miny && Y <= maxy)) return i + 1;
            }
            return 0;
        }

        void PictureBox1MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int COP = CoordOnPlanet(e.X, e.Y);
            if (COP > 0)
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        void PictureBox1MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            int COP = CoordOnPlanet(e.X, e.Y);
            if (COP > 0)
            {
                PlanetInfo.Execute(COP);
            }

        }

        void EartchCCheckedChanged(object sender, System.EventArgs e)
        {
            DrawSys(DrawDt);
        }

        private void btJumpTime_Click(object sender, EventArgs e)
        {
            ShowType = 0;
            DrawDt = dtpJumpTime.Value;
            DrawSys(DrawDt);
        }

        private void cmbZoomPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbZoomPreset.SelectedIndex)
            {
                case 0:
                    ZoomPercentage = 510;
                    break;
                case 1:
                    ZoomPercentage = 100;
                    break;
                case 2:
                    {
                        ZoomPercentage = 5000;
                        cbEartchC.Checked = true;
                    }
                    break;
                case 3:
                    {
                        ZoomPercentage = 10000;
                        cbEartchC.Checked = true;
                    }
                    break;
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                    ZoomPercentage = Convert.ToDouble(cmbZoomPreset.Text.Substring(0, cmbZoomPreset.Text.Length - 2));
                    break;
            }
            DrawSys(DrawDt);
        }

        private void tsbPlay_Click(object sender, EventArgs e)
        {
            DrawDt = DateTime.Now;
            ShowType = 1;
        }

        private void tsbStop_Click(object sender, EventArgs e)
        {
            ShowType = 0;
            tslState.Text = StoppedText;
        }

        private void tsbFastBackward_Click(object sender, EventArgs e)
        {
            DrawDt = DateTime.Now;
            ShowType = 2;
        }

        private void tsbFastForward_Click(object sender, EventArgs e)
        {
            DrawDt = DateTime.Now;
            ShowType = 3;
        }

        private void tsbZeroAngles_Click(object sender, EventArgs e)
        {
            AngX = 0;
            AngY = 0;
            AngZ = 0;
            DrawSys(DrawDt);
        }

        private void SolarSystem_ResizeEnd(object sender, EventArgs e)
        {
            AspectResize();
        }

        private void AspectResize()
        {
            if (cbKeepAspectRatio.Checked)
            {
                pbSolSys.Dock = DockStyle.None;
                if (pnSolSysHolder.Width > pnSolSysHolder.Height)
                {
                    pbSolSys.Size = new Size(pnSolSysHolder.Height, pnSolSysHolder.Height);
                    pbSolSys.Top = 0;
                    pbSolSys.Left = (pnSolSysHolder.Width - pbSolSys.Width) / 2;
                }
                else
                {
                    pbSolSys.Size = new Size(pnSolSysHolder.Width, pnSolSysHolder.Width);
                    pbSolSys.Top = 0;
                    pbSolSys.Left = (pnSolSysHolder.Width - pbSolSys.Width) / 2;
                }
            }
            else
            {
                pbSolSys.Dock = DockStyle.Fill;
            }

            DrawSys(DrawDt);
        }

        private void axisRotation_Scroll(object sender, EventArgs e)
        {
            AngX = tbXAxisRotation.Value;
            AngY = tbYAxisRotation.Value;
            AngZ = tbZAxisRotation.Value;
            DrawSys(DrawDt);
        }

        private void tsbZoomPlus_Click(object sender, EventArgs e)
        {
            ZoomPercentage += 10;
            DrawSys(DrawDt);
        }

        private void tsbZoomMinus_Click(object sender, EventArgs e)
        {
            if (ZoomPercentage - 10 > 0)
                ZoomPercentage -= 10;
            DrawSys(DrawDt);
        }

        private void cbKeepAspectRatio_CheckedChanged(object sender, EventArgs e)
        {
            AspectResize();
        }

        private void btCopyToClipboard_Click(object sender, EventArgs e)
        {
            tmPlot.Enabled = false;
            Clipboard.SetDataObject(pbSolSys.Image, true);
            tmPlot.Enabled = true;
        }

        private void SolarSystem_Resize(object sender, EventArgs e)
        {
            AspectResize();
        }
    }
}
