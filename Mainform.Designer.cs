using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMap
{
    public partial class MainForm
    {
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Label lbEast;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbNorth;
        private System.Windows.Forms.Label lbSouth;
        private System.Windows.Forms.Label lbWest;
        private System.Windows.Forms.PictureBox pbStarMap;
        private System.Windows.Forms.Timer tmUpdateChart;

        #region Windows Forms Designer generated code
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tmUpdateChart = new System.Windows.Forms.Timer(this.components);
            this.lbWest = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbSouth = new System.Windows.Forms.Label();
            this.lbNorth = new System.Windows.Forms.Label();
            this.lbEast = new System.Windows.Forms.Label();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.slTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.slStarTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.slSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.slLocation = new System.Windows.Forms.ToolStripStatusLabel();
            this.slLatLong = new System.Windows.Forms.ToolStripStatusLabel();
            this.slMagnitudeLimit = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbMouseDebug = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslJumpAmount = new System.Windows.Forms.ToolStripLabel();
            this.tbSpeedupAmount = new System.Windows.Forms.ToolStripTextBox();
            this.cmbSpeedUpType = new System.Windows.Forms.ToolStripComboBox();
            this.tsbSpeedNormal = new System.Windows.Forms.ToolStripButton();
            this.tbsSpeedPause = new System.Windows.Forms.ToolStripButton();
            this.tbsSpeedHighBackward = new System.Windows.Forms.ToolStripButton();
            this.tbsSpeedHigh = new System.Windows.Forms.ToolStripButton();
            this.tbsSpeedUltra = new System.Windows.Forms.ToolStripButton();
            this.pbStarMap = new System.Windows.Forms.PictureBox();
            this.mnuJumpToTime = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMarksInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSolInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSolSys = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCompass = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuConstellations = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBrowseStarDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuShowRaDec = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCalculations = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStarMap)).BeginInit();
            this.SuspendLayout();
            // 
            // tmUpdateChart
            // 
            this.tmUpdateChart.Interval = 1000;
            this.tmUpdateChart.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // lbWest
            // 
            this.lbWest.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbWest.AutoSize = true;
            this.lbWest.BackColor = System.Drawing.Color.Transparent;
            this.lbWest.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbWest.Location = new System.Drawing.Point(2, 287);
            this.lbWest.Name = "lbWest";
            this.lbWest.Size = new System.Drawing.Size(39, 13);
            this.lbWest.TabIndex = 13;
            this.lbWest.Text = "WEST";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.White;
            this.imageList1.Images.SetKeyName(0, "play0.png");
            this.imageList1.Images.SetKeyName(1, "play1.png");
            this.imageList1.Images.SetKeyName(2, "play2.png");
            this.imageList1.Images.SetKeyName(3, "jump.png");
            this.imageList1.Images.SetKeyName(4, "empty.png");
            this.imageList1.Images.SetKeyName(5, "compass.png");
            this.imageList1.Images.SetKeyName(6, "help_char.png");
            this.imageList1.Images.SetKeyName(7, "sol_info.png");
            this.imageList1.Images.SetKeyName(8, "exit_app.png");
            this.imageList1.Images.SetKeyName(9, "sol_sys.png");
            this.imageList1.Images.SetKeyName(10, "settings.png");
            this.imageList1.Images.SetKeyName(11, "stardb.png");
            this.imageList1.Images.SetKeyName(12, "help.png");
            this.imageList1.Images.SetKeyName(13, "help.png");
            this.imageList1.Images.SetKeyName(14, "comstellations.png");
            this.imageList1.Images.SetKeyName(15, "copy.png");
            // 
            // lbSouth
            // 
            this.lbSouth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbSouth.BackColor = System.Drawing.Color.Transparent;
            this.lbSouth.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbSouth.Location = new System.Drawing.Point(2, 618);
            this.lbSouth.Name = "lbSouth";
            this.lbSouth.Size = new System.Drawing.Size(669, 14);
            this.lbSouth.TabIndex = 11;
            this.lbSouth.Text = "SOUTH";
            this.lbSouth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbNorth
            // 
            this.lbNorth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNorth.BackColor = System.Drawing.Color.Transparent;
            this.lbNorth.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbNorth.Location = new System.Drawing.Point(0, 27);
            this.lbNorth.Name = "lbNorth";
            this.lbNorth.Size = new System.Drawing.Size(669, 14);
            this.lbNorth.TabIndex = 12;
            this.lbNorth.Text = "NORTH";
            this.lbNorth.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbEast
            // 
            this.lbEast.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEast.BackColor = System.Drawing.Color.Transparent;
            this.lbEast.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbEast.Location = new System.Drawing.Point(624, 294);
            this.lbEast.Name = "lbEast";
            this.lbEast.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbEast.Size = new System.Drawing.Size(40, 15);
            this.lbEast.TabIndex = 14;
            this.lbEast.Text = "EAST";
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(672, 24);
            this.mnuMain.TabIndex = 15;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuJumpToTime,
            this.mnuMarksInfo,
            this.mnuSolInfo,
            this.mnuSolSys,
            this.mnuCompass,
            this.mnuConstellations,
            this.mnuBrowseStarDB,
            this.mnuShowRaDec,
            this.toolStripMenuItem1,
            this.mnuCopyToClipboard,
            this.toolStripMenuItem2,
            this.mnuSettings,
            this.toolStripMenuItem3,
            this.mnuQuit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(290, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(290, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(290, 6);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAbout,
            this.mnuCalculations});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slTime,
            this.slStarTime,
            this.slSpeed,
            this.slLocation,
            this.slLatLong,
            this.slMagnitudeLimit,
            this.lbMouseDebug});
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(672, 22);
            this.statusStrip1.TabIndex = 17;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // slTime
            // 
            this.slTime.Name = "slTime";
            this.slTime.Size = new System.Drawing.Size(42, 17);
            this.slTime.Text = "slTime";
            // 
            // slStarTime
            // 
            this.slStarTime.Name = "slStarTime";
            this.slStarTime.Size = new System.Drawing.Size(50, 17);
            this.slStarTime.Text = "startime";
            // 
            // slSpeed
            // 
            this.slSpeed.AutoSize = false;
            this.slSpeed.Name = "slSpeed";
            this.slSpeed.Size = new System.Drawing.Size(30, 17);
            this.slSpeed.Text = "speed";
            // 
            // slLocation
            // 
            this.slLocation.Name = "slLocation";
            this.slLocation.Size = new System.Drawing.Size(74, 17);
            this.slLocation.Text = "city/location";
            // 
            // slLatLong
            // 
            this.slLatLong.Name = "slLatLong";
            this.slLatLong.Size = new System.Drawing.Size(42, 17);
            this.slLatLong.Text = "lat/lon";
            // 
            // slMagnitudeLimit
            // 
            this.slMagnitudeLimit.Name = "slMagnitudeLimit";
            this.slMagnitudeLimit.Size = new System.Drawing.Size(48, 17);
            this.slMagnitudeLimit.Text = "maglim";
            // 
            // lbMouseDebug
            // 
            this.lbMouseDebug.Name = "lbMouseDebug";
            this.lbMouseDebug.Size = new System.Drawing.Size(67, 17);
            this.lbMouseDebug.Text = "X = 0, Y = 0";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSpeedNormal,
            this.tbsSpeedPause,
            this.tbsSpeedHighBackward,
            this.tbsSpeedHigh,
            this.tbsSpeedUltra,
            this.toolStripSeparator1,
            this.tslJumpAmount,
            this.tbSpeedupAmount,
            this.cmbSpeedUpType});
            this.toolStrip1.Location = new System.Drawing.Point(0, 635);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(672, 25);
            this.toolStrip1.TabIndex = 18;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslJumpAmount
            // 
            this.tslJumpAmount.Name = "tslJumpAmount";
            this.tslJumpAmount.Size = new System.Drawing.Size(208, 22);
            this.tslJumpAmount.Text = "Amount of time to jump on speed up:";
            // 
            // tbSpeedupAmount
            // 
            this.tbSpeedupAmount.Name = "tbSpeedupAmount";
            this.tbSpeedupAmount.Size = new System.Drawing.Size(50, 25);
            // 
            // cmbSpeedUpType
            // 
            this.cmbSpeedUpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeedUpType.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours",
            "Days",
            "Months",
            "Years"});
            this.cmbSpeedUpType.Name = "cmbSpeedUpType";
            this.cmbSpeedUpType.Size = new System.Drawing.Size(121, 25);
            // 
            // tsbSpeedNormal
            // 
            this.tsbSpeedNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSpeedNormal.Image = global::SMap.Properties.Resources.Play;
            this.tsbSpeedNormal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpeedNormal.Name = "tsbSpeedNormal";
            this.tsbSpeedNormal.Size = new System.Drawing.Size(23, 22);
            this.tsbSpeedNormal.Click += new System.EventHandler(this.tsbSpeedNormal_Click);
            // 
            // tbsSpeedPause
            // 
            this.tbsSpeedPause.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbsSpeedPause.Image = global::SMap.Properties.Resources.Pause;
            this.tbsSpeedPause.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsSpeedPause.Name = "tbsSpeedPause";
            this.tbsSpeedPause.Size = new System.Drawing.Size(23, 22);
            this.tbsSpeedPause.Click += new System.EventHandler(this.tbsSpeedPause_Click);
            // 
            // tbsSpeedHighBackward
            // 
            this.tbsSpeedHighBackward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbsSpeedHighBackward.Image = global::SMap.Properties.Resources.Fast_rewind;
            this.tbsSpeedHighBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsSpeedHighBackward.Name = "tbsSpeedHighBackward";
            this.tbsSpeedHighBackward.Size = new System.Drawing.Size(23, 22);
            this.tbsSpeedHighBackward.Click += new System.EventHandler(this.tbsSpeedHighBackward_Click);
            // 
            // tbsSpeedHigh
            // 
            this.tbsSpeedHigh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbsSpeedHigh.Image = global::SMap.Properties.Resources.Fast_forward;
            this.tbsSpeedHigh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsSpeedHigh.Name = "tbsSpeedHigh";
            this.tbsSpeedHigh.Size = new System.Drawing.Size(23, 22);
            this.tbsSpeedHigh.Click += new System.EventHandler(this.tbsSpeedHigh_Click);
            // 
            // tbsSpeedUltra
            // 
            this.tbsSpeedUltra.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbsSpeedUltra.Image = global::SMap.Properties.Resources.time_fastest;
            this.tbsSpeedUltra.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbsSpeedUltra.Name = "tbsSpeedUltra";
            this.tbsSpeedUltra.Size = new System.Drawing.Size(23, 22);
            this.tbsSpeedUltra.Visible = false;
            this.tbsSpeedUltra.Click += new System.EventHandler(this.tbsSpeedUltra_Click);
            // 
            // pbStarMap
            // 
            this.pbStarMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbStarMap.BackColor = System.Drawing.Color.Transparent;
            this.pbStarMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbStarMap.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbStarMap.Location = new System.Drawing.Point(0, 27);
            this.pbStarMap.Name = "pbStarMap";
            this.pbStarMap.Size = new System.Drawing.Size(669, 605);
            this.pbStarMap.TabIndex = 8;
            this.pbStarMap.TabStop = false;
            this.pbStarMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbStarMap_MouseClick);
            this.pbStarMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbStarMap_MouseMove);
            // 
            // mnuJumpToTime
            // 
            this.mnuJumpToTime.Image = global::SMap.Properties.Resources.Calendar;
            this.mnuJumpToTime.Name = "mnuJumpToTime";
            this.mnuJumpToTime.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.J)));
            this.mnuJumpToTime.Size = new System.Drawing.Size(293, 22);
            this.mnuJumpToTime.Text = "Jump to time";
            this.mnuJumpToTime.Click += new System.EventHandler(this.mnuJumpToTime_Click);
            // 
            // mnuMarksInfo
            // 
            this.mnuMarksInfo.Image = global::SMap.Properties.Resources.info;
            this.mnuMarksInfo.Name = "mnuMarksInfo";
            this.mnuMarksInfo.Size = new System.Drawing.Size(293, 22);
            this.mnuMarksInfo.Text = "Character explanations";
            this.mnuMarksInfo.Click += new System.EventHandler(this.mnuMarksInfo_Click);
            // 
            // mnuSolInfo
            // 
            this.mnuSolInfo.Image = global::SMap.Properties.Resources.solsysinfo;
            this.mnuSolInfo.Name = "mnuSolInfo";
            this.mnuSolInfo.Size = new System.Drawing.Size(293, 22);
            this.mnuSolInfo.Text = "Info about planets, the sun and the moon";
            this.mnuSolInfo.Click += new System.EventHandler(this.mnuSolInfo_Click);
            // 
            // mnuSolSys
            // 
            this.mnuSolSys.Image = global::SMap.Properties.Resources.solsys2;
            this.mnuSolSys.Name = "mnuSolSys";
            this.mnuSolSys.Size = new System.Drawing.Size(293, 22);
            this.mnuSolSys.Text = "Solar system";
            this.mnuSolSys.Click += new System.EventHandler(this.mnuSolSys_Click);
            // 
            // mnuCompass
            // 
            this.mnuCompass.Image = global::SMap.Properties.Resources.compass2;
            this.mnuCompass.Name = "mnuCompass";
            this.mnuCompass.Size = new System.Drawing.Size(293, 22);
            this.mnuCompass.Text = "Compass";
            this.mnuCompass.Click += new System.EventHandler(this.mnuCompass_Click);
            // 
            // mnuConstellations
            // 
            this.mnuConstellations.Image = global::SMap.Properties.Resources.comstellations2;
            this.mnuConstellations.Name = "mnuConstellations";
            this.mnuConstellations.Size = new System.Drawing.Size(293, 22);
            this.mnuConstellations.Text = "Constellations";
            this.mnuConstellations.Click += new System.EventHandler(this.mnuConstellations_Click);
            // 
            // mnuBrowseStarDB
            // 
            this.mnuBrowseStarDB.Image = global::SMap.Properties.Resources.starinfo2;
            this.mnuBrowseStarDB.Name = "mnuBrowseStarDB";
            this.mnuBrowseStarDB.Size = new System.Drawing.Size(293, 22);
            this.mnuBrowseStarDB.Text = "Browse star databases";
            this.mnuBrowseStarDB.Click += new System.EventHandler(this.mnuBrowseStarDB_Click);
            // 
            // mnuShowRaDec
            // 
            this.mnuShowRaDec.Image = global::SMap.Properties.Resources.ra_dec;
            this.mnuShowRaDec.Name = "mnuShowRaDec";
            this.mnuShowRaDec.Size = new System.Drawing.Size(293, 22);
            this.mnuShowRaDec.Text = "Show Ra/Dec";
            this.mnuShowRaDec.Click += new System.EventHandler(this.mnuShowRaDec_Click);
            // 
            // mnuCopyToClipboard
            // 
            this.mnuCopyToClipboard.Image = global::SMap.Properties.Resources.Copy;
            this.mnuCopyToClipboard.Name = "mnuCopyToClipboard";
            this.mnuCopyToClipboard.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuCopyToClipboard.Size = new System.Drawing.Size(293, 22);
            this.mnuCopyToClipboard.Text = "Copy starmap to clipboard";
            this.mnuCopyToClipboard.Click += new System.EventHandler(this.mnuCopyToClipboard_Click);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Image = global::SMap.Properties.Resources.settings;
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(293, 22);
            this.mnuSettings.Text = "Settings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuQuit
            // 
            this.mnuQuit.Image = global::SMap.Properties.Resources.Exit;
            this.mnuQuit.Name = "mnuQuit";
            this.mnuQuit.Size = new System.Drawing.Size(293, 22);
            this.mnuQuit.Text = "Exit";
            this.mnuQuit.Click += new System.EventHandler(this.mnuQuit_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Image = global::SMap.Properties.Resources.About;
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(213, 22);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuCalculations
            // 
            this.mnuCalculations.Image = global::SMap.Properties.Resources.Calculator;
            this.mnuCalculations.Name = "mnuCalculations";
            this.mnuCalculations.Size = new System.Drawing.Size(213, 22);
            this.mnuCalculations.Text = "Calculations (External link)";
            this.mnuCalculations.Click += new System.EventHandler(this.mnuCalculations_Click);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(672, 682);
            this.Controls.Add(this.lbSouth);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lbEast);
            this.Controls.Add(this.lbWest);
            this.Controls.Add(this.lbNorth);
            this.Controls.Add(this.pbStarMap);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(680, 696);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Starmap";
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainFormResize);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbStarMap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuJumpToTime;
        private System.Windows.Forms.ToolStripMenuItem mnuBrowseStarDB;
        private System.Windows.Forms.ToolStripMenuItem mnuQuit;
        private System.Windows.Forms.ToolStripMenuItem mnuSolInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuSolSys;
        private System.Windows.Forms.ToolStripMenuItem mnuCompass;
        private System.Windows.Forms.ToolStripMenuItem mnuConstellations;
        private System.Windows.Forms.ToolStripMenuItem mnuMarksInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem mnuShowRaDec;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel slTime;
        private System.Windows.Forms.ToolStripStatusLabel slStarTime;
        private System.Windows.Forms.ToolStripStatusLabel slSpeed;
        private System.Windows.Forms.ToolStripStatusLabel slLocation;
        private System.Windows.Forms.ToolStripStatusLabel slLatLong;
        private System.Windows.Forms.ToolStripStatusLabel slMagnitudeLimit;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSpeedNormal;
        private System.Windows.Forms.ToolStripButton tbsSpeedHigh;
        private System.Windows.Forms.ToolStripButton tbsSpeedUltra;
        private System.Windows.Forms.ToolStripButton tbsSpeedPause;
        private System.Windows.Forms.ToolStripMenuItem mnuCalculations;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel tslJumpAmount;
        private System.Windows.Forms.ToolStripTextBox tbSpeedupAmount;
        private System.Windows.Forms.ToolStripComboBox cmbSpeedUpType;
        private System.Windows.Forms.ToolStripStatusLabel lbMouseDebug;
        private System.Windows.Forms.ToolStripButton tbsSpeedHighBackward;

    }
}
