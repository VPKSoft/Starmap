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
using Plotter;
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
    /// Description of PlaneettaTiedot.
    /// </summary>
    public partial class PlanetInfo : DBLangEngineWinforms
    {

        public Plot PC;

        string YearsText = string.Empty;

        public PlanetInfo()
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
            string OpDir = MainForm.OpDir;
            PC = new Plot(OpDir, true);
            InitLanguage();
        }


        public void FormatDataOut(string Text, ref Label L)
        {
            if (Text == "-1") Text = "-";
            if (Text == "-2") Text = "?";
            L.Text = Text;
        }

        public void SetPlanetData()
        {
            if (cmbBody.SelectedIndex < 0 || cmbBody.SelectedIndex > 11)
            {
                return;
            }

            StaticOrbElementInfo SOEI = new StaticOrbElementInfo();
            PC.GetPlanetDataStatic(cmbBody.SelectedIndex + 1, out SOEI);

            lbSiderealTimeYearsValue.Text = String.Format("= {0:F2} {1}.", SOEI.SiderealTimeLen / 365.0, YearsText);

            FormatDataOut(SOEI.Mass.ToString(), ref lbMassKgValue);
            FormatDataOut(SOEI.MeanDencity.ToString(), ref lbMeanDensityKgM3Value);
            FormatDataOut(SOEI.MeanOrbitalVelocity.ToString(), ref lbOrbitalVelKmSecValue);
            FormatDataOut(SOEI.SiderealTimeLen.ToString(), ref lbSiderealTimeDaysValue);


            FormatDataOut(SOEI.Radius.ToString(), ref lbRadiusKmValue);
            FormatDataOut(SOEI.RotationTime.ToString(), ref lbRotationPeriodHoursValue);
            FormatDataOut(SOEI.Volume.ToString(), ref lbVolumeM3Value);
            FormatDataOut(SOEI.MeanDistanceFromSun.ToString(), ref lbMeanDistSunKmValue);
            FormatDataOut(SOEI.Acceleration.ToString(), ref lbSurfaceGravityMS2Value);
            CountDistances(cmbBody.SelectedIndex + 1);
        }


        void ComboBox1SelectedIndexChanged(object sender, System.EventArgs e)
        {
            SetPlanetData();
        }

        void Button1Click(object sender, System.EventArgs e)
        {
            SetPlanetData();
        }

        public static void Execute(int Planet)
        {
            PlanetInfo Pt = new PlanetInfo();
            Pt.cmbBody.SelectedIndex = Planet - 1;
            Pt.ShowDialog();
        }

        void InitLanguage()
        {
            YearsText = DBLangEngine.GetMessage("msgYearsAmount", "years|amount of years");

            cmbBody.Items.Clear();
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNameSun2", "Sun|The name of the Sun"));
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNameMoon2", "Moon|The name of the Moon"));
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNameMercury", "Mercury|The name of Mercury"));
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNameVenus", "Venus|The name of Venus"));
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNameMars", "Mars|The name of Mars"));
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNameJupiter", "Jupiter|The name of Jupiter"));
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNameSaturn", "Saturn|The name of Saturn"));
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNameUranus", "Uranus|The name of Uranus"));
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNameNeptune", "Neptune|The name of Neptune"));
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNamePluto", "Pluto|The name of Pluto"));
            cmbBody.Items.Add(DBLangEngine.GetMessage("msgNameEarth", "Earth|The name of the Earth"));
            cmbBody.SelectedIndex = 0;
        }


        public void CountDistances(int Planet)
        {
            double[] Px = new double[11];
            double[] Py = new double[11];
            double[] Pz = new double[11];

            DateTime Dt = Plot.NoDayLight(DateTime.Now);

            PC.FillOrbElements(Dt);

            OrbElementExt OeE = new OrbElementExt();

            for (int i = Plot.SUN; i <= Plot.EARTH; i++)
            {
                if (i == Plot.EARTH)
                {
                    PC.GetSunData(Dt, ref OeE);
                }
                else
                {
                    PC.GetPlanetData(i, Dt, ref OeE);
                }
                Px[i - 1] = OeE.x;
                Py[i - 1] = OeE.y;
                Pz[i - 1] = OeE.z;
            }

            Px[Plot.EARTH - 1] *= -1;
            Py[Plot.EARTH - 1] *= -1;
            Pz[Plot.EARTH - 1] *= -1;

            Px[Plot.MOON - 1] *= 6378.140 / (Plot.AU * 1e6);
            Py[Plot.MOON - 1] *= 6378.140 / (Plot.AU * 1e6);
            Pz[Plot.MOON - 1] *= 6378.140 / (Plot.AU * 1e6);

            Px[Plot.MOON - 1] += Px[Plot.EARTH - 1];
            Py[Plot.MOON - 1] += Py[Plot.EARTH - 1];
            Pz[Plot.MOON - 1] += Pz[Plot.EARTH - 1];

            Px[Plot.SUN - 1] = 0;
            Py[Plot.SUN - 1] = 0;
            Pz[Plot.SUN - 1] = 0;

            int Planet2;

            lbDSun.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1], 2) + Math.Pow(Pz[Planet - 1], 2) + Math.Pow(Py[Planet - 1], 2)));
            Planet2 = Plot.MOON;
            lbDMoon.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1] - Px[Planet2 - 1], 2) + Math.Pow(Pz[Planet - 1] - Pz[Planet2 - 1], 2) + Math.Pow(Py[Planet - 1] - Py[Planet2 - 1], 2)));
            Planet2 = Plot.EARTH;
            lbDEarth.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1] - Px[Planet2 - 1], 2) + Math.Pow(Pz[Planet - 1] - Pz[Planet2 - 1], 2) + Math.Pow(Py[Planet - 1] - Py[Planet2 - 1], 2)));
            Planet2 = Plot.MERCURY;
            lbDMercury.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1] - Px[Planet2 - 1], 2) + Math.Pow(Pz[Planet - 1] - Pz[Planet2 - 1], 2) + Math.Pow(Py[Planet - 1] - Py[Planet2 - 1], 2)));
            Planet2 = Plot.VENUS;
            lbDVenus.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1] - Px[Planet2 - 1], 2) + Math.Pow(Pz[Planet - 1] - Pz[Planet2 - 1], 2) + Math.Pow(Py[Planet - 1] - Py[Planet2 - 1], 2)));
            Planet2 = Plot.MARS;
            lbDMars.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1] - Px[Planet2 - 1], 2) + Math.Pow(Pz[Planet - 1] - Pz[Planet2 - 1], 2) + Math.Pow(Py[Planet - 1] - Py[Planet2 - 1], 2)));
            Planet2 = Plot.JUPITER;
            lbDJupiter.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1] - Px[Planet2 - 1], 2) + Math.Pow(Pz[Planet - 1] - Pz[Planet2 - 1], 2) + Math.Pow(Py[Planet - 1] - Py[Planet2 - 1], 2)));
            Planet2 = Plot.SATURN;
            lbDSaturn.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1] - Px[Planet2 - 1], 2) + Math.Pow(Pz[Planet - 1] - Pz[Planet2 - 1], 2) + Math.Pow(Py[Planet - 1] - Py[Planet2 - 1], 2)));
            Planet2 = Plot.URANUS;
            lbDUranus.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1] - Px[Planet2 - 1], 2) + Math.Pow(Pz[Planet - 1] - Pz[Planet2 - 1], 2) + Math.Pow(Py[Planet - 1] - Py[Planet2 - 1], 2)));
            Planet2 = Plot.NEPTUNE;
            lbDNeptune.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1] - Px[Planet2 - 1], 2) + Math.Pow(Pz[Planet - 1] - Pz[Planet2 - 1], 2) + Math.Pow(Py[Planet - 1] - Py[Planet2 - 1], 2)));
            Planet2 = Plot.PLUTO;
            lbDPluto.Text = String.Format("{0:F0}", Plot.AU * 1e6 * Math.Sqrt(Math.Pow(Px[Planet - 1] - Px[Planet2 - 1], 2) + Math.Pow(Pz[Planet - 1] - Pz[Planet2 - 1], 2) + Math.Pow(Py[Planet - 1] - Py[Planet2 - 1], 2)));
        }
    }
}
