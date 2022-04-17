using Stellar;
using Plotter;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.IO;

using ListClasses;
namespace SMap
{
	public partial class BrowseDatabase
	{
		private System.Windows.Forms.Label lbHygInfo11;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label lbCalcsRA06;
		private System.Windows.Forms.Label lbCalcsRA07;
		private System.Windows.Forms.ListBox lbYale5Th;
		private System.Windows.Forms.ListBox lbGliese3rd;
		private System.Windows.Forms.ListBox lbHyv11;
		private System.Windows.Forms.Label lbCalcsDec09;
		private System.Windows.Forms.Label lbCalcsDec10;
		private System.Windows.Forms.Label lbCalcsDec06;
		private System.Windows.Forms.Label lbCalcsDec05;
		private System.Windows.Forms.Label lbCalcsRA08;
		private System.Windows.Forms.Label lbCalcsRA05;
		private System.Windows.Forms.Label lbCalcsDec07;
		private System.Windows.Forms.Label lbCalcsDec08;
		private System.Windows.Forms.Label lbCalcsTime12;
		private System.Windows.Forms.Label lbCalcsTime13;
		private System.Windows.Forms.Label lbCalcsDist04;
		private System.Windows.Forms.TextBox YALE1;
		private System.Windows.Forms.TextBox GLIESE13;
		private System.Windows.Forms.TextBox GLIESE12;
		private System.Windows.Forms.Label lbCalcsTime07;
		private System.Windows.Forms.TextBox GLIESE5;
		private System.Windows.Forms.TextBox GLIESE18;
		private System.Windows.Forms.GroupBox gbYale5thInfo;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.GroupBox gbHMSRAtoRA;
		private System.Windows.Forms.Label lbCalcsTime05;
		private System.Windows.Forms.Label lbYaleInfo08;
		private System.Windows.Forms.Label lbYaleInfo13;
		private System.Windows.Forms.Label lbYaleInfo12;
		private System.Windows.Forms.Label lbCalcsRA02;
		private System.Windows.Forms.Label lbCalcsJ1950to2000_01;
		private System.Windows.Forms.Label lbCalcsRA04;
		private System.Windows.Forms.TextBox distVv;
		private System.Windows.Forms.Label lbCalcsJ1950to2000_03;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lbYaleInfo31;
		private System.Windows.Forms.Label lbCalcsTime11;
		private System.Windows.Forms.Button btHMSRAtoRA;
		private System.Windows.Forms.Button btRAtoHMSRA;
		private System.Windows.Forms.Button btDeclination2;
		private System.Windows.Forms.Button btDeclination1;
		private System.Windows.Forms.TextBox GLIESE3;
		private System.Windows.Forms.Button btJ1950toJ2000;
		private System.Windows.Forms.Label GlieseSL;
		private System.Windows.Forms.TextBox RAHMS1;
		private System.Windows.Forms.TextBox GLIESE4;
		private System.Windows.Forms.TextBox RAHMS0;
		private System.Windows.Forms.TextBox GLIESE6;
		private System.Windows.Forms.TextBox RAHMS2;
		private System.Windows.Forms.TextBox RAHMS3;
		private System.Windows.Forms.TextBox GLIESE1;
		private System.Windows.Forms.TextBox GLIESE2;
		private System.Windows.Forms.TextBox timeYears;
		private System.Windows.Forms.TextBox GLIESE8;
		private System.Windows.Forms.TextBox GLIESE9;
		private System.Windows.Forms.GroupBox gbJ1950toJ2000;
		private System.Windows.Forms.TextBox HMSRA0;
		private System.Windows.Forms.TextBox HMSRA1;
		private System.Windows.Forms.TextBox HMSRA2;
		private System.Windows.Forms.TextBox HMSRA3;
		private System.Windows.Forms.TextBox DMSD0;
		private System.Windows.Forms.TextBox DMSD4;
		private System.Windows.Forms.TabPage tabHYHv11;
		private System.Windows.Forms.TabPage tabCgliese3rd;
		private System.Windows.Forms.TabPage tabYale5ht;
		private System.Windows.Forms.TabPage tabGreekAlphabet;
		private System.Windows.Forms.TabPage tabCalcs;
		private System.Windows.Forms.TabPage tabConstellationAbbrv;
		private System.Windows.Forms.TextBox timeMinutes;
		private System.Windows.Forms.TextBox GlieseS0;
		private System.Windows.Forms.TextBox kmPerMin;
		private System.Windows.Forms.TextBox GLIESE20;
		private System.Windows.Forms.GroupBox gbRAtoHMSRA;
		private System.Windows.Forms.GroupBox gbDeclination2;
		private System.Windows.Forms.GroupBox gbDeclication;
		private System.Windows.Forms.GroupBox gbGliese3rdInfo;
		private System.Windows.Forms.GroupBox gbSearchGliese3rd;
		private System.Windows.Forms.GroupBox gbSearchYale5th;
		private System.Windows.Forms.GroupBox gbSearchHYGv11;
		private System.Windows.Forms.TextBox timeSeconds;
		private System.Windows.Forms.Label lbGlieseInfo09;
		private System.Windows.Forms.TextBox pc;
		private System.Windows.Forms.Label lbGlieseInfo03;
		private System.Windows.Forms.TextBox DMSD3;
		private System.Windows.Forms.TextBox DMSD2;
		private System.Windows.Forms.TextBox DMSD1;
		private System.Windows.Forms.TextBox BJ1;
		private System.Windows.Forms.TextBox BJ0;
		private System.Windows.Forms.TextBox BJ3;
		private System.Windows.Forms.TextBox BJ2;
		private System.Windows.Forms.TextBox AU;
		private System.Windows.Forms.TextBox HYG3;
		private System.Windows.Forms.TextBox HYG2;
		private System.Windows.Forms.TextBox HYG1;
		private System.Windows.Forms.TextBox HYG0;
		private System.Windows.Forms.TextBox HYG7;
		private System.Windows.Forms.Label lbGlieseInfo23;
		private System.Windows.Forms.TextBox HYG5;
		private System.Windows.Forms.TextBox HYG4;
		private System.Windows.Forms.TextBox HYG9;
		private System.Windows.Forms.TextBox HYG8;
		private System.Windows.Forms.Label lbCalcsTime04;
		private System.Windows.Forms.Label lbCalcsDec04;
		private System.Windows.Forms.TextBox vv;
		private System.Windows.Forms.Label lbCalcsJ1950to2000_04;
		private System.Windows.Forms.Label lbCalcsRA01;
		private System.Windows.Forms.ComboBox cmbHygSIndex;
		private System.Windows.Forms.TextBox HYG6;
		private System.Windows.Forms.TextBox timeMonths;
		private System.Windows.Forms.Label lbYaleInfo15;
		private System.Windows.Forms.Label lbCalcsDec01;
		private System.Windows.Forms.Label lbGlieseInfo02;
		private System.Windows.Forms.Label lbGlieseInfo06;
		private System.Windows.Forms.Label lbCalcsDec02;
		private System.Windows.Forms.Label lbGlieseInfo01;
		private System.Windows.Forms.Label lbGlieseInfo11;
		private System.Windows.Forms.Label lbGlieseInfo07;
		private System.Windows.Forms.Label lbGlieseInfo08;
		private System.Windows.Forms.Label lbStarNoHYGv11;
		private System.Windows.Forms.Label lbGlieseInfo05;
		private System.Windows.Forms.TextBox km;
		private System.Windows.Forms.TextBox GLIESE15;
		private System.Windows.Forms.TextBox GLIESE14;
		private System.Windows.Forms.TextBox GLIESE17;
		private System.Windows.Forms.TextBox GLIESE16;
		private System.Windows.Forms.TextBox GLIESE11;
		private System.Windows.Forms.TextBox GLIESE10;
		private System.Windows.Forms.Label lbSearchResultHYGv11;
		private System.Windows.Forms.Label lbStarNoYale5th;
		private System.Windows.Forms.Label lbSearchResultYale5th;
		private System.Windows.Forms.Label lbStarNoGliese3rd;
		private System.Windows.Forms.Label lbSearchResultGliese3rd;
		private System.Windows.Forms.Label lbYaleInfo09;
		private System.Windows.Forms.TextBox GLIESE19;
		private System.Windows.Forms.Label lbYaleInfo07;
		private System.Windows.Forms.TextBox DDMS3;
		private System.Windows.Forms.TextBox DDMS2;
		private System.Windows.Forms.TextBox DDMS1;
		private System.Windows.Forms.TextBox DDMS0;
		private System.Windows.Forms.TextBox YALE6;
		private System.Windows.Forms.TextBox YALE7;
		private System.Windows.Forms.TextBox YALE0;
		private System.Windows.Forms.TextBox DDMS4;
		private System.Windows.Forms.TextBox YALE2;
		private System.Windows.Forms.TextBox YALE3;
		private System.Windows.Forms.TextBox YALE8;
		private System.Windows.Forms.TextBox YALE9;
		private System.Windows.Forms.NumericUpDown nudHYGSNo;
		private System.Windows.Forms.NumericUpDown nudGlieseSNo;
		private System.Windows.Forms.NumericUpDown nudYaleSNo;
		private System.Windows.Forms.TextBox YALE17;
		private System.Windows.Forms.TextBox YALE13;
		private System.Windows.Forms.TextBox YALE12;
		private System.Windows.Forms.TextBox timeHours;
		private System.Windows.Forms.ComboBox cmbGlieseSIndex;
		private System.Windows.Forms.Label lbHygInfo07;
		private System.Windows.Forms.Label lbHygInfo13;
		private System.Windows.Forms.Label lbHygInfo09;
		private System.Windows.Forms.Label lbHygInfo08;
		private System.Windows.Forms.Label lbYaleInfo03;
		private System.Windows.Forms.Label lbYaleInfo06;
		private System.Windows.Forms.Label lbYaleInfo01;
		private System.Windows.Forms.Label lbYaleInfo02;
		private System.Windows.Forms.TextBox YALE4;
		private System.Windows.Forms.Label lbYaleInfo05;
		private System.Windows.Forms.Label lbYaleInfo04;
		private System.Windows.Forms.TextBox HYG12;
		private System.Windows.Forms.TextBox HYG10;
		private System.Windows.Forms.TextBox HYG11;
		private System.Windows.Forms.TextBox kmPerSek;
		private System.Windows.Forms.TextBox GLIESE7;
		private System.Windows.Forms.TextBox GLIESE0;
		private System.Windows.Forms.TextBox GLIESE22;
		private System.Windows.Forms.TextBox GLIESE23;
		private System.Windows.Forms.Label lbGlieseInfo14;
		private System.Windows.Forms.TextBox GLIESE21;
		private System.Windows.Forms.Label lbGlieseInfo12;
		private System.Windows.Forms.Label lbGlieseInfo13;
		private System.Windows.Forms.Label lbGlieseInfo04;
		private System.Windows.Forms.Label lbYaleInfo32;
		private System.Windows.Forms.Label lbGlieseInfo10;
		private System.Windows.Forms.TextBox YaleS1;
		private System.Windows.Forms.TextBox YaleS0;
		private System.Windows.Forms.TextBox YALE16;
		private System.Windows.Forms.TextBox YALE11;
		private System.Windows.Forms.TextBox YALE10;
		private System.Windows.Forms.Label lbGlieseInfo16;
		private System.Windows.Forms.Label lbGlieseInfo17;
		private System.Windows.Forms.Label lbGlieseInfo20;
		private System.Windows.Forms.TextBox kmPerHour;
		private System.Windows.Forms.Label lbGlieseInfo22;
		private System.Windows.Forms.Label lbGlieseInfo24;
		private System.Windows.Forms.Label lbGlieseInfo15;
		private System.Windows.Forms.Label lbGlieseInfo19;
		private System.Windows.Forms.Label lbGlieseInfo18;
		private System.Windows.Forms.Label lbGlieseInfo21;
		private System.Windows.Forms.Label lbCalcsRA03;
		private System.Windows.Forms.TextBox YALE5;
		private System.Windows.Forms.Label lbCalcsDec03;
		private System.Windows.Forms.TextBox HygS0;
		private System.Windows.Forms.TextBox HygS1;
		private System.Windows.Forms.Label lbCalcsJ1950to2000_02;
		private System.Windows.Forms.TextBox distPc;
		private System.Windows.Forms.TextBox distAU;
		private System.Windows.Forms.TextBox YALE15;
		private System.Windows.Forms.TextBox YALE14;
		private System.Windows.Forms.Label lbYaleInfo16;
		private System.Windows.Forms.Label lbYaleInfo18;
		private System.Windows.Forms.Label lbYaleInfo19;
		private System.Windows.Forms.Label lbYaleInfo20;
		private System.Windows.Forms.Label lbYaleInfo17;
		private System.Windows.Forms.Label lbYaleInfo10;
		private System.Windows.Forms.Label lbYaleInfo11;
		private System.Windows.Forms.TextBox YALE19;
		private System.Windows.Forms.TextBox YALE18;
		private System.Windows.Forms.Label lbYaleInfo23;
		private System.Windows.Forms.Label lbYaleInfo14;
		private System.Windows.Forms.Label YaleSL;
		private System.Windows.Forms.Label lbYaleInfo28;
		private System.Windows.Forms.Label lbYaleInfo27;
		private System.Windows.Forms.Label lbYaleInfo24;
		private System.Windows.Forms.Label lbYaleInfo29;
		private System.Windows.Forms.Label lbYaleInfo26;
		private System.Windows.Forms.Label lbYaleInfo25;
		private System.Windows.Forms.Label lbYaleInfo22;
		private System.Windows.Forms.Label lbYaleInfo21;
		private System.Windows.Forms.Label lbYaleInfo30;
		private System.Windows.Forms.Label lbCalcsTime08;
		private System.Windows.Forms.Label lbCalcsTime09;
		private System.Windows.Forms.Label lbCalcsTime06;
		private System.Windows.Forms.Label lbCalcsTime01;
		private System.Windows.Forms.Label lbCalcsTime03;
		private System.Windows.Forms.Label lbCalcsDist01;
		private System.Windows.Forms.Label lbCalcsTime10;
		private System.Windows.Forms.Label lbCalcsTime02;
		private System.Windows.Forms.TextBox YALE28;
		private System.Windows.Forms.Label lbCalcsDist02;
		private System.Windows.Forms.Label lbCalcsDist03;
		private System.Windows.Forms.GroupBox gbHYGv11Info;
		private System.Windows.Forms.TextBox YALE31;
		private System.Windows.Forms.TextBox YALE30;
		private System.Windows.Forms.Label HygSL;
		private System.Windows.Forms.TextBox distKm;
		private System.Windows.Forms.TextBox timeDays;
		private System.Windows.Forms.Label lbHygInfo03;
		private System.Windows.Forms.TextBox GlieseS1;
		private System.Windows.Forms.TextBox YALE26;
		private System.Windows.Forms.TextBox YALE27;
		private System.Windows.Forms.TextBox YALE24;
		private System.Windows.Forms.TextBox YALE25;
		private System.Windows.Forms.TextBox YALE22;
		private System.Windows.Forms.TextBox YALE23;
		private System.Windows.Forms.TextBox YALE20;
		private System.Windows.Forms.TextBox YALE21;
		private System.Windows.Forms.Label lbHygInfo02;
		private System.Windows.Forms.Label lbHygInfo01;
		private System.Windows.Forms.ComboBox cmbYaleSIndex;
		private System.Windows.Forms.Label lbHygInfo12;
		private System.Windows.Forms.Label lbHygInfo06;
		private System.Windows.Forms.Label lbHygInfo05;
		private System.Windows.Forms.Label lbHygInfo04;
		private System.Windows.Forms.TextBox YALE29;
		private System.Windows.Forms.Label lbHygInfo10;


		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrowseDatabase));
            this.lbHygInfo10 = new System.Windows.Forms.Label();
            this.YALE29 = new System.Windows.Forms.TextBox();
            this.lbHygInfo04 = new System.Windows.Forms.Label();
            this.lbHygInfo05 = new System.Windows.Forms.Label();
            this.lbHygInfo06 = new System.Windows.Forms.Label();
            this.lbHygInfo12 = new System.Windows.Forms.Label();
            this.cmbYaleSIndex = new System.Windows.Forms.ComboBox();
            this.lbHygInfo01 = new System.Windows.Forms.Label();
            this.lbHygInfo02 = new System.Windows.Forms.Label();
            this.YALE21 = new System.Windows.Forms.TextBox();
            this.YALE20 = new System.Windows.Forms.TextBox();
            this.YALE23 = new System.Windows.Forms.TextBox();
            this.YALE22 = new System.Windows.Forms.TextBox();
            this.YALE25 = new System.Windows.Forms.TextBox();
            this.YALE24 = new System.Windows.Forms.TextBox();
            this.YALE27 = new System.Windows.Forms.TextBox();
            this.YALE26 = new System.Windows.Forms.TextBox();
            this.GlieseS1 = new System.Windows.Forms.TextBox();
            this.lbHygInfo03 = new System.Windows.Forms.Label();
            this.timeDays = new System.Windows.Forms.TextBox();
            this.distKm = new System.Windows.Forms.TextBox();
            this.HygSL = new System.Windows.Forms.Label();
            this.YALE30 = new System.Windows.Forms.TextBox();
            this.YALE31 = new System.Windows.Forms.TextBox();
            this.gbHYGv11Info = new System.Windows.Forms.GroupBox();
            this.HYG12 = new System.Windows.Forms.TextBox();
            this.HYG11 = new System.Windows.Forms.TextBox();
            this.HYG10 = new System.Windows.Forms.TextBox();
            this.HYG9 = new System.Windows.Forms.TextBox();
            this.HYG8 = new System.Windows.Forms.TextBox();
            this.HYG7 = new System.Windows.Forms.TextBox();
            this.HYG6 = new System.Windows.Forms.TextBox();
            this.HYG5 = new System.Windows.Forms.TextBox();
            this.HYG4 = new System.Windows.Forms.TextBox();
            this.HYG3 = new System.Windows.Forms.TextBox();
            this.HYG2 = new System.Windows.Forms.TextBox();
            this.HYG1 = new System.Windows.Forms.TextBox();
            this.HYG0 = new System.Windows.Forms.TextBox();
            this.lbHygInfo13 = new System.Windows.Forms.Label();
            this.lbHygInfo11 = new System.Windows.Forms.Label();
            this.lbHygInfo09 = new System.Windows.Forms.Label();
            this.lbHygInfo08 = new System.Windows.Forms.Label();
            this.lbHygInfo07 = new System.Windows.Forms.Label();
            this.lbCalcsDist03 = new System.Windows.Forms.Label();
            this.lbCalcsDist02 = new System.Windows.Forms.Label();
            this.YALE28 = new System.Windows.Forms.TextBox();
            this.lbCalcsTime02 = new System.Windows.Forms.Label();
            this.lbCalcsTime10 = new System.Windows.Forms.Label();
            this.lbCalcsDist01 = new System.Windows.Forms.Label();
            this.lbCalcsTime03 = new System.Windows.Forms.Label();
            this.lbCalcsTime01 = new System.Windows.Forms.Label();
            this.lbCalcsTime06 = new System.Windows.Forms.Label();
            this.lbCalcsTime09 = new System.Windows.Forms.Label();
            this.lbCalcsTime08 = new System.Windows.Forms.Label();
            this.lbYaleInfo30 = new System.Windows.Forms.Label();
            this.lbYaleInfo21 = new System.Windows.Forms.Label();
            this.lbYaleInfo22 = new System.Windows.Forms.Label();
            this.lbYaleInfo25 = new System.Windows.Forms.Label();
            this.lbYaleInfo26 = new System.Windows.Forms.Label();
            this.lbYaleInfo29 = new System.Windows.Forms.Label();
            this.lbYaleInfo24 = new System.Windows.Forms.Label();
            this.lbYaleInfo27 = new System.Windows.Forms.Label();
            this.lbYaleInfo28 = new System.Windows.Forms.Label();
            this.YaleSL = new System.Windows.Forms.Label();
            this.lbYaleInfo14 = new System.Windows.Forms.Label();
            this.lbYaleInfo23 = new System.Windows.Forms.Label();
            this.YALE18 = new System.Windows.Forms.TextBox();
            this.YALE19 = new System.Windows.Forms.TextBox();
            this.lbYaleInfo11 = new System.Windows.Forms.Label();
            this.lbYaleInfo10 = new System.Windows.Forms.Label();
            this.lbYaleInfo17 = new System.Windows.Forms.Label();
            this.lbYaleInfo20 = new System.Windows.Forms.Label();
            this.lbYaleInfo19 = new System.Windows.Forms.Label();
            this.lbYaleInfo18 = new System.Windows.Forms.Label();
            this.lbYaleInfo16 = new System.Windows.Forms.Label();
            this.YALE14 = new System.Windows.Forms.TextBox();
            this.YALE15 = new System.Windows.Forms.TextBox();
            this.distAU = new System.Windows.Forms.TextBox();
            this.distPc = new System.Windows.Forms.TextBox();
            this.lbCalcsJ1950to2000_02 = new System.Windows.Forms.Label();
            this.HygS1 = new System.Windows.Forms.TextBox();
            this.HygS0 = new System.Windows.Forms.TextBox();
            this.lbCalcsDec03 = new System.Windows.Forms.Label();
            this.YALE5 = new System.Windows.Forms.TextBox();
            this.lbCalcsRA03 = new System.Windows.Forms.Label();
            this.lbGlieseInfo21 = new System.Windows.Forms.Label();
            this.lbGlieseInfo18 = new System.Windows.Forms.Label();
            this.lbGlieseInfo19 = new System.Windows.Forms.Label();
            this.lbGlieseInfo15 = new System.Windows.Forms.Label();
            this.lbGlieseInfo24 = new System.Windows.Forms.Label();
            this.lbGlieseInfo22 = new System.Windows.Forms.Label();
            this.kmPerHour = new System.Windows.Forms.TextBox();
            this.lbGlieseInfo20 = new System.Windows.Forms.Label();
            this.lbGlieseInfo17 = new System.Windows.Forms.Label();
            this.lbGlieseInfo16 = new System.Windows.Forms.Label();
            this.YALE10 = new System.Windows.Forms.TextBox();
            this.YALE11 = new System.Windows.Forms.TextBox();
            this.YALE16 = new System.Windows.Forms.TextBox();
            this.YaleS0 = new System.Windows.Forms.TextBox();
            this.YaleS1 = new System.Windows.Forms.TextBox();
            this.lbGlieseInfo10 = new System.Windows.Forms.Label();
            this.lbYaleInfo32 = new System.Windows.Forms.Label();
            this.lbGlieseInfo04 = new System.Windows.Forms.Label();
            this.lbGlieseInfo13 = new System.Windows.Forms.Label();
            this.lbGlieseInfo12 = new System.Windows.Forms.Label();
            this.GLIESE21 = new System.Windows.Forms.TextBox();
            this.lbGlieseInfo14 = new System.Windows.Forms.Label();
            this.GLIESE23 = new System.Windows.Forms.TextBox();
            this.GLIESE22 = new System.Windows.Forms.TextBox();
            this.GLIESE0 = new System.Windows.Forms.TextBox();
            this.GLIESE7 = new System.Windows.Forms.TextBox();
            this.kmPerSek = new System.Windows.Forms.TextBox();
            this.lbYaleInfo04 = new System.Windows.Forms.Label();
            this.lbYaleInfo05 = new System.Windows.Forms.Label();
            this.YALE4 = new System.Windows.Forms.TextBox();
            this.lbYaleInfo02 = new System.Windows.Forms.Label();
            this.lbYaleInfo01 = new System.Windows.Forms.Label();
            this.lbYaleInfo06 = new System.Windows.Forms.Label();
            this.lbYaleInfo03 = new System.Windows.Forms.Label();
            this.cmbGlieseSIndex = new System.Windows.Forms.ComboBox();
            this.timeHours = new System.Windows.Forms.TextBox();
            this.YALE12 = new System.Windows.Forms.TextBox();
            this.YALE13 = new System.Windows.Forms.TextBox();
            this.YALE17 = new System.Windows.Forms.TextBox();
            this.nudYaleSNo = new System.Windows.Forms.NumericUpDown();
            this.nudGlieseSNo = new System.Windows.Forms.NumericUpDown();
            this.nudHYGSNo = new System.Windows.Forms.NumericUpDown();
            this.YALE9 = new System.Windows.Forms.TextBox();
            this.YALE8 = new System.Windows.Forms.TextBox();
            this.YALE3 = new System.Windows.Forms.TextBox();
            this.YALE2 = new System.Windows.Forms.TextBox();
            this.DDMS4 = new System.Windows.Forms.TextBox();
            this.YALE0 = new System.Windows.Forms.TextBox();
            this.YALE7 = new System.Windows.Forms.TextBox();
            this.YALE6 = new System.Windows.Forms.TextBox();
            this.DDMS0 = new System.Windows.Forms.TextBox();
            this.DDMS1 = new System.Windows.Forms.TextBox();
            this.DDMS2 = new System.Windows.Forms.TextBox();
            this.DDMS3 = new System.Windows.Forms.TextBox();
            this.lbYaleInfo07 = new System.Windows.Forms.Label();
            this.GLIESE19 = new System.Windows.Forms.TextBox();
            this.lbYaleInfo09 = new System.Windows.Forms.Label();
            this.lbSearchResultGliese3rd = new System.Windows.Forms.Label();
            this.lbStarNoGliese3rd = new System.Windows.Forms.Label();
            this.lbSearchResultYale5th = new System.Windows.Forms.Label();
            this.lbStarNoYale5th = new System.Windows.Forms.Label();
            this.lbSearchResultHYGv11 = new System.Windows.Forms.Label();
            this.GLIESE10 = new System.Windows.Forms.TextBox();
            this.GLIESE11 = new System.Windows.Forms.TextBox();
            this.GLIESE16 = new System.Windows.Forms.TextBox();
            this.GLIESE17 = new System.Windows.Forms.TextBox();
            this.GLIESE14 = new System.Windows.Forms.TextBox();
            this.GLIESE15 = new System.Windows.Forms.TextBox();
            this.km = new System.Windows.Forms.TextBox();
            this.lbGlieseInfo05 = new System.Windows.Forms.Label();
            this.lbStarNoHYGv11 = new System.Windows.Forms.Label();
            this.lbGlieseInfo08 = new System.Windows.Forms.Label();
            this.lbGlieseInfo07 = new System.Windows.Forms.Label();
            this.lbGlieseInfo11 = new System.Windows.Forms.Label();
            this.lbGlieseInfo01 = new System.Windows.Forms.Label();
            this.lbCalcsDec02 = new System.Windows.Forms.Label();
            this.lbGlieseInfo06 = new System.Windows.Forms.Label();
            this.lbGlieseInfo02 = new System.Windows.Forms.Label();
            this.lbCalcsDec01 = new System.Windows.Forms.Label();
            this.lbYaleInfo15 = new System.Windows.Forms.Label();
            this.timeMonths = new System.Windows.Forms.TextBox();
            this.cmbHygSIndex = new System.Windows.Forms.ComboBox();
            this.lbCalcsRA01 = new System.Windows.Forms.Label();
            this.lbCalcsJ1950to2000_04 = new System.Windows.Forms.Label();
            this.vv = new System.Windows.Forms.TextBox();
            this.lbCalcsDec04 = new System.Windows.Forms.Label();
            this.lbCalcsTime04 = new System.Windows.Forms.Label();
            this.lbGlieseInfo23 = new System.Windows.Forms.Label();
            this.AU = new System.Windows.Forms.TextBox();
            this.BJ2 = new System.Windows.Forms.TextBox();
            this.BJ3 = new System.Windows.Forms.TextBox();
            this.BJ0 = new System.Windows.Forms.TextBox();
            this.BJ1 = new System.Windows.Forms.TextBox();
            this.DMSD1 = new System.Windows.Forms.TextBox();
            this.DMSD2 = new System.Windows.Forms.TextBox();
            this.DMSD3 = new System.Windows.Forms.TextBox();
            this.lbGlieseInfo03 = new System.Windows.Forms.Label();
            this.pc = new System.Windows.Forms.TextBox();
            this.lbGlieseInfo09 = new System.Windows.Forms.Label();
            this.timeSeconds = new System.Windows.Forms.TextBox();
            this.gbSearchHYGv11 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gbSearchYale5th = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.gbSearchGliese3rd = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.GlieseSL = new System.Windows.Forms.Label();
            this.GlieseS0 = new System.Windows.Forms.TextBox();
            this.gbGliese3rdInfo = new System.Windows.Forms.GroupBox();
            this.GLIESE20 = new System.Windows.Forms.TextBox();
            this.GLIESE18 = new System.Windows.Forms.TextBox();
            this.GLIESE13 = new System.Windows.Forms.TextBox();
            this.GLIESE12 = new System.Windows.Forms.TextBox();
            this.GLIESE9 = new System.Windows.Forms.TextBox();
            this.GLIESE8 = new System.Windows.Forms.TextBox();
            this.GLIESE4 = new System.Windows.Forms.TextBox();
            this.GLIESE6 = new System.Windows.Forms.TextBox();
            this.GLIESE5 = new System.Windows.Forms.TextBox();
            this.GLIESE3 = new System.Windows.Forms.TextBox();
            this.GLIESE2 = new System.Windows.Forms.TextBox();
            this.GLIESE1 = new System.Windows.Forms.TextBox();
            this.gbDeclication = new System.Windows.Forms.GroupBox();
            this.DMSD4 = new System.Windows.Forms.TextBox();
            this.lbCalcsDec05 = new System.Windows.Forms.Label();
            this.btDeclination1 = new System.Windows.Forms.Button();
            this.DMSD0 = new System.Windows.Forms.TextBox();
            this.gbDeclination2 = new System.Windows.Forms.GroupBox();
            this.lbCalcsDec06 = new System.Windows.Forms.Label();
            this.btDeclination2 = new System.Windows.Forms.Button();
            this.lbCalcsDec10 = new System.Windows.Forms.Label();
            this.lbCalcsDec09 = new System.Windows.Forms.Label();
            this.lbCalcsDec08 = new System.Windows.Forms.Label();
            this.lbCalcsDec07 = new System.Windows.Forms.Label();
            this.gbRAtoHMSRA = new System.Windows.Forms.GroupBox();
            this.RAHMS0 = new System.Windows.Forms.TextBox();
            this.lbCalcsRA05 = new System.Windows.Forms.Label();
            this.btRAtoHMSRA = new System.Windows.Forms.Button();
            this.RAHMS3 = new System.Windows.Forms.TextBox();
            this.lbCalcsRA08 = new System.Windows.Forms.Label();
            this.RAHMS2 = new System.Windows.Forms.TextBox();
            this.lbCalcsRA07 = new System.Windows.Forms.Label();
            this.RAHMS1 = new System.Windows.Forms.TextBox();
            this.lbCalcsRA06 = new System.Windows.Forms.Label();
            this.kmPerMin = new System.Windows.Forms.TextBox();
            this.timeMinutes = new System.Windows.Forms.TextBox();
            this.tabConstellationAbbrv = new System.Windows.Forms.TabPage();
            this.lvConstellations = new System.Windows.Forms.ListView();
            this.colShortName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLongName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabCalcs = new System.Windows.Forms.TabPage();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.lbCalcsDist04 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.lbCalcsTime07 = new System.Windows.Forms.Label();
            this.lbCalcsTime13 = new System.Windows.Forms.Label();
            this.lbCalcsTime12 = new System.Windows.Forms.Label();
            this.lbCalcsTime11 = new System.Windows.Forms.Label();
            this.timeYears = new System.Windows.Forms.TextBox();
            this.distVv = new System.Windows.Forms.TextBox();
            this.lbCalcsTime05 = new System.Windows.Forms.Label();
            this.gbJ1950toJ2000 = new System.Windows.Forms.GroupBox();
            this.lbCalcsJ1950to2000_03 = new System.Windows.Forms.Label();
            this.lbCalcsJ1950to2000_01 = new System.Windows.Forms.Label();
            this.btJ1950toJ2000 = new System.Windows.Forms.Button();
            this.gbHMSRAtoRA = new System.Windows.Forms.GroupBox();
            this.HMSRA3 = new System.Windows.Forms.TextBox();
            this.lbCalcsRA04 = new System.Windows.Forms.Label();
            this.btHMSRAtoRA = new System.Windows.Forms.Button();
            this.HMSRA2 = new System.Windows.Forms.TextBox();
            this.HMSRA1 = new System.Windows.Forms.TextBox();
            this.lbCalcsRA02 = new System.Windows.Forms.Label();
            this.HMSRA0 = new System.Windows.Forms.TextBox();
            this.tabGreekAlphabet = new System.Windows.Forms.TabPage();
            this.lvGreekAlpha = new System.Windows.Forms.ListView();
            this.colUpperLetter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLowerLetter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAbbreviation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabYale5ht = new System.Windows.Forms.TabPage();
            this.lbYale5Th = new System.Windows.Forms.ListBox();
            this.gbYale5thInfo = new System.Windows.Forms.GroupBox();
            this.lbYaleInfo31 = new System.Windows.Forms.Label();
            this.lbYaleInfo13 = new System.Windows.Forms.Label();
            this.lbYaleInfo12 = new System.Windows.Forms.Label();
            this.lbYaleInfo08 = new System.Windows.Forms.Label();
            this.YALE1 = new System.Windows.Forms.TextBox();
            this.tabCgliese3rd = new System.Windows.Forms.TabPage();
            this.lbGliese3rd = new System.Windows.Forms.ListBox();
            this.tabHYHv11 = new System.Windows.Forms.TabPage();
            this.lbHyv11 = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.gbHYGv11Info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYaleSNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGlieseSNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHYGSNo)).BeginInit();
            this.gbSearchHYGv11.SuspendLayout();
            this.gbSearchYale5th.SuspendLayout();
            this.gbSearchGliese3rd.SuspendLayout();
            this.gbGliese3rdInfo.SuspendLayout();
            this.gbDeclication.SuspendLayout();
            this.gbDeclination2.SuspendLayout();
            this.gbRAtoHMSRA.SuspendLayout();
            this.tabConstellationAbbrv.SuspendLayout();
            this.tabCalcs.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.gbJ1950toJ2000.SuspendLayout();
            this.gbHMSRAtoRA.SuspendLayout();
            this.tabGreekAlphabet.SuspendLayout();
            this.tabYale5ht.SuspendLayout();
            this.gbYale5thInfo.SuspendLayout();
            this.tabCgliese3rd.SuspendLayout();
            this.tabHYHv11.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbHygInfo10
            // 
            this.lbHygInfo10.Location = new System.Drawing.Point(8, 232);
            this.lbHygInfo10.Name = "lbHygInfo10";
            this.lbHygInfo10.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo10.TabIndex = 9;
            this.lbHygInfo10.Text = "Mag:";
            // 
            // YALE29
            // 
            this.YALE29.Location = new System.Drawing.Point(72, 312);
            this.YALE29.Name = "YALE29";
            this.YALE29.ReadOnly = true;
            this.YALE29.Size = new System.Drawing.Size(144, 20);
            this.YALE29.TabIndex = 72;
            // 
            // lbHygInfo04
            // 
            this.lbHygInfo04.Location = new System.Drawing.Point(8, 88);
            this.lbHygInfo04.Name = "lbHygInfo04";
            this.lbHygInfo04.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo04.TabIndex = 3;
            this.lbHygInfo04.Text = "Gliese:";
            // 
            // lbHygInfo05
            // 
            this.lbHygInfo05.Location = new System.Drawing.Point(8, 112);
            this.lbHygInfo05.Name = "lbHygInfo05";
            this.lbHygInfo05.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo05.TabIndex = 4;
            this.lbHygInfo05.Text = "BayerFlamsteed:";
            // 
            // lbHygInfo06
            // 
            this.lbHygInfo06.Location = new System.Drawing.Point(8, 136);
            this.lbHygInfo06.Name = "lbHygInfo06";
            this.lbHygInfo06.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo06.TabIndex = 5;
            this.lbHygInfo06.Text = "Ra:";
            // 
            // lbHygInfo12
            // 
            this.lbHygInfo12.Location = new System.Drawing.Point(8, 280);
            this.lbHygInfo12.Name = "lbHygInfo12";
            this.lbHygInfo12.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo12.TabIndex = 11;
            this.lbHygInfo12.Text = "Spectrum:";
            // 
            // cmbYaleSIndex
            // 
            this.cmbYaleSIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbYaleSIndex.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbYaleSIndex.Items.AddRange(new object[] {
            "HR              : Tähden numero",
            "Name            : Nimi (Bayer/Flamsteed)",
            "DM              : ?",
            "HD              : Henry Draper -numero",
            "SAO             : SAO-numero",
            "FK5             : FK5-numero",
            "IRflag          : I, jos tähti on infrapunasäteilyn lähde",
            "RAh1900         : RA, tuntia      / 1900-aikajakso",
            "RAm1900         : RA, minuuttia   / 1900-aikajakso",
            "RAs1900         : RA, sekuntia    / 1900-aikajakso",
            "DE-1900         : Deklinaatio, etumerkki  / 1900-aikajakso",
            "DEd1900         : Deklinaatio, astetta    / 1900-aikajakso",
            "DEm1900         : Deklinaatio, minuuttia  / 1900-aikajakso",
            "DEs1900         : Deklinaatio, sekuntia   / 1900-aikajakso",
            "RAh             : RA, tuntia",
            "RAm             : RA, minuuttia",
            "RAs             : RA, sekuntia",
            "DE-             : Deklinaatio, etumerkki",
            "DEd             : Deklinaatio, astetta",
            "DEm             : Deklinaatio, minuuttia",
            "DEs             : Deklinaatio, sekuntia",
            "GLON            : Galaktinen pituus",
            "GLAT            : Galaktinen leveys",
            "VMag            : Visuaalinen magnitudi",
            "SpType          : Spektrityyppi",
            "pmRA            : Vuotuinen liike (RA)  / J2000,FK5 järjestelmä",
            "pmDE            : Vuotuinen liike (Dekl)/ J2000,FK5 järjestelmä",
            "RadVel          : Heliosentrinen tangentiaalinopeus",
            "n_RadVel        : Kommentit, heliosentrinen tangentiaalinopeus",
            "RotVel          : Pyörimisnopeus",
            "Ra              : Right Ascension",
            "Dec             : Declination"});
            this.cmbYaleSIndex.Location = new System.Drawing.Point(8, 16);
            this.cmbYaleSIndex.Name = "cmbYaleSIndex";
            this.cmbYaleSIndex.Size = new System.Drawing.Size(576, 22);
            this.cmbYaleSIndex.TabIndex = 0;
            this.cmbYaleSIndex.SelectedIndexChanged += new System.EventHandler(this.YaleSIndexSelectedIndexChanged);
            // 
            // lbHygInfo01
            // 
            this.lbHygInfo01.Location = new System.Drawing.Point(8, 16);
            this.lbHygInfo01.Name = "lbHygInfo01";
            this.lbHygInfo01.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo01.TabIndex = 0;
            this.lbHygInfo01.Text = "StarID:";
            // 
            // lbHygInfo02
            // 
            this.lbHygInfo02.Location = new System.Drawing.Point(8, 40);
            this.lbHygInfo02.Name = "lbHygInfo02";
            this.lbHygInfo02.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo02.TabIndex = 1;
            this.lbHygInfo02.Text = "HD:";
            // 
            // YALE21
            // 
            this.YALE21.Location = new System.Drawing.Point(216, 216);
            this.YALE21.Name = "YALE21";
            this.YALE21.ReadOnly = true;
            this.YALE21.Size = new System.Drawing.Size(80, 20);
            this.YALE21.TabIndex = 56;
            // 
            // YALE20
            // 
            this.YALE20.Location = new System.Drawing.Point(72, 216);
            this.YALE20.Name = "YALE20";
            this.YALE20.ReadOnly = true;
            this.YALE20.Size = new System.Drawing.Size(80, 20);
            this.YALE20.TabIndex = 54;
            // 
            // YALE23
            // 
            this.YALE23.Location = new System.Drawing.Point(72, 248);
            this.YALE23.Name = "YALE23";
            this.YALE23.ReadOnly = true;
            this.YALE23.Size = new System.Drawing.Size(80, 20);
            this.YALE23.TabIndex = 60;
            // 
            // YALE22
            // 
            this.YALE22.Location = new System.Drawing.Point(352, 216);
            this.YALE22.Name = "YALE22";
            this.YALE22.ReadOnly = true;
            this.YALE22.Size = new System.Drawing.Size(80, 20);
            this.YALE22.TabIndex = 58;
            // 
            // YALE25
            // 
            this.YALE25.Location = new System.Drawing.Point(352, 248);
            this.YALE25.Name = "YALE25";
            this.YALE25.ReadOnly = true;
            this.YALE25.Size = new System.Drawing.Size(80, 20);
            this.YALE25.TabIndex = 64;
            // 
            // YALE24
            // 
            this.YALE24.Location = new System.Drawing.Point(216, 248);
            this.YALE24.Name = "YALE24";
            this.YALE24.ReadOnly = true;
            this.YALE24.Size = new System.Drawing.Size(80, 20);
            this.YALE24.TabIndex = 62;
            // 
            // YALE27
            // 
            this.YALE27.Location = new System.Drawing.Point(216, 280);
            this.YALE27.Name = "YALE27";
            this.YALE27.ReadOnly = true;
            this.YALE27.Size = new System.Drawing.Size(80, 20);
            this.YALE27.TabIndex = 68;
            // 
            // YALE26
            // 
            this.YALE26.Location = new System.Drawing.Point(72, 280);
            this.YALE26.Name = "YALE26";
            this.YALE26.ReadOnly = true;
            this.YALE26.Size = new System.Drawing.Size(80, 20);
            this.YALE26.TabIndex = 66;
            // 
            // GlieseS1
            // 
            this.GlieseS1.Location = new System.Drawing.Point(408, 48);
            this.GlieseS1.Name = "GlieseS1";
            this.GlieseS1.Size = new System.Drawing.Size(128, 20);
            this.GlieseS1.TabIndex = 2;
            this.GlieseS1.Text = "0";
            this.GlieseS1.Enter += new System.EventHandler(this.GlieseS0Enter);
            // 
            // lbHygInfo03
            // 
            this.lbHygInfo03.Location = new System.Drawing.Point(8, 64);
            this.lbHygInfo03.Name = "lbHygInfo03";
            this.lbHygInfo03.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo03.TabIndex = 2;
            this.lbHygInfo03.Text = "HR:";
            // 
            // timeDays
            // 
            this.timeDays.Location = new System.Drawing.Point(384, 168);
            this.timeDays.Name = "timeDays";
            this.timeDays.ReadOnly = true;
            this.timeDays.Size = new System.Drawing.Size(180, 20);
            this.timeDays.TabIndex = 24;
            // 
            // distKm
            // 
            this.distKm.Location = new System.Drawing.Point(16, 88);
            this.distKm.Name = "distKm";
            this.distKm.Size = new System.Drawing.Size(272, 20);
            this.distKm.TabIndex = 12;
            this.distKm.TextChanged += new System.EventHandler(this.DistKmTextChanged);
            // 
            // HygSL
            // 
            this.HygSL.AutoSize = true;
            this.HygSL.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.HygSL.Location = new System.Drawing.Point(384, 48);
            this.HygSL.Name = "HygSL";
            this.HygSL.Size = new System.Drawing.Size(19, 16);
            this.HygSL.TabIndex = 3;
            this.HygSL.Text = "±";
            // 
            // YALE30
            // 
            this.YALE30.Location = new System.Drawing.Point(288, 312);
            this.YALE30.Name = "YALE30";
            this.YALE30.ReadOnly = true;
            this.YALE30.Size = new System.Drawing.Size(144, 20);
            this.YALE30.TabIndex = 74;
            // 
            // YALE31
            // 
            this.YALE31.Location = new System.Drawing.Point(72, 344);
            this.YALE31.Name = "YALE31";
            this.YALE31.ReadOnly = true;
            this.YALE31.Size = new System.Drawing.Size(144, 20);
            this.YALE31.TabIndex = 76;
            // 
            // gbHYGv11Info
            // 
            this.gbHYGv11Info.Controls.Add(this.HYG12);
            this.gbHYGv11Info.Controls.Add(this.HYG11);
            this.gbHYGv11Info.Controls.Add(this.HYG10);
            this.gbHYGv11Info.Controls.Add(this.HYG9);
            this.gbHYGv11Info.Controls.Add(this.HYG8);
            this.gbHYGv11Info.Controls.Add(this.HYG7);
            this.gbHYGv11Info.Controls.Add(this.HYG6);
            this.gbHYGv11Info.Controls.Add(this.HYG5);
            this.gbHYGv11Info.Controls.Add(this.HYG4);
            this.gbHYGv11Info.Controls.Add(this.HYG3);
            this.gbHYGv11Info.Controls.Add(this.HYG2);
            this.gbHYGv11Info.Controls.Add(this.HYG1);
            this.gbHYGv11Info.Controls.Add(this.HYG0);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo13);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo12);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo11);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo10);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo09);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo08);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo07);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo06);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo05);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo04);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo03);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo02);
            this.gbHYGv11Info.Controls.Add(this.lbHygInfo01);
            this.gbHYGv11Info.Location = new System.Drawing.Point(160, 88);
            this.gbHYGv11Info.Name = "gbHYGv11Info";
            this.gbHYGv11Info.Size = new System.Drawing.Size(440, 376);
            this.gbHYGv11Info.TabIndex = 1;
            this.gbHYGv11Info.TabStop = false;
            this.gbHYGv11Info.Text = "Information";
            this.gbHYGv11Info.Enter += new System.EventHandler(this.GroupBox1Enter);
            // 
            // HYG12
            // 
            this.HYG12.Location = new System.Drawing.Point(120, 304);
            this.HYG12.Name = "HYG12";
            this.HYG12.ReadOnly = true;
            this.HYG12.Size = new System.Drawing.Size(304, 20);
            this.HYG12.TabIndex = 25;
            // 
            // HYG11
            // 
            this.HYG11.Location = new System.Drawing.Point(120, 280);
            this.HYG11.Name = "HYG11";
            this.HYG11.ReadOnly = true;
            this.HYG11.Size = new System.Drawing.Size(304, 20);
            this.HYG11.TabIndex = 24;
            // 
            // HYG10
            // 
            this.HYG10.Location = new System.Drawing.Point(120, 256);
            this.HYG10.Name = "HYG10";
            this.HYG10.ReadOnly = true;
            this.HYG10.Size = new System.Drawing.Size(304, 20);
            this.HYG10.TabIndex = 23;
            // 
            // HYG9
            // 
            this.HYG9.Location = new System.Drawing.Point(120, 232);
            this.HYG9.Name = "HYG9";
            this.HYG9.ReadOnly = true;
            this.HYG9.Size = new System.Drawing.Size(304, 20);
            this.HYG9.TabIndex = 22;
            // 
            // HYG8
            // 
            this.HYG8.Location = new System.Drawing.Point(120, 208);
            this.HYG8.Name = "HYG8";
            this.HYG8.ReadOnly = true;
            this.HYG8.Size = new System.Drawing.Size(304, 20);
            this.HYG8.TabIndex = 21;
            // 
            // HYG7
            // 
            this.HYG7.Location = new System.Drawing.Point(120, 184);
            this.HYG7.Name = "HYG7";
            this.HYG7.ReadOnly = true;
            this.HYG7.Size = new System.Drawing.Size(304, 20);
            this.HYG7.TabIndex = 20;
            // 
            // HYG6
            // 
            this.HYG6.Location = new System.Drawing.Point(120, 160);
            this.HYG6.Name = "HYG6";
            this.HYG6.ReadOnly = true;
            this.HYG6.Size = new System.Drawing.Size(304, 20);
            this.HYG6.TabIndex = 19;
            // 
            // HYG5
            // 
            this.HYG5.Location = new System.Drawing.Point(120, 136);
            this.HYG5.Name = "HYG5";
            this.HYG5.ReadOnly = true;
            this.HYG5.Size = new System.Drawing.Size(304, 20);
            this.HYG5.TabIndex = 18;
            // 
            // HYG4
            // 
            this.HYG4.Location = new System.Drawing.Point(120, 112);
            this.HYG4.Name = "HYG4";
            this.HYG4.ReadOnly = true;
            this.HYG4.Size = new System.Drawing.Size(304, 20);
            this.HYG4.TabIndex = 17;
            // 
            // HYG3
            // 
            this.HYG3.Location = new System.Drawing.Point(120, 88);
            this.HYG3.Name = "HYG3";
            this.HYG3.ReadOnly = true;
            this.HYG3.Size = new System.Drawing.Size(304, 20);
            this.HYG3.TabIndex = 16;
            // 
            // HYG2
            // 
            this.HYG2.Location = new System.Drawing.Point(120, 64);
            this.HYG2.Name = "HYG2";
            this.HYG2.ReadOnly = true;
            this.HYG2.Size = new System.Drawing.Size(304, 20);
            this.HYG2.TabIndex = 15;
            // 
            // HYG1
            // 
            this.HYG1.Location = new System.Drawing.Point(120, 40);
            this.HYG1.Name = "HYG1";
            this.HYG1.ReadOnly = true;
            this.HYG1.Size = new System.Drawing.Size(304, 20);
            this.HYG1.TabIndex = 14;
            // 
            // HYG0
            // 
            this.HYG0.Location = new System.Drawing.Point(120, 16);
            this.HYG0.Name = "HYG0";
            this.HYG0.ReadOnly = true;
            this.HYG0.Size = new System.Drawing.Size(304, 20);
            this.HYG0.TabIndex = 13;
            // 
            // lbHygInfo13
            // 
            this.lbHygInfo13.Location = new System.Drawing.Point(8, 304);
            this.lbHygInfo13.Name = "lbHygInfo13";
            this.lbHygInfo13.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo13.TabIndex = 12;
            this.lbHygInfo13.Text = "ColorIndex:";
            // 
            // lbHygInfo11
            // 
            this.lbHygInfo11.Location = new System.Drawing.Point(8, 256);
            this.lbHygInfo11.Name = "lbHygInfo11";
            this.lbHygInfo11.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo11.TabIndex = 10;
            this.lbHygInfo11.Text = "AbsMag:";
            // 
            // lbHygInfo09
            // 
            this.lbHygInfo09.Location = new System.Drawing.Point(8, 208);
            this.lbHygInfo09.Name = "lbHygInfo09";
            this.lbHygInfo09.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo09.TabIndex = 8;
            this.lbHygInfo09.Text = "Distance:";
            // 
            // lbHygInfo08
            // 
            this.lbHygInfo08.Location = new System.Drawing.Point(8, 184);
            this.lbHygInfo08.Name = "lbHygInfo08";
            this.lbHygInfo08.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo08.TabIndex = 7;
            this.lbHygInfo08.Text = "ProperName:";
            // 
            // lbHygInfo07
            // 
            this.lbHygInfo07.Location = new System.Drawing.Point(8, 160);
            this.lbHygInfo07.Name = "lbHygInfo07";
            this.lbHygInfo07.Size = new System.Drawing.Size(100, 23);
            this.lbHygInfo07.TabIndex = 6;
            this.lbHygInfo07.Text = "Dec:";
            // 
            // lbCalcsDist03
            // 
            this.lbCalcsDist03.AutoSize = true;
            this.lbCalcsDist03.Location = new System.Drawing.Point(8, 80);
            this.lbCalcsDist03.Name = "lbCalcsDist03";
            this.lbCalcsDist03.Size = new System.Drawing.Size(64, 13);
            this.lbCalcsDist03.TabIndex = 12;
            this.lbCalcsDist03.Text = "Parsec (pc):";
            // 
            // lbCalcsDist02
            // 
            this.lbCalcsDist02.AutoSize = true;
            this.lbCalcsDist02.Location = new System.Drawing.Point(8, 48);
            this.lbCalcsDist02.Name = "lbCalcsDist02";
            this.lbCalcsDist02.Size = new System.Drawing.Size(114, 13);
            this.lbCalcsDist02.TabIndex = 11;
            this.lbCalcsDist02.Text = "Astronomical unit (AU):";
            // 
            // YALE28
            // 
            this.YALE28.Location = new System.Drawing.Point(352, 280);
            this.YALE28.Name = "YALE28";
            this.YALE28.ReadOnly = true;
            this.YALE28.Size = new System.Drawing.Size(80, 20);
            this.YALE28.TabIndex = 70;
            // 
            // lbCalcsTime02
            // 
            this.lbCalcsTime02.AutoSize = true;
            this.lbCalcsTime02.Location = new System.Drawing.Point(200, 24);
            this.lbCalcsTime02.Name = "lbCalcsTime02";
            this.lbCalcsTime02.Size = new System.Drawing.Size(82, 13);
            this.lbCalcsTime02.TabIndex = 25;
            this.lbCalcsTime02.Text = "Speed (km/min)";
            // 
            // lbCalcsTime10
            // 
            this.lbCalcsTime10.AutoSize = true;
            this.lbCalcsTime10.Location = new System.Drawing.Point(384, 152);
            this.lbCalcsTime10.Name = "lbCalcsTime10";
            this.lbCalcsTime10.Size = new System.Drawing.Size(61, 13);
            this.lbCalcsTime10.TabIndex = 23;
            this.lbCalcsTime10.Text = "Time (days)";
            // 
            // lbCalcsDist01
            // 
            this.lbCalcsDist01.AutoSize = true;
            this.lbCalcsDist01.Location = new System.Drawing.Point(8, 16);
            this.lbCalcsDist01.Name = "lbCalcsDist01";
            this.lbCalcsDist01.Size = new System.Drawing.Size(77, 13);
            this.lbCalcsDist01.TabIndex = 10;
            this.lbCalcsDist01.Text = "Light years (ly):";
            // 
            // lbCalcsTime03
            // 
            this.lbCalcsTime03.AutoSize = true;
            this.lbCalcsTime03.Location = new System.Drawing.Point(384, 24);
            this.lbCalcsTime03.Name = "lbCalcsTime03";
            this.lbCalcsTime03.Size = new System.Drawing.Size(72, 13);
            this.lbCalcsTime03.TabIndex = 27;
            this.lbCalcsTime03.Text = "Speed (km/h)";
            // 
            // lbCalcsTime01
            // 
            this.lbCalcsTime01.AutoSize = true;
            this.lbCalcsTime01.Location = new System.Drawing.Point(16, 24);
            this.lbCalcsTime01.Name = "lbCalcsTime01";
            this.lbCalcsTime01.Size = new System.Drawing.Size(83, 13);
            this.lbCalcsTime01.TabIndex = 17;
            this.lbCalcsTime01.Text = "Speed (km/sec)";
            // 
            // lbCalcsTime06
            // 
            this.lbCalcsTime06.AutoSize = true;
            this.lbCalcsTime06.Location = new System.Drawing.Point(16, 112);
            this.lbCalcsTime06.Name = "lbCalcsTime06";
            this.lbCalcsTime06.Size = new System.Drawing.Size(76, 13);
            this.lbCalcsTime06.TabIndex = 15;
            this.lbCalcsTime06.Text = "DistanceLy (ly)";
            // 
            // lbCalcsTime09
            // 
            this.lbCalcsTime09.AutoSize = true;
            this.lbCalcsTime09.Location = new System.Drawing.Point(200, 152);
            this.lbCalcsTime09.Name = "lbCalcsTime09";
            this.lbCalcsTime09.Size = new System.Drawing.Size(73, 13);
            this.lbCalcsTime09.TabIndex = 21;
            this.lbCalcsTime09.Text = "Time (months)";
            // 
            // lbCalcsTime08
            // 
            this.lbCalcsTime08.AutoSize = true;
            this.lbCalcsTime08.Location = new System.Drawing.Point(16, 152);
            this.lbCalcsTime08.Name = "lbCalcsTime08";
            this.lbCalcsTime08.Size = new System.Drawing.Size(64, 13);
            this.lbCalcsTime08.TabIndex = 19;
            this.lbCalcsTime08.Text = "Time (years)";
            // 
            // lbYaleInfo30
            // 
            this.lbYaleInfo30.AutoSize = true;
            this.lbYaleInfo30.Location = new System.Drawing.Point(16, 312);
            this.lbYaleInfo30.Name = "lbYaleInfo30";
            this.lbYaleInfo30.Size = new System.Drawing.Size(25, 13);
            this.lbYaleInfo30.TabIndex = 71;
            this.lbYaleInfo30.Text = "RA:";
            // 
            // lbYaleInfo21
            // 
            this.lbYaleInfo21.AutoSize = true;
            this.lbYaleInfo21.Location = new System.Drawing.Point(16, 216);
            this.lbYaleInfo21.Name = "lbYaleInfo21";
            this.lbYaleInfo21.Size = new System.Drawing.Size(40, 13);
            this.lbYaleInfo21.TabIndex = 53;
            this.lbYaleInfo21.Text = "GLON:";
            // 
            // lbYaleInfo22
            // 
            this.lbYaleInfo22.AutoSize = true;
            this.lbYaleInfo22.Location = new System.Drawing.Point(152, 216);
            this.lbYaleInfo22.Name = "lbYaleInfo22";
            this.lbYaleInfo22.Size = new System.Drawing.Size(38, 13);
            this.lbYaleInfo22.TabIndex = 55;
            this.lbYaleInfo22.Text = "GLAT:";
            // 
            // lbYaleInfo25
            // 
            this.lbYaleInfo25.AutoSize = true;
            this.lbYaleInfo25.Location = new System.Drawing.Point(152, 248);
            this.lbYaleInfo25.Name = "lbYaleInfo25";
            this.lbYaleInfo25.Size = new System.Drawing.Size(39, 13);
            this.lbYaleInfo25.TabIndex = 61;
            this.lbYaleInfo25.Text = "pmDE:";
            // 
            // lbYaleInfo26
            // 
            this.lbYaleInfo26.AutoSize = true;
            this.lbYaleInfo26.Location = new System.Drawing.Point(296, 248);
            this.lbYaleInfo26.Name = "lbYaleInfo26";
            this.lbYaleInfo26.Size = new System.Drawing.Size(45, 13);
            this.lbYaleInfo26.TabIndex = 63;
            this.lbYaleInfo26.Text = "RadVel:";
            // 
            // lbYaleInfo29
            // 
            this.lbYaleInfo29.AutoSize = true;
            this.lbYaleInfo29.Location = new System.Drawing.Point(296, 280);
            this.lbYaleInfo29.Name = "lbYaleInfo29";
            this.lbYaleInfo29.Size = new System.Drawing.Size(41, 13);
            this.lbYaleInfo29.TabIndex = 69;
            this.lbYaleInfo29.Text = "IRFlag:";
            // 
            // lbYaleInfo24
            // 
            this.lbYaleInfo24.AutoSize = true;
            this.lbYaleInfo24.Location = new System.Drawing.Point(16, 248);
            this.lbYaleInfo24.Name = "lbYaleInfo24";
            this.lbYaleInfo24.Size = new System.Drawing.Size(39, 13);
            this.lbYaleInfo24.TabIndex = 59;
            this.lbYaleInfo24.Text = "pmRA:";
            // 
            // lbYaleInfo27
            // 
            this.lbYaleInfo27.AutoSize = true;
            this.lbYaleInfo27.Location = new System.Drawing.Point(16, 280);
            this.lbYaleInfo27.Name = "lbYaleInfo27";
            this.lbYaleInfo27.Size = new System.Drawing.Size(57, 13);
            this.lbYaleInfo27.TabIndex = 65;
            this.lbYaleInfo27.Text = "n_RadVel:";
            // 
            // lbYaleInfo28
            // 
            this.lbYaleInfo28.AutoSize = true;
            this.lbYaleInfo28.Location = new System.Drawing.Point(152, 280);
            this.lbYaleInfo28.Name = "lbYaleInfo28";
            this.lbYaleInfo28.Size = new System.Drawing.Size(42, 13);
            this.lbYaleInfo28.TabIndex = 67;
            this.lbYaleInfo28.Text = "RotVel:";
            // 
            // YaleSL
            // 
            this.YaleSL.AutoSize = true;
            this.YaleSL.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.YaleSL.Location = new System.Drawing.Point(384, 48);
            this.YaleSL.Name = "YaleSL";
            this.YaleSL.Size = new System.Drawing.Size(19, 16);
            this.YaleSL.TabIndex = 3;
            this.YaleSL.Text = "±";
            // 
            // lbYaleInfo14
            // 
            this.lbYaleInfo14.AutoSize = true;
            this.lbYaleInfo14.Location = new System.Drawing.Point(16, 152);
            this.lbYaleInfo14.Name = "lbYaleInfo14";
            this.lbYaleInfo14.Size = new System.Drawing.Size(31, 13);
            this.lbYaleInfo14.TabIndex = 39;
            this.lbYaleInfo14.Text = "RAh:";
            // 
            // lbYaleInfo23
            // 
            this.lbYaleInfo23.AutoSize = true;
            this.lbYaleInfo23.Location = new System.Drawing.Point(296, 216);
            this.lbYaleInfo23.Name = "lbYaleInfo23";
            this.lbYaleInfo23.Size = new System.Drawing.Size(37, 13);
            this.lbYaleInfo23.TabIndex = 57;
            this.lbYaleInfo23.Text = "Vmag:";
            // 
            // YALE18
            // 
            this.YALE18.Location = new System.Drawing.Point(280, 184);
            this.YALE18.Name = "YALE18";
            this.YALE18.ReadOnly = true;
            this.YALE18.Size = new System.Drawing.Size(32, 20);
            this.YALE18.TabIndex = 48;
            // 
            // YALE19
            // 
            this.YALE19.Location = new System.Drawing.Point(384, 184);
            this.YALE19.Name = "YALE19";
            this.YALE19.ReadOnly = true;
            this.YALE19.Size = new System.Drawing.Size(32, 20);
            this.YALE19.TabIndex = 50;
            // 
            // lbYaleInfo11
            // 
            this.lbYaleInfo11.AutoSize = true;
            this.lbYaleInfo11.Location = new System.Drawing.Point(120, 112);
            this.lbYaleInfo11.Name = "lbYaleInfo11";
            this.lbYaleInfo11.Size = new System.Drawing.Size(55, 13);
            this.lbYaleInfo11.TabIndex = 31;
            this.lbYaleInfo11.Text = "DEd1900:";
            // 
            // lbYaleInfo10
            // 
            this.lbYaleInfo10.AutoSize = true;
            this.lbYaleInfo10.Location = new System.Drawing.Point(16, 112);
            this.lbYaleInfo10.Name = "lbYaleInfo10";
            this.lbYaleInfo10.Size = new System.Drawing.Size(52, 13);
            this.lbYaleInfo10.TabIndex = 37;
            this.lbYaleInfo10.Text = "DE-1900:";
            // 
            // lbYaleInfo17
            // 
            this.lbYaleInfo17.AutoSize = true;
            this.lbYaleInfo17.Location = new System.Drawing.Point(16, 184);
            this.lbYaleInfo17.Name = "lbYaleInfo17";
            this.lbYaleInfo17.Size = new System.Drawing.Size(28, 13);
            this.lbYaleInfo17.TabIndex = 51;
            this.lbYaleInfo17.Text = "DE-:";
            // 
            // lbYaleInfo20
            // 
            this.lbYaleInfo20.AutoSize = true;
            this.lbYaleInfo20.Location = new System.Drawing.Point(328, 184);
            this.lbYaleInfo20.Name = "lbYaleInfo20";
            this.lbYaleInfo20.Size = new System.Drawing.Size(30, 13);
            this.lbYaleInfo20.TabIndex = 49;
            this.lbYaleInfo20.Text = "DEs:";
            // 
            // lbYaleInfo19
            // 
            this.lbYaleInfo19.AutoSize = true;
            this.lbYaleInfo19.Location = new System.Drawing.Point(224, 184);
            this.lbYaleInfo19.Name = "lbYaleInfo19";
            this.lbYaleInfo19.Size = new System.Drawing.Size(33, 13);
            this.lbYaleInfo19.TabIndex = 47;
            this.lbYaleInfo19.Text = "DEm:";
            // 
            // lbYaleInfo18
            // 
            this.lbYaleInfo18.AutoSize = true;
            this.lbYaleInfo18.Location = new System.Drawing.Point(120, 184);
            this.lbYaleInfo18.Name = "lbYaleInfo18";
            this.lbYaleInfo18.Size = new System.Drawing.Size(31, 13);
            this.lbYaleInfo18.TabIndex = 45;
            this.lbYaleInfo18.Text = "DEd:";
            // 
            // lbYaleInfo16
            // 
            this.lbYaleInfo16.AutoSize = true;
            this.lbYaleInfo16.Location = new System.Drawing.Point(280, 152);
            this.lbYaleInfo16.Name = "lbYaleInfo16";
            this.lbYaleInfo16.Size = new System.Drawing.Size(30, 13);
            this.lbYaleInfo16.TabIndex = 43;
            this.lbYaleInfo16.Text = "RAs:";
            // 
            // YALE14
            // 
            this.YALE14.Location = new System.Drawing.Point(200, 152);
            this.YALE14.Name = "YALE14";
            this.YALE14.ReadOnly = true;
            this.YALE14.Size = new System.Drawing.Size(64, 20);
            this.YALE14.TabIndex = 42;
            // 
            // YALE15
            // 
            this.YALE15.Location = new System.Drawing.Point(336, 152);
            this.YALE15.Name = "YALE15";
            this.YALE15.ReadOnly = true;
            this.YALE15.Size = new System.Drawing.Size(56, 20);
            this.YALE15.TabIndex = 44;
            // 
            // distAU
            // 
            this.distAU.Location = new System.Drawing.Point(296, 128);
            this.distAU.Name = "distAU";
            this.distAU.Size = new System.Drawing.Size(272, 20);
            this.distAU.TabIndex = 36;
            this.distAU.TextChanged += new System.EventHandler(this.DistAUTextChanged);
            // 
            // distPc
            // 
            this.distPc.Location = new System.Drawing.Point(296, 88);
            this.distPc.Name = "distPc";
            this.distPc.Size = new System.Drawing.Size(272, 20);
            this.distPc.TabIndex = 14;
            this.distPc.TextChanged += new System.EventHandler(this.DistPcTextChanged);
            // 
            // lbCalcsJ1950to2000_02
            // 
            this.lbCalcsJ1950to2000_02.AutoSize = true;
            this.lbCalcsJ1950to2000_02.Location = new System.Drawing.Point(240, 24);
            this.lbCalcsJ1950to2000_02.Name = "lbCalcsJ1950to2000_02";
            this.lbCalcsJ1950to2000_02.Size = new System.Drawing.Size(96, 13);
            this.lbCalcsJ1950to2000_02.TabIndex = 12;
            this.lbCalcsJ1950to2000_02.Text = "declination (J2000)";
            // 
            // HygS1
            // 
            this.HygS1.Location = new System.Drawing.Point(408, 48);
            this.HygS1.Name = "HygS1";
            this.HygS1.Size = new System.Drawing.Size(128, 20);
            this.HygS1.TabIndex = 2;
            this.HygS1.Text = "0";
            this.HygS1.Enter += new System.EventHandler(this.HygS0Enter);
            // 
            // HygS0
            // 
            this.HygS0.Location = new System.Drawing.Point(8, 48);
            this.HygS0.Name = "HygS0";
            this.HygS0.Size = new System.Drawing.Size(368, 20);
            this.HygS0.TabIndex = 1;
            this.HygS0.Enter += new System.EventHandler(this.HygS0Enter);
            // 
            // lbCalcsDec03
            // 
            this.lbCalcsDec03.AutoSize = true;
            this.lbCalcsDec03.Location = new System.Drawing.Point(96, 24);
            this.lbCalcsDec03.Name = "lbCalcsDec03";
            this.lbCalcsDec03.Size = new System.Drawing.Size(15, 13);
            this.lbCalcsDec03.TabIndex = 4;
            this.lbCalcsDec03.Text = "m";
            // 
            // YALE5
            // 
            this.YALE5.Location = new System.Drawing.Point(352, 48);
            this.YALE5.Name = "YALE5";
            this.YALE5.ReadOnly = true;
            this.YALE5.Size = new System.Drawing.Size(80, 20);
            this.YALE5.TabIndex = 24;
            // 
            // lbCalcsRA03
            // 
            this.lbCalcsRA03.AutoSize = true;
            this.lbCalcsRA03.Location = new System.Drawing.Point(96, 24);
            this.lbCalcsRA03.Name = "lbCalcsRA03";
            this.lbCalcsRA03.Size = new System.Drawing.Size(12, 13);
            this.lbCalcsRA03.TabIndex = 6;
            this.lbCalcsRA03.Text = "s";
            // 
            // lbGlieseInfo21
            // 
            this.lbGlieseInfo21.AutoSize = true;
            this.lbGlieseInfo21.Location = new System.Drawing.Point(232, 240);
            this.lbGlieseInfo21.Name = "lbGlieseInfo21";
            this.lbGlieseInfo21.Size = new System.Drawing.Size(36, 13);
            this.lbGlieseInfo21.TabIndex = 91;
            this.lbGlieseInfo21.Text = "Other:";
            // 
            // lbGlieseInfo18
            // 
            this.lbGlieseInfo18.AutoSize = true;
            this.lbGlieseInfo18.Location = new System.Drawing.Point(16, 208);
            this.lbGlieseInfo18.Name = "lbGlieseInfo18";
            this.lbGlieseInfo18.Size = new System.Drawing.Size(27, 13);
            this.lbGlieseInfo18.TabIndex = 85;
            this.lbGlieseInfo18.Text = "DM:";
            // 
            // lbGlieseInfo19
            // 
            this.lbGlieseInfo19.AutoSize = true;
            this.lbGlieseInfo19.Location = new System.Drawing.Point(232, 208);
            this.lbGlieseInfo19.Name = "lbGlieseInfo19";
            this.lbGlieseInfo19.Size = new System.Drawing.Size(39, 13);
            this.lbGlieseInfo19.TabIndex = 87;
            this.lbGlieseInfo19.Text = "Giclas:";
            // 
            // lbGlieseInfo15
            // 
            this.lbGlieseInfo15.AutoSize = true;
            this.lbGlieseInfo15.Location = new System.Drawing.Point(16, 178);
            this.lbGlieseInfo15.Name = "lbGlieseInfo15";
            this.lbGlieseInfo15.Size = new System.Drawing.Size(18, 13);
            this.lbGlieseInfo15.TabIndex = 79;
            this.lbGlieseInfo15.Text = "U:";
            // 
            // lbGlieseInfo24
            // 
            this.lbGlieseInfo24.AutoSize = true;
            this.lbGlieseInfo24.Location = new System.Drawing.Point(16, 304);
            this.lbGlieseInfo24.Name = "lbGlieseInfo24";
            this.lbGlieseInfo24.Size = new System.Drawing.Size(52, 13);
            this.lbGlieseInfo24.TabIndex = 97;
            this.lbGlieseInfo24.Text = "Remarks:";
            // 
            // lbGlieseInfo22
            // 
            this.lbGlieseInfo22.AutoSize = true;
            this.lbGlieseInfo22.Location = new System.Drawing.Point(16, 272);
            this.lbGlieseInfo22.Name = "lbGlieseInfo22";
            this.lbGlieseInfo22.Size = new System.Drawing.Size(25, 13);
            this.lbGlieseInfo22.TabIndex = 93;
            this.lbGlieseInfo22.Text = "RA:";
            // 
            // kmPerHour
            // 
            this.kmPerHour.Location = new System.Drawing.Point(384, 40);
            this.kmPerHour.Name = "kmPerHour";
            this.kmPerHour.Size = new System.Drawing.Size(180, 20);
            this.kmPerHour.TabIndex = 28;
            this.kmPerHour.TextChanged += new System.EventHandler(this.KmPerHourTextChanged);
            // 
            // lbGlieseInfo20
            // 
            this.lbGlieseInfo20.AutoSize = true;
            this.lbGlieseInfo20.Location = new System.Drawing.Point(16, 240);
            this.lbGlieseInfo20.Name = "lbGlieseInfo20";
            this.lbGlieseInfo20.Size = new System.Drawing.Size(31, 13);
            this.lbGlieseInfo20.TabIndex = 89;
            this.lbGlieseInfo20.Text = "LHS:";
            // 
            // lbGlieseInfo17
            // 
            this.lbGlieseInfo17.AutoSize = true;
            this.lbGlieseInfo17.Location = new System.Drawing.Point(296, 178);
            this.lbGlieseInfo17.Name = "lbGlieseInfo17";
            this.lbGlieseInfo17.Size = new System.Drawing.Size(26, 13);
            this.lbGlieseInfo17.TabIndex = 83;
            this.lbGlieseInfo17.Text = "HD:";
            // 
            // lbGlieseInfo16
            // 
            this.lbGlieseInfo16.AutoSize = true;
            this.lbGlieseInfo16.Location = new System.Drawing.Point(152, 178);
            this.lbGlieseInfo16.Name = "lbGlieseInfo16";
            this.lbGlieseInfo16.Size = new System.Drawing.Size(21, 13);
            this.lbGlieseInfo16.TabIndex = 81;
            this.lbGlieseInfo16.Text = "W:";
            // 
            // YALE10
            // 
            this.YALE10.Location = new System.Drawing.Point(176, 112);
            this.YALE10.Name = "YALE10";
            this.YALE10.ReadOnly = true;
            this.YALE10.Size = new System.Drawing.Size(32, 20);
            this.YALE10.TabIndex = 32;
            // 
            // YALE11
            // 
            this.YALE11.Location = new System.Drawing.Point(280, 112);
            this.YALE11.Name = "YALE11";
            this.YALE11.ReadOnly = true;
            this.YALE11.Size = new System.Drawing.Size(32, 20);
            this.YALE11.TabIndex = 34;
            // 
            // YALE16
            // 
            this.YALE16.Location = new System.Drawing.Point(72, 184);
            this.YALE16.Name = "YALE16";
            this.YALE16.ReadOnly = true;
            this.YALE16.Size = new System.Drawing.Size(32, 20);
            this.YALE16.TabIndex = 52;
            // 
            // YaleS0
            // 
            this.YaleS0.Location = new System.Drawing.Point(8, 48);
            this.YaleS0.Name = "YaleS0";
            this.YaleS0.Size = new System.Drawing.Size(368, 20);
            this.YaleS0.TabIndex = 1;
            this.YaleS0.Enter += new System.EventHandler(this.YaleS0Enter);
            // 
            // YaleS1
            // 
            this.YaleS1.Location = new System.Drawing.Point(408, 48);
            this.YaleS1.Name = "YaleS1";
            this.YaleS1.Size = new System.Drawing.Size(128, 20);
            this.YaleS1.TabIndex = 2;
            this.YaleS1.Text = "0";
            this.YaleS1.Enter += new System.EventHandler(this.YaleS0Enter);
            // 
            // lbGlieseInfo10
            // 
            this.lbGlieseInfo10.AutoSize = true;
            this.lbGlieseInfo10.Location = new System.Drawing.Point(152, 112);
            this.lbGlieseInfo10.Name = "lbGlieseInfo10";
            this.lbGlieseInfo10.Size = new System.Drawing.Size(38, 13);
            this.lbGlieseInfo10.TabIndex = 69;
            this.lbGlieseInfo10.Text = "pmPA:";
            // 
            // lbYaleInfo32
            // 
            this.lbYaleInfo32.AutoSize = true;
            this.lbYaleInfo32.Location = new System.Drawing.Point(16, 344);
            this.lbYaleInfo32.Name = "lbYaleInfo32";
            this.lbYaleInfo32.Size = new System.Drawing.Size(47, 13);
            this.lbYaleInfo32.TabIndex = 75;
            this.lbYaleInfo32.Text = "SpType:";
            // 
            // lbGlieseInfo04
            // 
            this.lbGlieseInfo04.AutoSize = true;
            this.lbGlieseInfo04.Location = new System.Drawing.Point(144, 48);
            this.lbGlieseInfo04.Name = "lbGlieseInfo04";
            this.lbGlieseInfo04.Size = new System.Drawing.Size(33, 13);
            this.lbGlieseInfo04.TabIndex = 55;
            this.lbGlieseInfo04.Text = "RAm:";
            // 
            // lbGlieseInfo13
            // 
            this.lbGlieseInfo13.AutoSize = true;
            this.lbGlieseInfo13.Location = new System.Drawing.Point(152, 144);
            this.lbGlieseInfo13.Name = "lbGlieseInfo13";
            this.lbGlieseInfo13.Size = new System.Drawing.Size(17, 13);
            this.lbGlieseInfo13.TabIndex = 75;
            this.lbGlieseInfo13.Text = "V:";
            // 
            // lbGlieseInfo12
            // 
            this.lbGlieseInfo12.AutoSize = true;
            this.lbGlieseInfo12.Location = new System.Drawing.Point(16, 144);
            this.lbGlieseInfo12.Name = "lbGlieseInfo12";
            this.lbGlieseInfo12.Size = new System.Drawing.Size(23, 13);
            this.lbGlieseInfo12.TabIndex = 73;
            this.lbGlieseInfo12.Text = "Sp:";
            // 
            // GLIESE21
            // 
            this.GLIESE21.Location = new System.Drawing.Point(288, 272);
            this.GLIESE21.Name = "GLIESE21";
            this.GLIESE21.ReadOnly = true;
            this.GLIESE21.Size = new System.Drawing.Size(144, 20);
            this.GLIESE21.TabIndex = 96;
            // 
            // lbGlieseInfo14
            // 
            this.lbGlieseInfo14.AutoSize = true;
            this.lbGlieseInfo14.Location = new System.Drawing.Point(296, 144);
            this.lbGlieseInfo14.Name = "lbGlieseInfo14";
            this.lbGlieseInfo14.Size = new System.Drawing.Size(25, 13);
            this.lbGlieseInfo14.TabIndex = 77;
            this.lbGlieseInfo14.Text = "Mv:";
            // 
            // GLIESE23
            // 
            this.GLIESE23.Location = new System.Drawing.Point(336, 16);
            this.GLIESE23.Name = "GLIESE23";
            this.GLIESE23.ReadOnly = true;
            this.GLIESE23.Size = new System.Drawing.Size(56, 20);
            this.GLIESE23.TabIndex = 100;
            // 
            // GLIESE22
            // 
            this.GLIESE22.Location = new System.Drawing.Point(72, 304);
            this.GLIESE22.Name = "GLIESE22";
            this.GLIESE22.ReadOnly = true;
            this.GLIESE22.Size = new System.Drawing.Size(360, 20);
            this.GLIESE22.TabIndex = 98;
            // 
            // GLIESE0
            // 
            this.GLIESE0.Location = new System.Drawing.Point(72, 16);
            this.GLIESE0.Name = "GLIESE0";
            this.GLIESE0.ReadOnly = true;
            this.GLIESE0.Size = new System.Drawing.Size(144, 20);
            this.GLIESE0.TabIndex = 20;
            // 
            // GLIESE7
            // 
            this.GLIESE7.Location = new System.Drawing.Point(72, 112);
            this.GLIESE7.Name = "GLIESE7";
            this.GLIESE7.ReadOnly = true;
            this.GLIESE7.Size = new System.Drawing.Size(80, 20);
            this.GLIESE7.TabIndex = 68;
            // 
            // kmPerSek
            // 
            this.kmPerSek.Location = new System.Drawing.Point(16, 40);
            this.kmPerSek.Name = "kmPerSek";
            this.kmPerSek.Size = new System.Drawing.Size(180, 20);
            this.kmPerSek.TabIndex = 18;
            this.kmPerSek.TextChanged += new System.EventHandler(this.KmPerSekTextChanged);
            // 
            // lbYaleInfo04
            // 
            this.lbYaleInfo04.AutoSize = true;
            this.lbYaleInfo04.Location = new System.Drawing.Point(16, 48);
            this.lbYaleInfo04.Name = "lbYaleInfo04";
            this.lbYaleInfo04.Size = new System.Drawing.Size(26, 13);
            this.lbYaleInfo04.TabIndex = 19;
            this.lbYaleInfo04.Text = "HD:";
            // 
            // lbYaleInfo05
            // 
            this.lbYaleInfo05.AutoSize = true;
            this.lbYaleInfo05.Location = new System.Drawing.Point(152, 48);
            this.lbYaleInfo05.Name = "lbYaleInfo05";
            this.lbYaleInfo05.Size = new System.Drawing.Size(32, 13);
            this.lbYaleInfo05.TabIndex = 21;
            this.lbYaleInfo05.Text = "SAO:";
            // 
            // YALE4
            // 
            this.YALE4.Location = new System.Drawing.Point(216, 48);
            this.YALE4.Name = "YALE4";
            this.YALE4.ReadOnly = true;
            this.YALE4.Size = new System.Drawing.Size(80, 20);
            this.YALE4.TabIndex = 22;
            // 
            // lbYaleInfo02
            // 
            this.lbYaleInfo02.AutoSize = true;
            this.lbYaleInfo02.Location = new System.Drawing.Point(152, 16);
            this.lbYaleInfo02.Name = "lbYaleInfo02";
            this.lbYaleInfo02.Size = new System.Drawing.Size(38, 13);
            this.lbYaleInfo02.TabIndex = 15;
            this.lbYaleInfo02.Text = "Name:";
            // 
            // lbYaleInfo01
            // 
            this.lbYaleInfo01.AutoSize = true;
            this.lbYaleInfo01.Location = new System.Drawing.Point(16, 16);
            this.lbYaleInfo01.Name = "lbYaleInfo01";
            this.lbYaleInfo01.Size = new System.Drawing.Size(26, 13);
            this.lbYaleInfo01.TabIndex = 1;
            this.lbYaleInfo01.Text = "HR:";
            // 
            // lbYaleInfo06
            // 
            this.lbYaleInfo06.AutoSize = true;
            this.lbYaleInfo06.Location = new System.Drawing.Point(296, 48);
            this.lbYaleInfo06.Name = "lbYaleInfo06";
            this.lbYaleInfo06.Size = new System.Drawing.Size(29, 13);
            this.lbYaleInfo06.TabIndex = 23;
            this.lbYaleInfo06.Text = "FK5:";
            // 
            // lbYaleInfo03
            // 
            this.lbYaleInfo03.AutoSize = true;
            this.lbYaleInfo03.Location = new System.Drawing.Point(296, 16);
            this.lbYaleInfo03.Name = "lbYaleInfo03";
            this.lbYaleInfo03.Size = new System.Drawing.Size(27, 13);
            this.lbYaleInfo03.TabIndex = 17;
            this.lbYaleInfo03.Text = "DM:";
            // 
            // cmbGlieseSIndex
            // 
            this.cmbGlieseSIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGlieseSIndex.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGlieseSIndex.Items.AddRange(new object[] {
            "Ident           : Tunniste",
            "RAh             : RA, tuntia    / B1950",
            "RAm             : RA, minuuttia / B1950",
            "RAs             : RA, sekuntia  / B1950",
            "DE-             : Etumerkki, deklinaatio",
            "DEd             : Deklinaatio, astetta    / B1950",
            "DEm             : Deklinaatio, minuuttia  / B1950",
            "pm              : Liike arcsek/vuosi ?",
            "pmPA            : Pm:n suuntakulma",
            "RV              : Tangentaalinopeus",
            "Sp              : Spekrityyppi tai väriluokka",
            "Vmag            : Näennäinen magnitudi",
            "Mv              : Absoluuttinen magnitudi",
            "U               : Nopeuskomp. galaktisella tasolla gal. keskustan suuntaan       " +
                " (km/sek)",
            "V               : Nopeuskomp. galaktisella tasolla gal. pyörimisliikkeen suuntaan" +
                " (km/sek)",
            "W               : Nopeuskomp. galaktisella tasolla gal. pohjoisnavan suuntaan    " +
                " (km/sek)",
            "HD              : Määritys",
            "DM              : ?",
            "Giclas          : Numero",
            "LHS             : Numero",
            "Other           : Muuta",
            "Remarks         : Lisätietoja",
            "RA              : Ra            / B1950",
            "Dec             : Deklinaatio   / B1950"});
            this.cmbGlieseSIndex.Location = new System.Drawing.Point(8, 16);
            this.cmbGlieseSIndex.Name = "cmbGlieseSIndex";
            this.cmbGlieseSIndex.Size = new System.Drawing.Size(576, 22);
            this.cmbGlieseSIndex.TabIndex = 0;
            this.cmbGlieseSIndex.SelectedIndexChanged += new System.EventHandler(this.GlieseSIndexSelectedIndexChanged);
            // 
            // timeHours
            // 
            this.timeHours.Location = new System.Drawing.Point(16, 216);
            this.timeHours.Name = "timeHours";
            this.timeHours.ReadOnly = true;
            this.timeHours.Size = new System.Drawing.Size(180, 20);
            this.timeHours.TabIndex = 30;
            // 
            // YALE12
            // 
            this.YALE12.Location = new System.Drawing.Point(384, 112);
            this.YALE12.Name = "YALE12";
            this.YALE12.ReadOnly = true;
            this.YALE12.Size = new System.Drawing.Size(32, 20);
            this.YALE12.TabIndex = 36;
            // 
            // YALE13
            // 
            this.YALE13.Location = new System.Drawing.Point(72, 152);
            this.YALE13.Name = "YALE13";
            this.YALE13.ReadOnly = true;
            this.YALE13.Size = new System.Drawing.Size(56, 20);
            this.YALE13.TabIndex = 40;
            // 
            // YALE17
            // 
            this.YALE17.Location = new System.Drawing.Point(176, 184);
            this.YALE17.Name = "YALE17";
            this.YALE17.ReadOnly = true;
            this.YALE17.Size = new System.Drawing.Size(32, 20);
            this.YALE17.TabIndex = 46;
            // 
            // nudYaleSNo
            // 
            this.nudYaleSNo.Location = new System.Drawing.Point(8, 104);
            this.nudYaleSNo.Name = "nudYaleSNo";
            this.nudYaleSNo.Size = new System.Drawing.Size(144, 20);
            this.nudYaleSNo.TabIndex = 8;
            this.nudYaleSNo.ValueChanged += new System.EventHandler(this.NumericUpDown2ValueChanged);
            // 
            // nudGlieseSNo
            // 
            this.nudGlieseSNo.Location = new System.Drawing.Point(8, 104);
            this.nudGlieseSNo.Name = "nudGlieseSNo";
            this.nudGlieseSNo.Size = new System.Drawing.Size(144, 20);
            this.nudGlieseSNo.TabIndex = 9;
            this.nudGlieseSNo.ValueChanged += new System.EventHandler(this.NumericUpDown3ValueChanged);
            // 
            // nudHYGSNo
            // 
            this.nudHYGSNo.Location = new System.Drawing.Point(8, 104);
            this.nudHYGSNo.Name = "nudHYGSNo";
            this.nudHYGSNo.Size = new System.Drawing.Size(144, 20);
            this.nudHYGSNo.TabIndex = 3;
            this.nudHYGSNo.ValueChanged += new System.EventHandler(this.NumericUpDown1ValueChanged);
            // 
            // YALE9
            // 
            this.YALE9.Location = new System.Drawing.Point(72, 112);
            this.YALE9.Name = "YALE9";
            this.YALE9.ReadOnly = true;
            this.YALE9.Size = new System.Drawing.Size(32, 20);
            this.YALE9.TabIndex = 38;
            // 
            // YALE8
            // 
            this.YALE8.Location = new System.Drawing.Point(336, 80);
            this.YALE8.Name = "YALE8";
            this.YALE8.ReadOnly = true;
            this.YALE8.Size = new System.Drawing.Size(56, 20);
            this.YALE8.TabIndex = 30;
            // 
            // YALE3
            // 
            this.YALE3.Location = new System.Drawing.Point(72, 48);
            this.YALE3.Name = "YALE3";
            this.YALE3.ReadOnly = true;
            this.YALE3.Size = new System.Drawing.Size(80, 20);
            this.YALE3.TabIndex = 20;
            // 
            // YALE2
            // 
            this.YALE2.Location = new System.Drawing.Point(352, 16);
            this.YALE2.Name = "YALE2";
            this.YALE2.ReadOnly = true;
            this.YALE2.Size = new System.Drawing.Size(80, 20);
            this.YALE2.TabIndex = 18;
            // 
            // DDMS4
            // 
            this.DDMS4.Location = new System.Drawing.Point(384, 40);
            this.DDMS4.Name = "DDMS4";
            this.DDMS4.Size = new System.Drawing.Size(32, 20);
            this.DDMS4.TabIndex = 7;
            // 
            // YALE0
            // 
            this.YALE0.Location = new System.Drawing.Point(72, 16);
            this.YALE0.Name = "YALE0";
            this.YALE0.ReadOnly = true;
            this.YALE0.Size = new System.Drawing.Size(80, 20);
            this.YALE0.TabIndex = 14;
            // 
            // YALE7
            // 
            this.YALE7.Location = new System.Drawing.Point(200, 80);
            this.YALE7.Name = "YALE7";
            this.YALE7.ReadOnly = true;
            this.YALE7.Size = new System.Drawing.Size(64, 20);
            this.YALE7.TabIndex = 28;
            // 
            // YALE6
            // 
            this.YALE6.Location = new System.Drawing.Point(72, 80);
            this.YALE6.Name = "YALE6";
            this.YALE6.ReadOnly = true;
            this.YALE6.Size = new System.Drawing.Size(56, 20);
            this.YALE6.TabIndex = 26;
            // 
            // DDMS0
            // 
            this.DDMS0.Location = new System.Drawing.Point(16, 40);
            this.DDMS0.Name = "DDMS0";
            this.DDMS0.Size = new System.Drawing.Size(200, 20);
            this.DDMS0.TabIndex = 10;
            this.DDMS0.Enter += new System.EventHandler(this.DDMS0Enter);
            // 
            // DDMS1
            // 
            this.DDMS1.Location = new System.Drawing.Point(264, 40);
            this.DDMS1.Name = "DDMS1";
            this.DDMS1.Size = new System.Drawing.Size(32, 20);
            this.DDMS1.TabIndex = 1;
            // 
            // DDMS2
            // 
            this.DDMS2.Location = new System.Drawing.Point(304, 40);
            this.DDMS2.Name = "DDMS2";
            this.DDMS2.Size = new System.Drawing.Size(32, 20);
            this.DDMS2.TabIndex = 3;
            // 
            // DDMS3
            // 
            this.DDMS3.Location = new System.Drawing.Point(344, 40);
            this.DDMS3.Name = "DDMS3";
            this.DDMS3.Size = new System.Drawing.Size(32, 20);
            this.DDMS3.TabIndex = 5;
            // 
            // lbYaleInfo07
            // 
            this.lbYaleInfo07.AutoSize = true;
            this.lbYaleInfo07.Location = new System.Drawing.Point(16, 80);
            this.lbYaleInfo07.Name = "lbYaleInfo07";
            this.lbYaleInfo07.Size = new System.Drawing.Size(55, 13);
            this.lbYaleInfo07.TabIndex = 25;
            this.lbYaleInfo07.Text = "RAh1900:";
            // 
            // GLIESE19
            // 
            this.GLIESE19.Location = new System.Drawing.Point(288, 240);
            this.GLIESE19.Name = "GLIESE19";
            this.GLIESE19.ReadOnly = true;
            this.GLIESE19.Size = new System.Drawing.Size(144, 20);
            this.GLIESE19.TabIndex = 92;
            // 
            // lbYaleInfo09
            // 
            this.lbYaleInfo09.AutoSize = true;
            this.lbYaleInfo09.Location = new System.Drawing.Point(280, 80);
            this.lbYaleInfo09.Name = "lbYaleInfo09";
            this.lbYaleInfo09.Size = new System.Drawing.Size(54, 13);
            this.lbYaleInfo09.TabIndex = 29;
            this.lbYaleInfo09.Text = "RAs1900:";
            // 
            // lbSearchResultGliese3rd
            // 
            this.lbSearchResultGliese3rd.AutoSize = true;
            this.lbSearchResultGliese3rd.Location = new System.Drawing.Point(8, 144);
            this.lbSearchResultGliese3rd.Name = "lbSearchResultGliese3rd";
            this.lbSearchResultGliese3rd.Size = new System.Drawing.Size(77, 13);
            this.lbSearchResultGliese3rd.TabIndex = 10;
            this.lbSearchResultGliese3rd.Text = "Search results:";
            // 
            // lbStarNoGliese3rd
            // 
            this.lbStarNoGliese3rd.AutoSize = true;
            this.lbStarNoGliese3rd.Location = new System.Drawing.Point(8, 88);
            this.lbStarNoGliese3rd.Name = "lbStarNoGliese3rd";
            this.lbStarNoGliese3rd.Size = new System.Drawing.Size(49, 13);
            this.lbStarNoGliese3rd.TabIndex = 11;
            this.lbStarNoGliese3rd.Text = "Star N.o:";
            // 
            // lbSearchResultYale5th
            // 
            this.lbSearchResultYale5th.AutoSize = true;
            this.lbSearchResultYale5th.Location = new System.Drawing.Point(8, 144);
            this.lbSearchResultYale5th.Name = "lbSearchResultYale5th";
            this.lbSearchResultYale5th.Size = new System.Drawing.Size(77, 13);
            this.lbSearchResultYale5th.TabIndex = 9;
            this.lbSearchResultYale5th.Text = "Search results:";
            // 
            // lbStarNoYale5th
            // 
            this.lbStarNoYale5th.AutoSize = true;
            this.lbStarNoYale5th.Location = new System.Drawing.Point(8, 88);
            this.lbStarNoYale5th.Name = "lbStarNoYale5th";
            this.lbStarNoYale5th.Size = new System.Drawing.Size(49, 13);
            this.lbStarNoYale5th.TabIndex = 10;
            this.lbStarNoYale5th.Text = "Star N.o:";
            // 
            // lbSearchResultHYGv11
            // 
            this.lbSearchResultHYGv11.AutoSize = true;
            this.lbSearchResultHYGv11.Location = new System.Drawing.Point(8, 144);
            this.lbSearchResultHYGv11.Name = "lbSearchResultHYGv11";
            this.lbSearchResultHYGv11.Size = new System.Drawing.Size(77, 13);
            this.lbSearchResultHYGv11.TabIndex = 5;
            this.lbSearchResultHYGv11.Text = "Search results:";
            // 
            // GLIESE10
            // 
            this.GLIESE10.Location = new System.Drawing.Point(72, 144);
            this.GLIESE10.Name = "GLIESE10";
            this.GLIESE10.ReadOnly = true;
            this.GLIESE10.Size = new System.Drawing.Size(80, 20);
            this.GLIESE10.TabIndex = 74;
            // 
            // GLIESE11
            // 
            this.GLIESE11.Location = new System.Drawing.Point(216, 144);
            this.GLIESE11.Name = "GLIESE11";
            this.GLIESE11.ReadOnly = true;
            this.GLIESE11.Size = new System.Drawing.Size(80, 20);
            this.GLIESE11.TabIndex = 76;
            // 
            // GLIESE16
            // 
            this.GLIESE16.Location = new System.Drawing.Point(72, 208);
            this.GLIESE16.Name = "GLIESE16";
            this.GLIESE16.ReadOnly = true;
            this.GLIESE16.Size = new System.Drawing.Size(144, 20);
            this.GLIESE16.TabIndex = 86;
            // 
            // GLIESE17
            // 
            this.GLIESE17.Location = new System.Drawing.Point(288, 208);
            this.GLIESE17.Name = "GLIESE17";
            this.GLIESE17.ReadOnly = true;
            this.GLIESE17.Size = new System.Drawing.Size(144, 20);
            this.GLIESE17.TabIndex = 88;
            // 
            // GLIESE14
            // 
            this.GLIESE14.Location = new System.Drawing.Point(216, 178);
            this.GLIESE14.Name = "GLIESE14";
            this.GLIESE14.ReadOnly = true;
            this.GLIESE14.Size = new System.Drawing.Size(80, 20);
            this.GLIESE14.TabIndex = 82;
            // 
            // GLIESE15
            // 
            this.GLIESE15.Location = new System.Drawing.Point(352, 178);
            this.GLIESE15.Name = "GLIESE15";
            this.GLIESE15.ReadOnly = true;
            this.GLIESE15.Size = new System.Drawing.Size(80, 20);
            this.GLIESE15.TabIndex = 84;
            // 
            // km
            // 
            this.km.Location = new System.Drawing.Point(160, 112);
            this.km.Name = "km";
            this.km.Size = new System.Drawing.Size(408, 20);
            this.km.TabIndex = 32;
            this.km.TextChanged += new System.EventHandler(this.KmTextChanged);
            // 
            // lbGlieseInfo05
            // 
            this.lbGlieseInfo05.AutoSize = true;
            this.lbGlieseInfo05.Location = new System.Drawing.Point(280, 48);
            this.lbGlieseInfo05.Name = "lbGlieseInfo05";
            this.lbGlieseInfo05.Size = new System.Drawing.Size(30, 13);
            this.lbGlieseInfo05.TabIndex = 57;
            this.lbGlieseInfo05.Text = "RAs:";
            // 
            // lbStarNoHYGv11
            // 
            this.lbStarNoHYGv11.AutoSize = true;
            this.lbStarNoHYGv11.Location = new System.Drawing.Point(8, 88);
            this.lbStarNoHYGv11.Name = "lbStarNoHYGv11";
            this.lbStarNoHYGv11.Size = new System.Drawing.Size(49, 13);
            this.lbStarNoHYGv11.TabIndex = 6;
            this.lbStarNoHYGv11.Text = "Star N.o:";
            // 
            // lbGlieseInfo08
            // 
            this.lbGlieseInfo08.AutoSize = true;
            this.lbGlieseInfo08.Location = new System.Drawing.Point(224, 80);
            this.lbGlieseInfo08.Name = "lbGlieseInfo08";
            this.lbGlieseInfo08.Size = new System.Drawing.Size(33, 13);
            this.lbGlieseInfo08.TabIndex = 61;
            this.lbGlieseInfo08.Text = "DEm:";
            // 
            // lbGlieseInfo07
            // 
            this.lbGlieseInfo07.AutoSize = true;
            this.lbGlieseInfo07.Location = new System.Drawing.Point(120, 80);
            this.lbGlieseInfo07.Name = "lbGlieseInfo07";
            this.lbGlieseInfo07.Size = new System.Drawing.Size(31, 13);
            this.lbGlieseInfo07.TabIndex = 59;
            this.lbGlieseInfo07.Text = "DEd:";
            // 
            // lbGlieseInfo11
            // 
            this.lbGlieseInfo11.AutoSize = true;
            this.lbGlieseInfo11.Location = new System.Drawing.Point(296, 112);
            this.lbGlieseInfo11.Name = "lbGlieseInfo11";
            this.lbGlieseInfo11.Size = new System.Drawing.Size(25, 13);
            this.lbGlieseInfo11.TabIndex = 71;
            this.lbGlieseInfo11.Text = "RV:";
            // 
            // lbGlieseInfo01
            // 
            this.lbGlieseInfo01.AutoSize = true;
            this.lbGlieseInfo01.Location = new System.Drawing.Point(16, 16);
            this.lbGlieseInfo01.Name = "lbGlieseInfo01";
            this.lbGlieseInfo01.Size = new System.Drawing.Size(34, 13);
            this.lbGlieseInfo01.TabIndex = 19;
            this.lbGlieseInfo01.Text = "Ident:";
            // 
            // lbCalcsDec02
            // 
            this.lbCalcsDec02.AutoSize = true;
            this.lbCalcsDec02.Location = new System.Drawing.Point(56, 24);
            this.lbCalcsDec02.Name = "lbCalcsDec02";
            this.lbCalcsDec02.Size = new System.Drawing.Size(15, 13);
            this.lbCalcsDec02.TabIndex = 2;
            this.lbCalcsDec02.Text = "D";
            // 
            // lbGlieseInfo06
            // 
            this.lbGlieseInfo06.AutoSize = true;
            this.lbGlieseInfo06.Location = new System.Drawing.Point(16, 80);
            this.lbGlieseInfo06.Name = "lbGlieseInfo06";
            this.lbGlieseInfo06.Size = new System.Drawing.Size(28, 13);
            this.lbGlieseInfo06.TabIndex = 65;
            this.lbGlieseInfo06.Text = "DE-:";
            // 
            // lbGlieseInfo02
            // 
            this.lbGlieseInfo02.AutoSize = true;
            this.lbGlieseInfo02.Location = new System.Drawing.Point(280, 16);
            this.lbGlieseInfo02.Name = "lbGlieseInfo02";
            this.lbGlieseInfo02.Size = new System.Drawing.Size(37, 13);
            this.lbGlieseInfo02.TabIndex = 99;
            this.lbGlieseInfo02.Text = "Vmag:";
            // 
            // lbCalcsDec01
            // 
            this.lbCalcsDec01.AutoSize = true;
            this.lbCalcsDec01.Location = new System.Drawing.Point(16, 24);
            this.lbCalcsDec01.Name = "lbCalcsDec01";
            this.lbCalcsDec01.Size = new System.Drawing.Size(13, 13);
            this.lbCalcsDec01.TabIndex = 0;
            this.lbCalcsDec01.Text = "±";
            // 
            // lbYaleInfo15
            // 
            this.lbYaleInfo15.AutoSize = true;
            this.lbYaleInfo15.Location = new System.Drawing.Point(144, 152);
            this.lbYaleInfo15.Name = "lbYaleInfo15";
            this.lbYaleInfo15.Size = new System.Drawing.Size(33, 13);
            this.lbYaleInfo15.TabIndex = 41;
            this.lbYaleInfo15.Text = "RAm:";
            // 
            // timeMonths
            // 
            this.timeMonths.Location = new System.Drawing.Point(200, 168);
            this.timeMonths.Name = "timeMonths";
            this.timeMonths.ReadOnly = true;
            this.timeMonths.Size = new System.Drawing.Size(180, 20);
            this.timeMonths.TabIndex = 22;
            // 
            // cmbHygSIndex
            // 
            this.cmbHygSIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHygSIndex.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHygSIndex.Items.AddRange(new object[] {
            "StarID          : Tähden tunnus",
            "HD              : Tähden tunnus / H. Draper -tietokanta",
            "HR              : Tähden tunnus / Harvard/Yale -tietokanta",
            "Gliese          : Tähden tunnus / Gliese -tietokanta",
            "BayerFlamsteed  : Tähden nimi (Bayer/Flamsteed)",
            "Ra              : Right Ascension",
            "Dec             : Declination",
            "ProperName      : Oikea nimi",
            "Distance        : Etäisyys (pc)",
            "Mag             : Magnitudi",
            "AbsMag          : Absoluuttinen magnitudi",
            "Spectrum        : Spektri",
            "ColorIndex      : Värin indeksi"});
            this.cmbHygSIndex.Location = new System.Drawing.Point(8, 16);
            this.cmbHygSIndex.Name = "cmbHygSIndex";
            this.cmbHygSIndex.Size = new System.Drawing.Size(576, 22);
            this.cmbHygSIndex.TabIndex = 0;
            this.cmbHygSIndex.SelectedIndexChanged += new System.EventHandler(this.HygSIndexSelectedIndexChanged);
            // 
            // lbCalcsRA01
            // 
            this.lbCalcsRA01.AutoSize = true;
            this.lbCalcsRA01.Location = new System.Drawing.Point(16, 24);
            this.lbCalcsRA01.Name = "lbCalcsRA01";
            this.lbCalcsRA01.Size = new System.Drawing.Size(13, 13);
            this.lbCalcsRA01.TabIndex = 2;
            this.lbCalcsRA01.Text = "h";
            // 
            // lbCalcsJ1950to2000_04
            // 
            this.lbCalcsJ1950to2000_04.AutoSize = true;
            this.lbCalcsJ1950to2000_04.Location = new System.Drawing.Point(240, 72);
            this.lbCalcsJ1950to2000_04.Name = "lbCalcsJ1950to2000_04";
            this.lbCalcsJ1950to2000_04.Size = new System.Drawing.Size(60, 13);
            this.lbCalcsJ1950to2000_04.TabIndex = 16;
            this.lbCalcsJ1950to2000_04.Text = "RA (J2000)";
            // 
            // vv
            // 
            this.vv.Location = new System.Drawing.Point(160, 16);
            this.vv.Name = "vv";
            this.vv.Size = new System.Drawing.Size(408, 20);
            this.vv.TabIndex = 29;
            this.vv.TextChanged += new System.EventHandler(this.VvTextChanged);
            // 
            // lbCalcsDec04
            // 
            this.lbCalcsDec04.AutoSize = true;
            this.lbCalcsDec04.Location = new System.Drawing.Point(136, 24);
            this.lbCalcsDec04.Name = "lbCalcsDec04";
            this.lbCalcsDec04.Size = new System.Drawing.Size(12, 13);
            this.lbCalcsDec04.TabIndex = 6;
            this.lbCalcsDec04.Text = "s";
            // 
            // lbCalcsTime04
            // 
            this.lbCalcsTime04.AutoSize = true;
            this.lbCalcsTime04.Location = new System.Drawing.Point(16, 72);
            this.lbCalcsTime04.Name = "lbCalcsTime04";
            this.lbCalcsTime04.Size = new System.Drawing.Size(72, 13);
            this.lbCalcsTime04.TabIndex = 11;
            this.lbCalcsTime04.Text = "Distance (km)";
            // 
            // lbGlieseInfo23
            // 
            this.lbGlieseInfo23.AutoSize = true;
            this.lbGlieseInfo23.Location = new System.Drawing.Point(232, 272);
            this.lbGlieseInfo23.Name = "lbGlieseInfo23";
            this.lbGlieseInfo23.Size = new System.Drawing.Size(30, 13);
            this.lbGlieseInfo23.TabIndex = 95;
            this.lbGlieseInfo23.Text = "Dec:";
            // 
            // AU
            // 
            this.AU.Location = new System.Drawing.Point(160, 48);
            this.AU.Name = "AU";
            this.AU.Size = new System.Drawing.Size(408, 20);
            this.AU.TabIndex = 30;
            this.AU.TextChanged += new System.EventHandler(this.AUTextChanged);
            // 
            // BJ2
            // 
            this.BJ2.Location = new System.Drawing.Point(16, 90);
            this.BJ2.Name = "BJ2";
            this.BJ2.Size = new System.Drawing.Size(180, 20);
            this.BJ2.TabIndex = 14;
            this.BJ2.Enter += new System.EventHandler(this.BJ0Enter);
            // 
            // BJ3
            // 
            this.BJ3.Location = new System.Drawing.Point(240, 88);
            this.BJ3.Name = "BJ3";
            this.BJ3.Size = new System.Drawing.Size(180, 20);
            this.BJ3.TabIndex = 15;
            // 
            // BJ0
            // 
            this.BJ0.Location = new System.Drawing.Point(16, 40);
            this.BJ0.Name = "BJ0";
            this.BJ0.Size = new System.Drawing.Size(180, 20);
            this.BJ0.TabIndex = 10;
            this.BJ0.Enter += new System.EventHandler(this.BJ0Enter);
            // 
            // BJ1
            // 
            this.BJ1.Location = new System.Drawing.Point(240, 40);
            this.BJ1.Name = "BJ1";
            this.BJ1.Size = new System.Drawing.Size(180, 20);
            this.BJ1.TabIndex = 11;
            // 
            // DMSD1
            // 
            this.DMSD1.Location = new System.Drawing.Point(56, 40);
            this.DMSD1.Name = "DMSD1";
            this.DMSD1.Size = new System.Drawing.Size(32, 20);
            this.DMSD1.TabIndex = 3;
            this.DMSD1.Enter += new System.EventHandler(this.DMSD0Enter);
            // 
            // DMSD2
            // 
            this.DMSD2.Location = new System.Drawing.Point(96, 40);
            this.DMSD2.Name = "DMSD2";
            this.DMSD2.Size = new System.Drawing.Size(32, 20);
            this.DMSD2.TabIndex = 5;
            this.DMSD2.Enter += new System.EventHandler(this.DMSD0Enter);
            // 
            // DMSD3
            // 
            this.DMSD3.Location = new System.Drawing.Point(136, 40);
            this.DMSD3.Name = "DMSD3";
            this.DMSD3.Size = new System.Drawing.Size(32, 20);
            this.DMSD3.TabIndex = 7;
            this.DMSD3.Enter += new System.EventHandler(this.DMSD0Enter);
            // 
            // lbGlieseInfo03
            // 
            this.lbGlieseInfo03.AutoSize = true;
            this.lbGlieseInfo03.Location = new System.Drawing.Point(16, 48);
            this.lbGlieseInfo03.Name = "lbGlieseInfo03";
            this.lbGlieseInfo03.Size = new System.Drawing.Size(31, 13);
            this.lbGlieseInfo03.TabIndex = 53;
            this.lbGlieseInfo03.Text = "RAh:";
            // 
            // pc
            // 
            this.pc.Location = new System.Drawing.Point(160, 80);
            this.pc.Name = "pc";
            this.pc.Size = new System.Drawing.Size(408, 20);
            this.pc.TabIndex = 31;
            this.pc.TextChanged += new System.EventHandler(this.PcTextChanged);
            // 
            // lbGlieseInfo09
            // 
            this.lbGlieseInfo09.AutoSize = true;
            this.lbGlieseInfo09.Location = new System.Drawing.Point(16, 112);
            this.lbGlieseInfo09.Name = "lbGlieseInfo09";
            this.lbGlieseInfo09.Size = new System.Drawing.Size(24, 13);
            this.lbGlieseInfo09.TabIndex = 67;
            this.lbGlieseInfo09.Text = "pm:";
            // 
            // timeSeconds
            // 
            this.timeSeconds.Location = new System.Drawing.Point(384, 216);
            this.timeSeconds.Name = "timeSeconds";
            this.timeSeconds.ReadOnly = true;
            this.timeSeconds.Size = new System.Drawing.Size(180, 20);
            this.timeSeconds.TabIndex = 34;
            // 
            // gbSearchHYGv11
            // 
            this.gbSearchHYGv11.Controls.Add(this.button1);
            this.gbSearchHYGv11.Controls.Add(this.HygSL);
            this.gbSearchHYGv11.Controls.Add(this.HygS1);
            this.gbSearchHYGv11.Controls.Add(this.HygS0);
            this.gbSearchHYGv11.Controls.Add(this.cmbHygSIndex);
            this.gbSearchHYGv11.Location = new System.Drawing.Point(8, 8);
            this.gbSearchHYGv11.Name = "gbSearchHYGv11";
            this.gbSearchHYGv11.Size = new System.Drawing.Size(592, 80);
            this.gbSearchHYGv11.TabIndex = 2;
            this.gbSearchHYGv11.TabStop = false;
            this.gbSearchHYGv11.Text = "Search";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(544, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Find";
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // gbSearchYale5th
            // 
            this.gbSearchYale5th.Controls.Add(this.button2);
            this.gbSearchYale5th.Controls.Add(this.YaleSL);
            this.gbSearchYale5th.Controls.Add(this.YaleS1);
            this.gbSearchYale5th.Controls.Add(this.YaleS0);
            this.gbSearchYale5th.Controls.Add(this.cmbYaleSIndex);
            this.gbSearchYale5th.Location = new System.Drawing.Point(8, 8);
            this.gbSearchYale5th.Name = "gbSearchYale5th";
            this.gbSearchYale5th.Size = new System.Drawing.Size(592, 80);
            this.gbSearchYale5th.TabIndex = 3;
            this.gbSearchYale5th.TabStop = false;
            this.gbSearchYale5th.Text = "Search";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(544, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Find";
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // gbSearchGliese3rd
            // 
            this.gbSearchGliese3rd.Controls.Add(this.button3);
            this.gbSearchGliese3rd.Controls.Add(this.GlieseSL);
            this.gbSearchGliese3rd.Controls.Add(this.GlieseS1);
            this.gbSearchGliese3rd.Controls.Add(this.GlieseS0);
            this.gbSearchGliese3rd.Controls.Add(this.cmbGlieseSIndex);
            this.gbSearchGliese3rd.Location = new System.Drawing.Point(8, 8);
            this.gbSearchGliese3rd.Name = "gbSearchGliese3rd";
            this.gbSearchGliese3rd.Size = new System.Drawing.Size(592, 80);
            this.gbSearchGliese3rd.TabIndex = 7;
            this.gbSearchGliese3rd.TabStop = false;
            this.gbSearchGliese3rd.Text = "Search";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(544, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Find";
            this.button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // GlieseSL
            // 
            this.GlieseSL.AutoSize = true;
            this.GlieseSL.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World);
            this.GlieseSL.Location = new System.Drawing.Point(384, 48);
            this.GlieseSL.Name = "GlieseSL";
            this.GlieseSL.Size = new System.Drawing.Size(19, 16);
            this.GlieseSL.TabIndex = 3;
            this.GlieseSL.Text = "±";
            // 
            // GlieseS0
            // 
            this.GlieseS0.Location = new System.Drawing.Point(8, 48);
            this.GlieseS0.Name = "GlieseS0";
            this.GlieseS0.Size = new System.Drawing.Size(368, 20);
            this.GlieseS0.TabIndex = 1;
            this.GlieseS0.Enter += new System.EventHandler(this.GlieseS0Enter);
            // 
            // gbGliese3rdInfo
            // 
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE23);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo02);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE22);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo24);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE21);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo23);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE20);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo22);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE19);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo21);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE18);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo20);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE17);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo19);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE16);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo18);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE15);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo17);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE14);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo16);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE13);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo15);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE12);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo14);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE11);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo13);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE10);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo12);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE9);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo11);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE8);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo10);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE7);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo09);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE4);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo06);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE6);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo08);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE5);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo07);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE3);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo05);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE2);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo04);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE1);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo03);
            this.gbGliese3rdInfo.Controls.Add(this.GLIESE0);
            this.gbGliese3rdInfo.Controls.Add(this.lbGlieseInfo01);
            this.gbGliese3rdInfo.Location = new System.Drawing.Point(160, 88);
            this.gbGliese3rdInfo.Name = "gbGliese3rdInfo";
            this.gbGliese3rdInfo.Size = new System.Drawing.Size(440, 376);
            this.gbGliese3rdInfo.TabIndex = 6;
            this.gbGliese3rdInfo.TabStop = false;
            this.gbGliese3rdInfo.Text = "Information";
            // 
            // GLIESE20
            // 
            this.GLIESE20.Location = new System.Drawing.Point(72, 272);
            this.GLIESE20.Name = "GLIESE20";
            this.GLIESE20.ReadOnly = true;
            this.GLIESE20.Size = new System.Drawing.Size(144, 20);
            this.GLIESE20.TabIndex = 94;
            // 
            // GLIESE18
            // 
            this.GLIESE18.Location = new System.Drawing.Point(72, 240);
            this.GLIESE18.Name = "GLIESE18";
            this.GLIESE18.ReadOnly = true;
            this.GLIESE18.Size = new System.Drawing.Size(144, 20);
            this.GLIESE18.TabIndex = 90;
            // 
            // GLIESE13
            // 
            this.GLIESE13.Location = new System.Drawing.Point(72, 178);
            this.GLIESE13.Name = "GLIESE13";
            this.GLIESE13.ReadOnly = true;
            this.GLIESE13.Size = new System.Drawing.Size(80, 20);
            this.GLIESE13.TabIndex = 80;
            // 
            // GLIESE12
            // 
            this.GLIESE12.Location = new System.Drawing.Point(352, 144);
            this.GLIESE12.Name = "GLIESE12";
            this.GLIESE12.ReadOnly = true;
            this.GLIESE12.Size = new System.Drawing.Size(80, 20);
            this.GLIESE12.TabIndex = 78;
            // 
            // GLIESE9
            // 
            this.GLIESE9.Location = new System.Drawing.Point(352, 112);
            this.GLIESE9.Name = "GLIESE9";
            this.GLIESE9.ReadOnly = true;
            this.GLIESE9.Size = new System.Drawing.Size(80, 20);
            this.GLIESE9.TabIndex = 72;
            // 
            // GLIESE8
            // 
            this.GLIESE8.Location = new System.Drawing.Point(216, 112);
            this.GLIESE8.Name = "GLIESE8";
            this.GLIESE8.ReadOnly = true;
            this.GLIESE8.Size = new System.Drawing.Size(80, 20);
            this.GLIESE8.TabIndex = 70;
            // 
            // GLIESE4
            // 
            this.GLIESE4.Location = new System.Drawing.Point(72, 80);
            this.GLIESE4.Name = "GLIESE4";
            this.GLIESE4.ReadOnly = true;
            this.GLIESE4.Size = new System.Drawing.Size(32, 20);
            this.GLIESE4.TabIndex = 66;
            // 
            // GLIESE6
            // 
            this.GLIESE6.Location = new System.Drawing.Point(280, 80);
            this.GLIESE6.Name = "GLIESE6";
            this.GLIESE6.ReadOnly = true;
            this.GLIESE6.Size = new System.Drawing.Size(48, 20);
            this.GLIESE6.TabIndex = 62;
            // 
            // GLIESE5
            // 
            this.GLIESE5.Location = new System.Drawing.Point(176, 80);
            this.GLIESE5.Name = "GLIESE5";
            this.GLIESE5.ReadOnly = true;
            this.GLIESE5.Size = new System.Drawing.Size(32, 20);
            this.GLIESE5.TabIndex = 60;
            // 
            // GLIESE3
            // 
            this.GLIESE3.Location = new System.Drawing.Point(336, 48);
            this.GLIESE3.Name = "GLIESE3";
            this.GLIESE3.ReadOnly = true;
            this.GLIESE3.Size = new System.Drawing.Size(56, 20);
            this.GLIESE3.TabIndex = 58;
            // 
            // GLIESE2
            // 
            this.GLIESE2.Location = new System.Drawing.Point(200, 48);
            this.GLIESE2.Name = "GLIESE2";
            this.GLIESE2.ReadOnly = true;
            this.GLIESE2.Size = new System.Drawing.Size(64, 20);
            this.GLIESE2.TabIndex = 56;
            // 
            // GLIESE1
            // 
            this.GLIESE1.Location = new System.Drawing.Point(72, 48);
            this.GLIESE1.Name = "GLIESE1";
            this.GLIESE1.ReadOnly = true;
            this.GLIESE1.Size = new System.Drawing.Size(56, 20);
            this.GLIESE1.TabIndex = 54;
            // 
            // gbDeclication
            // 
            this.gbDeclication.Controls.Add(this.DMSD4);
            this.gbDeclication.Controls.Add(this.lbCalcsDec05);
            this.gbDeclication.Controls.Add(this.btDeclination1);
            this.gbDeclication.Controls.Add(this.DMSD3);
            this.gbDeclication.Controls.Add(this.lbCalcsDec04);
            this.gbDeclication.Controls.Add(this.DMSD2);
            this.gbDeclication.Controls.Add(this.lbCalcsDec03);
            this.gbDeclication.Controls.Add(this.DMSD1);
            this.gbDeclication.Controls.Add(this.lbCalcsDec02);
            this.gbDeclication.Controls.Add(this.DMSD0);
            this.gbDeclication.Controls.Add(this.lbCalcsDec01);
            this.gbDeclication.Location = new System.Drawing.Point(8, 8);
            this.gbDeclication.Name = "gbDeclication";
            this.gbDeclication.Size = new System.Drawing.Size(424, 72);
            this.gbDeclication.TabIndex = 0;
            this.gbDeclication.TabStop = false;
            this.gbDeclication.Text = "DMS declination -> declination";
            // 
            // DMSD4
            // 
            this.DMSD4.Location = new System.Drawing.Point(216, 40);
            this.DMSD4.Name = "DMSD4";
            this.DMSD4.Size = new System.Drawing.Size(200, 20);
            this.DMSD4.TabIndex = 10;
            // 
            // lbCalcsDec05
            // 
            this.lbCalcsDec05.AutoSize = true;
            this.lbCalcsDec05.Location = new System.Drawing.Point(216, 24);
            this.lbCalcsDec05.Name = "lbCalcsDec05";
            this.lbCalcsDec05.Size = new System.Drawing.Size(58, 13);
            this.lbCalcsDec05.TabIndex = 9;
            this.lbCalcsDec05.Text = "declination";
            // 
            // btDeclination1
            // 
            this.btDeclination1.Location = new System.Drawing.Point(176, 40);
            this.btDeclination1.Name = "btDeclination1";
            this.btDeclination1.Size = new System.Drawing.Size(32, 23);
            this.btDeclination1.TabIndex = 8;
            this.btDeclination1.Text = "->";
            this.btDeclination1.Click += new System.EventHandler(this.Button4Click);
            // 
            // DMSD0
            // 
            this.DMSD0.Location = new System.Drawing.Point(16, 40);
            this.DMSD0.Name = "DMSD0";
            this.DMSD0.Size = new System.Drawing.Size(32, 20);
            this.DMSD0.TabIndex = 1;
            this.DMSD0.Enter += new System.EventHandler(this.DMSD0Enter);
            // 
            // gbDeclination2
            // 
            this.gbDeclination2.Controls.Add(this.DDMS0);
            this.gbDeclination2.Controls.Add(this.lbCalcsDec06);
            this.gbDeclination2.Controls.Add(this.btDeclination2);
            this.gbDeclination2.Controls.Add(this.DDMS4);
            this.gbDeclination2.Controls.Add(this.lbCalcsDec10);
            this.gbDeclination2.Controls.Add(this.DDMS3);
            this.gbDeclination2.Controls.Add(this.lbCalcsDec09);
            this.gbDeclination2.Controls.Add(this.DDMS2);
            this.gbDeclination2.Controls.Add(this.lbCalcsDec08);
            this.gbDeclination2.Controls.Add(this.DDMS1);
            this.gbDeclination2.Controls.Add(this.lbCalcsDec07);
            this.gbDeclination2.Location = new System.Drawing.Point(8, 80);
            this.gbDeclination2.Name = "gbDeclination2";
            this.gbDeclination2.Size = new System.Drawing.Size(424, 72);
            this.gbDeclination2.TabIndex = 1;
            this.gbDeclination2.TabStop = false;
            this.gbDeclination2.Text = "declination -> DMS declination";
            // 
            // lbCalcsDec06
            // 
            this.lbCalcsDec06.AutoSize = true;
            this.lbCalcsDec06.Location = new System.Drawing.Point(16, 24);
            this.lbCalcsDec06.Name = "lbCalcsDec06";
            this.lbCalcsDec06.Size = new System.Drawing.Size(58, 13);
            this.lbCalcsDec06.TabIndex = 9;
            this.lbCalcsDec06.Text = "declination";
            // 
            // btDeclination2
            // 
            this.btDeclination2.Location = new System.Drawing.Point(224, 40);
            this.btDeclination2.Name = "btDeclination2";
            this.btDeclination2.Size = new System.Drawing.Size(32, 23);
            this.btDeclination2.TabIndex = 8;
            this.btDeclination2.Text = "->";
            this.btDeclination2.Click += new System.EventHandler(this.Button5Click);
            // 
            // lbCalcsDec10
            // 
            this.lbCalcsDec10.AutoSize = true;
            this.lbCalcsDec10.Location = new System.Drawing.Point(384, 24);
            this.lbCalcsDec10.Name = "lbCalcsDec10";
            this.lbCalcsDec10.Size = new System.Drawing.Size(12, 13);
            this.lbCalcsDec10.TabIndex = 6;
            this.lbCalcsDec10.Text = "s";
            // 
            // lbCalcsDec09
            // 
            this.lbCalcsDec09.AutoSize = true;
            this.lbCalcsDec09.Location = new System.Drawing.Point(344, 24);
            this.lbCalcsDec09.Name = "lbCalcsDec09";
            this.lbCalcsDec09.Size = new System.Drawing.Size(15, 13);
            this.lbCalcsDec09.TabIndex = 4;
            this.lbCalcsDec09.Text = "m";
            // 
            // lbCalcsDec08
            // 
            this.lbCalcsDec08.AutoSize = true;
            this.lbCalcsDec08.Location = new System.Drawing.Point(304, 24);
            this.lbCalcsDec08.Name = "lbCalcsDec08";
            this.lbCalcsDec08.Size = new System.Drawing.Size(15, 13);
            this.lbCalcsDec08.TabIndex = 2;
            this.lbCalcsDec08.Text = "D";
            // 
            // lbCalcsDec07
            // 
            this.lbCalcsDec07.AutoSize = true;
            this.lbCalcsDec07.Location = new System.Drawing.Point(264, 24);
            this.lbCalcsDec07.Name = "lbCalcsDec07";
            this.lbCalcsDec07.Size = new System.Drawing.Size(13, 13);
            this.lbCalcsDec07.TabIndex = 0;
            this.lbCalcsDec07.Text = "±";
            // 
            // gbRAtoHMSRA
            // 
            this.gbRAtoHMSRA.Controls.Add(this.RAHMS0);
            this.gbRAtoHMSRA.Controls.Add(this.lbCalcsRA05);
            this.gbRAtoHMSRA.Controls.Add(this.btRAtoHMSRA);
            this.gbRAtoHMSRA.Controls.Add(this.RAHMS3);
            this.gbRAtoHMSRA.Controls.Add(this.lbCalcsRA08);
            this.gbRAtoHMSRA.Controls.Add(this.RAHMS2);
            this.gbRAtoHMSRA.Controls.Add(this.lbCalcsRA07);
            this.gbRAtoHMSRA.Controls.Add(this.RAHMS1);
            this.gbRAtoHMSRA.Controls.Add(this.lbCalcsRA06);
            this.gbRAtoHMSRA.Location = new System.Drawing.Point(8, 344);
            this.gbRAtoHMSRA.Name = "gbRAtoHMSRA";
            this.gbRAtoHMSRA.Size = new System.Drawing.Size(424, 72);
            this.gbRAtoHMSRA.TabIndex = 2;
            this.gbRAtoHMSRA.TabStop = false;
            this.gbRAtoHMSRA.Text = "RA -> HMS RA";
            // 
            // RAHMS0
            // 
            this.RAHMS0.Location = new System.Drawing.Point(16, 40);
            this.RAHMS0.Name = "RAHMS0";
            this.RAHMS0.Size = new System.Drawing.Size(240, 20);
            this.RAHMS0.TabIndex = 10;
            this.RAHMS0.Enter += new System.EventHandler(this.RAHMS0Enter);
            // 
            // lbCalcsRA05
            // 
            this.lbCalcsRA05.AutoSize = true;
            this.lbCalcsRA05.Location = new System.Drawing.Point(16, 24);
            this.lbCalcsRA05.Name = "lbCalcsRA05";
            this.lbCalcsRA05.Size = new System.Drawing.Size(22, 13);
            this.lbCalcsRA05.TabIndex = 9;
            this.lbCalcsRA05.Text = "RA";
            // 
            // btRAtoHMSRA
            // 
            this.btRAtoHMSRA.Location = new System.Drawing.Point(264, 40);
            this.btRAtoHMSRA.Name = "btRAtoHMSRA";
            this.btRAtoHMSRA.Size = new System.Drawing.Size(32, 23);
            this.btRAtoHMSRA.TabIndex = 8;
            this.btRAtoHMSRA.Text = "->";
            this.btRAtoHMSRA.Click += new System.EventHandler(this.Button6Click);
            // 
            // RAHMS3
            // 
            this.RAHMS3.Location = new System.Drawing.Point(384, 40);
            this.RAHMS3.Name = "RAHMS3";
            this.RAHMS3.Size = new System.Drawing.Size(32, 20);
            this.RAHMS3.TabIndex = 7;
            // 
            // lbCalcsRA08
            // 
            this.lbCalcsRA08.AutoSize = true;
            this.lbCalcsRA08.Location = new System.Drawing.Point(384, 24);
            this.lbCalcsRA08.Name = "lbCalcsRA08";
            this.lbCalcsRA08.Size = new System.Drawing.Size(12, 13);
            this.lbCalcsRA08.TabIndex = 6;
            this.lbCalcsRA08.Text = "s";
            // 
            // RAHMS2
            // 
            this.RAHMS2.Location = new System.Drawing.Point(344, 40);
            this.RAHMS2.Name = "RAHMS2";
            this.RAHMS2.Size = new System.Drawing.Size(32, 20);
            this.RAHMS2.TabIndex = 5;
            // 
            // lbCalcsRA07
            // 
            this.lbCalcsRA07.AutoSize = true;
            this.lbCalcsRA07.Location = new System.Drawing.Point(344, 24);
            this.lbCalcsRA07.Name = "lbCalcsRA07";
            this.lbCalcsRA07.Size = new System.Drawing.Size(15, 13);
            this.lbCalcsRA07.TabIndex = 4;
            this.lbCalcsRA07.Text = "m";
            // 
            // RAHMS1
            // 
            this.RAHMS1.Location = new System.Drawing.Point(304, 40);
            this.RAHMS1.Name = "RAHMS1";
            this.RAHMS1.Size = new System.Drawing.Size(32, 20);
            this.RAHMS1.TabIndex = 3;
            // 
            // lbCalcsRA06
            // 
            this.lbCalcsRA06.AutoSize = true;
            this.lbCalcsRA06.Location = new System.Drawing.Point(304, 24);
            this.lbCalcsRA06.Name = "lbCalcsRA06";
            this.lbCalcsRA06.Size = new System.Drawing.Size(13, 13);
            this.lbCalcsRA06.TabIndex = 2;
            this.lbCalcsRA06.Text = "h";
            // 
            // kmPerMin
            // 
            this.kmPerMin.Location = new System.Drawing.Point(200, 40);
            this.kmPerMin.Name = "kmPerMin";
            this.kmPerMin.Size = new System.Drawing.Size(180, 20);
            this.kmPerMin.TabIndex = 26;
            this.kmPerMin.TextChanged += new System.EventHandler(this.KmPerMinTextChanged);
            // 
            // timeMinutes
            // 
            this.timeMinutes.Location = new System.Drawing.Point(200, 216);
            this.timeMinutes.Name = "timeMinutes";
            this.timeMinutes.ReadOnly = true;
            this.timeMinutes.Size = new System.Drawing.Size(180, 20);
            this.timeMinutes.TabIndex = 32;
            // 
            // tabConstellationAbbrv
            // 
            this.tabConstellationAbbrv.AutoScroll = true;
            this.tabConstellationAbbrv.Controls.Add(this.lvConstellations);
            this.tabConstellationAbbrv.Location = new System.Drawing.Point(4, 22);
            this.tabConstellationAbbrv.Name = "tabConstellationAbbrv";
            this.tabConstellationAbbrv.Size = new System.Drawing.Size(608, 470);
            this.tabConstellationAbbrv.TabIndex = 5;
            this.tabConstellationAbbrv.Text = "Constellation abbreviations";
            // 
            // lvConstellations
            // 
            this.lvConstellations.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvConstellations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvConstellations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShortName,
            this.colLongName});
            this.lvConstellations.FullRowSelect = true;
            this.lvConstellations.Location = new System.Drawing.Point(8, 7);
            this.lvConstellations.Name = "lvConstellations";
            this.lvConstellations.Size = new System.Drawing.Size(592, 457);
            this.lvConstellations.TabIndex = 1;
            this.lvConstellations.UseCompatibleStateImageBehavior = false;
            this.lvConstellations.View = System.Windows.Forms.View.Details;
            // 
            // colShortName
            // 
            this.colShortName.Text = "Short name";
            this.colShortName.Width = 100;
            // 
            // colLongName
            // 
            this.colLongName.Text = "Long name";
            this.colLongName.Width = 200;
            // 
            // tabCalcs
            // 
            this.tabCalcs.AutoScroll = true;
            this.tabCalcs.Controls.Add(this.groupBox13);
            this.tabCalcs.Controls.Add(this.groupBox12);
            this.tabCalcs.Controls.Add(this.gbJ1950toJ2000);
            this.tabCalcs.Controls.Add(this.gbHMSRAtoRA);
            this.tabCalcs.Controls.Add(this.gbRAtoHMSRA);
            this.tabCalcs.Controls.Add(this.gbDeclination2);
            this.tabCalcs.Controls.Add(this.gbDeclication);
            this.tabCalcs.Location = new System.Drawing.Point(4, 22);
            this.tabCalcs.Name = "tabCalcs";
            this.tabCalcs.Size = new System.Drawing.Size(608, 470);
            this.tabCalcs.TabIndex = 3;
            this.tabCalcs.Text = "Calculations";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.km);
            this.groupBox13.Controls.Add(this.pc);
            this.groupBox13.Controls.Add(this.AU);
            this.groupBox13.Controls.Add(this.vv);
            this.groupBox13.Controls.Add(this.lbCalcsDist04);
            this.groupBox13.Controls.Add(this.lbCalcsDist03);
            this.groupBox13.Controls.Add(this.lbCalcsDist02);
            this.groupBox13.Controls.Add(this.lbCalcsDist01);
            this.groupBox13.Location = new System.Drawing.Point(8, 416);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(576, 144);
            this.groupBox13.TabIndex = 6;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Distances";
            // 
            // lbCalcsDist04
            // 
            this.lbCalcsDist04.AutoSize = true;
            this.lbCalcsDist04.Location = new System.Drawing.Point(8, 112);
            this.lbCalcsDist04.Name = "lbCalcsDist04";
            this.lbCalcsDist04.Size = new System.Drawing.Size(81, 13);
            this.lbCalcsDist04.TabIndex = 13;
            this.lbCalcsDist04.Text = "Kilometers (km):";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.distAU);
            this.groupBox12.Controls.Add(this.lbCalcsTime07);
            this.groupBox12.Controls.Add(this.timeSeconds);
            this.groupBox12.Controls.Add(this.lbCalcsTime13);
            this.groupBox12.Controls.Add(this.timeMinutes);
            this.groupBox12.Controls.Add(this.lbCalcsTime12);
            this.groupBox12.Controls.Add(this.timeHours);
            this.groupBox12.Controls.Add(this.lbCalcsTime11);
            this.groupBox12.Controls.Add(this.kmPerHour);
            this.groupBox12.Controls.Add(this.lbCalcsTime03);
            this.groupBox12.Controls.Add(this.kmPerMin);
            this.groupBox12.Controls.Add(this.lbCalcsTime02);
            this.groupBox12.Controls.Add(this.timeDays);
            this.groupBox12.Controls.Add(this.lbCalcsTime10);
            this.groupBox12.Controls.Add(this.timeMonths);
            this.groupBox12.Controls.Add(this.lbCalcsTime09);
            this.groupBox12.Controls.Add(this.timeYears);
            this.groupBox12.Controls.Add(this.lbCalcsTime08);
            this.groupBox12.Controls.Add(this.kmPerSek);
            this.groupBox12.Controls.Add(this.lbCalcsTime01);
            this.groupBox12.Controls.Add(this.distVv);
            this.groupBox12.Controls.Add(this.lbCalcsTime06);
            this.groupBox12.Controls.Add(this.distPc);
            this.groupBox12.Controls.Add(this.lbCalcsTime05);
            this.groupBox12.Controls.Add(this.distKm);
            this.groupBox12.Controls.Add(this.lbCalcsTime04);
            this.groupBox12.Location = new System.Drawing.Point(8, 560);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(576, 248);
            this.groupBox12.TabIndex = 5;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Time used for distance";
            // 
            // lbCalcsTime07
            // 
            this.lbCalcsTime07.AutoSize = true;
            this.lbCalcsTime07.Location = new System.Drawing.Point(296, 112);
            this.lbCalcsTime07.Name = "lbCalcsTime07";
            this.lbCalcsTime07.Size = new System.Drawing.Size(73, 13);
            this.lbCalcsTime07.TabIndex = 35;
            this.lbCalcsTime07.Text = "Distance (AU)";
            // 
            // lbCalcsTime13
            // 
            this.lbCalcsTime13.AutoSize = true;
            this.lbCalcsTime13.Location = new System.Drawing.Point(384, 200);
            this.lbCalcsTime13.Name = "lbCalcsTime13";
            this.lbCalcsTime13.Size = new System.Drawing.Size(79, 13);
            this.lbCalcsTime13.TabIndex = 33;
            this.lbCalcsTime13.Text = "Time (seconds)";
            // 
            // lbCalcsTime12
            // 
            this.lbCalcsTime12.AutoSize = true;
            this.lbCalcsTime12.Location = new System.Drawing.Point(200, 200);
            this.lbCalcsTime12.Name = "lbCalcsTime12";
            this.lbCalcsTime12.Size = new System.Drawing.Size(75, 13);
            this.lbCalcsTime12.TabIndex = 31;
            this.lbCalcsTime12.Text = "Time (minutes)";
            // 
            // lbCalcsTime11
            // 
            this.lbCalcsTime11.AutoSize = true;
            this.lbCalcsTime11.Location = new System.Drawing.Point(16, 200);
            this.lbCalcsTime11.Name = "lbCalcsTime11";
            this.lbCalcsTime11.Size = new System.Drawing.Size(65, 13);
            this.lbCalcsTime11.TabIndex = 29;
            this.lbCalcsTime11.Text = "Time (hours)";
            // 
            // timeYears
            // 
            this.timeYears.Location = new System.Drawing.Point(16, 168);
            this.timeYears.Name = "timeYears";
            this.timeYears.ReadOnly = true;
            this.timeYears.Size = new System.Drawing.Size(180, 20);
            this.timeYears.TabIndex = 20;
            // 
            // distVv
            // 
            this.distVv.Location = new System.Drawing.Point(16, 128);
            this.distVv.Name = "distVv";
            this.distVv.Size = new System.Drawing.Size(272, 20);
            this.distVv.TabIndex = 16;
            this.distVv.TextChanged += new System.EventHandler(this.DistVvTextChanged);
            // 
            // lbCalcsTime05
            // 
            this.lbCalcsTime05.AutoSize = true;
            this.lbCalcsTime05.Location = new System.Drawing.Point(296, 72);
            this.lbCalcsTime05.Name = "lbCalcsTime05";
            this.lbCalcsTime05.Size = new System.Drawing.Size(70, 13);
            this.lbCalcsTime05.TabIndex = 13;
            this.lbCalcsTime05.Text = "Distance (pc)";
            // 
            // gbJ1950toJ2000
            // 
            this.gbJ1950toJ2000.Controls.Add(this.BJ3);
            this.gbJ1950toJ2000.Controls.Add(this.lbCalcsJ1950to2000_04);
            this.gbJ1950toJ2000.Controls.Add(this.BJ2);
            this.gbJ1950toJ2000.Controls.Add(this.lbCalcsJ1950to2000_03);
            this.gbJ1950toJ2000.Controls.Add(this.BJ1);
            this.gbJ1950toJ2000.Controls.Add(this.lbCalcsJ1950to2000_02);
            this.gbJ1950toJ2000.Controls.Add(this.BJ0);
            this.gbJ1950toJ2000.Controls.Add(this.lbCalcsJ1950to2000_01);
            this.gbJ1950toJ2000.Controls.Add(this.btJ1950toJ2000);
            this.gbJ1950toJ2000.Location = new System.Drawing.Point(8, 152);
            this.gbJ1950toJ2000.Name = "gbJ1950toJ2000";
            this.gbJ1950toJ2000.Size = new System.Drawing.Size(432, 120);
            this.gbJ1950toJ2000.TabIndex = 4;
            this.gbJ1950toJ2000.TabStop = false;
            this.gbJ1950toJ2000.Text = "B1950 -> J2000";
            // 
            // lbCalcsJ1950to2000_03
            // 
            this.lbCalcsJ1950to2000_03.AutoSize = true;
            this.lbCalcsJ1950to2000_03.Location = new System.Drawing.Point(16, 74);
            this.lbCalcsJ1950to2000_03.Name = "lbCalcsJ1950to2000_03";
            this.lbCalcsJ1950to2000_03.Size = new System.Drawing.Size(62, 13);
            this.lbCalcsJ1950to2000_03.TabIndex = 13;
            this.lbCalcsJ1950to2000_03.Text = "RA (B1950)";
            // 
            // lbCalcsJ1950to2000_01
            // 
            this.lbCalcsJ1950to2000_01.AutoSize = true;
            this.lbCalcsJ1950to2000_01.Location = new System.Drawing.Point(16, 24);
            this.lbCalcsJ1950to2000_01.Name = "lbCalcsJ1950to2000_01";
            this.lbCalcsJ1950to2000_01.Size = new System.Drawing.Size(98, 13);
            this.lbCalcsJ1950to2000_01.TabIndex = 9;
            this.lbCalcsJ1950to2000_01.Text = "declination (B1950)";
            // 
            // btJ1950toJ2000
            // 
            this.btJ1950toJ2000.Location = new System.Drawing.Point(200, 64);
            this.btJ1950toJ2000.Name = "btJ1950toJ2000";
            this.btJ1950toJ2000.Size = new System.Drawing.Size(32, 23);
            this.btJ1950toJ2000.TabIndex = 8;
            this.btJ1950toJ2000.Text = "->";
            this.btJ1950toJ2000.Click += new System.EventHandler(this.Button8Click);
            // 
            // gbHMSRAtoRA
            // 
            this.gbHMSRAtoRA.Controls.Add(this.HMSRA3);
            this.gbHMSRAtoRA.Controls.Add(this.lbCalcsRA04);
            this.gbHMSRAtoRA.Controls.Add(this.btHMSRAtoRA);
            this.gbHMSRAtoRA.Controls.Add(this.HMSRA2);
            this.gbHMSRAtoRA.Controls.Add(this.lbCalcsRA03);
            this.gbHMSRAtoRA.Controls.Add(this.HMSRA1);
            this.gbHMSRAtoRA.Controls.Add(this.lbCalcsRA02);
            this.gbHMSRAtoRA.Controls.Add(this.HMSRA0);
            this.gbHMSRAtoRA.Controls.Add(this.lbCalcsRA01);
            this.gbHMSRAtoRA.Location = new System.Drawing.Point(8, 272);
            this.gbHMSRAtoRA.Name = "gbHMSRAtoRA";
            this.gbHMSRAtoRA.Size = new System.Drawing.Size(424, 72);
            this.gbHMSRAtoRA.TabIndex = 3;
            this.gbHMSRAtoRA.TabStop = false;
            this.gbHMSRAtoRA.Text = "HMS RA -> RA";
            // 
            // HMSRA3
            // 
            this.HMSRA3.Location = new System.Drawing.Point(176, 40);
            this.HMSRA3.Name = "HMSRA3";
            this.HMSRA3.Size = new System.Drawing.Size(240, 20);
            this.HMSRA3.TabIndex = 10;
            // 
            // lbCalcsRA04
            // 
            this.lbCalcsRA04.AutoSize = true;
            this.lbCalcsRA04.Location = new System.Drawing.Point(176, 24);
            this.lbCalcsRA04.Name = "lbCalcsRA04";
            this.lbCalcsRA04.Size = new System.Drawing.Size(22, 13);
            this.lbCalcsRA04.TabIndex = 9;
            this.lbCalcsRA04.Text = "RA";
            // 
            // btHMSRAtoRA
            // 
            this.btHMSRAtoRA.Location = new System.Drawing.Point(136, 40);
            this.btHMSRAtoRA.Name = "btHMSRAtoRA";
            this.btHMSRAtoRA.Size = new System.Drawing.Size(32, 23);
            this.btHMSRAtoRA.TabIndex = 8;
            this.btHMSRAtoRA.Text = "->";
            this.btHMSRAtoRA.Click += new System.EventHandler(this.Button7Click);
            // 
            // HMSRA2
            // 
            this.HMSRA2.Location = new System.Drawing.Point(96, 40);
            this.HMSRA2.Name = "HMSRA2";
            this.HMSRA2.Size = new System.Drawing.Size(32, 20);
            this.HMSRA2.TabIndex = 7;
            this.HMSRA2.Enter += new System.EventHandler(this.HMSRA0Enter);
            // 
            // HMSRA1
            // 
            this.HMSRA1.Location = new System.Drawing.Point(56, 40);
            this.HMSRA1.Name = "HMSRA1";
            this.HMSRA1.Size = new System.Drawing.Size(32, 20);
            this.HMSRA1.TabIndex = 5;
            this.HMSRA1.Enter += new System.EventHandler(this.HMSRA0Enter);
            // 
            // lbCalcsRA02
            // 
            this.lbCalcsRA02.AutoSize = true;
            this.lbCalcsRA02.Location = new System.Drawing.Point(56, 24);
            this.lbCalcsRA02.Name = "lbCalcsRA02";
            this.lbCalcsRA02.Size = new System.Drawing.Size(15, 13);
            this.lbCalcsRA02.TabIndex = 4;
            this.lbCalcsRA02.Text = "m";
            // 
            // HMSRA0
            // 
            this.HMSRA0.Location = new System.Drawing.Point(16, 40);
            this.HMSRA0.Name = "HMSRA0";
            this.HMSRA0.Size = new System.Drawing.Size(32, 20);
            this.HMSRA0.TabIndex = 3;
            this.HMSRA0.Enter += new System.EventHandler(this.HMSRA0Enter);
            // 
            // tabGreekAlphabet
            // 
            this.tabGreekAlphabet.AutoScroll = true;
            this.tabGreekAlphabet.Controls.Add(this.lvGreekAlpha);
            this.tabGreekAlphabet.Location = new System.Drawing.Point(4, 22);
            this.tabGreekAlphabet.Name = "tabGreekAlphabet";
            this.tabGreekAlphabet.Size = new System.Drawing.Size(608, 470);
            this.tabGreekAlphabet.TabIndex = 4;
            this.tabGreekAlphabet.Text = "Greek alphabet";
            // 
            // lvGreekAlpha
            // 
            this.lvGreekAlpha.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvGreekAlpha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvGreekAlpha.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUpperLetter,
            this.colLowerLetter,
            this.colAbbreviation,
            this.colName});
            this.lvGreekAlpha.FullRowSelect = true;
            this.lvGreekAlpha.Location = new System.Drawing.Point(8, 3);
            this.lvGreekAlpha.Name = "lvGreekAlpha";
            this.lvGreekAlpha.Size = new System.Drawing.Size(592, 457);
            this.lvGreekAlpha.TabIndex = 0;
            this.lvGreekAlpha.UseCompatibleStateImageBehavior = false;
            this.lvGreekAlpha.View = System.Windows.Forms.View.Details;
            // 
            // colUpperLetter
            // 
            this.colUpperLetter.Text = "Upper case letter";
            this.colUpperLetter.Width = 100;
            // 
            // colLowerLetter
            // 
            this.colLowerLetter.Text = "Lower case letter";
            this.colLowerLetter.Width = 100;
            // 
            // colAbbreviation
            // 
            this.colAbbreviation.Text = "Abbreviation";
            this.colAbbreviation.Width = 100;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // tabYale5ht
            // 
            this.tabYale5ht.Controls.Add(this.lbYale5Th);
            this.tabYale5ht.Controls.Add(this.nudYaleSNo);
            this.tabYale5ht.Controls.Add(this.lbStarNoYale5th);
            this.tabYale5ht.Controls.Add(this.lbSearchResultYale5th);
            this.tabYale5ht.Controls.Add(this.gbSearchYale5th);
            this.tabYale5ht.Controls.Add(this.gbYale5thInfo);
            this.tabYale5ht.Location = new System.Drawing.Point(4, 22);
            this.tabYale5ht.Name = "tabYale5ht";
            this.tabYale5ht.Size = new System.Drawing.Size(608, 470);
            this.tabYale5ht.TabIndex = 1;
            this.tabYale5ht.Text = "Yale 5th";
            // 
            // lbYale5Th
            // 
            this.lbYale5Th.Location = new System.Drawing.Point(8, 160);
            this.lbYale5Th.Name = "lbYale5Th";
            this.lbYale5Th.Size = new System.Drawing.Size(144, 303);
            this.lbYale5Th.TabIndex = 11;
            this.lbYale5Th.SelectedIndexChanged += new System.EventHandler(this.ListBox2SelectedIndexChanged);
            // 
            // gbYale5thInfo
            // 
            this.gbYale5thInfo.Controls.Add(this.YALE31);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo32);
            this.gbYale5thInfo.Controls.Add(this.YALE30);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo31);
            this.gbYale5thInfo.Controls.Add(this.YALE29);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo30);
            this.gbYale5thInfo.Controls.Add(this.YALE28);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo29);
            this.gbYale5thInfo.Controls.Add(this.YALE27);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo28);
            this.gbYale5thInfo.Controls.Add(this.YALE26);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo27);
            this.gbYale5thInfo.Controls.Add(this.YALE25);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo26);
            this.gbYale5thInfo.Controls.Add(this.YALE24);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo25);
            this.gbYale5thInfo.Controls.Add(this.YALE23);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo24);
            this.gbYale5thInfo.Controls.Add(this.YALE22);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo23);
            this.gbYale5thInfo.Controls.Add(this.YALE21);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo22);
            this.gbYale5thInfo.Controls.Add(this.YALE20);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo21);
            this.gbYale5thInfo.Controls.Add(this.YALE16);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo17);
            this.gbYale5thInfo.Controls.Add(this.YALE19);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo20);
            this.gbYale5thInfo.Controls.Add(this.YALE18);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo19);
            this.gbYale5thInfo.Controls.Add(this.YALE17);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo18);
            this.gbYale5thInfo.Controls.Add(this.YALE15);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo16);
            this.gbYale5thInfo.Controls.Add(this.YALE14);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo15);
            this.gbYale5thInfo.Controls.Add(this.YALE13);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo14);
            this.gbYale5thInfo.Controls.Add(this.YALE9);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo10);
            this.gbYale5thInfo.Controls.Add(this.YALE12);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo13);
            this.gbYale5thInfo.Controls.Add(this.YALE11);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo12);
            this.gbYale5thInfo.Controls.Add(this.YALE10);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo11);
            this.gbYale5thInfo.Controls.Add(this.YALE8);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo09);
            this.gbYale5thInfo.Controls.Add(this.YALE7);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo08);
            this.gbYale5thInfo.Controls.Add(this.YALE6);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo07);
            this.gbYale5thInfo.Controls.Add(this.YALE5);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo06);
            this.gbYale5thInfo.Controls.Add(this.YALE4);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo05);
            this.gbYale5thInfo.Controls.Add(this.YALE3);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo04);
            this.gbYale5thInfo.Controls.Add(this.YALE2);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo03);
            this.gbYale5thInfo.Controls.Add(this.YALE1);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo02);
            this.gbYale5thInfo.Controls.Add(this.YALE0);
            this.gbYale5thInfo.Controls.Add(this.lbYaleInfo01);
            this.gbYale5thInfo.Location = new System.Drawing.Point(160, 88);
            this.gbYale5thInfo.Name = "gbYale5thInfo";
            this.gbYale5thInfo.Size = new System.Drawing.Size(440, 376);
            this.gbYale5thInfo.TabIndex = 2;
            this.gbYale5thInfo.TabStop = false;
            this.gbYale5thInfo.Text = "Information";
            // 
            // lbYaleInfo31
            // 
            this.lbYaleInfo31.AutoSize = true;
            this.lbYaleInfo31.Location = new System.Drawing.Point(232, 312);
            this.lbYaleInfo31.Name = "lbYaleInfo31";
            this.lbYaleInfo31.Size = new System.Drawing.Size(30, 13);
            this.lbYaleInfo31.TabIndex = 73;
            this.lbYaleInfo31.Text = "Dec:";
            // 
            // lbYaleInfo13
            // 
            this.lbYaleInfo13.AutoSize = true;
            this.lbYaleInfo13.Location = new System.Drawing.Point(328, 112);
            this.lbYaleInfo13.Name = "lbYaleInfo13";
            this.lbYaleInfo13.Size = new System.Drawing.Size(54, 13);
            this.lbYaleInfo13.TabIndex = 35;
            this.lbYaleInfo13.Text = "DEs1900:";
            // 
            // lbYaleInfo12
            // 
            this.lbYaleInfo12.AutoSize = true;
            this.lbYaleInfo12.Location = new System.Drawing.Point(224, 112);
            this.lbYaleInfo12.Name = "lbYaleInfo12";
            this.lbYaleInfo12.Size = new System.Drawing.Size(57, 13);
            this.lbYaleInfo12.TabIndex = 33;
            this.lbYaleInfo12.Text = "DEm1900:";
            // 
            // lbYaleInfo08
            // 
            this.lbYaleInfo08.AutoSize = true;
            this.lbYaleInfo08.Location = new System.Drawing.Point(144, 80);
            this.lbYaleInfo08.Name = "lbYaleInfo08";
            this.lbYaleInfo08.Size = new System.Drawing.Size(57, 13);
            this.lbYaleInfo08.TabIndex = 27;
            this.lbYaleInfo08.Text = "RAm1900:";
            // 
            // YALE1
            // 
            this.YALE1.Location = new System.Drawing.Point(216, 16);
            this.YALE1.Name = "YALE1";
            this.YALE1.ReadOnly = true;
            this.YALE1.Size = new System.Drawing.Size(80, 20);
            this.YALE1.TabIndex = 16;
            // 
            // tabCgliese3rd
            // 
            this.tabCgliese3rd.Controls.Add(this.lbGliese3rd);
            this.tabCgliese3rd.Controls.Add(this.nudGlieseSNo);
            this.tabCgliese3rd.Controls.Add(this.lbStarNoGliese3rd);
            this.tabCgliese3rd.Controls.Add(this.lbSearchResultGliese3rd);
            this.tabCgliese3rd.Controls.Add(this.gbSearchGliese3rd);
            this.tabCgliese3rd.Controls.Add(this.gbGliese3rdInfo);
            this.tabCgliese3rd.Location = new System.Drawing.Point(4, 22);
            this.tabCgliese3rd.Name = "tabCgliese3rd";
            this.tabCgliese3rd.Size = new System.Drawing.Size(608, 470);
            this.tabCgliese3rd.TabIndex = 2;
            this.tabCgliese3rd.Text = "Gliese 3rd";
            // 
            // lbGliese3rd
            // 
            this.lbGliese3rd.Location = new System.Drawing.Point(8, 160);
            this.lbGliese3rd.Name = "lbGliese3rd";
            this.lbGliese3rd.Size = new System.Drawing.Size(144, 303);
            this.lbGliese3rd.TabIndex = 12;
            this.lbGliese3rd.SelectedIndexChanged += new System.EventHandler(this.ListBox3SelectedIndexChanged);
            // 
            // tabHYHv11
            // 
            this.tabHYHv11.Controls.Add(this.nudHYGSNo);
            this.tabHYHv11.Controls.Add(this.lbStarNoHYGv11);
            this.tabHYHv11.Controls.Add(this.lbHyv11);
            this.tabHYHv11.Controls.Add(this.lbSearchResultHYGv11);
            this.tabHYHv11.Controls.Add(this.gbSearchHYGv11);
            this.tabHYHv11.Controls.Add(this.gbHYGv11Info);
            this.tabHYHv11.Location = new System.Drawing.Point(4, 22);
            this.tabHYHv11.Name = "tabHYHv11";
            this.tabHYHv11.Size = new System.Drawing.Size(608, 470);
            this.tabHYHv11.TabIndex = 0;
            this.tabHYHv11.Text = "HYG v.1.1";
            // 
            // lbHyv11
            // 
            this.lbHyv11.Location = new System.Drawing.Point(8, 160);
            this.lbHyv11.Name = "lbHyv11";
            this.lbHyv11.Size = new System.Drawing.Size(144, 303);
            this.lbHyv11.TabIndex = 0;
            this.lbHyv11.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabHYHv11);
            this.tabControl1.Controls.Add(this.tabYale5ht);
            this.tabControl1.Controls.Add(this.tabCgliese3rd);
            this.tabControl1.Controls.Add(this.tabCalcs);
            this.tabControl1.Controls.Add(this.tabGreekAlphabet);
            this.tabControl1.Controls.Add(this.tabConstellationAbbrv);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(616, 496);
            this.tabControl1.TabIndex = 0;
            // 
            // BrowseDatabase
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(616, 494);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BrowseDatabase";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Browse star databases";
            this.gbHYGv11Info.ResumeLayout(false);
            this.gbHYGv11Info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudYaleSNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGlieseSNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHYGSNo)).EndInit();
            this.gbSearchHYGv11.ResumeLayout(false);
            this.gbSearchHYGv11.PerformLayout();
            this.gbSearchYale5th.ResumeLayout(false);
            this.gbSearchYale5th.PerformLayout();
            this.gbSearchGliese3rd.ResumeLayout(false);
            this.gbSearchGliese3rd.PerformLayout();
            this.gbGliese3rdInfo.ResumeLayout(false);
            this.gbGliese3rdInfo.PerformLayout();
            this.gbDeclication.ResumeLayout(false);
            this.gbDeclication.PerformLayout();
            this.gbDeclination2.ResumeLayout(false);
            this.gbDeclination2.PerformLayout();
            this.gbRAtoHMSRA.ResumeLayout(false);
            this.gbRAtoHMSRA.PerformLayout();
            this.tabConstellationAbbrv.ResumeLayout(false);
            this.tabCalcs.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.gbJ1950toJ2000.ResumeLayout(false);
            this.gbJ1950toJ2000.PerformLayout();
            this.gbHMSRAtoRA.ResumeLayout(false);
            this.gbHMSRAtoRA.PerformLayout();
            this.tabGreekAlphabet.ResumeLayout(false);
            this.tabYale5ht.ResumeLayout(false);
            this.tabYale5ht.PerformLayout();
            this.gbYale5thInfo.ResumeLayout(false);
            this.gbYale5thInfo.PerformLayout();
            this.tabCgliese3rd.ResumeLayout(false);
            this.tabCgliese3rd.PerformLayout();
            this.tabHYHv11.ResumeLayout(false);
            this.tabHYHv11.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private ListView lvGreekAlpha;
        private ColumnHeader colUpperLetter;
        private ColumnHeader colLowerLetter;
        private ColumnHeader colAbbreviation;
        private ColumnHeader colName;
        private ListView lvConstellations;
        private ColumnHeader colShortName;
        private ColumnHeader colLongName;

    }
}

