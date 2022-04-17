using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SMap
{
    partial class JumpToTime
    {
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.DateTimePicker dtpJump;

        #region Windows Forms Designer generated code
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.dtpJump = new System.Windows.Forms.DateTimePicker();
            this.btOK = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.lbSiderealTime = new System.Windows.Forms.Label();
            this.lbTime = new System.Windows.Forms.Label();
            this.tbSiederealTime = new System.Windows.Forms.TextBox();
            this.tbSidereal = new System.Windows.Forms.TrackBar();
            this.btCloseHold = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbSidereal)).BeginInit();
            this.SuspendLayout();
            // 
            // dtpJump
            // 
            this.dtpJump.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpJump.CustomFormat = "dd.MM.yyyy, HH:mm / dddd";
            this.dtpJump.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJump.Location = new System.Drawing.Point(121, 12);
            this.dtpJump.Name = "dtpJump";
            this.dtpJump.ShowUpDown = true;
            this.dtpJump.Size = new System.Drawing.Size(252, 20);
            this.dtpJump.TabIndex = 0;
            this.dtpJump.ValueChanged += new System.EventHandler(this.dtpJump_ValueChanged);
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btOK.Location = new System.Drawing.Point(12, 67);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.Button1Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(298, 67);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 2;
            this.btClose.Text = "Close";
            // 
            // lbSiderealTime
            // 
            this.lbSiderealTime.AutoSize = true;
            this.lbSiderealTime.Location = new System.Drawing.Point(12, 41);
            this.lbSiderealTime.Name = "lbSiderealTime";
            this.lbSiderealTime.Size = new System.Drawing.Size(86, 13);
            this.lbSiderealTime.TabIndex = 3;
            this.lbSiderealTime.Text = "Sidereal time (Θ):";
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Location = new System.Drawing.Point(12, 18);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(33, 13);
            this.lbTime.TabIndex = 4;
            this.lbTime.Text = "Time:";
            // 
            // tbSiederealTime
            // 
            this.tbSiederealTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSiederealTime.Location = new System.Drawing.Point(324, 38);
            this.tbSiederealTime.Name = "tbSiederealTime";
            this.tbSiederealTime.Size = new System.Drawing.Size(49, 20);
            this.tbSiederealTime.TabIndex = 6;
            this.tbSiederealTime.TextChanged += new System.EventHandler(this.tbSiederealTime_TextChanged);
            // 
            // tbSidereal
            // 
            this.tbSidereal.AutoSize = false;
            this.tbSidereal.Location = new System.Drawing.Point(121, 38);
            this.tbSidereal.Maximum = 1439;
            this.tbSidereal.Name = "tbSidereal";
            this.tbSidereal.Size = new System.Drawing.Size(197, 20);
            this.tbSidereal.TabIndex = 7;
            this.tbSidereal.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbSidereal.Scroll += new System.EventHandler(this.tbSidereal_Scroll);
            // 
            // btCloseHold
            // 
            this.btCloseHold.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btCloseHold.Location = new System.Drawing.Point(152, 67);
            this.btCloseHold.Name = "btCloseHold";
            this.btCloseHold.Size = new System.Drawing.Size(75, 23);
            this.btCloseHold.TabIndex = 8;
            this.btCloseHold.Text = "Close && Hold";
            this.btCloseHold.UseVisualStyleBackColor = true;
            this.btCloseHold.Click += new System.EventHandler(this.btCloseHold_Click);
            // 
            // JumpToTime
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(385, 102);
            this.Controls.Add(this.btCloseHold);
            this.Controls.Add(this.tbSidereal);
            this.Controls.Add(this.tbSiederealTime);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.lbSiderealTime);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.dtpJump);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "JumpToTime";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Jump to time";
            this.Shown += new System.EventHandler(this.JumpToTime_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tbSidereal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lbSiderealTime;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.TextBox tbSiederealTime;
        private System.Windows.Forms.TrackBar tbSidereal;
        private System.Windows.Forms.Button btCloseHold;
    }
}