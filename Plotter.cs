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
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using VPKSoft.DateTimeExtensions;

namespace Plotter
{

    public struct OrbElement
    {
        /// <summary>
        /// Long of asc. node
        /// </summary>
        public double N; // (Long of asc. node)

        /// <summary>
        /// Inclination
        /// </summary>
        public double i; // (Inclination)

        /// <summary>
        /// Argument of perihelion
        /// </summary>
        public double w; // (Argument of perihelion)

        /// <summary>
        /// Semi-major axis
        /// </summary>
        public double a; // (Semi-major axis)

        /// <summary>
        /// Eccentricity
        /// </summary>
        public double e; // (Eccentricity)

        /// <summary>
        /// Mean anonaly
        /// </summary>
        public double M; // (Mean anonaly)
    }

    public struct OrbElementExt
    {
        /// <summary>
        /// Long of asc. node
        /// </summary>
        public double N; // (Long of asc. node)

        /// <summary>
        /// Inclination
        /// </summary>
        public double i; // (Inclination)

        /// <summary>
        /// Argument of perihelion
        /// </summary>
        public double w; // (Argument of perihelion)

        /// <summary>
        /// Semi-major axis
        /// </summary>
        public double a; // (Semi-major axis)

        /// <summary>
        /// Eccentricity
        /// </summary>
        public double e; // (Eccentricity)

        /// <summary>
        /// Mean anonaly
        /// </summary>
        public double M; // (Mean anonaly)

        /// <summary>
        /// heliocentric distance
        /// </summary>
        public double r; // (heliocentric distance)

        /// <summary>
        /// geocentric distance
        /// </summary>
        public double R; // (geocentric distance)

        /// <summary>
        /// heliocentric longitude
        /// </summary>
        public double lon;

        /// <summary>
        /// heliocentric latitude
        /// </summary>
        public double lat; // (heliocentric lon,lat)

        /// <summary>
        /// heliocentric rectangular 3D coordinates: x
        /// </summary>
        public double x;

        /// <summary>
        /// heliocentric rectangular 3D coordinates: y
        /// </summary>        
        public double y;

        /// <summary>
        /// heliocentric rectangular 3D coordinates: z
        /// </summary>        
        public double z; // heliocentric rectangular 3D coordinates
    }

    public struct StaticOrbElementInfo
    {
        public double Mass;
        public double MeanDencity;
        public double MeanOrbitalVelocity;
        public double SiderealTimeLen;
        public double Radius;
        public double RotationTime;
        public double Volume;
        public double MeanDistanceFromSun;
        public double Acceleration;
    }

    public struct ConsNamesBinary
    {
        public string ShortName; // 4
        public string LongName; // 20
        public string FinName; // 20
        public double RA;
        public double Dec;
    }

    public struct ConsCoordBinary
    {
        public string ConsName; // 4
        public string BayerFlamsteed1; // 11
        public string ProperName1; // 11
        public string BayerFlamsteed2; // 18
        public string ProperName2; // 18
        public double RA1, Dec1, RA2, Dec2;
        public double R1, R2;
    }

    public struct UserObject
    {
        public string Name;
        public double Vmag;
        public double RA;
        public double Dec;
        public double DistPC;
        public string DrawType;
        public string Note;
        public bool ShowName;
        public Color DrawCol;
    }

    public struct YaleSmallBinary
    {
        public double RA;
        public double Dec;
        public double Mag;
    }

    public struct HYGBinary
    {
        public int StarID, Hip, HD, HR;
        public string Gliese; // 10
        public string BayerFlamsteedName; // 11
        public string ProperName; // 20
        public string Spectrum; // 15
        public double RA, Dec, Distance, Mag, AbsMag, ColorIndex;
    }

    public struct YaleBinary
    {
        public string Name; //11
        public string DM; //12
        public string ADS; //6
        public string ADScomp; //3
        public string VarID; //10
        public string SpType; // 21
        public string n_RadVel; // 5
        public string l_RotVel; // 3
        public string MultID; // 5
        public sbyte IRflag, r_IRflag, Multiple, DE_1900, DE_, n_Vmag, u_Vmag, u_B_V, u_U_B, n_R_I, n_SpType, n_Parallax, u_RotVel, NoteFlag;
        public int HR, HD, SAO, FK5, RAh1900, RAm1900, DEd1900, DEm1900, DEs1900, RAh, RAm, DEd, DEm, DEs, RadVel, RotVel, MultCnt;
        public double RAs1900, RAs, GLON, GLAT, Vmag, B_V, U_B, R_I, pmRA, pmDE, Parallax, Dmag, Sep;
    }

    public struct GlieseBinary
    {
        public string Ident; // 9
        public string Comp; // 3
        public string n_RV; // 4
        public string Sp; // 13
        public string n_Mv; // 3
        public string DM; // 13
        public string Giclas; // 10
        public string LHS; // 6
        public string Other; // 6
        public string Remarks; // 70
        public sbyte DistRel, DE_, u_pm, r_Sp, n_V, Joint_V, n_B_V, Joint_B_V, n_U_B, Joint_U_B, n_R_I, Joint_R_I, n_plx, q_Mv;
        public int RAh, RAm, RAs, DEd, U, V, W, HD;
        public double DEm, pm, pmPA, RV, B_V, U_B, R_I, trplx, e_trplx, plx, e_plx, Mv, Vmag;
    }

    public struct StarData
    {
        public double Magnitude;       // mag
        public double Declination;     // dec
        public double RightAscencion;  // ra
    }

    public struct ColStruct
    {
        public Color LineCol;
        public Color TextCol;
        public Color StarCol;
        public Color BackCol;
        public Color RounCol;
    }

    public class NULLTStrings
    {
        public static string NULLTToString(byte[] Bytes)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF7;
            int EndIndex = 0;
            for (int i = 0; i < Bytes.Length; i++)
            {
                if (Bytes[i] == 0)
                {
                    EndIndex = i;
                    break;
                }
            }
            if (EndIndex == 0) return "";
            return encoding.GetString(Bytes, 0, EndIndex);
        }

