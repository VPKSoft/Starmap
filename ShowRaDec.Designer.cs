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
	public partial class ShowRaDec
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.NumericUpDown nudUseSign;
		private System.Windows.Forms.Label lbDec;
		private System.Windows.Forms.Label lbRA;
		private System.Windows.Forms.Button btShow;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.PictureBox pbSign;
		private System.Windows.Forms.ImageList locationMarks;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Label lbUseSign;
		private System.Windows.Forms.TextBox textBox2;
		private static PictureBox PicBox;
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowRaDec));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbUseSign = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.locationMarks = new System.Windows.Forms.ImageList(this.components);
            this.pbSign = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btShow = new System.Windows.Forms.Button();
            this.lbRA = new System.Windows.Forms.Label();
            this.lbDec = new System.Windows.Forms.Label();
            this.nudUseSign = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pbSign)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUseSign)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(120, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 3;
            // 
            // lbUseSign
            // 
            this.lbUseSign.Location = new System.Drawing.Point(8, 64);
            this.lbUseSign.Name = "lbUseSign";
            this.lbUseSign.Size = new System.Drawing.Size(80, 23);
            this.lbUseSign.TabIndex = 8;
            this.lbUseSign.Text = "Use symbol:";
            // 
            // btOK
            // 
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btOK.Location = new System.Drawing.Point(136, 96);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(72, 23);
            this.btOK.TabIndex = 7;
            this.btOK.Text = "OK";
            this.btOK.Click += new System.EventHandler(this.Button3Click);
            // 
            // locationMarks
            // 
            this.locationMarks.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("locationMarks.ImageStream")));
            this.locationMarks.TransparentColor = System.Drawing.Color.Black;
            this.locationMarks.Images.SetKeyName(0, "custom_symbol1.png");
            this.locationMarks.Images.SetKeyName(1, "custom_symbol2.png");
            this.locationMarks.Images.SetKeyName(2, "custom_symbol3.png");
            this.locationMarks.Images.SetKeyName(3, "custom_symbol4.png");
            this.locationMarks.Images.SetKeyName(4, "custom_symbol5.png");
            // 
            // pbSign
            // 
            this.pbSign.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbSign.Location = new System.Drawing.Point(176, 64);
            this.pbSign.Name = "pbSign";
            this.pbSign.Size = new System.Drawing.Size(21, 21);
            this.pbSign.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbSign.TabIndex = 10;
            this.pbSign.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            // 
            // btShow
            // 
            this.btShow.Location = new System.Drawing.Point(248, 8);
            this.btShow.Name = "btShow";
            this.btShow.Size = new System.Drawing.Size(96, 21);
            this.btShow.TabIndex = 4;
            this.btShow.Text = "Show >>";
            this.btShow.Click += new System.EventHandler(this.Button1Click);
            // 
            // lbRA
            // 
            this.lbRA.Location = new System.Drawing.Point(8, 8);
            this.lbRA.Name = "lbRA";
            this.lbRA.Size = new System.Drawing.Size(100, 23);
            this.lbRA.TabIndex = 0;
            this.lbRA.Text = "Right ascension:";
            // 
            // lbDec
            // 
            this.lbDec.Location = new System.Drawing.Point(120, 8);
            this.lbDec.Name = "lbDec";
            this.lbDec.Size = new System.Drawing.Size(100, 23);
            this.lbDec.TabIndex = 1;
            this.lbDec.Text = "Declination:";
            // 
            // nudUseSign
            // 
            this.nudUseSign.Location = new System.Drawing.Point(96, 64);
            this.nudUseSign.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudUseSign.Name = "nudUseSign";
            this.nudUseSign.Size = new System.Drawing.Size(64, 20);
            this.nudUseSign.TabIndex = 9;
            this.nudUseSign.ValueChanged += new System.EventHandler(this.nudUseSign_ValueChanged);
            // 
            // ShowRaDec
            // 
            this.AcceptButton = this.btOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btOK;
            this.ClientSize = new System.Drawing.Size(354, 128);
            this.Controls.Add(this.pbSign);
            this.Controls.Add(this.nudUseSign);
            this.Controls.Add(this.lbUseSign);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.btShow);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbDec);
            this.Controls.Add(this.lbRA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowRaDec";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Show RA/Dec";
            ((System.ComponentModel.ISupportInitialize)(this.pbSign)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUseSign)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
	}
}

