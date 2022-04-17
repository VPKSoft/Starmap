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
	public partial class Compass
	{
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox ObjRA;
		private System.Windows.Forms.Panel pnObjC;
		private System.Windows.Forms.Label lbObj3;
		private System.Windows.Forms.Label lbObj0;
		private System.Windows.Forms.Label lbObj1;
		private System.Windows.Forms.TextBox ObjName;
		private System.Windows.Forms.Label lbSun0;
		private System.Windows.Forms.Label lbObj4;
		private System.Windows.Forms.Label lbObj5;
		private System.Windows.Forms.GroupBox gbOther;
		private System.Windows.Forms.GroupBox gbSun;
		private System.Windows.Forms.Panel pnMoonC;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.GroupBox gbMoon;
		private System.Windows.Forms.TextBox ObjDec;
		private System.Windows.Forms.Label lbObj2;
		private System.Windows.Forms.Panel pnSunC;
		private System.Windows.Forms.Label lbSun1;
		private System.Windows.Forms.Label lbMoon4;
		private System.Windows.Forms.Label lbMoon5;
		private System.Windows.Forms.Label lbMoon2;
		private System.Windows.Forms.Label lbMoon3;
		private System.Windows.Forms.Label lbMoon0;
		private System.Windows.Forms.Label lbMoon1;
		private System.Windows.Forms.Label lbSun5;
		private System.Windows.Forms.Label lbSun4;
		private System.Windows.Forms.Label lbDec;
		private System.Windows.Forms.Label lbRA;
		private System.Windows.Forms.Label lbName;
		private System.Windows.Forms.PictureBox pbCompass;
		private System.Windows.Forms.Label lbSun3;
		private System.Windows.Forms.Label lbSun2;
		
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.lbSun2 = new System.Windows.Forms.Label();
            this.lbSun3 = new System.Windows.Forms.Label();
            this.pbCompass = new System.Windows.Forms.PictureBox();
            this.lbName = new System.Windows.Forms.Label();
            this.lbRA = new System.Windows.Forms.Label();
            this.lbDec = new System.Windows.Forms.Label();
            this.lbSun4 = new System.Windows.Forms.Label();
            this.lbSun5 = new System.Windows.Forms.Label();
            this.lbMoon1 = new System.Windows.Forms.Label();
            this.lbMoon0 = new System.Windows.Forms.Label();
            this.lbMoon3 = new System.Windows.Forms.Label();
            this.lbMoon2 = new System.Windows.Forms.Label();
            this.lbMoon5 = new System.Windows.Forms.Label();
            this.lbMoon4 = new System.Windows.Forms.Label();
            this.lbSun1 = new System.Windows.Forms.Label();
            this.pnSunC = new System.Windows.Forms.Panel();
            this.lbObj2 = new System.Windows.Forms.Label();
            this.ObjDec = new System.Windows.Forms.TextBox();
            this.gbMoon = new System.Windows.Forms.GroupBox();
            this.pnMoonC = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbSun = new System.Windows.Forms.GroupBox();
            this.lbSun0 = new System.Windows.Forms.Label();
            this.gbOther = new System.Windows.Forms.GroupBox();
            this.lbObj3 = new System.Windows.Forms.Label();
            this.pnObjC = new System.Windows.Forms.Panel();
            this.lbObj5 = new System.Windows.Forms.Label();
            this.lbObj1 = new System.Windows.Forms.Label();
            this.lbObj0 = new System.Windows.Forms.Label();
            this.ObjRA = new System.Windows.Forms.TextBox();
            this.ObjName = new System.Windows.Forms.TextBox();
            this.lbObj4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCompass)).BeginInit();
            this.gbMoon.SuspendLayout();
            this.gbSun.SuspendLayout();
            this.gbOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSun2
            // 
            this.lbSun2.AutoSize = true;
            this.lbSun2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSun2.Location = new System.Drawing.Point(8, 60);
            this.lbSun2.Name = "lbSun2";
            this.lbSun2.Size = new System.Drawing.Size(35, 13);
            this.lbSun2.TabIndex = 2;
            this.lbSun2.Text = "label3";
            // 
            // lbSun3
            // 
            this.lbSun3.AutoSize = true;
            this.lbSun3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSun3.Location = new System.Drawing.Point(8, 82);
            this.lbSun3.Name = "lbSun3";
            this.lbSun3.Size = new System.Drawing.Size(35, 13);
            this.lbSun3.TabIndex = 3;
            this.lbSun3.Text = "label4";
            // 
            // pbCompass
            // 
            this.pbCompass.Location = new System.Drawing.Point(0, 0);
            this.pbCompass.Name = "pbCompass";
            this.pbCompass.Size = new System.Drawing.Size(300, 300);
            this.pbCompass.TabIndex = 0;
            this.pbCompass.TabStop = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.Location = new System.Drawing.Point(8, 24);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(38, 13);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Name:";
            // 
            // lbRA
            // 
            this.lbRA.AutoSize = true;
            this.lbRA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRA.Location = new System.Drawing.Point(8, 48);
            this.lbRA.Name = "lbRA";
            this.lbRA.Size = new System.Drawing.Size(25, 13);
            this.lbRA.TabIndex = 2;
            this.lbRA.Text = "RA:";
            // 
            // lbDec
            // 
            this.lbDec.AutoSize = true;
            this.lbDec.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDec.Location = new System.Drawing.Point(8, 72);
            this.lbDec.Name = "lbDec";
            this.lbDec.Size = new System.Drawing.Size(63, 13);
            this.lbDec.TabIndex = 3;
            this.lbDec.Text = "Declination:";
            // 
            // lbSun4
            // 
            this.lbSun4.AutoSize = true;
            this.lbSun4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSun4.Location = new System.Drawing.Point(8, 104);
            this.lbSun4.Name = "lbSun4";
            this.lbSun4.Size = new System.Drawing.Size(35, 13);
            this.lbSun4.TabIndex = 4;
            this.lbSun4.Text = "label5";
            // 
            // lbSun5
            // 
            this.lbSun5.AutoSize = true;
            this.lbSun5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSun5.Location = new System.Drawing.Point(8, 126);
            this.lbSun5.Name = "lbSun5";
            this.lbSun5.Size = new System.Drawing.Size(117, 13);
            this.lbSun5.TabIndex = 5;
            this.lbSun5.Text = "Sun direction line color:";
            // 
            // lbMoon1
            // 
            this.lbMoon1.AutoSize = true;
            this.lbMoon1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoon1.Location = new System.Drawing.Point(8, 38);
            this.lbMoon1.Name = "lbMoon1";
            this.lbMoon1.Size = new System.Drawing.Size(35, 13);
            this.lbMoon1.TabIndex = 1;
            this.lbMoon1.Text = "label2";
            // 
            // lbMoon0
            // 
            this.lbMoon0.AutoSize = true;
            this.lbMoon0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoon0.Location = new System.Drawing.Point(8, 16);
            this.lbMoon0.Name = "lbMoon0";
            this.lbMoon0.Size = new System.Drawing.Size(35, 13);
            this.lbMoon0.TabIndex = 0;
            this.lbMoon0.Text = "label1";
            // 
            // lbMoon3
            // 
            this.lbMoon3.AutoSize = true;
            this.lbMoon3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoon3.Location = new System.Drawing.Point(8, 82);
            this.lbMoon3.Name = "lbMoon3";
            this.lbMoon3.Size = new System.Drawing.Size(35, 13);
            this.lbMoon3.TabIndex = 3;
            this.lbMoon3.Text = "label4";
            // 
            // lbMoon2
            // 
            this.lbMoon2.AutoSize = true;
            this.lbMoon2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoon2.Location = new System.Drawing.Point(8, 60);
            this.lbMoon2.Name = "lbMoon2";
            this.lbMoon2.Size = new System.Drawing.Size(35, 13);
            this.lbMoon2.TabIndex = 2;
            this.lbMoon2.Text = "label3";
            // 
            // lbMoon5
            // 
            this.lbMoon5.AutoSize = true;
            this.lbMoon5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoon5.Location = new System.Drawing.Point(8, 126);
            this.lbMoon5.Name = "lbMoon5";
            this.lbMoon5.Size = new System.Drawing.Size(125, 13);
            this.lbMoon5.TabIndex = 5;
            this.lbMoon5.Text = "Moon direction line color:";
            // 
            // lbMoon4
            // 
            this.lbMoon4.AutoSize = true;
            this.lbMoon4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoon4.Location = new System.Drawing.Point(8, 104);
            this.lbMoon4.Name = "lbMoon4";
            this.lbMoon4.Size = new System.Drawing.Size(35, 13);
            this.lbMoon4.TabIndex = 4;
            this.lbMoon4.Text = "label5";
            // 
            // lbSun1
            // 
            this.lbSun1.AutoSize = true;
            this.lbSun1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSun1.Location = new System.Drawing.Point(8, 38);
            this.lbSun1.Name = "lbSun1";
            this.lbSun1.Size = new System.Drawing.Size(35, 13);
            this.lbSun1.TabIndex = 1;
            this.lbSun1.Text = "label2";
            // 
            // pnSunC
            // 
            this.pnSunC.BackColor = System.Drawing.Color.Yellow;
            this.pnSunC.Location = new System.Drawing.Point(288, 126);
            this.pnSunC.Name = "pnSunC";
            this.pnSunC.Size = new System.Drawing.Size(48, 16);
            this.pnSunC.TabIndex = 6;
            // 
            // lbObj2
            // 
            this.lbObj2.AutoSize = true;
            this.lbObj2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObj2.Location = new System.Drawing.Point(192, 72);
            this.lbObj2.Name = "lbObj2";
            this.lbObj2.Size = new System.Drawing.Size(35, 13);
            this.lbObj2.TabIndex = 10;
            this.lbObj2.Text = "label4";
            // 
            // ObjDec
            // 
            this.ObjDec.Location = new System.Drawing.Point(72, 72);
            this.ObjDec.Name = "ObjDec";
            this.ObjDec.Size = new System.Drawing.Size(112, 20);
            this.ObjDec.TabIndex = 7;
            this.ObjDec.Text = "-1.20191725";
            // 
            // gbMoon
            // 
            this.gbMoon.Controls.Add(this.pnMoonC);
            this.gbMoon.Controls.Add(this.lbMoon5);
            this.gbMoon.Controls.Add(this.lbMoon4);
            this.gbMoon.Controls.Add(this.lbMoon3);
            this.gbMoon.Controls.Add(this.lbMoon2);
            this.gbMoon.Controls.Add(this.lbMoon1);
            this.gbMoon.Controls.Add(this.lbMoon0);
            this.gbMoon.Location = new System.Drawing.Point(304, 152);
            this.gbMoon.Name = "gbMoon";
            this.gbMoon.Size = new System.Drawing.Size(345, 153);
            this.gbMoon.TabIndex = 2;
            this.gbMoon.TabStop = false;
            this.gbMoon.Text = "Moon";
            // 
            // pnMoonC
            // 
            this.pnMoonC.BackColor = System.Drawing.Color.Gray;
            this.pnMoonC.Location = new System.Drawing.Point(288, 126);
            this.pnMoonC.Name = "pnMoonC";
            this.pnMoonC.Size = new System.Drawing.Size(48, 16);
            this.pnMoonC.TabIndex = 6;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
            // 
            // gbSun
            // 
            this.gbSun.Controls.Add(this.pnSunC);
            this.gbSun.Controls.Add(this.lbSun5);
            this.gbSun.Controls.Add(this.lbSun4);
            this.gbSun.Controls.Add(this.lbSun3);
            this.gbSun.Controls.Add(this.lbSun2);
            this.gbSun.Controls.Add(this.lbSun1);
            this.gbSun.Controls.Add(this.lbSun0);
            this.gbSun.Location = new System.Drawing.Point(304, 0);
            this.gbSun.Name = "gbSun";
            this.gbSun.Size = new System.Drawing.Size(345, 153);
            this.gbSun.TabIndex = 1;
            this.gbSun.TabStop = false;
            this.gbSun.Text = "Sun";
            // 
            // lbSun0
            // 
            this.lbSun0.AutoSize = true;
            this.lbSun0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSun0.Location = new System.Drawing.Point(8, 16);
            this.lbSun0.Name = "lbSun0";
            this.lbSun0.Size = new System.Drawing.Size(35, 13);
            this.lbSun0.TabIndex = 0;
            this.lbSun0.Text = "label1";
            // 
            // gbOther
            // 
            this.gbOther.Controls.Add(this.lbObj3);
            this.gbOther.Controls.Add(this.pnObjC);
            this.gbOther.Controls.Add(this.lbObj5);
            this.gbOther.Controls.Add(this.lbObj2);
            this.gbOther.Controls.Add(this.lbObj1);
            this.gbOther.Controls.Add(this.lbObj0);
            this.gbOther.Controls.Add(this.ObjDec);
            this.gbOther.Controls.Add(this.ObjRA);
            this.gbOther.Controls.Add(this.ObjName);
            this.gbOther.Controls.Add(this.lbObj4);
            this.gbOther.Controls.Add(this.lbDec);
            this.gbOther.Controls.Add(this.lbRA);
            this.gbOther.Controls.Add(this.lbName);
            this.gbOther.Location = new System.Drawing.Point(0, 304);
            this.gbOther.Name = "gbOther";
            this.gbOther.Size = new System.Drawing.Size(649, 121);
            this.gbOther.TabIndex = 3;
            this.gbOther.TabStop = false;
            this.gbOther.Text = "Other object";
            // 
            // lbObj3
            // 
            this.lbObj3.AutoSize = true;
            this.lbObj3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObj3.Location = new System.Drawing.Point(376, 24);
            this.lbObj3.Name = "lbObj3";
            this.lbObj3.Size = new System.Drawing.Size(35, 13);
            this.lbObj3.TabIndex = 13;
            this.lbObj3.Text = "label4";
            // 
            // pnObjC
            // 
            this.pnObjC.BackColor = System.Drawing.Color.DodgerBlue;
            this.pnObjC.Location = new System.Drawing.Point(592, 96);
            this.pnObjC.Name = "pnObjC";
            this.pnObjC.Size = new System.Drawing.Size(48, 16);
            this.pnObjC.TabIndex = 12;
            // 
            // lbObj5
            // 
            this.lbObj5.AutoSize = true;
            this.lbObj5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObj5.Location = new System.Drawing.Point(376, 96);
            this.lbObj5.Name = "lbObj5";
            this.lbObj5.Size = new System.Drawing.Size(97, 13);
            this.lbObj5.TabIndex = 11;
            this.lbObj5.Text = "Direction line color:";
            // 
            // lbObj1
            // 
            this.lbObj1.AutoSize = true;
            this.lbObj1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObj1.Location = new System.Drawing.Point(192, 48);
            this.lbObj1.Name = "lbObj1";
            this.lbObj1.Size = new System.Drawing.Size(35, 13);
            this.lbObj1.TabIndex = 9;
            this.lbObj1.Text = "label4";
            // 
            // lbObj0
            // 
            this.lbObj0.AutoSize = true;
            this.lbObj0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObj0.Location = new System.Drawing.Point(192, 24);
            this.lbObj0.Name = "lbObj0";
            this.lbObj0.Size = new System.Drawing.Size(35, 13);
            this.lbObj0.TabIndex = 8;
            this.lbObj0.Text = "label4";
            // 
            // ObjRA
            // 
            this.ObjRA.Location = new System.Drawing.Point(72, 48);
            this.ObjRA.Name = "ObjRA";
            this.ObjRA.Size = new System.Drawing.Size(112, 20);
            this.ObjRA.TabIndex = 6;
            this.ObjRA.Text = "5.60355904";
            // 
            // ObjName
            // 
            this.ObjName.Location = new System.Drawing.Point(72, 24);
            this.ObjName.Name = "ObjName";
            this.ObjName.Size = new System.Drawing.Size(112, 20);
            this.ObjName.TabIndex = 5;
            this.ObjName.Text = "Alnilam/Epsilon Orion";
            // 
            // lbObj4
            // 
            this.lbObj4.AutoSize = true;
            this.lbObj4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObj4.Location = new System.Drawing.Point(8, 96);
            this.lbObj4.Name = "lbObj4";
            this.lbObj4.Size = new System.Drawing.Size(35, 13);
            this.lbObj4.TabIndex = 4;
            this.lbObj4.Text = "label1";
            // 
            // Compass
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(656, 430);
            this.Controls.Add(this.gbOther);
            this.Controls.Add(this.gbMoon);
            this.Controls.Add(this.gbSun);
            this.Controls.Add(this.pbCompass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Compass";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Compass";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.KompassiClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbCompass)).EndInit();
            this.gbMoon.ResumeLayout(false);
            this.gbMoon.PerformLayout();
            this.gbSun.ResumeLayout(false);
            this.gbSun.PerformLayout();
            this.gbOther.ResumeLayout(false);
            this.gbOther.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
	}
}

