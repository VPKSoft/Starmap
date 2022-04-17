using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.Resources;
using System.Diagnostics;
using ListClasses;
namespace SMap
{
    public partial class ConfigForm
	{
		private System.Windows.Forms.GroupBox gbStarmapColors;
		private System.Windows.Forms.CheckBox cbHideSolSys;
		private System.Windows.Forms.RadioButton rbConstNameShort;
		private System.Windows.Forms.GroupBox gbStartmapRotation;
		private System.Windows.Forms.Label lbConstellationColor;
		private System.Windows.Forms.GroupBox gbConstellationNames;
		private System.Windows.Forms.GroupBox gbStarDB;
		private System.Windows.Forms.GroupBox gbTimeZone;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.ComboBox cmbMagLimit;
		private System.Windows.Forms.Panel pnStarmapBackgroundColor;
        private System.Windows.Forms.TextBox tbLat;
		private System.Windows.Forms.RadioButton rbConstNameLong;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.Windows.Forms.Label lbLocation;
        private System.Windows.Forms.Label lbLocationName;
		private System.Windows.Forms.Label lbSysTZSys;
		private System.Windows.Forms.Label lbLong;
		private System.Windows.Forms.Panel pnConstellationNameColor;
		private System.Windows.Forms.Panel pnConstellationColor;
		private System.Windows.Forms.Label lbMagnitudeLimit;
        private System.Windows.Forms.Panel pnStarColor;
		private System.Windows.Forms.Label lbStarmapBackgroundColor;
		private System.Windows.Forms.Label lbStarColor;
		private System.Windows.Forms.Label lbConstellationNameColor;
		private System.Windows.Forms.CheckBox cbFlipX;
		private System.Windows.Forms.CheckBox cbHideCons;
		private System.Windows.Forms.TextBox tbLong;
		private System.Windows.Forms.TextBox tbLocationName;
		private System.Windows.Forms.Label lbSysTZSysValue;
		private System.Windows.Forms.CheckBox cbFlipY;
		private System.Windows.Forms.RadioButton rbGliese3rd;
		private System.Windows.Forms.RadioButton rbYaleLarge;
		private System.Windows.Forms.RadioButton rbHYGv11;
		private System.Windows.Forms.RadioButton rbYaleSmall;
		private System.Windows.Forms.Label lbLat;

