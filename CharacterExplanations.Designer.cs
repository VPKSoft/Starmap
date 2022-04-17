using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.IO;
namespace SMap
{
	public partial class CharacterExplanations
	{
		private System.Windows.Forms.Label lbVenus;
		private System.Windows.Forms.Label lbMoon;
		private System.Windows.Forms.Label lbSun;
		private System.Windows.Forms.Label lbJupiter;
		private System.Windows.Forms.Label lbSaturn;
		private System.Windows.Forms.Label lbUranus;
		private System.Windows.Forms.Label lbMercury;
		private System.Windows.Forms.PictureBox pbStellarObjects;
		private System.Windows.Forms.Label lbNeptune;
		private System.Windows.Forms.Label lbMars;
		private System.Windows.Forms.Label lbPluto;
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
            this.lbPluto = new System.Windows.Forms.Label();
            this.lbMars = new System.Windows.Forms.Label();
            this.lbNeptune = new System.Windows.Forms.Label();
            this.pbStellarObjects = new System.Windows.Forms.PictureBox();
            this.lbMercury = new System.Windows.Forms.Label();
            this.lbUranus = new System.Windows.Forms.Label();
            this.lbSaturn = new System.Windows.Forms.Label();
            this.lbJupiter = new System.Windows.Forms.Label();
            this.lbSun = new System.Windows.Forms.Label();
            this.lbMoon = new System.Windows.Forms.Label();
            this.lbVenus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbStellarObjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbPluto
            // 
            this.lbPluto.AutoSize = true;
            this.lbPluto.Location = new System.Drawing.Point(40, 144);
            this.lbPluto.Name = "lbPluto";
            this.lbPluto.Size = new System.Drawing.Size(31, 13);
            this.lbPluto.TabIndex = 10;
            this.lbPluto.Text = "Pluto";
            // 
            // lbMars
            // 
            this.lbMars.AutoSize = true;
            this.lbMars.Location = new System.Drawing.Point(40, 67);
            this.lbMars.Name = "lbMars";
            this.lbMars.Size = new System.Drawing.Size(30, 13);
            this.lbMars.TabIndex = 5;
            this.lbMars.Text = "Mars";
            // 
            // lbNeptune
            // 
            this.lbNeptune.AutoSize = true;
            this.lbNeptune.Location = new System.Drawing.Point(40, 128);
            this.lbNeptune.Name = "lbNeptune";
            this.lbNeptune.Size = new System.Drawing.Size(48, 13);
            this.lbNeptune.TabIndex = 9;
            this.lbNeptune.Text = "Neptune";
            // 
            // pbStellarObjects
            // 
            this.pbStellarObjects.Image = global::SMap.Properties.Resources.all;
            this.pbStellarObjects.Location = new System.Drawing.Point(16, 8);
            this.pbStellarObjects.Name = "pbStellarObjects";
            this.pbStellarObjects.Size = new System.Drawing.Size(16, 152);
            this.pbStellarObjects.TabIndex = 0;
            this.pbStellarObjects.TabStop = false;
            // 
            // lbMercury
            // 
            this.lbMercury.AutoSize = true;
            this.lbMercury.Location = new System.Drawing.Point(40, 37);
            this.lbMercury.Name = "lbMercury";
            this.lbMercury.Size = new System.Drawing.Size(45, 13);
            this.lbMercury.TabIndex = 3;
            this.lbMercury.Text = "Mercury";
            // 
            // lbUranus
            // 
            this.lbUranus.AutoSize = true;
            this.lbUranus.Location = new System.Drawing.Point(40, 112);
            this.lbUranus.Name = "lbUranus";
            this.lbUranus.Size = new System.Drawing.Size(41, 13);
            this.lbUranus.TabIndex = 8;
            this.lbUranus.Text = "Uranus";
            // 
            // lbSaturn
            // 
            this.lbSaturn.AutoSize = true;
            this.lbSaturn.Location = new System.Drawing.Point(40, 97);
            this.lbSaturn.Name = "lbSaturn";
            this.lbSaturn.Size = new System.Drawing.Size(38, 13);
            this.lbSaturn.TabIndex = 7;
            this.lbSaturn.Text = "Saturn";
            // 
            // lbJupiter
            // 
            this.lbJupiter.AutoSize = true;
            this.lbJupiter.Location = new System.Drawing.Point(40, 82);
            this.lbJupiter.Name = "lbJupiter";
            this.lbJupiter.Size = new System.Drawing.Size(38, 13);
            this.lbJupiter.TabIndex = 6;
            this.lbJupiter.Text = "Jupiter";
            // 
            // lbSun
            // 
            this.lbSun.AutoSize = true;
            this.lbSun.Location = new System.Drawing.Point(40, 8);
            this.lbSun.Name = "lbSun";
            this.lbSun.Size = new System.Drawing.Size(26, 13);
            this.lbSun.TabIndex = 1;
            this.lbSun.Text = "Sun";
            // 
            // lbMoon
            // 
            this.lbMoon.AutoSize = true;
            this.lbMoon.Location = new System.Drawing.Point(40, 23);
            this.lbMoon.Name = "lbMoon";
            this.lbMoon.Size = new System.Drawing.Size(34, 13);
            this.lbMoon.TabIndex = 2;
            this.lbMoon.Text = "Moon";
            // 
            // lbVenus
            // 
            this.lbVenus.AutoSize = true;
            this.lbVenus.Location = new System.Drawing.Point(40, 52);
            this.lbVenus.Name = "lbVenus";
            this.lbVenus.Size = new System.Drawing.Size(37, 13);
            this.lbVenus.TabIndex = 4;
            this.lbVenus.Text = "Venus";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SMap.Properties.Resources.all_old;
            this.pictureBox1.Location = new System.Drawing.Point(114, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 152);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // CharacterExplanations
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(142, 166);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbPluto);
            this.Controls.Add(this.lbNeptune);
            this.Controls.Add(this.lbUranus);
            this.Controls.Add(this.lbSaturn);
            this.Controls.Add(this.lbJupiter);
            this.Controls.Add(this.lbMars);
            this.Controls.Add(this.lbVenus);
            this.Controls.Add(this.lbMercury);
            this.Controls.Add(this.lbMoon);
            this.Controls.Add(this.lbSun);
            this.Controls.Add(this.pbStellarObjects);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CharacterExplanations";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Character eplanations";
            this.TopMost = true;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MerkkienSelityksetClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbStellarObjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private PictureBox pictureBox1;
	}
}

