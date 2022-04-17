using System;
using Plotter;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.IO;
namespace SMap
{
	public partial class PlanetInfo
	{
		private System.Windows.Forms.Label lbDMoon;
		private System.Windows.Forms.GroupBox gbDistancesKm;
		private System.Windows.Forms.Label lbSiderealTimeDays;
		private System.Windows.Forms.Label lbDSaturn;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.Button btRefresh;
		private System.Windows.Forms.ComboBox cmbBody;
		private System.Windows.Forms.Label lbSurfaceGravityMS2Value;
		private System.Windows.Forms.Label lbSiderealTimeYearsValue;
		private System.Windows.Forms.Label lbDSun;
		private System.Windows.Forms.Label lbDNeptune;
		private System.Windows.Forms.Label lbDPluto;
		private System.Windows.Forms.Label lbDEarth;
		private System.Windows.Forms.Label lbRotationPeriodHours;
		private System.Windows.Forms.Label lbOrbitalVelKmSec;
		private System.Windows.Forms.Label lbDVenus;
		private System.Windows.Forms.Label lbMassKg;
		private System.Windows.Forms.Label lbMeanDistSunKm;
		private System.Windows.Forms.Label lbRadiusKm;
		private System.Windows.Forms.Label lbSurfaceGravityMS2;
		private System.Windows.Forms.Label lbDistEarth;
		private System.Windows.Forms.Label lbVolumeM3;
		private System.Windows.Forms.Label lbDistMoon;
		private System.Windows.Forms.Label lbDistVenus;
		private System.Windows.Forms.Label lbDistMars;
		private System.Windows.Forms.Label lnDistSun;
		private System.Windows.Forms.Label lbDistMercury;
		private System.Windows.Forms.Label lbDJupiter;
		private System.Windows.Forms.Label lbDistJupiter;
		private System.Windows.Forms.Label lbDistNeptune;
		private System.Windows.Forms.Label lbDistUranus;
		private System.Windows.Forms.Label lbDistPluto;
		private System.Windows.Forms.Label lbDistSaturn;
		private System.Windows.Forms.Label lbSiderealTimeDaysValue;
		private System.Windows.Forms.Label lbOrbitalVelKmSecValue;
		private System.Windows.Forms.Label lbRotationPeriodHoursValue;
		private System.Windows.Forms.Label lbRadiusKmValue;
		private System.Windows.Forms.Label lbMeanDensityKgM3Value;
		private System.Windows.Forms.Label lbMassKgValue;
		private System.Windows.Forms.Label lbMeanDistSunKmValue;
		private System.Windows.Forms.Label lbVolumeM3Value;
		private System.Windows.Forms.Label lbDMercury;
		private System.Windows.Forms.Label lbDUranus;
		private System.Windows.Forms.Label lbDMars;
		private System.Windows.Forms.Label lbMeanDensityKgM3;
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
            this.lbMeanDensityKgM3 = new System.Windows.Forms.Label();
            this.lbDMars = new System.Windows.Forms.Label();
            this.lbDUranus = new System.Windows.Forms.Label();
            this.lbDMercury = new System.Windows.Forms.Label();
            this.lbVolumeM3Value = new System.Windows.Forms.Label();
            this.lbMeanDistSunKmValue = new System.Windows.Forms.Label();
            this.lbMassKgValue = new System.Windows.Forms.Label();
            this.lbMeanDensityKgM3Value = new System.Windows.Forms.Label();
            this.lbRadiusKmValue = new System.Windows.Forms.Label();
            this.lbRotationPeriodHoursValue = new System.Windows.Forms.Label();
            this.lbOrbitalVelKmSecValue = new System.Windows.Forms.Label();
            this.lbSiderealTimeDaysValue = new System.Windows.Forms.Label();
            this.lbDistSaturn = new System.Windows.Forms.Label();
            this.lbDistPluto = new System.Windows.Forms.Label();
            this.lbDistUranus = new System.Windows.Forms.Label();
            this.lbDistNeptune = new System.Windows.Forms.Label();
            this.lbDistJupiter = new System.Windows.Forms.Label();
            this.lbDJupiter = new System.Windows.Forms.Label();
            this.lbDistMercury = new System.Windows.Forms.Label();
            this.lnDistSun = new System.Windows.Forms.Label();
            this.lbDistMars = new System.Windows.Forms.Label();
            this.lbDistVenus = new System.Windows.Forms.Label();
            this.lbDistMoon = new System.Windows.Forms.Label();
            this.lbVolumeM3 = new System.Windows.Forms.Label();
            this.lbDistEarth = new System.Windows.Forms.Label();
            this.lbSurfaceGravityMS2 = new System.Windows.Forms.Label();
            this.lbRadiusKm = new System.Windows.Forms.Label();
            this.lbMeanDistSunKm = new System.Windows.Forms.Label();
            this.lbMassKg = new System.Windows.Forms.Label();
            this.lbDVenus = new System.Windows.Forms.Label();
            this.lbOrbitalVelKmSec = new System.Windows.Forms.Label();
            this.lbRotationPeriodHours = new System.Windows.Forms.Label();
            this.lbDEarth = new System.Windows.Forms.Label();
            this.lbDPluto = new System.Windows.Forms.Label();
            this.lbDNeptune = new System.Windows.Forms.Label();
            this.lbDSun = new System.Windows.Forms.Label();
            this.lbSiderealTimeYearsValue = new System.Windows.Forms.Label();
            this.lbSurfaceGravityMS2Value = new System.Windows.Forms.Label();
            this.cmbBody = new System.Windows.Forms.ComboBox();
            this.btRefresh = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.lbDSaturn = new System.Windows.Forms.Label();
            this.lbSiderealTimeDays = new System.Windows.Forms.Label();
            this.gbDistancesKm = new System.Windows.Forms.GroupBox();
            this.lbDMoon = new System.Windows.Forms.Label();
            this.gbDistancesKm.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbMeanDensityKgM3
            // 
            this.lbMeanDensityKgM3.Location = new System.Drawing.Point(8, 64);
            this.lbMeanDensityKgM3.Name = "lbMeanDensityKgM3";
            this.lbMeanDensityKgM3.Size = new System.Drawing.Size(170, 23);
            this.lbMeanDensityKgM3.TabIndex = 4;
            this.lbMeanDensityKgM3.Text = "Mean density (kg/m3):";
            // 
            // lbDMars
            // 
            this.lbDMars.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDMars.Location = new System.Drawing.Point(352, 16);
            this.lbDMars.Name = "lbDMars";
            this.lbDMars.Size = new System.Drawing.Size(88, 17);
            this.lbDMars.TabIndex = 18;
            this.lbDMars.Text = "-";
            this.lbDMars.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbDUranus
            // 
            this.lbDUranus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDUranus.Location = new System.Drawing.Point(352, 88);
            this.lbDUranus.Name = "lbDUranus";
            this.lbDUranus.Size = new System.Drawing.Size(88, 17);
            this.lbDUranus.TabIndex = 21;
            this.lbDUranus.Text = "-";
            this.lbDUranus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbDMercury
            // 
            this.lbDMercury.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDMercury.Location = new System.Drawing.Point(120, 88);
            this.lbDMercury.Name = "lbDMercury";
            this.lbDMercury.Size = new System.Drawing.Size(88, 17);
            this.lbDMercury.TabIndex = 15;
            this.lbDMercury.Text = "-";
            this.lbDMercury.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbVolumeM3Value
            // 
            this.lbVolumeM3Value.AutoSize = true;
            this.lbVolumeM3Value.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbVolumeM3Value.Location = new System.Drawing.Point(192, 184);
            this.lbVolumeM3Value.Name = "lbVolumeM3Value";
            this.lbVolumeM3Value.Size = new System.Drawing.Size(10, 13);
            this.lbVolumeM3Value.TabIndex = 20;
            this.lbVolumeM3Value.Text = "-";
            // 
            // lbMeanDistSunKmValue
            // 
            this.lbMeanDistSunKmValue.AutoSize = true;
            this.lbMeanDistSunKmValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbMeanDistSunKmValue.Location = new System.Drawing.Point(192, 208);
            this.lbMeanDistSunKmValue.Name = "lbMeanDistSunKmValue";
            this.lbMeanDistSunKmValue.Size = new System.Drawing.Size(10, 13);
            this.lbMeanDistSunKmValue.TabIndex = 21;
            this.lbMeanDistSunKmValue.Text = "-";
            // 
            // lbMassKgValue
            // 
            this.lbMassKgValue.AutoSize = true;
            this.lbMassKgValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbMassKgValue.Location = new System.Drawing.Point(192, 40);
            this.lbMassKgValue.Name = "lbMassKgValue";
            this.lbMassKgValue.Size = new System.Drawing.Size(10, 13);
            this.lbMassKgValue.TabIndex = 14;
            this.lbMassKgValue.Text = "-";
            // 
            // lbMeanDensityKgM3Value
            // 
            this.lbMeanDensityKgM3Value.AutoSize = true;
            this.lbMeanDensityKgM3Value.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbMeanDensityKgM3Value.Location = new System.Drawing.Point(192, 64);
            this.lbMeanDensityKgM3Value.Name = "lbMeanDensityKgM3Value";
            this.lbMeanDensityKgM3Value.Size = new System.Drawing.Size(10, 13);
            this.lbMeanDensityKgM3Value.TabIndex = 15;
            this.lbMeanDensityKgM3Value.Text = "-";
            // 
            // lbRadiusKmValue
            // 
            this.lbRadiusKmValue.AutoSize = true;
            this.lbRadiusKmValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbRadiusKmValue.Location = new System.Drawing.Point(192, 136);
            this.lbRadiusKmValue.Name = "lbRadiusKmValue";
            this.lbRadiusKmValue.Size = new System.Drawing.Size(10, 13);
            this.lbRadiusKmValue.TabIndex = 18;
            this.lbRadiusKmValue.Text = "-";
            // 
            // lbRotationPeriodHoursValue
            // 
            this.lbRotationPeriodHoursValue.AutoSize = true;
            this.lbRotationPeriodHoursValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbRotationPeriodHoursValue.Location = new System.Drawing.Point(192, 160);
            this.lbRotationPeriodHoursValue.Name = "lbRotationPeriodHoursValue";
            this.lbRotationPeriodHoursValue.Size = new System.Drawing.Size(10, 13);
            this.lbRotationPeriodHoursValue.TabIndex = 19;
            this.lbRotationPeriodHoursValue.Text = "-";
            // 
            // lbOrbitalVelKmSecValue
            // 
            this.lbOrbitalVelKmSecValue.AutoSize = true;
            this.lbOrbitalVelKmSecValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbOrbitalVelKmSecValue.Location = new System.Drawing.Point(192, 88);
            this.lbOrbitalVelKmSecValue.Name = "lbOrbitalVelKmSecValue";
            this.lbOrbitalVelKmSecValue.Size = new System.Drawing.Size(10, 13);
            this.lbOrbitalVelKmSecValue.TabIndex = 16;
            this.lbOrbitalVelKmSecValue.Text = "-";
            // 
            // lbSiderealTimeDaysValue
            // 
            this.lbSiderealTimeDaysValue.AutoSize = true;
            this.lbSiderealTimeDaysValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbSiderealTimeDaysValue.Location = new System.Drawing.Point(192, 112);
            this.lbSiderealTimeDaysValue.Name = "lbSiderealTimeDaysValue";
            this.lbSiderealTimeDaysValue.Size = new System.Drawing.Size(10, 13);
            this.lbSiderealTimeDaysValue.TabIndex = 17;
            this.lbSiderealTimeDaysValue.Text = "-";
            // 
            // lbDistSaturn
            // 
            this.lbDistSaturn.AutoSize = true;
            this.lbDistSaturn.Location = new System.Drawing.Point(232, 64);
            this.lbDistSaturn.Name = "lbDistSaturn";
            this.lbDistSaturn.Size = new System.Drawing.Size(88, 13);
            this.lbDistSaturn.TabIndex = 8;
            this.lbDistSaturn.Text = "Dist. from Saturn:";
            // 
            // lbDistPluto
            // 
            this.lbDistPluto.AutoSize = true;
            this.lbDistPluto.Location = new System.Drawing.Point(8, 136);
            this.lbDistPluto.Name = "lbDistPluto";
            this.lbDistPluto.Size = new System.Drawing.Size(81, 13);
            this.lbDistPluto.TabIndex = 11;
            this.lbDistPluto.Text = "Dist. from Pluto:";
            // 
            // lbDistUranus
            // 
            this.lbDistUranus.AutoSize = true;
            this.lbDistUranus.Location = new System.Drawing.Point(232, 88);
            this.lbDistUranus.Name = "lbDistUranus";
            this.lbDistUranus.Size = new System.Drawing.Size(91, 13);
            this.lbDistUranus.TabIndex = 9;
            this.lbDistUranus.Text = "Dist. from Uranus:";
            // 
            // lbDistNeptune
            // 
            this.lbDistNeptune.AutoSize = true;
            this.lbDistNeptune.Location = new System.Drawing.Point(232, 112);
            this.lbDistNeptune.Name = "lbDistNeptune";
            this.lbDistNeptune.Size = new System.Drawing.Size(98, 13);
            this.lbDistNeptune.TabIndex = 10;
            this.lbDistNeptune.Text = "Dist. from Neptune:";
            // 
            // lbDistJupiter
            // 
            this.lbDistJupiter.AutoSize = true;
            this.lbDistJupiter.Location = new System.Drawing.Point(232, 40);
            this.lbDistJupiter.Name = "lbDistJupiter";
            this.lbDistJupiter.Size = new System.Drawing.Size(88, 13);
            this.lbDistJupiter.TabIndex = 7;
            this.lbDistJupiter.Text = "Dist. from Jupiter:";
            // 
            // lbDJupiter
            // 
            this.lbDJupiter.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDJupiter.Location = new System.Drawing.Point(352, 40);
            this.lbDJupiter.Name = "lbDJupiter";
            this.lbDJupiter.Size = new System.Drawing.Size(88, 17);
            this.lbDJupiter.TabIndex = 19;
            this.lbDJupiter.Text = "-";
            this.lbDJupiter.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbDistMercury
            // 
            this.lbDistMercury.AutoSize = true;
            this.lbDistMercury.Location = new System.Drawing.Point(8, 88);
            this.lbDistMercury.Name = "lbDistMercury";
            this.lbDistMercury.Size = new System.Drawing.Size(95, 13);
            this.lbDistMercury.TabIndex = 4;
            this.lbDistMercury.Text = "Dist. from Mercury:";
            // 
            // lnDistSun
            // 
            this.lnDistSun.AutoSize = true;
            this.lnDistSun.Location = new System.Drawing.Point(8, 64);
            this.lnDistSun.Name = "lnDistSun";
            this.lnDistSun.Size = new System.Drawing.Size(92, 13);
            this.lnDistSun.TabIndex = 3;
            this.lnDistSun.Text = "Dist. from the sun:";
            // 
            // lbDistMars
            // 
            this.lbDistMars.AutoSize = true;
            this.lbDistMars.Location = new System.Drawing.Point(232, 16);
            this.lbDistMars.Name = "lbDistMars";
            this.lbDistMars.Size = new System.Drawing.Size(80, 13);
            this.lbDistMars.TabIndex = 6;
            this.lbDistMars.Text = "Dist. from Mars:";
            // 
            // lbDistVenus
            // 
            this.lbDistVenus.AutoSize = true;
            this.lbDistVenus.Location = new System.Drawing.Point(8, 112);
            this.lbDistVenus.Name = "lbDistVenus";
            this.lbDistVenus.Size = new System.Drawing.Size(87, 13);
            this.lbDistVenus.TabIndex = 5;
            this.lbDistVenus.Text = "Dist. from Venus:";
            // 
            // lbDistMoon
            // 
            this.lbDistMoon.AutoSize = true;
            this.lbDistMoon.Location = new System.Drawing.Point(8, 16);
            this.lbDistMoon.Name = "lbDistMoon";
            this.lbDistMoon.Size = new System.Drawing.Size(101, 13);
            this.lbDistMoon.TabIndex = 1;
            this.lbDistMoon.Text = "Dist. from the moon:";
            // 
            // lbVolumeM3
            // 
            this.lbVolumeM3.Location = new System.Drawing.Point(8, 184);
            this.lbVolumeM3.Name = "lbVolumeM3";
            this.lbVolumeM3.Size = new System.Drawing.Size(170, 23);
            this.lbVolumeM3.TabIndex = 9;
            this.lbVolumeM3.Text = "Volume (m3):";
            // 
            // lbDistEarth
            // 
            this.lbDistEarth.AutoSize = true;
            this.lbDistEarth.Location = new System.Drawing.Point(8, 40);
            this.lbDistEarth.Name = "lbDistEarth";
            this.lbDistEarth.Size = new System.Drawing.Size(99, 13);
            this.lbDistEarth.TabIndex = 2;
            this.lbDistEarth.Text = "Dist. from the earth:";
            // 
            // lbSurfaceGravityMS2
            // 
            this.lbSurfaceGravityMS2.Location = new System.Drawing.Point(8, 232);
            this.lbSurfaceGravityMS2.Name = "lbSurfaceGravityMS2";
            this.lbSurfaceGravityMS2.Size = new System.Drawing.Size(170, 23);
            this.lbSurfaceGravityMS2.TabIndex = 11;
            this.lbSurfaceGravityMS2.Text = "Surface gravity (m/s2):";
            // 
            // lbRadiusKm
            // 
            this.lbRadiusKm.Location = new System.Drawing.Point(8, 136);
            this.lbRadiusKm.Name = "lbRadiusKm";
            this.lbRadiusKm.Size = new System.Drawing.Size(170, 23);
            this.lbRadiusKm.TabIndex = 7;
            this.lbRadiusKm.Text = "Radius (km):";
            // 
            // lbMeanDistSunKm
            // 
            this.lbMeanDistSunKm.Location = new System.Drawing.Point(8, 208);
            this.lbMeanDistSunKm.Name = "lbMeanDistSunKm";
            this.lbMeanDistSunKm.Size = new System.Drawing.Size(170, 23);
            this.lbMeanDistSunKm.TabIndex = 10;
            this.lbMeanDistSunKm.Text = "Mean distance from the sun (km):";
            // 
            // lbMassKg
            // 
            this.lbMassKg.Location = new System.Drawing.Point(8, 40);
            this.lbMassKg.Name = "lbMassKg";
            this.lbMassKg.Size = new System.Drawing.Size(170, 23);
            this.lbMassKg.TabIndex = 3;
            this.lbMassKg.Text = "Mass (kg):";
            // 
            // lbDVenus
            // 
            this.lbDVenus.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDVenus.Location = new System.Drawing.Point(120, 112);
            this.lbDVenus.Name = "lbDVenus";
            this.lbDVenus.Size = new System.Drawing.Size(88, 17);
            this.lbDVenus.TabIndex = 16;
            this.lbDVenus.Text = "-";
            this.lbDVenus.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbOrbitalVelKmSec
            // 
            this.lbOrbitalVelKmSec.Location = new System.Drawing.Point(8, 88);
            this.lbOrbitalVelKmSec.Name = "lbOrbitalVelKmSec";
            this.lbOrbitalVelKmSec.Size = new System.Drawing.Size(170, 23);
            this.lbOrbitalVelKmSec.TabIndex = 5;
            this.lbOrbitalVelKmSec.Text = "Orbital velocity (km/sec):";
            // 
            // lbRotationPeriodHours
            // 
            this.lbRotationPeriodHours.Location = new System.Drawing.Point(8, 160);
            this.lbRotationPeriodHours.Name = "lbRotationPeriodHours";
            this.lbRotationPeriodHours.Size = new System.Drawing.Size(170, 23);
            this.lbRotationPeriodHours.TabIndex = 8;
            this.lbRotationPeriodHours.Text = "Rotation period (h):";
            // 
            // lbDEarth
            // 
            this.lbDEarth.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDEarth.Location = new System.Drawing.Point(120, 40);
            this.lbDEarth.Name = "lbDEarth";
            this.lbDEarth.Size = new System.Drawing.Size(88, 17);
            this.lbDEarth.TabIndex = 13;
            this.lbDEarth.Text = "-";
            this.lbDEarth.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbDPluto
            // 
            this.lbDPluto.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDPluto.Location = new System.Drawing.Point(120, 136);
            this.lbDPluto.Name = "lbDPluto";
            this.lbDPluto.Size = new System.Drawing.Size(88, 17);
            this.lbDPluto.TabIndex = 17;
            this.lbDPluto.Text = "-";
            this.lbDPluto.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbDNeptune
            // 
            this.lbDNeptune.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDNeptune.Location = new System.Drawing.Point(352, 112);
            this.lbDNeptune.Name = "lbDNeptune";
            this.lbDNeptune.Size = new System.Drawing.Size(88, 17);
            this.lbDNeptune.TabIndex = 22;
            this.lbDNeptune.Text = "-";
            this.lbDNeptune.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbDSun
            // 
            this.lbDSun.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDSun.Location = new System.Drawing.Point(120, 64);
            this.lbDSun.Name = "lbDSun";
            this.lbDSun.Size = new System.Drawing.Size(88, 17);
            this.lbDSun.TabIndex = 14;
            this.lbDSun.Text = "-";
            this.lbDSun.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbSiderealTimeYearsValue
            // 
            this.lbSiderealTimeYearsValue.AutoSize = true;
            this.lbSiderealTimeYearsValue.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbSiderealTimeYearsValue.Location = new System.Drawing.Point(320, 112);
            this.lbSiderealTimeYearsValue.Name = "lbSiderealTimeYearsValue";
            this.lbSiderealTimeYearsValue.Size = new System.Drawing.Size(10, 13);
            this.lbSiderealTimeYearsValue.TabIndex = 23;
            this.lbSiderealTimeYearsValue.Text = "-";
            // 
            // lbSurfaceGravityMS2Value
            // 
            this.lbSurfaceGravityMS2Value.AutoSize = true;
            this.lbSurfaceGravityMS2Value.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbSurfaceGravityMS2Value.Location = new System.Drawing.Point(192, 232);
            this.lbSurfaceGravityMS2Value.Name = "lbSurfaceGravityMS2Value";
            this.lbSurfaceGravityMS2Value.Size = new System.Drawing.Size(10, 13);
            this.lbSurfaceGravityMS2Value.TabIndex = 22;
            this.lbSurfaceGravityMS2Value.Text = "-";
            // 
            // cmbBody
            // 
            this.cmbBody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBody.Items.AddRange(new object[] {
            "Aurinko",
            "Kuu",
            "Merkurius",
            "Venus",
            "Mars",
            "Jupiters",
            "Saturnus",
            "Uranus",
            "Neptunus",
            "Pluto",
            "Maa"});
            this.cmbBody.Location = new System.Drawing.Point(8, 8);
            this.cmbBody.Name = "cmbBody";
            this.cmbBody.Size = new System.Drawing.Size(184, 21);
            this.cmbBody.TabIndex = 1;
            this.cmbBody.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(8, 424);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(80, 23);
            this.btRefresh.TabIndex = 24;
            this.btRefresh.Text = "Refresh info";
            this.btRefresh.Click += new System.EventHandler(this.Button1Click);
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btClose.Location = new System.Drawing.Point(376, 424);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(80, 23);
            this.btClose.TabIndex = 25;
            this.btClose.Text = "Close";
            // 
            // lbDSaturn
            // 
            this.lbDSaturn.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDSaturn.Location = new System.Drawing.Point(352, 64);
            this.lbDSaturn.Name = "lbDSaturn";
            this.lbDSaturn.Size = new System.Drawing.Size(88, 17);
            this.lbDSaturn.TabIndex = 20;
            this.lbDSaturn.Text = "-";
            this.lbDSaturn.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbSiderealTimeDays
            // 
            this.lbSiderealTimeDays.Location = new System.Drawing.Point(8, 112);
            this.lbSiderealTimeDays.Name = "lbSiderealTimeDays";
            this.lbSiderealTimeDays.Size = new System.Drawing.Size(170, 23);
            this.lbSiderealTimeDays.TabIndex = 6;
            this.lbSiderealTimeDays.Text = "Sidereal time (days):";
            // 
            // gbDistancesKm
            // 
            this.gbDistancesKm.Controls.Add(this.lbDNeptune);
            this.gbDistancesKm.Controls.Add(this.lbDUranus);
            this.gbDistancesKm.Controls.Add(this.lbDSaturn);
            this.gbDistancesKm.Controls.Add(this.lbDJupiter);
            this.gbDistancesKm.Controls.Add(this.lbDMars);
            this.gbDistancesKm.Controls.Add(this.lbDPluto);
            this.gbDistancesKm.Controls.Add(this.lbDVenus);
            this.gbDistancesKm.Controls.Add(this.lbDMercury);
            this.gbDistancesKm.Controls.Add(this.lbDSun);
            this.gbDistancesKm.Controls.Add(this.lbDEarth);
            this.gbDistancesKm.Controls.Add(this.lbDMoon);
            this.gbDistancesKm.Controls.Add(this.lbDistPluto);
            this.gbDistancesKm.Controls.Add(this.lbDistNeptune);
            this.gbDistancesKm.Controls.Add(this.lbDistUranus);
            this.gbDistancesKm.Controls.Add(this.lbDistSaturn);
            this.gbDistancesKm.Controls.Add(this.lbDistJupiter);
            this.gbDistancesKm.Controls.Add(this.lbDistMars);
            this.gbDistancesKm.Controls.Add(this.lbDistVenus);
            this.gbDistancesKm.Controls.Add(this.lbDistMercury);
            this.gbDistancesKm.Controls.Add(this.lnDistSun);
            this.gbDistancesKm.Controls.Add(this.lbDistEarth);
            this.gbDistancesKm.Controls.Add(this.lbDistMoon);
            this.gbDistancesKm.Location = new System.Drawing.Point(8, 256);
            this.gbDistancesKm.Name = "gbDistancesKm";
            this.gbDistancesKm.Size = new System.Drawing.Size(448, 160);
            this.gbDistancesKm.TabIndex = 26;
            this.gbDistancesKm.TabStop = false;
            this.gbDistancesKm.Text = "Distances (km)";
            // 
            // lbDMoon
            // 
            this.lbDMoon.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbDMoon.Location = new System.Drawing.Point(120, 16);
            this.lbDMoon.Name = "lbDMoon";
            this.lbDMoon.Size = new System.Drawing.Size(88, 17);
            this.lbDMoon.TabIndex = 12;
            this.lbDMoon.Text = "-";
            this.lbDMoon.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // PlanetInfo
            // 
            this.AcceptButton = this.btRefresh;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(464, 456);
            this.Controls.Add(this.gbDistancesKm);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btRefresh);
            this.Controls.Add(this.lbSiderealTimeYearsValue);
            this.Controls.Add(this.lbSurfaceGravityMS2Value);
            this.Controls.Add(this.lbMeanDistSunKmValue);
            this.Controls.Add(this.lbVolumeM3Value);
            this.Controls.Add(this.lbRotationPeriodHoursValue);
            this.Controls.Add(this.lbRadiusKmValue);
            this.Controls.Add(this.lbSiderealTimeDaysValue);
            this.Controls.Add(this.lbOrbitalVelKmSecValue);
            this.Controls.Add(this.lbMeanDensityKgM3Value);
            this.Controls.Add(this.lbMassKgValue);
            this.Controls.Add(this.lbSurfaceGravityMS2);
            this.Controls.Add(this.lbMeanDistSunKm);
            this.Controls.Add(this.lbVolumeM3);
            this.Controls.Add(this.lbRotationPeriodHours);
            this.Controls.Add(this.lbRadiusKm);
            this.Controls.Add(this.lbSiderealTimeDays);
            this.Controls.Add(this.lbOrbitalVelKmSec);
            this.Controls.Add(this.lbMeanDensityKgM3);
            this.Controls.Add(this.lbMassKg);
            this.Controls.Add(this.cmbBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PlanetInfo";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Info about planets, the sun and the moon";
            this.gbDistancesKm.ResumeLayout(false);
            this.gbDistancesKm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}