        public static string NULLTToStringUTF8(byte[] Bytes)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            int EndIndex = 0;
            for (int i = 0; i < Bytes.Length; i++)
            {
                if (Bytes[i] == 0)
                {
                    EndIndex = i;
                    break;
                }
            }
            if (EndIndex == 0) return "";
            return encoding.GetString(Bytes, 0, EndIndex);
        }
    }

    public class DegreeMath
    {
        public const double PI = 3.14159265358979323846;
        public const double RADEG = 180.0 / PI;
        public const double DEGRAD = PI / 180.0;

        public static double DegToRad(double x)
        {
            return x * DEGRAD;
        }

        public static double RadToDeg(double x)
        {
            return x * RADEG;
        }

        public static double sind(double x)
        {
            return Math.Sin(x * DEGRAD);
        }

        public static double cosd(double x)
        {
            return Math.Cos(x * DEGRAD);
        }

        public static double tand(double x)
        {
            return Math.Tan(x * DEGRAD);
        }

        public static double asind(double x)
        {
            return RADEG * Math.Asin(x);
        }

        public static double acosd(double x)
        {
            return RADEG * Math.Acos(x);
        }

        public static double atand(double x)
        {
            return RADEG * Math.Atan(x);
        }

        public static double atan2d(double y, double x)
        {
            return RADEG * Math.Atan2(y, x);
        }
    }

    public class Plot
    {
        public string OpDir;
        public Plot(string OperatingDirectory, bool useConventionalImages)
        {
            OpDir = OperatingDirectory;
            FillStaticOrbElements();
            InitGrahTools();
            InitPlanetImages(useConventionalImages);
        }

        public OrbElement Sun, Moon, Mercury, Venus, Mars, Jupiter, Saturn, Uranus, Neptune, Pluto;
        public StaticOrbElementInfo SunS, MoonS, MercuryS, VenusS, MarsS, JupiterS, SaturnS, UranusS, NeptuneS, PlutoS, EarthS;
        public const int SUN = 1;
        public const int MOON = 2;
        public const int MERCURY = 3;
        public const int VENUS = 4;
        public const int MARS = 5;
        public const int JUPITER = 6;
        public const int SATURN = 7;
        public const int URANUS = 8;
        public const int NEPTUNE = 9;
        public const int PLUTO = 10;
        public const int EARTH = 11;

        public const double EarthSiderealTimeLen = 365.2564;
        public const double AU = 149.5979;

        public const int CNAMESHORT = 0;
        public const int CNAMELONG = 1;
        public const int CNAMEFIN = 2;

        public ImageList PlanetImages;

        private FontFamily DrawFont;
        private Pen DrawPen;
        private SolidBrush DrawBrush;

        private void InitGrahTools()
        {
            for (int i = 0; i < FontFamily.Families.Length; i++)
            {
                if (FontFamily.Families[i].Name == "Arial")
                {
                    DrawFont = FontFamily.Families[i];
                    return;
                }
            }
            DrawFont = FontFamily.GenericSansSerif;
            DrawPen = new Pen(Color.Black, 1);
            DrawBrush = new SolidBrush(Color.Black);
        }

        public static DateTime NoDayLight(DateTime Dt)
        {
            /*
            DaylightTime Dl = TimeZone.CurrentTimeZone.GetDaylightChanges(Dt.Year);
            if (Dt >= Dl.Start && Dt <= Dl.End)
            {
                Dt -= Dl.Delta;
            }
            */
            return Dt;
        }

        public static void NoDayLight(ref DateTime Dt)
        {
            return;
            /*
            DaylightTime Dl = TimeZone.CurrentTimeZone.GetDaylightChanges(Dt.Year);
            if (Dt >= Dl.Start && Dt <= Dl.End)
            {
                Dt -= Dl.Delta;
            }
            */
        }

        public void SetAlpha(ref Bitmap bmp, byte alpha)
        {
            if (bmp == null) throw new ArgumentNullException("bmp");

            var data = bmp.LockBits(
                new Rectangle(0, 0, bmp.Width, bmp.Height),
                System.Drawing.Imaging.ImageLockMode.ReadWrite,
                System.Drawing.Imaging.PixelFormat.Format32bppPArgb);

            var line = data.Scan0;
            var eof = line + data.Height * data.Stride;
            while (line != eof)
            {
                var pixelAlpha = line + 3;
                var eol = pixelAlpha + data.Width * 4;
                while (pixelAlpha != eol)
                {
                    System.Runtime.InteropServices.Marshal.WriteByte(
                        pixelAlpha, alpha);
                    pixelAlpha += 4;
                }
                line += data.Stride;
            }
            bmp.UnlockBits(data);
        }

        public void InitPlanetImages(bool conventional)
        {
            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                return; // not now while localizing
            }

            PlanetImages = new ImageList();
            PlanetImages.ImageSize = new Size(15, 15);

            if (conventional)
            {
                Bitmap Bm = new Bitmap(OpDir + @"/Data/Images/Planet00.bmp");
                Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/Planet01.bmp");
                Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/Planet02.bmp");
                PlanetImages.Images.Add(Bm);
                Bm.MakeTransparent(Color.Black);
                Bm = new Bitmap(OpDir + @"/Data/Images/Planet03.bmp");
                Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/Planet04.bmp");
                Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/Planet05.bmp");
                Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/Planet06.bmp");
                Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/Planet07.bmp");
                Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/Planet08.bmp");
                Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/Planet09.bmp");
                Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);

            }
            else
            {
                Bitmap Bm = new Bitmap(OpDir + @"/Data/Images/sun.png");
                //			Bm.MakeTransparent(Color.Black);
                SetAlpha(ref Bm, 255);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/moon.png");
                SetAlpha(ref Bm, 255);
                //            Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/mercury.png");
                SetAlpha(ref Bm, 255);
                PlanetImages.Images.Add(Bm);
                //            Bm.MakeTransparent(Color.Black);
                Bm = new Bitmap(OpDir + @"/Data/Images/venus.png");
                //			Bm.MakeTransparent(Color.Black);
                SetAlpha(ref Bm, 255);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/mars.png");
                //			Bm.MakeTransparent(Color.Black);
                SetAlpha(ref Bm, 255);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/jupiter.png");
                SetAlpha(ref Bm, 255);
                //            Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/saturn.png");
                SetAlpha(ref Bm, 255);
                //            Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/uranus.png");
                SetAlpha(ref Bm, 255);
                //            Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/neptune.png");
                SetAlpha(ref Bm, 255);
                //            Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
                Bm = new Bitmap(OpDir + @"/Data/Images/pluto.png");
                SetAlpha(ref Bm, 255);
                //            Bm.MakeTransparent(Color.Black);
                PlanetImages.Images.Add(Bm);
            }
        }

        public Image CreatePlanetImage(int Planet)
        {
            switch (Planet)
            {
                case SUN:
                    return PlanetImages.Images[0];
                case MOON:
                    return PlanetImages.Images[1];
                case MERCURY:
                    return PlanetImages.Images[2];
                case VENUS:
                    return PlanetImages.Images[3];
                case MARS:
                    return PlanetImages.Images[4];
                case JUPITER:
                    return PlanetImages.Images[5];
                case SATURN:
                    return PlanetImages.Images[6];
                case URANUS:
                    return PlanetImages.Images[7];
                case NEPTUNE:
                    return PlanetImages.Images[8];
                case PLUTO:
                    return PlanetImages.Images[9];
                default:
                    return new Bitmap(15, 15);
            }
        }


        // STEREOGRAPHIC SKY PROJECTION

        public static double SGN(double VAL)
        {
            if (VAL < 0)
            {
                return -1;
            }
            else if (VAL > 0)
            {
                return 1;
            }
            return 0;
        }



        public static void StereographicProjection(double K /*Radius*/, double B /*LAT*/, double L, ref double X, ref double Y, double LST, double RA, double DEC)
        {
            double P = DegreeMath.PI;
            double R1 = P / 180;
            B *= R1;
            L *= R1;
            // Local Siderial Time (decimal)
            double T = LST * 15 * R1 - L;
            // RA ?
            double R = RA * 15 * R1;
            // DEC ?
            double D = DEC * R1;
            // LOCAL HR ANGLE
            double T5 = T - R + L;
            double S1 = Math.Sin(B) * Math.Sin(D);
            S1 = S1 + Math.Cos(B) * Math.Cos(D) * Math.Cos(T5);
            double C1 = 1 - S1 * S1;
            double H;
            if (C1 > 0)
            {
                C1 = Math.Sqrt(C1);
                H = Math.Atan(S1 / C1);
            }
            else
            {
                H = SGN(S1) * P / 2;
            }
            double C2 = Math.Cos(B) * Math.Sin(D);
            C2 = C2 - Math.Sin(B) * Math.Cos(D) * Math.Cos(T5);
            double S2 = -Math.Cos(D) * Math.Sin(T5);
            double A;
            if (C2 == 0)
            {
                A = SGN(S2) * P / 2;
                if (A < 0) A = A + 2 * P;
            }
            else
            {
                A = Math.Atan(S2 / C2);
                if (C2 < 0) A = A + P;
            }
            double Q = P / 4 - H / 2;
            X = K * Math.Sin(Q) / Math.Cos(Q) * Math.Sin(2 * P - A);
            Y = K * Math.Sin(Q) / Math.Cos(Q) * Math.Cos(2 * P - A);
        }

        //		public static void DeStereographicProjection (double B /*LAT*/, double L, double X, double Y, double LST, out double RA, out double DEC)
        //		{
        //		}


        public class PlanetPlot
        {
            public double X = 0;
            public double Y = 0;
            public int Planet = 0;
        }

        public static bool MouseOverPlanet(PlanetPlot planet, int x, int y)
        {
            //return (x > planet.X && x < planet.X + 7 && y > planet.Y && y < planet.Y + 7);
            return Math.Pow(planet.X - (double)x, 2.0) + Math.Pow(planet.Y - (double)y, 2.0) < Math.Pow(8.0, 2.0);
        }

        public static List<PlanetPlot> LastPlotLocations = new List<PlanetPlot>(); // 28.10.17, Last planet coordinates (x, y and planet)

        public void PlotSkyMap(double Latid, double Longit, DateTime Dt, out Image Bm1, bool FlipX, bool FlipY, ref StarDataHolder SData, double MagnitudeLimit, bool NoSolSys, bool NoCons, string[] ConsNames, double offset, double scale, ref ColStruct MapColors)
        {
            double SidTime = SiderealTime(Dt, Longit);
            float F1 = 2 * (float)offset;
            Bitmap Bm = new Bitmap((int)F1, (int)F1);
            Bm1 = new Bitmap((int)F1, (int)F1);
            Graphics PG = Graphics.FromImage(Bm);

            DrawBrush = new SolidBrush(MapColors.RounCol);
            PG.FillRectangle(DrawBrush, 0, 0, F1, F1);

            DrawBrush.Color = Color.White;
            dCircleFill(offset, offset, scale + 1, ref PG);
            Bm.MakeTransparent(Color.White);

            PG = Graphics.FromImage(Bm1);
            DrawBrush.Color = MapColors.BackCol;
            PG.FillRectangle(DrawBrush, 0, 0, F1, F1);

            double x = 0, y = 0;

            double r, d, m;

            // planets and the sun..

            FillOrbElements(Dt);
            LastPlotLocations.Clear(); // Clear the list so it can be filled again.. (28.10.17)
            if (!NoSolSys)
            {

                for (int i = SUN; i <= PLUTO; i++)
                {
                    CalculateRaDecPlanet(i, Dt, out r, out d);
                    StereographicProjection(1, Latid, Longit, ref x, ref y, SidTime, r, d);
                    if (!FlipY) y *= -1;
                    if (!FlipX) x *= -1;
                    Image Pim = CreatePlanetImage(i);

                    float pX = (float)(scale * x + offset - 7); // Point X
                    float pY = (float)(scale * y + offset - 7); // Point Y

                    LastPlotLocations.Add(new PlanetPlot() { X = pX + 7, Y = pY + 7, Planet = i }); // Add the last locations to the list (28.10.17)

                    PG.DrawImage(Pim, pX, pY);
                }
            }

            //*******************************

            double rs;
            DrawBrush.Color = MapColors.StarCol;
            for (int i = 0; i < SData.StarDataCount; i++)
            {
                SData.Get(i, out r, out d, out m);

                if (m > MagnitudeLimit) continue;
                StereographicProjection(1, Latid, Longit, ref x, ref y, SidTime, r, d);

                if (m < 6) rs = Math.Sqrt(MagnitudeLimit - m); else rs = 1;
                if (!FlipY) y *= -1;
                if (!FlipX) x *= -1;
                if (rs >= 0) dCircleFill(scale * x + offset, scale * y + offset, rs, ref PG);
            }

            for (int i = 0; i < SData.UObjCount; i++)
            {
                StereographicProjection(1, Latid, Longit, ref x, ref y, SidTime, SData.UObj[i].RA, SData.UObj[i].Dec);

                if (!FlipY) y *= -1;
                if (!FlipX) x *= -1;

                x = x * scale + offset;
                y = y * scale + offset;

                StarDataHolder.DrawUserObject((float)x, (float)y, SData.UObj[i], MapColors.TextCol, ref PG);
            }


            double x1 = 0, y1 = 0, x2 = 0, y2 = 0;

            if (!NoCons)
            {
                DrawPen = new Pen(MapColors.LineCol, 1);
                for (int i = 0; i < SData.ConsCoordCount; i++)
                {
                    StereographicProjection(1, Latid, Longit, ref x1, ref y1, SidTime, SData.CCoords[i].RA1, SData.CCoords[i].Dec1);
                    StereographicProjection(1, Latid, Longit, ref x2, ref y2, SidTime, SData.CCoords[i].RA2, SData.CCoords[i].Dec2);

                    if (!FlipY) y1 *= -1;
                    if (!FlipY) y2 *= -1;

                    if (!FlipX) x1 *= -1;
                    if (!FlipX) x2 *= -1;

                    x1 = x1 * scale + offset;
                    x2 = x2 * scale + offset;
                    y1 = y1 * scale + offset;
                    y2 = y2 * scale + offset;

                    if (WithInCircle(offset, offset, scale, x1, y1) || WithInCircle(offset, offset, scale, x2, y2))
                        dLine(x1, y1, x2, y2, ref PG);
                }
                DrawBrush.Color = MapColors.TextCol;

                for (int i = 0; i < SData.ConsNamesCount; i++)
                {
                    StereographicProjection(1, Latid, Longit, ref x, ref y, SidTime, SData.CNames[i].RA, SData.CNames[i].Dec);

                    if (!FlipY) y *= -1;
                    if (!FlipX) x *= -1;
                    if (WithInCircle(offset, offset, scale, scale * x + offset, scale * y + offset))
                        TextToCanvas(scale * x + offset, scale * y + offset, ConsNames[i], 8, MapColors.TextCol, ref PG);
                }
            }

            PG = Graphics.FromImage(Bm1);
            PG.DrawImage(Bm, 0, 0);
        }

        public void GetPlanetDataStatic(int Planet, out StaticOrbElementInfo SOEI)
        {
            switch (Planet)
            {
                case SUN:
                    SOEI = SunS;
                    break;
                case MOON:
                    SOEI = MoonS;
                    break;
                case MERCURY:
                    SOEI = MercuryS;
                    break;
                case VENUS:
                    SOEI = VenusS;
                    break;
                case MARS:
                    SOEI = MarsS;
                    break;
                case JUPITER:
                    SOEI = JupiterS;
                    break;
                case SATURN:
                    SOEI = SaturnS;
                    break;
                case URANUS:
                    SOEI = UranusS;
                    break;
                case NEPTUNE:
                    SOEI = NeptuneS;
                    break;
                case PLUTO:
                    SOEI = PlutoS;
                    break;
                case EARTH:
                    SOEI = EarthS;
                    break;
                default:
                    SOEI = new StaticOrbElementInfo();
                    break;
            }
        }

        public void dLine(double origX, double origY, double endX, double endY, ref Graphics cv)
        {
            cv.DrawLine(DrawPen, (float)origX, (float)origY, (float)endX, (float)endY);
        }

        public void dCircleFill(double centerX, double centerY, double radius, ref Graphics cv)
        {
            cv.FillEllipse(DrawBrush, (float)centerX - (float)radius, (float)centerY - (float)radius, 2 * (float)radius, 2 * (float)radius);
        }

        public void dCircle(double centerX, double centerY, double radius, ref Graphics cv)
        {
            cv.DrawEllipse(DrawPen, (float)centerX - (float)radius, (float)centerY - (float)radius, 2 * (float)radius, 2 * (float)radius);
        }

        public void TextToCanvas(double x, double y, string Text, float FontSize, Color FontColor, ref Graphics cv)
        {
            Font DFont = new Font(DrawFont, FontSize);
            DrawBrush.Color = FontColor;
            SizeF StringDim = cv.MeasureString(Text, DFont);
            cv.DrawString(Text, DFont, DrawBrush, (float)x - StringDim.Width / 2, (float)y - StringDim.Height / 2);
        }

        public void GetSunData(DateTime Dt, ref OrbElementExt OeE)
        {
            double d = Calculate_d(Dt);
            double M = NormalizeDegree(356.0470 + 0.9856002585 * d);
            double e = 0.016709 - 1.151E-9 * d;
            double E = M + e * DegreeMath.sind(M) * (1.0 + e * DegreeMath.cosd(M));

            double xv = DegreeMath.cosd(E) - e;
            double yv = Math.Sqrt(1.0 - e * e) * DegreeMath.sind(E);

            double v = DegreeMath.atan2d(yv, xv);
            double r = Math.Sqrt(xv * xv + yv * yv);
            double w = 282.9404 + 4.70935E-5 * d;
            double lonsun = v + w;

            double lon_corr = 3.82394E-5 * (365.2422 * (2000 - 2000.0) - d);
            lonsun += lon_corr;

            lonsun = NormalizeDegree(lonsun);



            double xs = r * DegreeMath.cosd(lonsun);
            double ys = r * DegreeMath.sind(lonsun);
            OeE.x = xs;
            OeE.y = ys;
            OeE.z = 0;

            OeE.R = r;
            OeE.r = 0;
        }


        public void GetPlanetData(int Planet, DateTime Dt, ref OrbElementExt OeE)
        {
            FillOrbElements(Dt);
            OrbElement Element;
            switch (Planet)
            {
                case SUN:
                    {
                        GetSunData(Dt, ref OeE);
                        return;
                    }
                case MOON:
                    Element = Moon;
                    break;
                case MERCURY:
                    Element = Mercury;
                    break;
                case VENUS:
                    Element = Venus;
                    break;
                case MARS:
                    Element = Mars;
                    break;
                case JUPITER:
                    Element = Jupiter;
                    break;
                case SATURN:
                    Element = Saturn;
                    break;
                case URANUS:
                    Element = Uranus;
                    break;
                case NEPTUNE:
                    Element = Neptune;
                    break;
                case PLUTO:
                    Element = Pluto;
                    break;
                default:
                    {
                        Element.N = 0;
                        Element.i = 0;
                        Element.w = 0;
                        Element.a = 0;
                        Element.e = 0;
                        Element.M = 0;
                    }
                    break;

            }
            double d = Calculate_d(Dt);
            double E0 = Element.M + (180 / DegreeMath.PI) * Element.e * DegreeMath.sind(Element.M) * (1 + Element.e * DegreeMath.cosd(Element.M)), E1;
            while (true)
            {
                E1 = E0 - (E0 - (180 / DegreeMath.PI) * Element.e * DegreeMath.sind(E0) - Element.M) / (1 - Element.e * DegreeMath.cosd(E0));
                if (Math.Abs(Math.Abs(E0) - Math.Abs(E1)) < 0.005) break;
                E0 = E1;
            }
            double E = E1, x, y, r = 0, v, lonecl = 0, latecl = 0, lon_corr, xg, yg, zg, rs, xs, ys, xh, yh, zh, xe, ye, ze;
            if (Planet != PLUTO)
            {
                x = Element.a * (DegreeMath.cosd(E) - Element.e);
                y = Element.a * Math.Sqrt(1 - Element.e * Element.e) * DegreeMath.sind(E);

                r = Math.Sqrt(x * x + y * y);
                v = DegreeMath.atan2d(y, x);

                xh = r * (DegreeMath.cosd(Element.N) * DegreeMath.cosd(v + Element.w) - DegreeMath.sind(Element.N) * DegreeMath.sind(v + Element.w) * DegreeMath.cosd(Element.i));
                yh = r * (DegreeMath.sind(Element.N) * DegreeMath.cosd(v + Element.w) + DegreeMath.cosd(Element.N) * DegreeMath.sind(v + Element.w) * DegreeMath.cosd(Element.i));
                zh = r * DegreeMath.sind(v + Element.w) * DegreeMath.sind(Element.i);

                lonecl = DegreeMath.atan2d(yh, xh);
                latecl = DegreeMath.atan2d(zh, Math.Sqrt(xh * xh + yh * yh));
            }

            lon_corr = 3.82394E-5 * (365.2422 * (2000 - 2000.0) - d);

            lonecl += lon_corr;

            double lonsun = GetLonSun(Dt, out rs);

            //korjaukset ***************

            double Mj = Jupiter.M;
            double Ms = Saturn.M;
            double Mu = Uranus.M;

            if (Planet == JUPITER)
            {
                lonecl += -0.332 * DegreeMath.sind(2 * Mj - 5 * Ms - 67.6);
                lonecl += -0.056 * DegreeMath.sind(2 * Mj - 2 * Ms + 21);
                lonecl += +0.042 * DegreeMath.sind(3 * Mj - 5 * Ms + 21);
                lonecl += -0.036 * DegreeMath.sind(Mj - 2 * Ms);
                lonecl += +0.022 * DegreeMath.cosd(Mj - Ms);
                lonecl += +0.023 * DegreeMath.sind(2 * Mj - 3 * Ms + 52);
                lonecl += -0.016 * DegreeMath.sind(Mj - 5 * Ms - 69);
            }

            if (Planet == SATURN)
            {
                lonecl += +0.812 * DegreeMath.sind(2 * Mj - 5 * Ms - 67.6);
                lonecl += -0.229 * DegreeMath.cosd(2 * Mj - 4 * Ms - 2);
                lonecl += +0.119 * DegreeMath.sind(Mj - 2 * Ms - 3);
                lonecl += +0.046 * DegreeMath.sind(2 * Mj - 6 * Ms - 69);
                lonecl += +0.014 * DegreeMath.sind(Mj - 3 * Ms + 32);

                latecl += -0.020 * DegreeMath.cosd(2 * Mj - 4 * Ms - 2);
                latecl += +0.018 * DegreeMath.sind(2 * Mj - 6 * Ms - 49);
            }

            if (Planet == URANUS)
            {
                lonecl += +0.040 * DegreeMath.sind(Ms - 2 * Mu + 6);
                lonecl += +0.035 * DegreeMath.sind(Ms - 3 * Mu + 33);
                lonecl += -0.015 * DegreeMath.sind(Mj - Mu + 20);
            }

            if (Planet == MOON)
            {
                double Ls = NormalizeDegree(lonsun);
                double Lm = NormalizeDegree(Moon.N + Moon.w + Moon.M);
                Ms = NormalizeDegree(Sun.M);
                double Mm = NormalizeDegree(Moon.M);
                double D = NormalizeDegree(Lm - Ls);
                double F = NormalizeDegree(Lm - Moon.N);

                lonecl += -1.274 * DegreeMath.sind(Mm - 2 * D);
                lonecl += +0.658 * DegreeMath.sind(2 * D);
                lonecl += -0.186 * DegreeMath.sind(Ms);
                lonecl += -0.059 * DegreeMath.sind(2 * Mm - 2 * D);
                lonecl += -0.057 * DegreeMath.sind(Mm - 2 * D + Ms);
                lonecl += +0.053 * DegreeMath.sind(Mm + 2 * D);
                lonecl += +0.046 * DegreeMath.sind(2 * D - Ms);
                lonecl += +0.041 * DegreeMath.sind(Mm - Ms);
                lonecl += -0.035 * DegreeMath.sind(D);
                lonecl += -0.031 * DegreeMath.sind(Mm + Ms);
                lonecl += -0.015 * DegreeMath.sind(2 * F - 2 * D);
                lonecl += +0.011 * DegreeMath.sind(Mm - 4 * D);

                latecl += -0.173 * DegreeMath.sind(F - 2 * D);
                latecl += -0.055 * DegreeMath.sind(Mm - F - 2 * D);
                latecl += -0.046 * DegreeMath.sind(Mm + F - 2 * D);
                latecl += +0.033 * DegreeMath.sind(F + 2 * D);
                latecl += +0.017 * DegreeMath.sind(2 * Mm + F);

                r += -0.58 * DegreeMath.cosd(Mm - 2 * D);
                r += -0.46 * DegreeMath.cosd(2 * D);

                lonecl = NormalizeDegree(lonecl);
            }

            if (Planet == PLUTO)
            {
                double S = 50.03 + 0.033459652 * d;
                double P = 238.95 + 0.003968789 * d;

                lonecl = 238.9508 + 0.00400703 * d;
                lonecl += -19.799 * DegreeMath.sind(P) + 19.848 * DegreeMath.cosd(P);
                lonecl += +0.897 * DegreeMath.sind(2 * P) - 4.956 * DegreeMath.cosd(2 * P);
                lonecl += +0.610 * DegreeMath.sind(3 * P) + 1.211 * DegreeMath.cosd(3 * P);
                lonecl += -0.341 * DegreeMath.sind(4 * P) - 0.190 * DegreeMath.cosd(4 * P);
                lonecl += +0.128 * DegreeMath.sind(5 * P) - 0.034 * DegreeMath.cosd(5 * P);
                lonecl += -0.038 * DegreeMath.sind(6 * P) + 0.031 * DegreeMath.cosd(6 * P);
                lonecl += +0.020 * DegreeMath.sind(S - P) - 0.010 * DegreeMath.cosd(S - P);

                latecl = -3.9082;
                latecl += -5.453 * DegreeMath.sind(P) - 14.975 * DegreeMath.cosd(P);
                latecl += +3.527 * DegreeMath.sind(2 * P) + 1.673 * DegreeMath.cosd(2 * P);
                latecl += -1.051 * DegreeMath.sind(3 * P) + 0.328 * DegreeMath.cosd(3 * P);
                latecl += +0.179 * DegreeMath.sind(4 * P) - 0.292 * DegreeMath.cosd(4 * P);
                latecl += +0.019 * DegreeMath.sind(5 * P) + 0.100 * DegreeMath.cosd(5 * P);
                latecl += -0.031 * DegreeMath.sind(6 * P) - 0.026 * DegreeMath.cosd(6 * P);
                latecl += +0.011 * DegreeMath.cosd(S - P);

                r = 40.72;
                r += +6.68 * DegreeMath.sind(P) + 6.90 * DegreeMath.cosd(P);
                r += -1.18 * DegreeMath.sind(2 * P) - 0.03 * DegreeMath.cosd(2 * P);
                r += +0.15 * DegreeMath.sind(3 * P) - 0.14 * DegreeMath.cosd(3 * P);

                lonecl += lon_corr;
                lonecl = NormalizeDegree(lonecl);
            }
            // *************************
            xh = r * DegreeMath.cosd(lonecl) * DegreeMath.cosd(latecl);
            yh = r * DegreeMath.sind(lonecl) * DegreeMath.cosd(latecl);
            zh = r * DegreeMath.sind(latecl);
            OeE.x = xh;
            OeE.y = yh;
            OeE.z = zh;

            if (Planet != MOON)
            {
                xs = rs * DegreeMath.cosd(lonsun);
                ys = rs * DegreeMath.sind(lonsun);

                xg = xh + xs;
                yg = yh + ys;
                zg = zh;
            }
            else
            {
                xg = xh;
                yg = yh;
                zg = zh;
            }

            double ecl = 23.4393 - 3.563E-7 * d;

            xe = xg;
            ye = yg * DegreeMath.cosd(ecl) - zg * DegreeMath.sind(ecl);
            ze = yg * DegreeMath.sind(ecl) + zg * DegreeMath.cosd(ecl);

            double rg = Math.Sqrt(xe * xe + ye * ye + ze * ze);
            // *************************
            OeE.R = rg;
            if (Planet != MOON)
            {
                OeE.r = r;
            }
            else
            {
                OeE.r = r / 23450;
            }
            OeE.lon = lonecl;
            OeE.lat = latecl;
        }

        public static void SunRaDec2(DateTime Dt, out double RA, out double Dec)
        {
            double d = Calculate_d(Dt);
            double ecl = 23.4393 - 3.563E-7 * d;
            double M = NormalizeDegree(356.0470 + 0.9856002585 * d);
            double e = 0.016709 - 1.151E-9 * d;
            double E = M + e * DegreeMath.sind(M) * (1.0 + e * DegreeMath.cosd(M));

            double xv = DegreeMath.cosd(E) - e;
            double yv = Math.Sqrt(1.0 - e * e) * DegreeMath.sind(E);

            double v = DegreeMath.atan2d(yv, xv);
            double r = Math.Sqrt(xv * xv + yv * yv);
            double w = 282.9404 + 4.70935E-5 * d;
            double lonsun = v + w;

            double lon_corr = 3.82394E-5 * (365.2422 * (2000 - 2000.0) - d);
            lonsun += lon_corr;

            lonsun = NormalizeDegree(lonsun);



            double xs = r * DegreeMath.cosd(lonsun);
            double ys = r * DegreeMath.sind(lonsun);

            double xe = xs;
            double ye = ys * DegreeMath.cosd(ecl);
            double ze = ys * DegreeMath.sind(ecl);

            RA = DegreeMath.atan2d(ye, xe) / 15;
            Dec = DegreeMath.atan2d(ze, Math.Sqrt(xe * xe + ye * ye));
        }

        public void CalculateRaDecPlanet(int Planet, DateTime Dt, out double RA, out double Dec)
        {
            FillOrbElements(Dt);
            OrbElement Element;
            switch (Planet)
            {
                case SUN:
                    {
                        SunRaDec2(Dt, out RA, out Dec);
                        return;
                    }
                case MOON:
                    Element = Moon;
                    break;
                case MERCURY:
                    Element = Mercury;
                    break;
                case VENUS:
                    Element = Venus;
                    break;
                case MARS:
                    Element = Mars;
                    break;
                case JUPITER:
                    Element = Jupiter;
                    break;
                case SATURN:
                    Element = Saturn;
                    break;
                case URANUS:
                    Element = Uranus;
                    break;
                case NEPTUNE:
                    Element = Neptune;
                    break;
                case PLUTO:
                    Element = Pluto;
                    break;
                default:
                    {
                        Element.N = 0;
                        Element.i = 0;
                        Element.w = 0;
                        Element.a = 0;
                        Element.e = 0;
                        Element.M = 0;
                    }
                    break;

            }
            double d = Calculate_d(Dt);
            double E0 = Element.M + (180 / DegreeMath.PI) * Element.e * DegreeMath.sind(Element.M) * (1 + Element.e * DegreeMath.cosd(Element.M)), E1;
            while (true)
            {
                E1 = E0 - (E0 - (180 / DegreeMath.PI) * Element.e * DegreeMath.sind(E0) - Element.M) / (1 - Element.e * DegreeMath.cosd(E0));
                if (Math.Abs(Math.Abs(E0) - Math.Abs(E1)) < 0.005) break;
                E0 = E1;
            }
            double E = E1, x, y, r = 0, v, lonecl = 0, latecl = 0, lon_corr, xg, yg, zg, rs, xs, ys, xh, yh, zh, xe, ye, ze;
            if (Planet != PLUTO)
            {
                x = Element.a * (DegreeMath.cosd(E) - Element.e);
                y = Element.a * Math.Sqrt(1 - Element.e * Element.e) * DegreeMath.sind(E);

                r = Math.Sqrt(x * x + y * y);
                v = DegreeMath.atan2d(y, x);

                xh = r * (DegreeMath.cosd(Element.N) * DegreeMath.cosd(v + Element.w) - DegreeMath.sind(Element.N) * DegreeMath.sind(v + Element.w) * DegreeMath.cosd(Element.i));
                yh = r * (DegreeMath.sind(Element.N) * DegreeMath.cosd(v + Element.w) + DegreeMath.cosd(Element.N) * DegreeMath.sind(v + Element.w) * DegreeMath.cosd(Element.i));
                zh = r * DegreeMath.sind(v + Element.w) * DegreeMath.sind(Element.i);

                lonecl = DegreeMath.atan2d(yh, xh);
                latecl = DegreeMath.atan2d(zh, Math.Sqrt(xh * xh + yh * yh));
            }

            lon_corr = 3.82394E-5 * (365.2422 * (2000 - 2000.0) - d);

            lonecl += lon_corr;

            double lonsun = GetLonSun(Dt, out rs);

            //korjaukset ***************

            double Mj = Jupiter.M;
            double Ms = Saturn.M;
            double Mu = Uranus.M;

            if (Planet == JUPITER)
            {
                lonecl += -0.332 * DegreeMath.sind(2 * Mj - 5 * Ms - 67.6);
                lonecl += -0.056 * DegreeMath.sind(2 * Mj - 2 * Ms + 21);
                lonecl += +0.042 * DegreeMath.sind(3 * Mj - 5 * Ms + 21);
                lonecl += -0.036 * DegreeMath.sind(Mj - 2 * Ms);
                lonecl += +0.022 * DegreeMath.cosd(Mj - Ms);
                lonecl += +0.023 * DegreeMath.sind(2 * Mj - 3 * Ms + 52);
                lonecl += -0.016 * DegreeMath.sind(Mj - 5 * Ms - 69);
            }

            if (Planet == SATURN)
            {
                lonecl += +0.812 * DegreeMath.sind(2 * Mj - 5 * Ms - 67.6);
                lonecl += -0.229 * DegreeMath.cosd(2 * Mj - 4 * Ms - 2);
                lonecl += +0.119 * DegreeMath.sind(Mj - 2 * Ms - 3);
                lonecl += +0.046 * DegreeMath.sind(2 * Mj - 6 * Ms - 69);
                lonecl += +0.014 * DegreeMath.sind(Mj - 3 * Ms + 32);

                latecl += -0.020 * DegreeMath.cosd(2 * Mj - 4 * Ms - 2);
                latecl += +0.018 * DegreeMath.sind(2 * Mj - 6 * Ms - 49);
            }

            if (Planet == URANUS)
            {
                lonecl += +0.040 * DegreeMath.sind(Ms - 2 * Mu + 6);
                lonecl += +0.035 * DegreeMath.sind(Ms - 3 * Mu + 33);
                lonecl += -0.015 * DegreeMath.sind(Mj - Mu + 20);
            }

            if (Planet == MOON)
            {
                double Ls = NormalizeDegree(lonsun);
                double Lm = NormalizeDegree(Moon.N + Moon.w + Moon.M);
                Ms = NormalizeDegree(Sun.M);
                double Mm = NormalizeDegree(Moon.M);
                double D = NormalizeDegree(Lm - Ls);
                double F = NormalizeDegree(Lm - Moon.N);

                lonecl += -1.274 * DegreeMath.sind(Mm - 2 * D);
                lonecl += +0.658 * DegreeMath.sind(2 * D);
                lonecl += -0.186 * DegreeMath.sind(Ms);
                lonecl += -0.059 * DegreeMath.sind(2 * Mm - 2 * D);
                lonecl += -0.057 * DegreeMath.sind(Mm - 2 * D + Ms);
                lonecl += +0.053 * DegreeMath.sind(Mm + 2 * D);
                lonecl += +0.046 * DegreeMath.sind(2 * D - Ms);
                lonecl += +0.041 * DegreeMath.sind(Mm - Ms);
                lonecl += -0.035 * DegreeMath.sind(D);
                lonecl += -0.031 * DegreeMath.sind(Mm + Ms);
                lonecl += -0.015 * DegreeMath.sind(2 * F - 2 * D);
                lonecl += +0.011 * DegreeMath.sind(Mm - 4 * D);

                latecl += -0.173 * DegreeMath.sind(F - 2 * D);
                latecl += -0.055 * DegreeMath.sind(Mm - F - 2 * D);
                latecl += -0.046 * DegreeMath.sind(Mm + F - 2 * D);
                latecl += +0.033 * DegreeMath.sind(F + 2 * D);
                latecl += +0.017 * DegreeMath.sind(2 * Mm + F);

                r += -0.58 * DegreeMath.cosd(Mm - 2 * D);
                r += -0.46 * DegreeMath.cosd(2 * D);

                lonecl = NormalizeDegree(lonecl);
            }

            if (Planet == PLUTO)
            {
                double S = 50.03 + 0.033459652 * d;
                double P = 238.95 + 0.003968789 * d;

                lonecl = 238.9508 + 0.00400703 * d;
                lonecl += -19.799 * DegreeMath.sind(P) + 19.848 * DegreeMath.cosd(P);
                lonecl += +0.897 * DegreeMath.sind(2 * P) - 4.956 * DegreeMath.cosd(2 * P);
                lonecl += +0.610 * DegreeMath.sind(3 * P) + 1.211 * DegreeMath.cosd(3 * P);
                lonecl += -0.341 * DegreeMath.sind(4 * P) - 0.190 * DegreeMath.cosd(4 * P);
                lonecl += +0.128 * DegreeMath.sind(5 * P) - 0.034 * DegreeMath.cosd(5 * P);
                lonecl += -0.038 * DegreeMath.sind(6 * P) + 0.031 * DegreeMath.cosd(6 * P);
                lonecl += +0.020 * DegreeMath.sind(S - P) - 0.010 * DegreeMath.cosd(S - P);

                latecl = -3.9082;
                latecl += -5.453 * DegreeMath.sind(P) - 14.975 * DegreeMath.cosd(P);
                latecl += +3.527 * DegreeMath.sind(2 * P) + 1.673 * DegreeMath.cosd(2 * P);
                latecl += -1.051 * DegreeMath.sind(3 * P) + 0.328 * DegreeMath.cosd(3 * P);
                latecl += +0.179 * DegreeMath.sind(4 * P) - 0.292 * DegreeMath.cosd(4 * P);
                latecl += +0.019 * DegreeMath.sind(5 * P) + 0.100 * DegreeMath.cosd(5 * P);
                latecl += -0.031 * DegreeMath.sind(6 * P) - 0.026 * DegreeMath.cosd(6 * P);
                latecl += +0.011 * DegreeMath.cosd(S - P);

                r = 40.72;
                r += +6.68 * DegreeMath.sind(P) + 6.90 * DegreeMath.cosd(P);
                r += -1.18 * DegreeMath.sind(2 * P) - 0.03 * DegreeMath.cosd(2 * P);
                r += +0.15 * DegreeMath.sind(3 * P) - 0.14 * DegreeMath.cosd(3 * P);

                lonecl += lon_corr;
                lonecl = NormalizeDegree(lonecl);
            }

            // *************************

            xh = r * DegreeMath.cosd(lonecl) * DegreeMath.cosd(latecl);
            yh = r * DegreeMath.sind(lonecl) * DegreeMath.cosd(latecl);
            zh = r * DegreeMath.sind(latecl);

            if (Planet != MOON)
            {
                xs = rs * DegreeMath.cosd(lonsun);
                ys = rs * DegreeMath.sind(lonsun);

                xg = xh + xs;
                yg = yh + ys;
                zg = zh;
            }
            else
            {
                xg = xh;
                yg = yh;
                zg = zh;
            }

            double ecl = 23.4393 - 3.563E-7 * d;

            xe = xg;
            ye = yg * DegreeMath.cosd(ecl) - zg * DegreeMath.sind(ecl);
            ze = yg * DegreeMath.sind(ecl) + zg * DegreeMath.cosd(ecl);

            RA = NormalizeDegree(DegreeMath.atan2d(ye, xe)) / 15;
            Dec = DegreeMath.atan2d(ze, Math.Sqrt(xe * xe + ye * ye));
        }


        public static void SunRaDec(DateTime Dt, out double RA, out double Dec)
        {
            double T = (DateTimeToJulianDate(Dt) - 2451545.0) / 36525;
            double k = 2 * DegreeMath.PI / 360;
            double M = 357.52910 + 35999.05030 * T - 0.0001559 * T * T - 0.00000048 * T * T * T; // mean anomaly, degree
            double L0 = 280.46645 + 36000.76983 * T + 0.0003032 * T * T; // mean longitude, degree
            double DL = (1.914600 - 0.004817 * T - 0.000014 * T * T) * Math.Sin(k * M) + (0.019993 - 0.000101 * T) * Math.Sin(k * 2 * M) + 0.000290 * Math.Sin(k * 3 * M);
            double L = L0 + DL; // true longitude, degree
            L = NormalizeDegree(L);

            //convert ecliptic longitude L to right ascension RA and declination delta
            double eps = 23.4393 - 3.563E-7 * Calculate_d(Dt);
            double X = Math.Cos(L), Y = Math.Cos(eps) * Math.Sin(L), Z = Math.Sin(eps) * Math.Sin(L);
            double R = Math.Sqrt(1.0 - Z * Z);

            double delta = (180 / DegreeMath.PI) * Math.Atan2(Z, R); // in degrees
            RA = (24 / DegreeMath.PI) * Math.Atan2(Y, X + R); // in hours
            Dec = delta;
        }

        public static double GetLonSun(DateTime Dt, out double radii)
        {
            double d = Calculate_d(Dt);
            double M = NormalizeDegree(356.0470 + 0.9856002585 * d);
            double e = 0.016709 - 1.151E-9 * d;
            double E = M + e * DegreeMath.sind(M) * (1.0 + e * DegreeMath.cosd(M));

            double xv = DegreeMath.cosd(E) - e;
            double yv = Math.Sqrt(1.0 - e * e) * DegreeMath.sind(E);

            double v = DegreeMath.atan2d(yv, xv);
            double r = Math.Sqrt(xv * xv + yv * yv);
            double w = 282.9404 + 4.70935E-5 * d;
            double lonsun = v + w;

            double lon_corr = 3.82394E-5 * (365.2422 * (2000 - 2000.0) - d);
            lonsun += lon_corr;

            lonsun = NormalizeDegree(lonsun);
            radii = r;
            return lonsun;
        }

        public static string GetPlanetName(int Planet)
        {
            switch (Planet)
            {
                case SUN:
                    return "Aurinko";
                case MOON:
                    return "Kuu";
                case MERCURY:
                    return "Merkurius";
                case VENUS:
                    return "Venus";
                case MARS:
                    return "Mars";
                case JUPITER:
                    return "Jupiter";
                case SATURN:
                    return "Saturnus";
                case URANUS:
                    return "Uranus";
                case NEPTUNE:
                    return "Neptunus";
                case PLUTO:
                    return "Pluto";
                case EARTH:
                    return "Maa";
                default:
                    return "";
            }
        }

        public void FillOrbElements(DateTime Dt)
        {
            double d = Calculate_d(Dt);
            Sun.N = NormalizeDegree(0.0);
            Sun.i = NormalizeDegree(0.0);
            Sun.w = NormalizeDegree(282.9404 + 4.70935E-5 * d);
            Sun.a = 1.0;
            Sun.e = 0.016709 - 1.151E-9 * d;
            Sun.M = NormalizeDegree(356.0470 + 0.9856002585 * d);

            Moon.N = NormalizeDegree(125.1228 - 0.0529538083 * d);
            Moon.i = NormalizeDegree(5.1454);
            Moon.w = NormalizeDegree(318.0634 + 0.1643573223 * d);
            Moon.a = 60.2666;
            Moon.e = 0.054900;
            Moon.M = NormalizeDegree(115.3654 + 13.0649929509 * d);

            Mercury.N = NormalizeDegree(48.3313 + 3.24587E-5 * d);
            Mercury.i = NormalizeDegree(7.0047 + 5.00E-8 * d);
            Mercury.w = NormalizeDegree(29.1241 + 1.01444E-5 * d);
            Mercury.a = 0.387098;
            Mercury.e = 0.205635 + 5.59E-10 * d;
            Mercury.M = NormalizeDegree(168.6562 + 4.0923344368 * d);

            Venus.N = NormalizeDegree(76.6799 + 2.46590E-5 * d);
            Venus.i = NormalizeDegree(3.3946 + 2.75E-8 * d);
            Venus.w = NormalizeDegree(54.8910 + 1.38374E-5 * d);
            Venus.a = 0.723330;
            Venus.e = 0.006773 - 1.302E-9 * d;
            Venus.M = NormalizeDegree(48.0052 + 1.6021302244 * d);

            Mars.N = NormalizeDegree(49.5574 + 2.11081E-5 * d);
            Mars.i = NormalizeDegree(1.8497 - 1.78E-8 * d);
            Mars.w = NormalizeDegree(286.5016 + 2.92961E-5 * d);
            Mars.a = 1.523688;
            Mars.e = 0.093405 + 2.516E-9 * d;
            Mars.M = NormalizeDegree(18.6021 + 0.5240207766 * d);

            Jupiter.N = NormalizeDegree(100.4542 + 2.76854E-5 * d);
            Jupiter.i = NormalizeDegree(1.3030 - 1.557E-7 * d);
            Jupiter.w = NormalizeDegree(273.8777 + 1.64505E-5 * d);
            Jupiter.a = 5.20256;
            Jupiter.e = 0.048498 + 4.469E-9 * d;
            Jupiter.M = NormalizeDegree(19.8950 + 0.0830853001 * d);

            Saturn.N = NormalizeDegree(113.6634 + 2.38980E-5 * d);
            Saturn.i = NormalizeDegree(2.4886 - 1.081E-7 * d);
            Saturn.w = NormalizeDegree(339.3939 + 2.97661E-5 * d);
            Saturn.a = 9.55475;
            Saturn.e = 0.055546 - 9.499E-9 * d;
            Saturn.M = NormalizeDegree(316.9670 + 0.0334442282 * d);

            Uranus.N = NormalizeDegree(74.0005 + 1.3978E-5 * d);
            Uranus.i = NormalizeDegree(0.7733 + 1.9E-8 * d);
            Uranus.w = NormalizeDegree(96.6612 + 3.0565E-5 * d);
            Uranus.a = 19.18171 - 1.55E-8 * d;
            Uranus.e = 0.047318 + 7.45E-9 * d;
            Uranus.M = NormalizeDegree(142.5905 + 0.011725806 * d);

            Neptune.N = NormalizeDegree(131.7806 + 3.0173E-5 * d);
            Neptune.i = NormalizeDegree(1.7700 - 2.55E-7 * d);
            Neptune.w = NormalizeDegree(272.8461 - 6.027E-6 * d);
            Neptune.a = 30.05826 + 3.313E-8 * d;
            Neptune.e = 0.008606 + 2.15E-9 * d;
            Neptune.M = NormalizeDegree(260.2471 + 0.005995147 * d);
        }


        public void FillStaticOrbElements()
        {
            SunS.Mass = 1.989e30;
            SunS.MeanDencity = 1409;
            SunS.MeanOrbitalVelocity = 220;
            SunS.SiderealTimeLen = 240e8 * EarthSiderealTimeLen;
            SunS.Radius = 6.960e5;
            SunS.RotationTime = -1;
            SunS.Volume = 1.423e27;
            SunS.MeanDistanceFromSun = 0;
            SunS.Acceleration = 274.4;

            MoonS.Mass = 7.348e22;
            MoonS.MeanDencity = 3341;
            MoonS.MeanOrbitalVelocity = 1.023;
            MoonS.SiderealTimeLen = 27.3217;
            MoonS.Radius = 1738.2;
            MoonS.RotationTime = -1;
            MoonS.Volume = 2.2e19;
            MoonS.MeanDistanceFromSun = 1.59787e9;
            MoonS.Acceleration = 1.622;

            MercuryS.Mass = 0.0553 * 5.974e24;
            MercuryS.MeanDencity = 5400;
            MercuryS.MeanOrbitalVelocity = 47.89;
            MercuryS.SiderealTimeLen = 0.2408 * EarthSiderealTimeLen;
            MercuryS.Radius = 2439;
            MercuryS.RotationTime = 58.6 * 24;
            MercuryS.Volume = 0.056 * 1.083e21;
            MercuryS.MeanDistanceFromSun = 57.9e6;
            MercuryS.Acceleration = 3.63;

            VenusS.Mass = 0.816 * 5.974e24;
            VenusS.MeanDencity = 5200;
            VenusS.MeanOrbitalVelocity = 35.03;
            VenusS.SiderealTimeLen = 0.6152 * EarthSiderealTimeLen;
            VenusS.Radius = 6052;
            VenusS.RotationTime = 243 * 24;
            VenusS.Volume = 0.853 * 1.083e21;
            VenusS.MeanDistanceFromSun = 108.2e6;
            VenusS.Acceleration = 8.60;

            MarsS.Mass = 0.1075 * 5.974e24;
            MarsS.MeanDencity = 3950;
            MarsS.MeanOrbitalVelocity = 24.13;
            MarsS.SiderealTimeLen = 1.8809 * EarthSiderealTimeLen;
            MarsS.Radius = 3397;
            MarsS.RotationTime = 24.6231;
            MarsS.Volume = 0.151 * 1.083e21;
            MarsS.MeanDistanceFromSun = 227.9e6;
            MarsS.Acceleration = 3.74;

            JupiterS.Mass = 317.83 * 5.974e24;
            JupiterS.MeanDencity = 1340;
            JupiterS.MeanOrbitalVelocity = 13.06;
            JupiterS.SiderealTimeLen = 11.863 * EarthSiderealTimeLen;
            JupiterS.Radius = 71398;
            JupiterS.RotationTime = 9.9250;
            JupiterS.Volume = 1403 * 1.083e21;
            JupiterS.MeanDistanceFromSun = 778.4e6;
            JupiterS.Acceleration = 25.9;

            SaturnS.Mass = 95.15 * 5.974e24;
            SaturnS.MeanDencity = 700;
            SaturnS.MeanOrbitalVelocity = 9.64;
            SaturnS.SiderealTimeLen = 29.41 * EarthSiderealTimeLen;
            SaturnS.Radius = 60100;
            SaturnS.RotationTime = 10.5;
            SaturnS.Volume = 830 * 1.083e21;
            SaturnS.MeanDistanceFromSun = 1425.6e6;
            SaturnS.Acceleration = 11.3;

            UranusS.Mass = 14.54 * 5.974e24;
            UranusS.MeanDencity = 1100;
            UranusS.MeanOrbitalVelocity = 6.81;
            UranusS.SiderealTimeLen = 88.04 * EarthSiderealTimeLen;
            UranusS.Radius = 26320;
            UranusS.RotationTime = 17.23;
            UranusS.Volume = 70 * 1.083e21;
            UranusS.MeanDistanceFromSun = 2870e6;
            UranusS.Acceleration = 10.4;

            NeptuneS.Mass = 17.23 * 5.974e24;
            NeptuneS.MeanDencity = 1700;
            NeptuneS.MeanOrbitalVelocity = 5.43;
            NeptuneS.SiderealTimeLen = 165.0 * EarthSiderealTimeLen;
            NeptuneS.Radius = 24300;
            NeptuneS.RotationTime = 18;
            NeptuneS.Volume = 55 * 1.083e21;
            NeptuneS.MeanDistanceFromSun = 4501e6;
            NeptuneS.Acceleration = 14.0;

            PlutoS.Mass = 0.002 * 5.974e24;
            PlutoS.MeanDencity = 2100;
            PlutoS.MeanOrbitalVelocity = 4.74;
            PlutoS.SiderealTimeLen = 246.8 * EarthSiderealTimeLen;
            PlutoS.Radius = 1150;
            PlutoS.RotationTime = 6.387 * 24;
            PlutoS.Volume = 0.006 * 1.083e21;
            PlutoS.MeanDistanceFromSun = 5885e6;
            PlutoS.Acceleration = -2;

            EarthS.Mass = 5.974e24;
            EarthS.MeanDencity = 5517;
            EarthS.MeanOrbitalVelocity = 29.78;
            EarthS.SiderealTimeLen = EarthSiderealTimeLen;
            EarthS.Radius = 6378.140;
            EarthS.RotationTime = 23.93447222222222222222222222222222;
            EarthS.Volume = 1.083e21;
            EarthS.MeanDistanceFromSun = 149.59787e6;
            EarthS.Acceleration = 9.80665;
        }

        public static double Calculate_d(DateTime Dt)
        {
            Dt = Dt.ToUniversalTime();
            int y = Dt.Year;
            int m = Dt.Month;
            int D = Dt.Day;
            double d = 367 * y - 7 * (y + (m + 9) / 12) / 4 + 275 * m / 9 + D - 730530;
            d += Dt.ToDecimalHourFraction(); // this was missing before..
            return d;
        }

        public static double DateTimeToJulianDate(DateTime Dt)
        {
            double d = 367 * Dt.Year - (7 * (Dt.Year + ((Dt.Month + 9) / 12))) / 4 + (275 * Dt.Month) / 9 + Dt.Day - 730530;
            d += 2451543.5;
            double HH = Dt.Hour;
            double MM = Dt.Minute;
            double SS = Dt.Second;
            double MS = Dt.Millisecond;
            double FracDay = HH / 24 + MM / (24 * 60) + SS / (24 * 60 * 60) + MS / (24 * 60 * 60 * 1000);
            return d + FracDay;
        }

        public static DateTime JulianDateToDateTime(double julianDate)
        {
            double secondValue = (julianDate - 2451543.5) * 86400;

            DateTime dtDateTime = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(secondValue);

            return dtDateTime;
        }

        public static double SiderealTime(DateTime Dt, double Longitude, bool utc = true)
        {
            return SMap.SiderealTime.LMST(Dt, Longitude); 
        }
   
        public static void RotateX(double Angle, ref double x, ref double y, ref double z)
        {
            double xp, yp, zp;
            zp = z * DegreeMath.cosd(Angle) - x * DegreeMath.sind(Angle);
            xp = z * DegreeMath.sind(Angle) + x * DegreeMath.cosd(Angle);
            yp = y;
            x = xp; y = yp; z = zp;
        }

        public static void RotateY(double Angle, ref double x, ref double y, ref double z)
        {
            double xp, yp, zp;
            yp = y * DegreeMath.cosd(Angle) - z * DegreeMath.sind(Angle);
            zp = y * DegreeMath.sind(Angle) + z * DegreeMath.cosd(Angle);
            xp = x;
            x = xp; y = yp; z = zp;
        }

        public static void RotateZ(double Angle, ref double x, ref double y, ref double z)
        {
            double xp, yp, zp;
            xp = x * DegreeMath.cosd(Angle) - y * DegreeMath.sind(Angle);
            yp = x * DegreeMath.sind(Angle) + y * DegreeMath.cosd(Angle);
            zp = z;
            x = xp; y = yp; z = zp;
        }


        public static double NormalizeDegree(double Degree)
        {
            if (Degree < 0)
            {
                while (Degree < 0)
                {
                    Degree += 360.0;
                }
            }
            else
            {
                while (Degree > 360)
                {
                    Degree -= 360.0;
                }
            }
            return Degree;
        }


        public static bool WithInCircle(double CenterX, double CenterY, double Radius, double X, double Y)
        {
            double a = Math.Sqrt((X - CenterX) * (X - CenterX) + (Y - CenterY) * (Y - CenterY));
            if (a > Radius)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }


    public class YaleSmallHolder
    {
        public YaleSmallBinary[] YaleSmall;
        public YaleSmallHolder(string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open);
            BinaryReader r = new BinaryReader(fs);
            int nOfStructs = r.ReadInt32();
            Console.WriteLine("Yale Small-tietoja: {0}", nOfStructs);
            YaleSmall = new YaleSmallBinary[nOfStructs];
            for (int i = 0; i < nOfStructs; i++)
            {
                YaleSmall[i].RA = r.ReadDouble();
                YaleSmall[i].Dec = r.ReadDouble();
                YaleSmall[i].Mag = r.ReadDouble();
            }
            r.Close();
        }
        public YaleSmallBinary GetStar(int Index)
        {
            return YaleSmall[Index];
        }

        public StarData GetStarData(int Index)
        {
            StarData Data = new StarData();
            Data.Declination = YaleSmall[Index].Dec;
            Data.RightAscencion = YaleSmall[Index].RA;
            Data.Magnitude = YaleSmall[Index].Mag;
            return Data;
        }
    }


    public class HYGHolder
    {
        public HYGBinary[] HYG;
        public HYGHolder(string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open);
            BinaryReader r = new BinaryReader(fs);
            int nOfStructs = r.ReadInt32();
            Console.WriteLine("HYG-tietoja: {0}", nOfStructs);
            HYG = new HYGBinary[nOfStructs];
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            for (int i = 0; i < nOfStructs; i++)
            {
                HYG[i].StarID = r.ReadInt32();
                HYG[i].Hip = r.ReadInt32();
                HYG[i].HD = r.ReadInt32();
                HYG[i].HR = r.ReadInt32();
                HYG[i].Gliese = NULLTStrings.NULLTToString(r.ReadBytes(10));
                HYG[i].BayerFlamsteedName = NULLTStrings.NULLTToString(r.ReadBytes(11));
                HYG[i].ProperName = NULLTStrings.NULLTToString(r.ReadBytes(20));
                HYG[i].Spectrum = NULLTStrings.NULLTToString(r.ReadBytes(15));
                HYG[i].RA = r.ReadDouble();
                HYG[i].Dec = r.ReadDouble();
                HYG[i].Distance = r.ReadDouble();
                HYG[i].Mag = r.ReadDouble();
                HYG[i].AbsMag = r.ReadDouble();
                HYG[i].ColorIndex = r.ReadDouble();
            }
            r.Close();
        }
        public HYGBinary GetStar(int Index)
        {
            return HYG[Index];
        }

        public StarData GetStarData(int Index)
        {
            StarData Data = new StarData();
            Data.Declination = HYG[Index].Dec;
            Data.RightAscencion = HYG[Index].RA;
            Data.Magnitude = HYG[Index].Mag;
            return Data;
        }
    }


    public class YaleHolder
    {
        public YaleBinary[] Yale;
        public YaleHolder(string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open);
            BinaryReader r = new BinaryReader(fs);
            int nOfStructs = r.ReadInt32();
            Console.WriteLine("Yale-tietoja: {0}", nOfStructs);
            Yale = new YaleBinary[nOfStructs];
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            for (int i = 0; i < nOfStructs; i++)
            {
                Yale[i].Name = NULLTStrings.NULLTToString(r.ReadBytes(11)); //11
                Yale[i].DM = NULLTStrings.NULLTToString(r.ReadBytes(12)); //12
                Yale[i].ADS = NULLTStrings.NULLTToString(r.ReadBytes(6)); //6
                Yale[i].ADScomp = NULLTStrings.NULLTToString(r.ReadBytes(3)); //3
                Yale[i].VarID = NULLTStrings.NULLTToString(r.ReadBytes(10)); //10
                Yale[i].SpType = NULLTStrings.NULLTToString(r.ReadBytes(21)); // 21
                Yale[i].n_RadVel = NULLTStrings.NULLTToString(r.ReadBytes(5)); // 5
                Yale[i].l_RotVel = NULLTStrings.NULLTToString(r.ReadBytes(3)); // 3
                Yale[i].MultID = NULLTStrings.NULLTToString(r.ReadBytes(5)); // 5

                Yale[i].IRflag = r.ReadSByte();
                Yale[i].r_IRflag = r.ReadSByte();
                Yale[i].Multiple = r.ReadSByte();
                Yale[i].DE_1900 = r.ReadSByte();
                Yale[i].DE_ = r.ReadSByte();
                Yale[i].n_Vmag = r.ReadSByte();
                Yale[i].u_Vmag = r.ReadSByte();
                Yale[i].u_B_V = r.ReadSByte();
                Yale[i].u_U_B = r.ReadSByte();
                Yale[i].n_R_I = r.ReadSByte();
                Yale[i].n_SpType = r.ReadSByte();
                Yale[i].n_Parallax = r.ReadSByte();
                Yale[i].u_RotVel = r.ReadSByte();
                Yale[i].NoteFlag = r.ReadSByte();

                Yale[i].HR = r.ReadInt32();
                Yale[i].HD = r.ReadInt32();
                Yale[i].SAO = r.ReadInt32();
                Yale[i].FK5 = r.ReadInt32();
                Yale[i].RAh1900 = r.ReadInt32();
                Yale[i].RAm1900 = r.ReadInt32();
                Yale[i].DEd1900 = r.ReadInt32();
                Yale[i].DEm1900 = r.ReadInt32();
                Yale[i].DEs1900 = r.ReadInt32();
                Yale[i].RAh = r.ReadInt32();
                Yale[i].RAm = r.ReadInt32();
                Yale[i].DEd = r.ReadInt32();
                Yale[i].DEm = r.ReadInt32();
                Yale[i].DEs = r.ReadInt32();
                Yale[i].RadVel = r.ReadInt32();
                Yale[i].RotVel = r.ReadInt32();
                Yale[i].MultCnt = r.ReadInt32();

                Yale[i].RAs1900 = r.ReadDouble();
                Yale[i].RAs = r.ReadDouble();
                Yale[i].GLON = r.ReadDouble();
                Yale[i].GLAT = r.ReadDouble();
                Yale[i].Vmag = r.ReadDouble();
                Yale[i].B_V = r.ReadDouble();
                Yale[i].U_B = r.ReadDouble();
                Yale[i].R_I = r.ReadDouble();
                Yale[i].pmRA = r.ReadDouble();
                Yale[i].pmDE = r.ReadDouble();
                Yale[i].Parallax = r.ReadDouble();
                Yale[i].Dmag = r.ReadDouble();
                Yale[i].Sep = r.ReadDouble();
            }
            r.Close();
        }
        public YaleBinary GetStar(int Index)
        {
            return Yale[Index];
        }

        public StarData GetStarData(int Index)
        {
            StarData Data = new StarData();
            Data.RightAscencion = StarDataHolder.HMSRaToRa(Yale[Index].RAh, Yale[Index].RAm, Yale[Index].RAs);
            Data.Declination = StarDataHolder.DMSDecToDec(Yale[Index].DEd, Yale[Index].DEm, Yale[Index].DEs, Yale[Index].DE_);
            Data.Magnitude = Yale[Index].Vmag;
            return Data;
        }

    }

    public class GlieseHolder
    {
        public GlieseBinary[] Gliese;
        public GlieseHolder(string FileName)
        {
            FileStream fs = new FileStream(FileName, FileMode.Open);
            BinaryReader r = new BinaryReader(fs);
            int nOfStructs = r.ReadInt32();
            Console.WriteLine("Gliese-tietoja: {0}", nOfStructs);
            Gliese = new GlieseBinary[nOfStructs];
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            for (int i = 0; i < nOfStructs; i++)
            {
                Gliese[i].Ident = NULLTStrings.NULLTToString(r.ReadBytes(9)); // 9
                Gliese[i].Comp = NULLTStrings.NULLTToString(r.ReadBytes(3)); // 3
                Gliese[i].n_RV = NULLTStrings.NULLTToString(r.ReadBytes(4)); // 4
                Gliese[i].Sp = NULLTStrings.NULLTToString(r.ReadBytes(13)); // 13
                Gliese[i].n_Mv = NULLTStrings.NULLTToString(r.ReadBytes(3)); // 3
                Gliese[i].DM = NULLTStrings.NULLTToString(r.ReadBytes(13)); // 13
                Gliese[i].Giclas = NULLTStrings.NULLTToString(r.ReadBytes(10)); // 10
                Gliese[i].LHS = NULLTStrings.NULLTToString(r.ReadBytes(6)); // 6
                Gliese[i].Other = NULLTStrings.NULLTToString(r.ReadBytes(6)); // 6
                Gliese[i].Remarks = NULLTStrings.NULLTToString(r.ReadBytes(70)); // 70

                Gliese[i].DistRel = r.ReadSByte();
                Gliese[i].DE_ = r.ReadSByte();
                Gliese[i].u_pm = r.ReadSByte();
                Gliese[i].r_Sp = r.ReadSByte();
                Gliese[i].n_V = r.ReadSByte();
                Gliese[i].Joint_V = r.ReadSByte();
                Gliese[i].n_B_V = r.ReadSByte();
                Gliese[i].Joint_B_V = r.ReadSByte();
                Gliese[i].n_U_B = r.ReadSByte();
                Gliese[i].Joint_U_B = r.ReadSByte();
                Gliese[i].n_R_I = r.ReadSByte();
                Gliese[i].Joint_R_I = r.ReadSByte();
                Gliese[i].n_plx = r.ReadSByte();
                Gliese[i].q_Mv = r.ReadSByte();

                Gliese[i].RAh = r.ReadInt32();
                Gliese[i].RAm = r.ReadInt32();
                Gliese[i].RAs = r.ReadInt32();
                Gliese[i].DEd = r.ReadInt32();
                Gliese[i].U = r.ReadInt32();
                Gliese[i].V = r.ReadInt32();
                Gliese[i].W = r.ReadInt32();
                Gliese[i].HD = r.ReadInt32();

                Gliese[i].DEm = r.ReadDouble();
                Gliese[i].pm = r.ReadDouble();
                Gliese[i].pmPA = r.ReadDouble();
                Gliese[i].RV = r.ReadDouble();
                Gliese[i].B_V = r.ReadDouble();
                Gliese[i].U_B = r.ReadDouble();
                Gliese[i].R_I = r.ReadDouble();
                Gliese[i].trplx = r.ReadDouble();
                Gliese[i].e_trplx = r.ReadDouble();
                Gliese[i].plx = r.ReadDouble();
                Gliese[i].e_plx = r.ReadDouble();
                Gliese[i].Mv = r.ReadDouble();
                Gliese[i].Vmag = r.ReadDouble();
            }
            r.Close();
        }
        public GlieseBinary GetStar(int Index)
        {
            return Gliese[Index];
        }

        public StarData GetStarData(int Index)
        {
            StarData Data = new StarData();
            Data.RightAscencion = StarDataHolder.HMSRaToRa(Gliese[Index].RAh, Gliese[Index].RAm, (double)Gliese[Index].RAs);
            Data.Declination = StarDataHolder.DMDecToDec(Gliese[Index].DEd, Gliese[Index].DEm, Gliese[Index].DE_);
            Data.Magnitude = Gliese[Index].Mv;
            StarDataHolder.B1950ToJ2000(ref Data.RightAscencion, ref Data.Declination);
            return Data;
        }

    }


    public class StarDataHolder
    {
        private string OpDir;
        public StarDataHolder(string OperatingDirectory)
        {
            OpDir = OperatingDirectory;
            InitCNames();
            InitCCoords();
            LoadYaleSmall();
            InitUserObjecs();
        }

        public StarData[] Data = null;
        public int StarDataCount = 0;

        public ConsNamesBinary[] CNames = null;
        public int ConsNamesCount = 0;

        public ConsCoordBinary[] CCoords = null;
        public int ConsCoordCount = 0;

        public UserObject[] UObj = null;
        public int UObjCount = 0;

        public void InitCNames()
        {
            string FileName = OpDir + @"/Data/StarData/cnames_bin.dat";
            FileStream fs = new FileStream(FileName, FileMode.Open);
            BinaryReader r = new BinaryReader(fs);
            int nOfStructs = r.ReadInt32();
            ConsNamesCount = nOfStructs;
            CNames = new ConsNamesBinary[nOfStructs];
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            for (int i = 0; i < nOfStructs; i++)
            {
                CNames[i].ShortName = NULLTStrings.NULLTToString(r.ReadBytes(4)); // 4
                CNames[i].LongName = NULLTStrings.NULLTToString(r.ReadBytes(20)); // 20
                CNames[i].FinName = NULLTStrings.NULLTToString(r.ReadBytes(20)); // 20
                CNames[i].RA = r.ReadDouble();
                CNames[i].Dec = r.ReadDouble();
            }
            r.Close();
        }

        public void CreateDefaultUserObjects()
        {
            string FileName = OpDir + @"/Data/StarData/UserObjects.txt";
            StreamWriter sw = new StreamWriter(FileName, false, System.Text.Encoding.UTF8);
            sw.WriteLine(";File for user defined objects");
            sw.WriteLine("");
            sw.WriteLine(";#\"ObjectName\", Vmag, ra, dec, Distance, DrawType|Param, ColorR, ColorB, ColorG, ShowName, \"Note\"");
            sw.WriteLine("");
            sw.WriteLine(";DrawTypes:");
            sw.WriteLine(";C  = Circle				| Diameter");
            sw.WriteLine(";CF = Filled Circle		| Diameter");
            sw.WriteLine(";R  = Rectangle			| Width & Height");
            sw.WriteLine(";RF = Filled Rectangle	| Width & Height");
            sw.WriteLine(";D  = Dot					| no parameters are accepted");
            sw.WriteLine("");
            sw.WriteLine(";Example: M31 Galaxy, circle with diameter of 4, white.");
            sw.WriteLine(";Diameter can be a decimal value.");
            sw.WriteLine("");
            sw.WriteLine("#\"M31\", 3.4, 0.711666666666667, 41.2666666666667, 0, C|4, 255, 255, 255, true, \"M31 galaxy\"");
            sw.Close();
        }

        public static void DrawUserObject(float X, float Y, UserObject UsObject, Color TextColor, ref Graphics Gr)
        {
            string DType = UsObject.DrawType.Substring(0, UsObject.DrawType.IndexOf("|"));
            string TempStr = UsObject.DrawType.Substring(DType.Length + 1, UsObject.DrawType.Length - DType.Length - 1);
            float DParam = 0;
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            if (TempStr != string.Empty)
            {
                DParam = Convert.ToSingle(TempStr, nfi);
                X -= DParam / 2;
                Y -= DParam / 2;
            }

            switch (DType)
            {
                case "C":
                    Gr.DrawEllipse(new Pen(UsObject.DrawCol, 1), X, Y, DParam, DParam);
                    break;
                case "CF":
                    Gr.FillEllipse(new SolidBrush(UsObject.DrawCol), X, Y, DParam, DParam);
                    break;
                case "R":
                    Gr.DrawRectangle(new Pen(UsObject.DrawCol, 1), X, Y, DParam, DParam);
                    break;
                case "RF":
                    Gr.FillRectangle(new SolidBrush(UsObject.DrawCol), X, Y, DParam, DParam);
                    break;
                case "D":
                    Gr.DrawRectangle(new Pen(UsObject.DrawCol, 1), X, Y, 1, 1);
                    break;
            }
            if (UsObject.ShowName)
            {
                Gr.DrawString(UsObject.Name, new Font("Arial", 8), new SolidBrush(TextColor), X + DParam + 5, Y);
            }
        }

        public void InitUserObjecs()
        {
            string FileName = OpDir + @"/Data/StarData/UserObjects.txt";
            if (!File.Exists(FileName))
            {
                CreateDefaultUserObjects();
            }
            StreamReader sr = new StreamReader(FileName, System.Text.Encoding.UTF8);
            string CsLine;
            while ((CsLine = sr.ReadLine()) != null)
            {
                if (CsLine == String.Empty)
                {
                    continue;
                }
                else if (CsLine.StartsWith("#"))
                {
                    try
                    {
                        UserObject UsObject = new UserObject();
                        NumberFormatInfo nfi = new NumberFormatInfo();
                        nfi.NumberDecimalSeparator = ".";
                        int ColR, ColG, ColB;

                        string TempStr = CsLine.Substring(2, CsLine.IndexOf("\", ") - 2);
                        UsObject.Name = TempStr;

                        CsLine = CsLine.Remove(0, CsLine.IndexOf("\", ") + 3);
                        TempStr = CsLine.Substring(0, CsLine.IndexOf(", "));
                        UsObject.Vmag = Convert.ToDouble(TempStr, nfi);

                        CsLine = CsLine.Remove(0, CsLine.IndexOf(", ") + 2);
                        TempStr = CsLine.Substring(0, CsLine.IndexOf(", "));
                        UsObject.RA = Convert.ToDouble(TempStr, nfi);

                        CsLine = CsLine.Remove(0, CsLine.IndexOf(", ") + 2);
                        TempStr = CsLine.Substring(0, CsLine.IndexOf(", "));
                        UsObject.Dec = Convert.ToDouble(TempStr, nfi);

                        CsLine = CsLine.Remove(0, CsLine.IndexOf(", ") + 2);
                        TempStr = CsLine.Substring(0, CsLine.IndexOf(", "));
                        UsObject.DistPC = Convert.ToDouble(TempStr, nfi);

                        CsLine = CsLine.Remove(0, CsLine.IndexOf(", ") + 2);
                        TempStr = CsLine.Substring(0, CsLine.IndexOf(", "));
                        UsObject.DrawType = TempStr;

                        CsLine = CsLine.Remove(0, CsLine.IndexOf(", ") + 2);
                        TempStr = CsLine.Substring(0, CsLine.IndexOf(", "));
                        ColR = Convert.ToInt32(TempStr);

                        CsLine = CsLine.Remove(0, CsLine.IndexOf(", ") + 2);
                        TempStr = CsLine.Substring(0, CsLine.IndexOf(", "));
                        ColG = Convert.ToInt32(TempStr);

                        CsLine = CsLine.Remove(0, CsLine.IndexOf(", ") + 2);
                        TempStr = CsLine.Substring(0, CsLine.IndexOf(", "));
                        ColB = Convert.ToInt32(TempStr);

                        UsObject.DrawCol = Color.FromArgb(ColR, ColG, ColB);

                        CsLine = CsLine.Remove(0, CsLine.IndexOf(", ") + 2);
                        TempStr = CsLine.Substring(0, CsLine.IndexOf(", "));
                        UsObject.ShowName = Convert.ToBoolean(TempStr);

                        CsLine = CsLine.Remove(0, CsLine.IndexOf(", \"") + 3);
                        TempStr = CsLine.Substring(0, CsLine.IndexOf("\""));
                        UsObject.Note = TempStr;

                        Bitmap TempBm = new Bitmap(10, 10);
                        Graphics Gr = Graphics.FromImage(TempBm);
                        DrawUserObject(0, 0, UsObject, Color.White, ref Gr);

                        if (UObj == null)
                        {
                            UObj = new UserObject[] { UsObject };
                            UObjCount = 1;
                        }
                        else
                        {
                            UserObject[] TempObjects = new UserObject[UObj.Length + 1];
                            UObj.CopyTo(TempObjects, 0);
                            TempObjects[TempObjects.Length - 1] = UsObject;

                            UObj = TempObjects;
                            UObjCount = UObj.Length;
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show("Virhe ladattaessa käyttäjän objektia (" + e.Message + ").", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    continue;
                }
            }

        }


        public void InitCCoords()
        {
            string FileName = OpDir + @"/Data/StarData/conlines_bin.dat";
            FileStream fs = new FileStream(FileName, FileMode.Open);
            BinaryReader r = new BinaryReader(fs);
            int nOfStructs = r.ReadInt32();
            ConsCoordCount = nOfStructs;
            CCoords = new ConsCoordBinary[nOfStructs];
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            for (int i = 0; i < nOfStructs; i++)
            {
                CCoords[i].ConsName = NULLTStrings.NULLTToString(r.ReadBytes(4)); // 4
                CCoords[i].BayerFlamsteed1 = NULLTStrings.NULLTToString(r.ReadBytes(11)); // 11
                CCoords[i].ProperName1 = NULLTStrings.NULLTToString(r.ReadBytes(11)); // 11
                CCoords[i].BayerFlamsteed2 = NULLTStrings.NULLTToString(r.ReadBytes(18)); // 18
                CCoords[i].ProperName2 = NULLTStrings.NULLTToString(r.ReadBytes(18)); // 18

                CCoords[i].RA1 = r.ReadDouble();
                CCoords[i].Dec1 = r.ReadDouble();
                CCoords[i].RA2 = r.ReadDouble();
                CCoords[i].Dec2 = r.ReadDouble();
                CCoords[i].R1 = r.ReadDouble();
                CCoords[i].R2 = r.ReadDouble();
            }
            r.Close();
        }

        public void LoadHyg()
        {
            HYGHolder Hyg = new HYGHolder(OpDir + @"/Data/StarData/hyg_bin.dat");
            StarDataCount = Hyg.HYG.Length;
            Data = new StarData[StarDataCount];
            for (int i = 0; i < StarDataCount; i++)
            {
                Data[i] = Hyg.GetStarData(i);
            }
        }

        public void LoadYaleSmall()
        {
            YaleSmallHolder YaleSmall = new YaleSmallHolder(OpDir + @"/Data/StarData/yalesmall_bin.dat");
            StarDataCount = YaleSmall.YaleSmall.Length;
            Data = new StarData[StarDataCount];
            for (int i = 0; i < StarDataCount; i++)
            {
                Data[i] = YaleSmall.GetStarData(i);
            }
        }

        public void LoadYale()
        {
            YaleHolder Yale = new YaleHolder(OpDir + @"/Data/StarData/yale_bin.dat");
            StarDataCount = Yale.Yale.Length;
            Data = new StarData[StarDataCount];
            for (int i = 0; i < StarDataCount; i++)
            {
                Data[i] = Yale.GetStarData(i);
            }
        }

        public void LoadGliese()
        {
            GlieseHolder Gliese = new GlieseHolder(OpDir + @"/Data/StarData/gliese3_bin.dat");
            StarDataCount = Gliese.Gliese.Length;
            Data = new StarData[StarDataCount];
            for (int i = 0; i < StarDataCount; i++)
            {
                Data[i] = Gliese.GetStarData(i);
            }
        }

        public static double HMSRaToRa(int h, int m, double s)
        {
            double RetVal = (double)h;
            RetVal += (double)m / 60.0;
            RetVal += s / 3600.0;
            return RetVal;
        }

        public static double DMSDecToDec(int d, int m, int s)
        {
            return DMSDecToDec(d, m, s, (sbyte)'+');
        }

        public static double DMDecToDec(int d, double m, sbyte sign)
        {
            double RetVal = (double)d;
            RetVal += m / 60.0;
            if (sign == '-') RetVal *= -1;
            return RetVal;
        }

        public static double DMDecToDec(int d, double m, string sign)
        {
            double RetVal = (double)d;
            RetVal += m / 60.0;
            if (sign == "-") RetVal *= -1;
            return RetVal;
        }

        public static double DMSDecToDec(int d, int m, int s, string sign)
        {
            double RetVal = (double)d;
            RetVal += (double)m / 60.0;
            RetVal += (double)s / 3600.0;
            if (sign == "-") RetVal *= -1;
            return RetVal;
        }

        public static double DMSDecToDec(int d, int m, int s, sbyte sign)
        {
            double RetVal = (double)d;
            RetVal += (double)m / 60.0;
            RetVal += (double)s / 3600.0;
            if (sign == '-') RetVal *= -1;
            return RetVal;
        }

        public static void RADecToXYZ(double RA, double Dec, out double X, out double Y, out double Z)
        {
            X = DegreeMath.cosd(RA) * DegreeMath.cosd(Dec);
            Y = DegreeMath.sind(RA) * DegreeMath.cosd(Dec);
            Z = DegreeMath.sind(Dec);
        }

        public static void RADecRToXYZ(double RA, double Dec, double Radius, out double X, out double Y, out double Z)
        {
            X = DegreeMath.cosd(RA) * DegreeMath.cosd(Dec) * Radius;
            Y = DegreeMath.sind(RA) * DegreeMath.cosd(Dec) * Radius;
            Z = DegreeMath.sind(Dec) * Radius;
        }

        public static void B1950ToJ2000(ref double RA, ref double Dec)
        {
            //   Corrected precession coefficients.
            //  form direction cosines (i.e. rectangular coordinates assuming
            //  radius vector of 1 unit)
            double x = DegreeMath.cosd(RA) * DegreeMath.cosd(Dec);
            double y = DegreeMath.sind(RA) * DegreeMath.cosd(Dec);
            double z = DegreeMath.sind(Dec);
            //   apply the precession matrix
            double x2 = .999925708 * x - .0111789372 * y - .0048590035 * z;
            double y2 = .0111789372 * x + .9999375134 * y - .0000271626 * z;
            double z2 = .0048590036 * x - .0000271579 * y + .9999881946 * z;
            //   convert the new direction cosines to RA, DEC
            double ra2 = DegreeMath.atan2d(y2, x2);
            double dec2 = DegreeMath.asind(z2);
            RA = ra2;
            Dec = dec2;
        }

        public void Get(int Index, out double Ra, out double Dec, out double Mag)
        {
            Ra = Data[Index].RightAscencion;
            Dec = Data[Index].Declination;
            Mag = Data[Index].Magnitude;
        }
    }



}
