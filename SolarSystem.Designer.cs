using Stellar;
using Plotter;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.IO;
namespace SMap
{
	public partial class SolarSystem
	{
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer tmPlot;
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SolarSystem));
            this.tmPlot = new System.Windows.Forms.Timer(this.components);
            this.pnToolBox = new System.Windows.Forms.Panel();
            this.lbHint = new System.Windows.Forms.Label();
            this.btCopyToClipboard = new System.Windows.Forms.Button();
            this.cbKeepAspectRatio = new System.Windows.Forms.CheckBox();
            this.tbZAxisRotation = new System.Windows.Forms.TrackBar();
            this.lbZAxisRotation = new System.Windows.Forms.Label();
            this.tbYAxisRotation = new System.Windows.Forms.TrackBar();
            this.lbYAxisRotation = new System.Windows.Forms.Label();
            this.tbXAxisRotation = new System.Windows.Forms.TrackBar();
            this.lbXAxisRotation = new System.Windows.Forms.Label();
            this.cbEartchC = new System.Windows.Forms.CheckBox();
            this.cmbZoomPreset = new System.Windows.Forms.ComboBox();
            this.btJumpTime = new System.Windows.Forms.Button();
            this.lbZoom = new System.Windows.Forms.Label();
            this.dtpJumpTime = new System.Windows.Forms.DateTimePicker();
            this.lbJumpToTime = new System.Windows.Forms.Label();
            this.cmbTimeSpeedUp = new System.Windows.Forms.ComboBox();
            this.lbSpeedTimeSpan = new System.Windows.Forms.Label();
            this.tsUtils = new System.Windows.Forms.ToolStrip();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbPlay = new System.Windows.Forms.ToolStripButton();
            this.tsbFastBackward = new System.Windows.Forms.ToolStripButton();
            this.tsbFastForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tslState = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tslTime = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tslUTC = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZeroAngles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbZoomMinus = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomPlus = new System.Windows.Forms.ToolStripButton();
            this.lbSolDist = new System.Windows.Forms.Label();
            this.pnSolSysHolder = new System.Windows.Forms.Panel();
            this.pbSolSys = new System.Windows.Forms.PictureBox();
            this.pnToolBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbZAxisRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYAxisRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXAxisRotation)).BeginInit();
            this.tsUtils.SuspendLayout();
            this.pnSolSysHolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSolSys)).BeginInit();
            this.SuspendLayout();
            // 
            // tmPlot
            // 
            this.tmPlot.Interval = 1000;
            this.tmPlot.Tick += new System.EventHandler(this.tmPlotTick);
            // 
            // pnToolBox
            // 
            this.pnToolBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnToolBox.Controls.Add(this.lbHint);
            this.pnToolBox.Controls.Add(this.btCopyToClipboard);
            this.pnToolBox.Controls.Add(this.cbKeepAspectRatio);
            this.pnToolBox.Controls.Add(this.tbZAxisRotation);
            this.pnToolBox.Controls.Add(this.lbZAxisRotation);
            this.pnToolBox.Controls.Add(this.tbYAxisRotation);
            this.pnToolBox.Controls.Add(this.lbYAxisRotation);
            this.pnToolBox.Controls.Add(this.tbXAxisRotation);
            this.pnToolBox.Controls.Add(this.lbXAxisRotation);
            this.pnToolBox.Controls.Add(this.cbEartchC);
            this.pnToolBox.Controls.Add(this.cmbZoomPreset);
            this.pnToolBox.Controls.Add(this.btJumpTime);
            this.pnToolBox.Controls.Add(this.lbZoom);
            this.pnToolBox.Controls.Add(this.dtpJumpTime);
            this.pnToolBox.Controls.Add(this.lbJumpToTime);
            this.pnToolBox.Controls.Add(this.cmbTimeSpeedUp);
            this.pnToolBox.Controls.Add(this.lbSpeedTimeSpan);
            this.pnToolBox.Location = new System.Drawing.Point(606, 0);
            this.pnToolBox.Name = "pnToolBox";
            this.pnToolBox.Size = new System.Drawing.Size(349, 600);
            this.pnToolBox.TabIndex = 20;
            // 
            // lbHint
            // 
            this.lbHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbHint.ForeColor = System.Drawing.Color.Green;
            this.lbHint.Location = new System.Drawing.Point(3, 525);
            this.lbHint.Name = "lbHint";
            this.lbHint.Size = new System.Drawing.Size(343, 66);
            this.lbHint.TabIndex = 43;
            this.lbHint.Text = "Hint: use buttons q ,w, e, a, s, d, + and - to adjust zoom and angles";
            this.lbHint.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btCopyToClipboard
            // 
            this.btCopyToClipboard.Location = new System.Drawing.Point(6, 226);
            this.btCopyToClipboard.Name = "btCopyToClipboard";
            this.btCopyToClipboard.Size = new System.Drawing.Size(117, 23);
            this.btCopyToClipboard.TabIndex = 42;
            this.btCopyToClipboard.Text = "Copy to clipboard";
            this.btCopyToClipboard.UseVisualStyleBackColor = true;
            this.btCopyToClipboard.Click += new System.EventHandler(this.btCopyToClipboard_Click);
            // 
            // cbKeepAspectRatio
            // 
            this.cbKeepAspectRatio.AutoSize = true;
            this.cbKeepAspectRatio.Checked = true;
            this.cbKeepAspectRatio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbKeepAspectRatio.Location = new System.Drawing.Point(6, 203);
            this.cbKeepAspectRatio.Name = "cbKeepAspectRatio";
            this.cbKeepAspectRatio.Size = new System.Drawing.Size(109, 17);
            this.cbKeepAspectRatio.TabIndex = 41;
            this.cbKeepAspectRatio.Text = "Keep aspect ratio";
            this.cbKeepAspectRatio.UseVisualStyleBackColor = true;
            this.cbKeepAspectRatio.CheckedChanged += new System.EventHandler(this.cbKeepAspectRatio_CheckedChanged);
            // 
            // tbZAxisRotation
            // 
            this.tbZAxisRotation.AutoSize = false;
            this.tbZAxisRotation.Location = new System.Drawing.Point(123, 173);
            this.tbZAxisRotation.Maximum = 360;
            this.tbZAxisRotation.Name = "tbZAxisRotation";
            this.tbZAxisRotation.Size = new System.Drawing.Size(170, 24);
            this.tbZAxisRotation.TabIndex = 40;
            this.tbZAxisRotation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbZAxisRotation.Scroll += new System.EventHandler(this.axisRotation_Scroll);
            // 
            // lbZAxisRotation
            // 
            this.lbZAxisRotation.AutoSize = true;
            this.lbZAxisRotation.Location = new System.Drawing.Point(3, 173);
            this.lbZAxisRotation.Name = "lbZAxisRotation";
            this.lbZAxisRotation.Size = new System.Drawing.Size(90, 13);
            this.lbZAxisRotation.TabIndex = 39;
            this.lbZAxisRotation.Text = "Z-Axis rotation (°):";
            // 
            // tbYAxisRotation
            // 
            this.tbYAxisRotation.AutoSize = false;
            this.tbYAxisRotation.Location = new System.Drawing.Point(123, 143);
            this.tbYAxisRotation.Maximum = 360;
            this.tbYAxisRotation.Name = "tbYAxisRotation";
            this.tbYAxisRotation.Size = new System.Drawing.Size(170, 24);
            this.tbYAxisRotation.TabIndex = 38;
            this.tbYAxisRotation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbYAxisRotation.Scroll += new System.EventHandler(this.axisRotation_Scroll);
            // 
            // lbYAxisRotation
            // 
            this.lbYAxisRotation.AutoSize = true;
            this.lbYAxisRotation.Location = new System.Drawing.Point(3, 143);
            this.lbYAxisRotation.Name = "lbYAxisRotation";
            this.lbYAxisRotation.Size = new System.Drawing.Size(90, 13);
            this.lbYAxisRotation.TabIndex = 37;
            this.lbYAxisRotation.Text = "Y-Axis rotation (°):";
            // 
            // tbXAxisRotation
            // 
            this.tbXAxisRotation.AutoSize = false;
            this.tbXAxisRotation.Location = new System.Drawing.Point(123, 113);
            this.tbXAxisRotation.Maximum = 360;
            this.tbXAxisRotation.Name = "tbXAxisRotation";
            this.tbXAxisRotation.Size = new System.Drawing.Size(170, 24);
            this.tbXAxisRotation.TabIndex = 36;
            this.tbXAxisRotation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbXAxisRotation.Scroll += new System.EventHandler(this.axisRotation_Scroll);
            // 
            // lbXAxisRotation
            // 
            this.lbXAxisRotation.AutoSize = true;
            this.lbXAxisRotation.Location = new System.Drawing.Point(3, 113);
            this.lbXAxisRotation.Name = "lbXAxisRotation";
            this.lbXAxisRotation.Size = new System.Drawing.Size(90, 13);
            this.lbXAxisRotation.TabIndex = 35;
            this.lbXAxisRotation.Text = "X-Axis rotation (°):";
            // 
            // cbEartchC
            // 
            this.cbEartchC.Location = new System.Drawing.Point(6, 57);
            this.cbEartchC.Name = "cbEartchC";
            this.cbEartchC.Size = new System.Drawing.Size(120, 24);
            this.cbEartchC.TabIndex = 34;
            this.cbEartchC.Text = "Geocentric";
            this.cbEartchC.Click += new System.EventHandler(this.EartchCCheckedChanged);
            // 
            // cmbZoomPreset
            // 
            this.cmbZoomPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbZoomPreset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbZoomPreset.Items.AddRange(new object[] {
            "Sisempi aurinkokunta",
            "Koko aurinkokunta",
            "Maa ja kuu",
            "Maa ja kuu x 2",
            "200 %",
            "300 %",
            "400 %",
            "500 %",
            "600 %",
            "700 %",
            "800 %",
            "900 %",
            "1000 %"});
            this.cmbZoomPreset.Location = new System.Drawing.Point(123, 30);
            this.cmbZoomPreset.Name = "cmbZoomPreset";
            this.cmbZoomPreset.Size = new System.Drawing.Size(121, 21);
            this.cmbZoomPreset.TabIndex = 33;
            this.cmbZoomPreset.SelectedIndexChanged += new System.EventHandler(this.cmbZoomPreset_SelectedIndexChanged);
            // 
            // btJumpTime
            // 
            this.btJumpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btJumpTime.Image = global::SMap.Properties.Resources.time_jump;
            this.btJumpTime.Location = new System.Drawing.Point(313, 87);
            this.btJumpTime.Name = "btJumpTime";
            this.btJumpTime.Size = new System.Drawing.Size(23, 23);
            this.btJumpTime.TabIndex = 31;
            this.btJumpTime.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btJumpTime.Click += new System.EventHandler(this.btJumpTime_Click);
            // 
            // lbZoom
            // 
            this.lbZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbZoom.Location = new System.Drawing.Point(3, 30);
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(120, 13);
            this.lbZoom.TabIndex = 30;
            this.lbZoom.Text = "Zoom:";
            // 
            // dtpJumpTime
            // 
            this.dtpJumpTime.CustomFormat = "dd.MM.yyyy, HH:mm / dddd";
            this.dtpJumpTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpJumpTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJumpTime.Location = new System.Drawing.Point(123, 87);
            this.dtpJumpTime.Name = "dtpJumpTime";
            this.dtpJumpTime.Size = new System.Drawing.Size(184, 20);
            this.dtpJumpTime.TabIndex = 29;
            // 
            // lbJumpToTime
            // 
            this.lbJumpToTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbJumpToTime.Location = new System.Drawing.Point(3, 87);
            this.lbJumpToTime.Name = "lbJumpToTime";
            this.lbJumpToTime.Size = new System.Drawing.Size(120, 13);
            this.lbJumpToTime.TabIndex = 28;
            this.lbJumpToTime.Text = "Jump to time:";
            // 
            // cmbTimeSpeedUp
            // 
            this.cmbTimeSpeedUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimeSpeedUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTimeSpeedUp.Items.AddRange(new object[] {
            "Vuosi",
            "Kuukausi",
            "Päivä",
            "Tunti"});
            this.cmbTimeSpeedUp.Location = new System.Drawing.Point(123, 3);
            this.cmbTimeSpeedUp.Name = "cmbTimeSpeedUp";
            this.cmbTimeSpeedUp.Size = new System.Drawing.Size(121, 21);
            this.cmbTimeSpeedUp.TabIndex = 27;
            // 
            // lbSpeedTimeSpan
            // 
            this.lbSpeedTimeSpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSpeedTimeSpan.Location = new System.Drawing.Point(3, 3);
            this.lbSpeedTimeSpan.Name = "lbSpeedTimeSpan";
            this.lbSpeedTimeSpan.Size = new System.Drawing.Size(120, 13);
            this.lbSpeedTimeSpan.TabIndex = 26;
            this.lbSpeedTimeSpan.Text = "Speed time span:";
            // 
            // tsUtils
            // 
            this.tsUtils.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tsUtils.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStop,
            this.tsbPlay,
            this.tsbFastBackward,
            this.tsbFastForward,
            this.toolStripSeparator3,
            this.tslState,
            this.toolStripSeparator1,
            this.tslTime,
            this.toolStripSeparator2,
            this.tslUTC,
            this.toolStripSeparator4,
            this.tsbZeroAngles,
            this.toolStripSeparator5,
            this.tsbZoomMinus,
            this.tsbZoomPlus});
            this.tsUtils.Location = new System.Drawing.Point(0, 603);
            this.tsUtils.Name = "tsUtils";
            this.tsUtils.Size = new System.Drawing.Size(955, 25);
            this.tsUtils.TabIndex = 21;
            this.tsUtils.Text = "toolStrip1";
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Image = global::SMap.Properties.Resources.play_stop;
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(23, 22);
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tsbPlay
            // 
            this.tsbPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPlay.Image = global::SMap.Properties.Resources.play0;
            this.tsbPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPlay.Name = "tsbPlay";
            this.tsbPlay.Size = new System.Drawing.Size(23, 22);
            this.tsbPlay.Click += new System.EventHandler(this.tsbPlay_Click);
            // 
            // tsbFastBackward
            // 
            this.tsbFastBackward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFastBackward.Image = global::SMap.Properties.Resources.time_back_faster;
            this.tsbFastBackward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFastBackward.Name = "tsbFastBackward";
            this.tsbFastBackward.Size = new System.Drawing.Size(23, 22);
            this.tsbFastBackward.Click += new System.EventHandler(this.tsbFastBackward_Click);
            // 
            // tsbFastForward
            // 
            this.tsbFastForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFastForward.Image = global::SMap.Properties.Resources.time_faster;
            this.tsbFastForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFastForward.Name = "tsbFastForward";
            this.tsbFastForward.Size = new System.Drawing.Size(23, 22);
            this.tsbFastForward.Click += new System.EventHandler(this.tsbFastForward_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tslState
            // 
            this.tslState.AutoSize = false;
            this.tslState.Name = "tslState";
            this.tslState.Size = new System.Drawing.Size(70, 22);
            this.tslState.Text = ">";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tslTime
            // 
            this.tslTime.AutoSize = false;
            this.tslTime.Name = "tslTime";
            this.tslTime.Size = new System.Drawing.Size(150, 22);
            this.tslTime.Text = "Time:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tslUTC
            // 
            this.tslUTC.AutoSize = false;
            this.tslUTC.Name = "tslUTC";
            this.tslUTC.Size = new System.Drawing.Size(150, 22);
            this.tslUTC.Text = "UTC:";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbZeroAngles
            // 
            this.tsbZeroAngles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbZeroAngles.Image = ((System.Drawing.Image)(resources.GetObject("tsbZeroAngles.Image")));
            this.tsbZeroAngles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZeroAngles.Name = "tsbZeroAngles";
            this.tsbZeroAngles.Size = new System.Drawing.Size(72, 22);
            this.tsbZeroAngles.Text = "Zero angles";
            this.tsbZeroAngles.Click += new System.EventHandler(this.tsbZeroAngles_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbZoomMinus
            // 
            this.tsbZoomMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomMinus.Image = global::SMap.Properties.Resources.zoom_minus;
            this.tsbZoomMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomMinus.Name = "tsbZoomMinus";
            this.tsbZoomMinus.Size = new System.Drawing.Size(23, 22);
            this.tsbZoomMinus.Click += new System.EventHandler(this.tsbZoomMinus_Click);
            // 
            // tsbZoomPlus
            // 
            this.tsbZoomPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbZoomPlus.Image = global::SMap.Properties.Resources.zoom_plus;
            this.tsbZoomPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomPlus.Name = "tsbZoomPlus";
            this.tsbZoomPlus.Size = new System.Drawing.Size(23, 22);
            this.tsbZoomPlus.Click += new System.EventHandler(this.tsbZoomPlus_Click);
            // 
            // lbSolDist
            // 
            this.lbSolDist.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbSolDist.AutoSize = true;
            this.lbSolDist.BackColor = System.Drawing.Color.Transparent;
            this.lbSolDist.ForeColor = System.Drawing.Color.White;
            this.lbSolDist.Location = new System.Drawing.Point(12, 578);
            this.lbSolDist.Name = "lbSolDist";
            this.lbSolDist.Size = new System.Drawing.Size(48, 13);
            this.lbSolDist.TabIndex = 22;
            this.lbSolDist.Text = "lbSolDist";
            // 
            // pnSolSysHolder
            // 
            this.pnSolSysHolder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnSolSysHolder.Controls.Add(this.pbSolSys);
            this.pnSolSysHolder.Location = new System.Drawing.Point(0, 0);
            this.pnSolSysHolder.Name = "pnSolSysHolder";
            this.pnSolSysHolder.Size = new System.Drawing.Size(600, 600);
            this.pnSolSysHolder.TabIndex = 23;
            // 
            // pbSolSys
            // 
            this.pbSolSys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSolSys.Location = new System.Drawing.Point(0, 0);
            this.pbSolSys.Name = "pbSolSys";
            this.pbSolSys.Size = new System.Drawing.Size(600, 600);
            this.pbSolSys.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSolSys.TabIndex = 5;
            this.pbSolSys.TabStop = false;
            this.pbSolSys.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseDown);
            this.pbSolSys.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseMove);
            // 
            // SolarSystem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(955, 628);
            this.Controls.Add(this.pnSolSysHolder);
            this.Controls.Add(this.lbSolDist);
            this.Controls.Add(this.pnToolBox);
            this.Controls.Add(this.tsUtils);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SolarSystem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solar system";
            this.ResizeEnd += new System.EventHandler(this.SolarSystem_ResizeEnd);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AurinkokuntaKeyPress);
            this.Resize += new System.EventHandler(this.SolarSystem_Resize);
            this.pnToolBox.ResumeLayout(false);
            this.pnToolBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbZAxisRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbYAxisRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbXAxisRotation)).EndInit();
            this.tsUtils.ResumeLayout(false);
            this.tsUtils.PerformLayout();
            this.pnSolSysHolder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSolSys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private Panel pnToolBox;
        private CheckBox cbEartchC;
        private ComboBox cmbZoomPreset;
        private Button btJumpTime;
        private Label lbZoom;
        private DateTimePicker dtpJumpTime;
        private Label lbJumpToTime;
        private ComboBox cmbTimeSpeedUp;
        private Label lbSpeedTimeSpan;
        private ToolStrip tsUtils;
        private ToolStripButton tsbPlay;
        private ToolStripButton tsbStop;
        private ToolStripButton tsbFastBackward;
        private ToolStripButton tsbFastForward;
        private ToolStripLabel tslState;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel tslTime;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel tslUTC;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton tsbZeroAngles;
        private TrackBar tbZAxisRotation;
        private Label lbZAxisRotation;
        private TrackBar tbYAxisRotation;
        private Label lbYAxisRotation;
        private TrackBar tbXAxisRotation;
        private Label lbXAxisRotation;
        private ToolStripButton tsbZoomMinus;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripButton tsbZoomPlus;
        private Label lbSolDist;
        private Panel pnSolSysHolder;
        private PictureBox pbSolSys;
        private CheckBox cbKeepAspectRatio;
        private Button btCopyToClipboard;
        private Label lbHint;

    }
}

