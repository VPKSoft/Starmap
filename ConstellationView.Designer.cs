using Plotter;
using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
namespace SMap
{
	public partial class ConstellationView
	{
		private System.Windows.Forms.TrackBar tbConstellationAngle;
		private System.Windows.Forms.CheckBox cbMirror;
		private System.Windows.Forms.CheckBox cbHideSNames;
		private System.Windows.Forms.ComboBox cmbConstellations;
		private System.Windows.Forms.PictureBox pbConstellation;
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConstellationView));
            this.pbConstellation = new System.Windows.Forms.PictureBox();
            this.cmbConstellations = new System.Windows.Forms.ComboBox();
            this.cbHideSNames = new System.Windows.Forms.CheckBox();
            this.cbMirror = new System.Windows.Forms.CheckBox();
            this.tbConstellationAngle = new System.Windows.Forms.TrackBar();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnBottom = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbConstellation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbConstellationAngle)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.pnBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbConstellation
            // 
            this.pbConstellation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbConstellation.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pbConstellation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbConstellation.Location = new System.Drawing.Point(3, 30);
            this.pbConstellation.Name = "pbConstellation";
            this.pbConstellation.Size = new System.Drawing.Size(639, 542);
            this.pbConstellation.TabIndex = 0;
            this.pbConstellation.TabStop = false;
            this.pbConstellation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1MouseMove);
            // 
            // cmbConstellations
            // 
            this.cmbConstellations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbConstellations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConstellations.Location = new System.Drawing.Point(3, 3);
            this.cmbConstellations.Name = "cmbConstellations";
            this.cmbConstellations.Size = new System.Drawing.Size(639, 21);
            this.cmbConstellations.TabIndex = 1;
            this.cmbConstellations.SelectedIndexChanged += new System.EventHandler(this.ComboBox1SelectedIndexChanged);
            // 
            // cbHideSNames
            // 
            this.cbHideSNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbHideSNames.Location = new System.Drawing.Point(15, 12);
            this.cbHideSNames.Name = "cbHideSNames";
            this.cbHideSNames.Size = new System.Drawing.Size(136, 24);
            this.cbHideSNames.TabIndex = 3;
            this.cbHideSNames.Text = "Hide star names";
            this.cbHideSNames.CheckedChanged += new System.EventHandler(this.HideSNamesCheckedChanged);
            // 
            // cbMirror
            // 
            this.cbMirror.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbMirror.Location = new System.Drawing.Point(157, 12);
            this.cbMirror.Name = "cbMirror";
            this.cbMirror.Size = new System.Drawing.Size(136, 24);
            this.cbMirror.TabIndex = 5;
            this.cbMirror.Text = "Mirror";
            this.cbMirror.CheckedChanged += new System.EventHandler(this.HideSNamesCheckedChanged);
            // 
            // tbConstellationAngle
            // 
            this.tbConstellationAngle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbConstellationAngle.Location = new System.Drawing.Point(3, 36);
            this.tbConstellationAngle.Maximum = 360;
            this.tbConstellationAngle.Name = "tbConstellationAngle";
            this.tbConstellationAngle.Size = new System.Drawing.Size(633, 45);
            this.tbConstellationAngle.TabIndex = 4;
            this.tbConstellationAngle.TickFrequency = 10;
            this.tbConstellationAngle.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.tbConstellationAngle.Scroll += new System.EventHandler(this.CAngleScroll);
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.cmbConstellations, 0, 0);
            this.tlpMain.Controls.Add(this.pbConstellation, 0, 1);
            this.tlpMain.Controls.Add(this.pnBottom, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(645, 665);
            this.tlpMain.TabIndex = 6;
            // 
            // pnBottom
            // 
            this.pnBottom.Controls.Add(this.tbConstellationAngle);
            this.pnBottom.Controls.Add(this.cbMirror);
            this.pnBottom.Controls.Add(this.cbHideSNames);
            this.pnBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnBottom.Location = new System.Drawing.Point(3, 578);
            this.pnBottom.Name = "pnBottom";
            this.pnBottom.Size = new System.Drawing.Size(639, 84);
            this.pnBottom.TabIndex = 2;
            // 
            // ConstellationView
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(645, 665);
            this.Controls.Add(this.tlpMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "ConstellationView";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Constellations";
            this.Resize += new System.EventHandler(this.ConstellationView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pbConstellation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbConstellationAngle)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.pnBottom.ResumeLayout(false);
            this.pnBottom.PerformLayout();
            this.ResumeLayout(false);

		}

        private TableLayoutPanel tlpMain;
        private Panel pnBottom;
		
	}
}