		private void InitializeComponent()
		{
            this.lbLat = new System.Windows.Forms.Label();
            this.rbYaleSmall = new System.Windows.Forms.RadioButton();
            this.rbHYGv11 = new System.Windows.Forms.RadioButton();
            this.rbYaleLarge = new System.Windows.Forms.RadioButton();
            this.rbGliese3rd = new System.Windows.Forms.RadioButton();
            this.cbFlipY = new System.Windows.Forms.CheckBox();
            this.lbSysTZSysValue = new System.Windows.Forms.Label();
            this.tbLocationName = new System.Windows.Forms.TextBox();
            this.tbLong = new System.Windows.Forms.TextBox();
            this.cbHideCons = new System.Windows.Forms.CheckBox();
            this.cbFlipX = new System.Windows.Forms.CheckBox();
            this.lbConstellationNameColor = new System.Windows.Forms.Label();
            this.lbStarColor = new System.Windows.Forms.Label();
            this.lbStarmapBackgroundColor = new System.Windows.Forms.Label();
            this.pnStarColor = new System.Windows.Forms.Panel();
            this.lbMagnitudeLimit = new System.Windows.Forms.Label();
            this.pnConstellationColor = new System.Windows.Forms.Panel();
            this.pnConstellationNameColor = new System.Windows.Forms.Panel();
            this.lbLong = new System.Windows.Forms.Label();
            this.lbSysTZSys = new System.Windows.Forms.Label();
            this.lbLocationName = new System.Windows.Forms.Label();
            this.lbLocation = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.rbConstNameLong = new System.Windows.Forms.RadioButton();
            this.tbLat = new System.Windows.Forms.TextBox();
            this.pnStarmapBackgroundColor = new System.Windows.Forms.Panel();
            this.cmbMagLimit = new System.Windows.Forms.ComboBox();
            this.btCancel = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.gbTimeZone = new System.Windows.Forms.GroupBox();
            this.gbStarDB = new System.Windows.Forms.GroupBox();
            this.gbConstellationNames = new System.Windows.Forms.GroupBox();
            this.rbConstNameShort = new System.Windows.Forms.RadioButton();
            this.lbConstellationColor = new System.Windows.Forms.Label();
            this.gbStartmapRotation = new System.Windows.Forms.GroupBox();
            this.cbHideSolSys = new System.Windows.Forms.CheckBox();
            this.gbStarmapColors = new System.Windows.Forms.GroupBox();
            this.btFind = new System.Windows.Forms.Button();
            this.gpPlanetImages = new System.Windows.Forms.GroupBox();
            this.rbUseImages = new System.Windows.Forms.RadioButton();
            this.rbUseConventional = new System.Windows.Forms.RadioButton();
            this.gbTimeZone.SuspendLayout();
            this.gbStarDB.SuspendLayout();
            this.gbConstellationNames.SuspendLayout();
            this.gbStartmapRotation.SuspendLayout();
            this.gbStarmapColors.SuspendLayout();
            this.gpPlanetImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbLat
            // 
            this.lbLat.AutoSize = true;
            this.lbLat.Location = new System.Drawing.Point(91, 74);
            this.lbLat.Name = "lbLat";
            this.lbLat.Size = new System.Drawing.Size(48, 13);
            this.lbLat.TabIndex = 22;
            this.lbLat.Text = "Latitude:";
            // 
            // rbYaleSmall
            // 
            this.rbYaleSmall.Location = new System.Drawing.Point(8, 15);
            this.rbYaleSmall.Name = "rbYaleSmall";
            this.rbYaleSmall.Size = new System.Drawing.Size(176, 22);
            this.rbYaleSmall.TabIndex = 0;
            this.rbYaleSmall.Text = "Yale, small (903 stars)";
            // 
            // rbHYGv11
            // 
            this.rbHYGv11.Location = new System.Drawing.Point(8, 37);
            this.rbHYGv11.Name = "rbHYGv11";
            this.rbHYGv11.Size = new System.Drawing.Size(192, 22);
            this.rbHYGv11.TabIndex = 1;
            this.rbHYGv11.Text = "HYG v.1.1 (87475 stars)";
            // 
            // rbYaleLarge
            // 
            this.rbYaleLarge.Location = new System.Drawing.Point(8, 59);
            this.rbYaleLarge.Name = "rbYaleLarge";
            this.rbYaleLarge.Size = new System.Drawing.Size(328, 23);
            this.rbYaleLarge.TabIndex = 2;
            this.rbYaleLarge.Text = "Yale Bright Star Catalogue, 5th Revised Ed. (9110 stars)";
            // 
            // rbGliese3rd
            // 
            this.rbGliese3rd.Location = new System.Drawing.Point(8, 82);
            this.rbGliese3rd.Name = "rbGliese3rd";
            this.rbGliese3rd.Size = new System.Drawing.Size(336, 22);
            this.rbGliese3rd.TabIndex = 3;
            this.rbGliese3rd.Text = "Gliese, Nearby Stars, Preliminary 3rd Version (3803 stars)";
            // 
            // cbFlipY
            // 
            this.cbFlipY.Location = new System.Drawing.Point(8, 16);
            this.cbFlipY.Name = "cbFlipY";
            this.cbFlipY.Size = new System.Drawing.Size(272, 22);
            this.cbFlipY.TabIndex = 35;
            this.cbFlipY.Text = "Flip star map in north-south direction";
            // 
            // lbSysTZSysValue
            // 
            this.lbSysTZSysValue.AutoSize = true;
            this.lbSysTZSysValue.Location = new System.Drawing.Point(152, 37);
            this.lbSysTZSysValue.Name = "lbSysTZSysValue";
            this.lbSysTZSysValue.Size = new System.Drawing.Size(10, 13);
            this.lbSysTZSysValue.TabIndex = 6;
            this.lbSysTZSysValue.Text = "-";
            // 
            // tbLocationName
            // 
            this.tbLocationName.Location = new System.Drawing.Point(91, 16);
            this.tbLocationName.MaxLength = 30;
            this.tbLocationName.Name = "tbLocationName";
            this.tbLocationName.Size = new System.Drawing.Size(192, 20);
            this.tbLocationName.TabIndex = 18;
            // 
            // tbLong
            // 
            this.tbLong.Location = new System.Drawing.Point(195, 98);
            this.tbLong.Name = "tbLong";
            this.tbLong.Size = new System.Drawing.Size(88, 20);
            this.tbLong.TabIndex = 21;
            // 
            // cbHideCons
            // 
            this.cbHideCons.Location = new System.Drawing.Point(291, 155);
            this.cbHideCons.Name = "cbHideCons";
            this.cbHideCons.Size = new System.Drawing.Size(352, 22);
            this.cbHideCons.TabIndex = 28;
            this.cbHideCons.Text = "Hide constellations";
            // 
            // cbFlipX
            // 
            this.cbFlipX.Location = new System.Drawing.Point(8, 40);
            this.cbFlipX.Name = "cbFlipX";
            this.cbFlipX.Size = new System.Drawing.Size(272, 22);
            this.cbFlipX.TabIndex = 34;
            this.cbFlipX.Text = "Flip star map in east-west direction";
            // 
            // lbConstellationNameColor
            // 
            this.lbConstellationNameColor.AutoSize = true;
            this.lbConstellationNameColor.Location = new System.Drawing.Point(16, 45);
            this.lbConstellationNameColor.Name = "lbConstellationNameColor";
            this.lbConstellationNameColor.Size = new System.Drawing.Size(125, 13);
            this.lbConstellationNameColor.TabIndex = 20;
            this.lbConstellationNameColor.Text = "Constellation name color:";
            // 
            // lbStarColor
            // 
            this.lbStarColor.AutoSize = true;
            this.lbStarColor.Location = new System.Drawing.Point(16, 67);
            this.lbStarColor.Name = "lbStarColor";
            this.lbStarColor.Size = new System.Drawing.Size(89, 13);
            this.lbStarColor.TabIndex = 19;
            this.lbStarColor.Text = "Color of the stars:";
            // 
            // lbStarmapBackgroundColor
            // 
            this.lbStarmapBackgroundColor.AutoSize = true;
            this.lbStarmapBackgroundColor.Location = new System.Drawing.Point(16, 89);
            this.lbStarmapBackgroundColor.Name = "lbStarmapBackgroundColor";
            this.lbStarmapBackgroundColor.Size = new System.Drawing.Size(138, 13);
            this.lbStarmapBackgroundColor.TabIndex = 21;
            this.lbStarmapBackgroundColor.Text = "Star map background color:";
            // 
            // pnStarColor
            // 
            this.pnStarColor.BackColor = System.Drawing.Color.White;
            this.pnStarColor.Location = new System.Drawing.Point(208, 67);
            this.pnStarColor.Name = "pnStarColor";
            this.pnStarColor.Size = new System.Drawing.Size(48, 15);
            this.pnStarColor.TabIndex = 24;
            this.pnStarColor.Click += new System.EventHandler(this.Col0Click);
            // 
            // lbMagnitudeLimit
            // 
            this.lbMagnitudeLimit.AutoSize = true;
            this.lbMagnitudeLimit.Location = new System.Drawing.Point(296, 195);
            this.lbMagnitudeLimit.Name = "lbMagnitudeLimit";
            this.lbMagnitudeLimit.Size = new System.Drawing.Size(80, 13);
            this.lbMagnitudeLimit.TabIndex = 30;
            this.lbMagnitudeLimit.Text = "Magnitude limit:";
            // 
            // pnConstellationColor
            // 
            this.pnConstellationColor.BackColor = System.Drawing.Color.White;
            this.pnConstellationColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnConstellationColor.Location = new System.Drawing.Point(208, 22);
            this.pnConstellationColor.Name = "pnConstellationColor";
            this.pnConstellationColor.Size = new System.Drawing.Size(48, 15);
            this.pnConstellationColor.TabIndex = 22;
            this.pnConstellationColor.Click += new System.EventHandler(this.Col0Click);
            // 
            // pnConstellationNameColor
            // 
            this.pnConstellationNameColor.BackColor = System.Drawing.Color.Aquamarine;
            this.pnConstellationNameColor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnConstellationNameColor.Location = new System.Drawing.Point(208, 45);
            this.pnConstellationNameColor.Name = "pnConstellationNameColor";
            this.pnConstellationNameColor.Size = new System.Drawing.Size(48, 14);
            this.pnConstellationNameColor.TabIndex = 23;
            this.pnConstellationNameColor.Click += new System.EventHandler(this.Col0Click);
            // 
            // lbLong
            // 
            this.lbLong.AutoSize = true;
            this.lbLong.Location = new System.Drawing.Point(195, 74);
            this.lbLong.Name = "lbLong";
            this.lbLong.Size = new System.Drawing.Size(57, 13);
            this.lbLong.TabIndex = 23;
            this.lbLong.Text = "Longitude:";
            // 
            // lbSysTZSys
            // 
            this.lbSysTZSys.AutoSize = true;
            this.lbSysTZSys.Location = new System.Drawing.Point(16, 37);
            this.lbSysTZSys.Name = "lbSysTZSys";
            this.lbSysTZSys.Size = new System.Drawing.Size(114, 13);
            this.lbSysTZSys.TabIndex = 1;
            this.lbSysTZSys.Text = "Announced by system:";
            // 
            // lbLocationName
            // 
            this.lbLocationName.AutoSize = true;
            this.lbLocationName.Location = new System.Drawing.Point(11, 16);
            this.lbLocationName.Name = "lbLocationName";
            this.lbLocationName.Size = new System.Drawing.Size(80, 13);
            this.lbLocationName.TabIndex = 17;
            this.lbLocationName.Text = "Location name:";
            // 
            // lbLocation
            // 
            this.lbLocation.AutoSize = true;
            this.lbLocation.Location = new System.Drawing.Point(11, 98);
            this.lbLocation.Name = "lbLocation";
            this.lbLocation.Size = new System.Drawing.Size(51, 13);
            this.lbLocation.TabIndex = 19;
            this.lbLocation.Text = "Location:";
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // rbConstNameLong
            // 
            this.rbConstNameLong.Location = new System.Drawing.Point(8, 37);
            this.rbConstNameLong.Name = "rbConstNameLong";
            this.rbConstNameLong.Size = new System.Drawing.Size(104, 22);
            this.rbConstNameLong.TabIndex = 1;
            this.rbConstNameLong.Text = "Long";
            // 
            // tbLat
            // 
            this.tbLat.Location = new System.Drawing.Point(91, 98);
            this.tbLat.Name = "tbLat";
            this.tbLat.Size = new System.Drawing.Size(88, 20);
            this.tbLat.TabIndex = 20;
            // 
            // pnStarmapBackgroundColor
            // 
            this.pnStarmapBackgroundColor.BackColor = System.Drawing.Color.Black;
            this.pnStarmapBackgroundColor.Location = new System.Drawing.Point(208, 89);
            this.pnStarmapBackgroundColor.Name = "pnStarmapBackgroundColor";
            this.pnStarmapBackgroundColor.Size = new System.Drawing.Size(48, 15);
            this.pnStarmapBackgroundColor.TabIndex = 25;
            this.pnStarmapBackgroundColor.Click += new System.EventHandler(this.Col0Click);
            // 
            // cmbMagLimit
            // 
            this.cmbMagLimit.Items.AddRange(new object[] {
            "1.0",
            "2.0",
            "3.0",
            "4.0",
            "5.0",
            "6.0",
            "7.0",
            "8.0",
            "9.0"});
            this.cmbMagLimit.Location = new System.Drawing.Point(387, 192);
            this.cmbMagLimit.Name = "cmbMagLimit";
            this.cmbMagLimit.Size = new System.Drawing.Size(256, 21);
            this.cmbMagLimit.TabIndex = 29;
            this.cmbMagLimit.Text = "1.0";
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(208, 352);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 21);
            this.btCancel.TabIndex = 32;
            this.btCancel.Text = "Cancel";
            this.btCancel.Click += new System.EventHandler(this.Button1Click);
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btOK.Location = new System.Drawing.Point(11, 352);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 21);
            this.btOK.TabIndex = 33;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.Button2Click);
            // 
            // gbTimeZone
            // 
            this.gbTimeZone.Controls.Add(this.lbSysTZSysValue);
            this.gbTimeZone.Controls.Add(this.lbSysTZSys);
            this.gbTimeZone.Location = new System.Drawing.Point(649, 336);
            this.gbTimeZone.Name = "gbTimeZone";
            this.gbTimeZone.Size = new System.Drawing.Size(272, 82);
            this.gbTimeZone.TabIndex = 24;
            this.gbTimeZone.TabStop = false;
            this.gbTimeZone.Text = "Time zone";
            this.gbTimeZone.Visible = false;
            // 
            // gbStarDB
            // 
            this.gbStarDB.Controls.Add(this.rbGliese3rd);
            this.gbStarDB.Controls.Add(this.rbYaleLarge);
            this.gbStarDB.Controls.Add(this.rbHYGv11);
            this.gbStarDB.Controls.Add(this.rbYaleSmall);
            this.gbStarDB.Location = new System.Drawing.Point(291, 16);
            this.gbStarDB.Name = "gbStarDB";
            this.gbStarDB.Size = new System.Drawing.Size(352, 111);
            this.gbStarDB.TabIndex = 25;
            this.gbStarDB.TabStop = false;
            this.gbStarDB.Text = "Star database to use (requires restart)";
            // 
            // gbConstellationNames
            // 
            this.gbConstellationNames.Controls.Add(this.rbConstNameLong);
            this.gbConstellationNames.Controls.Add(this.rbConstNameShort);
            this.gbConstellationNames.Location = new System.Drawing.Point(291, 222);
            this.gbConstellationNames.Name = "gbConstellationNames";
            this.gbConstellationNames.Size = new System.Drawing.Size(352, 66);
            this.gbConstellationNames.TabIndex = 26;
            this.gbConstellationNames.TabStop = false;
            this.gbConstellationNames.Text = "Constellation names";
            // 
            // rbConstNameShort
            // 
            this.rbConstNameShort.Location = new System.Drawing.Point(8, 15);
            this.rbConstNameShort.Name = "rbConstNameShort";
            this.rbConstNameShort.Size = new System.Drawing.Size(104, 22);
            this.rbConstNameShort.TabIndex = 0;
            this.rbConstNameShort.Text = "Short";
            // 
            // lbConstellationColor
            // 
            this.lbConstellationColor.AutoSize = true;
            this.lbConstellationColor.Location = new System.Drawing.Point(16, 22);
            this.lbConstellationColor.Name = "lbConstellationColor";
            this.lbConstellationColor.Size = new System.Drawing.Size(115, 13);
            this.lbConstellationColor.TabIndex = 18;
            this.lbConstellationColor.Text = "Constellation line color:";
            // 
            // gbStartmapRotation
            // 
            this.gbStartmapRotation.Controls.Add(this.cbFlipY);
            this.gbStartmapRotation.Controls.Add(this.cbFlipX);
            this.gbStartmapRotation.Location = new System.Drawing.Point(291, 296);
            this.gbStartmapRotation.Name = "gbStartmapRotation";
            this.gbStartmapRotation.Size = new System.Drawing.Size(352, 72);
            this.gbStartmapRotation.TabIndex = 38;
            this.gbStartmapRotation.TabStop = false;
            this.gbStartmapRotation.Text = "Star map rotation";
            // 
            // cbHideSolSys
            // 
            this.cbHideSolSys.Location = new System.Drawing.Point(291, 133);
            this.cbHideSolSys.Name = "cbHideSolSys";
            this.cbHideSolSys.Size = new System.Drawing.Size(352, 22);
            this.cbHideSolSys.TabIndex = 27;
            this.cbHideSolSys.Text = "Hide solar system objects";
            // 
            // gbStarmapColors
            // 
            this.gbStarmapColors.Controls.Add(this.pnStarmapBackgroundColor);
            this.gbStarmapColors.Controls.Add(this.pnStarColor);
            this.gbStarmapColors.Controls.Add(this.pnConstellationNameColor);
            this.gbStarmapColors.Controls.Add(this.pnConstellationColor);
            this.gbStarmapColors.Controls.Add(this.lbStarmapBackgroundColor);
            this.gbStarmapColors.Controls.Add(this.lbConstellationNameColor);
            this.gbStarmapColors.Controls.Add(this.lbStarColor);
            this.gbStarmapColors.Controls.Add(this.lbConstellationColor);
            this.gbStarmapColors.Location = new System.Drawing.Point(11, 216);
            this.gbStarmapColors.Name = "gbStarmapColors";
            this.gbStarmapColors.Size = new System.Drawing.Size(272, 126);
            this.gbStarmapColors.TabIndex = 31;
            this.gbStarmapColors.TabStop = false;
            this.gbStarmapColors.Text = "Star map colors";
            // 
            // btFind
            // 
            this.btFind.Location = new System.Drawing.Point(91, 42);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(75, 21);
            this.btFind.TabIndex = 39;
            this.btFind.Text = "Find...";
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // gpPlanetImages
            // 
            this.gpPlanetImages.Controls.Add(this.rbUseImages);
            this.gpPlanetImages.Controls.Add(this.rbUseConventional);
            this.gpPlanetImages.Location = new System.Drawing.Point(14, 133);
            this.gpPlanetImages.Name = "gpPlanetImages";
            this.gpPlanetImages.Size = new System.Drawing.Size(269, 53);
            this.gpPlanetImages.TabIndex = 40;
            this.gpPlanetImages.TabStop = false;
            this.gpPlanetImages.Text = "Planet images";
            // 
            // rbUseImages
            // 
            this.rbUseImages.AutoSize = true;
            this.rbUseImages.Location = new System.Drawing.Point(139, 19);
            this.rbUseImages.Name = "rbUseImages";
            this.rbUseImages.Size = new System.Drawing.Size(84, 17);
            this.rbUseImages.TabIndex = 1;
            this.rbUseImages.TabStop = true;
            this.rbUseImages.Text = "Use pictures";
            this.rbUseImages.UseVisualStyleBackColor = true;
            // 
            // rbUseConventional
            // 
            this.rbUseConventional.AutoSize = true;
            this.rbUseConventional.Location = new System.Drawing.Point(6, 19);
            this.rbUseConventional.Name = "rbUseConventional";
            this.rbUseConventional.Size = new System.Drawing.Size(102, 17);
            this.rbUseConventional.TabIndex = 0;
            this.rbUseConventional.TabStop = true;
            this.rbUseConventional.Text = "Use convetional";
            this.rbUseConventional.UseVisualStyleBackColor = true;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(656, 376);
            this.Controls.Add(this.gpPlanetImages);
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.gbStartmapRotation);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.gbStarmapColors);
            this.Controls.Add(this.lbMagnitudeLimit);
            this.Controls.Add(this.cmbMagLimit);
            this.Controls.Add(this.cbHideCons);
            this.Controls.Add(this.cbHideSolSys);
            this.Controls.Add(this.gbConstellationNames);
            this.Controls.Add(this.gbStarDB);
            this.Controls.Add(this.gbTimeZone);
            this.Controls.Add(this.lbLong);
            this.Controls.Add(this.lbLat);
            this.Controls.Add(this.tbLong);
            this.Controls.Add(this.tbLat);
            this.Controls.Add(this.lbLocation);
            this.Controls.Add(this.tbLocationName);
            this.Controls.Add(this.lbLocationName);
            this.Controls.Add(this.btOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ConfigForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.AsetusIkkunaLoad);
            this.gbTimeZone.ResumeLayout(false);
            this.gbTimeZone.PerformLayout();
            this.gbStarDB.ResumeLayout(false);
            this.gbConstellationNames.ResumeLayout(false);
            this.gbStartmapRotation.ResumeLayout(false);
            this.gbStarmapColors.ResumeLayout(false);
            this.gbStarmapColors.PerformLayout();
            this.gpPlanetImages.ResumeLayout(false);
            this.gpPlanetImages.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button btFind;
        private GroupBox gpPlanetImages;
        private RadioButton rbUseImages;
        private RadioButton rbUseConventional;
	}
}

