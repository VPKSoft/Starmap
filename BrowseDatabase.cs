#region License
/*
Starmap

A 2D star map program.
Copyright © 2017 VPKSoft, Petteri Kautonen

Contact: vpksoft@vpksoft.net

This file is part of Starmap.

Starmap is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Starmap is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with Starmap.  If not, see <http://www.gnu.org/licenses/>.
*/
#endregion

using Stellar;
using Plotter;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.IO;
using VPKSoft.LangLib;


using ListClasses;

namespace SMap
{
    /// <summary>
    /// Description of BrowseDatabase.
    /// </summary>
    public partial class BrowseDatabase : DBLangEngineWinforms
    {
        private HYGHolder Hyg;
        private GlieseHolder Gliese;
        private YaleHolder Yale;
        private int HygCount;
        private int YaleCount;
        private int GlieseCount;

        string StarNumberText2 = string.Empty;
        static string InvalidFloatingPointText = string.Empty;
        static string InvalidIntegerText = string.Empty;
        static string CanNotSearchEmptyStringText = string.Empty;
        static string WhenSearchingFlagOnlyOneCharacterNeededText = string.Empty;
        static string InternalErrorByteInStrText = string.Empty;

        string ErrorInvalidValues = string.Empty;
        string ErrorInvalidValue = string.Empty;
        string ErrorUpperCase = string.Empty;
        string ErrorSpeedHigherThanLightSpeed = string.Empty;
        string ErrorSpeedSmallerThanZero = string.Empty;
        string ErrorDistanceSmallerThanZero = string.Empty;
        string ErrorDialogCaption = string.Empty;


        public BrowseDatabase()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            if (Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("SMap.Messages", Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }
            DBLangEngine.InitalizeLanguage("SMap.Messages");
            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            MaximizeBox = false;
            MinimizeBox = false;
            string OpDir = MainForm.OpDir;
            Hyg = new HYGHolder(OpDir + @"/Data/StarData/hyg_bin.dat");
            Gliese = new GlieseHolder(OpDir + @"/Data/StarData/gliese3_bin.dat");
            Yale = new YaleHolder(OpDir + @"/Data/StarData/yale_bin.dat");
            HygCount = Hyg.HYG.Length;
            YaleCount = Yale.Yale.Length;
            GlieseCount = Gliese.Gliese.Length;
            ListHyg();
            ListYale();
            ListGliese();

            InitLanguage();

            InitSearchHyg();
            InitSearchYale();
            InitSearchGliese();
            GreekAlphaList();
            SListList(OpDir);
        }
        void GroupBox1Enter(object sender, System.EventArgs e)
        {

        }

        void InitLanguage()
        {
            cmbHygSIndex.Items.Clear();
            cmbHygSIndex.Items.AddRange(DBLangEngine.GetMessage("msgHygItems", "StarID          : Star ID;HD              : Star ID / H. Draper database;HR              : Star ID / Harvard/Yale database;Gliese          : Star ID / Gliese database;BayerFlamsteed  : Bayer / Flamsteed designation;Ra              : Right ascension;Dec             : Declination;ProperName      : Common name;Distance        : Distance (pc);Mag             : Magnitude;AbsMag          : Absolute magnitude;Spectrum        : Spectrum;ColorIndex      : Color index|Items for the HYG v.1.1 ComboBox").Split(';'));
            cmbHygSIndex.SelectedIndex = 0;

            cmbYaleSIndex.Items.Clear();
            cmbYaleSIndex.Items.AddRange(DBLangEngine.GetMessage("msgYaleItems", "HR              : Harvard Revised Number = Bright Star Number;Name            : Name, generally Bayer and/or Flamsteed name;DM              : Durchmusterung Identification;HD              : Henry Draper Catalog Number;SAO             : SAO Catalog Number;FK5             : FK5-number;IRflag          : I if infrared source;RAh1900         : RA, hours / B1900;RAh1900         : RA, minutes / B1900;RAh1900         : RA, seconds / B1900;DE-1900         : Declination, sign / B1900;DEd1900         : Declination, degrees / B1900;DEm1900         : Declination, minutes / B1900;DEs1900         : Declination, seconds / B1900;RAh             : RA, hours;RAm             : RA, minutes;RAs             : RA, seconds;DE-             : Declination, sign;DEd             : Declination, degrees;DEm             : Declination, minutes;DEs             : Declination, seconds;GLON            : Galactic longitude;GLAT            : Galactic latitude;VMag            : Visual magnitude;SpType          : Spectral type;pmRA            : Annual proper motion in RA J2000, FK5;pmDE            : Annual proper motion in Dec J2000, FK5;RadVel          : Heliocentric Radial Velocity;n_RadVel        : Radial velocity comments;RotVel          : Rotational velocity;Ra              : Right ascension;Dec             : Declination|Items for Yale 5th").Split(';'));
            cmbYaleSIndex.SelectedIndex = 0;

            cmbGlieseSIndex.Items.Clear();
            cmbGlieseSIndex.Items.AddRange(DBLangEngine.GetMessage("msgGlieseItems", "Ident           : Identification number;RAh             : RA, hours / B1950;RAm             : RA, minutes / B1950;RAs             : RA, seconds / B1950;DE-             : Declination, sign;DEd             : Declination, degrees / B1950;DEm             : Declination, minutes / B1950;pm              : Total proper motion (arcsec/yr);pmPA            : Direction angle of proper motion;RV              : Radial velocity;Sp              : Spectral type or color class;Vmag            : Apparent magnitude;Mv              : Absolute visual magnitude;U               : space velocity component in the galactic plane and directed to the galactic center (km/sec);V               : space velocity component in the galactic plane and in the direction of galactic rotation (km/sec);W               : space velocity component in the galactic plane and in the direction of the North Galactic Pole (km/sec);HD              : Star ID / H. Draper -database;DM              : Durchmusterung number BD / CD / CP ?;Giclas          : Number;LHS             : Number;Other           : Other;Remarks         : Remarks;RA              : RA / B1950;Dec             : Declination   / B1950|Items for Gliese 3rd").Split(';'));
            cmbGlieseSIndex.SelectedIndex = 0;
        }


        public void ListHyg()
        {
            nudHYGSNo.Maximum = HygCount;
            SetHyg(0);
            lbHyv11.Items.Clear();
        }

        public void ListYale()
        {
            nudYaleSNo.Maximum = YaleCount;
            SetYale(0);
            lbYale5Th.Items.Clear();
        }

        public void ListGliese()
        {
            nudGlieseSNo.Maximum = GlieseCount;
            SetGliese(0);
            lbGliese3rd.Items.Clear();
        }

        public void SetHyg(int Index)
        {
            HYGBinary HB = new HYGBinary();
            HB = Hyg.GetStar(Index);
            HYG0.Text = HB.StarID.ToString();
            HYG1.Text = HB.HD.ToString();
            HYG2.Text = HB.HR.ToString();
            HYG3.Text = HB.Gliese;
            HYG4.Text = HB.BayerFlamsteedName;
            HYG5.Text = HB.RA.ToString();
            HYG6.Text = HB.Dec.ToString();
            HYG7.Text = HB.ProperName;
            HYG8.Text = HB.Distance.ToString();
            HYG9.Text = HB.Mag.ToString();
            HYG10.Text = HB.AbsMag.ToString();
            HYG11.Text = HB.Spectrum;
            HYG12.Text = HB.ColorIndex.ToString();
            gbHYGv11Info.Text = string.Format(StarNumberText2, Index, HygCount);

        }

        public void SetYale(int Index)
        {
            YaleBinary YB = new YaleBinary();
            YB = Yale.GetStar(Index);
            YALE0.Text = YB.HR.ToString();
            YALE1.Text = YB.Name;
            YALE2.Text = YB.DM.ToString();
            YALE3.Text = YB.HD.ToString();
            YALE4.Text = YB.SAO.ToString();
            YALE5.Text = YB.FK5.ToString();
            YALE6.Text = YB.RAh1900.ToString();
            YALE7.Text = YB.RAm1900.ToString();
            YALE8.Text = YB.RAs1900.ToString();
            if (YB.DE_1900 == '-') YALE9.Text = "-"; else YALE9.Text = "+";
            YALE10.Text = YB.DEd1900.ToString();
            YALE11.Text = YB.DEm1900.ToString();
            YALE12.Text = YB.DEs1900.ToString();
            YALE13.Text = YB.RAh.ToString();
            YALE14.Text = YB.RAm.ToString();
            YALE15.Text = YB.RAs.ToString();
            if (YB.DE_ == '-') YALE16.Text = "-"; else YALE16.Text = "+";
            YALE17.Text = YB.DEd.ToString();
            YALE18.Text = YB.DEm.ToString();
            YALE19.Text = YB.DEs.ToString();
            YALE20.Text = YB.GLON.ToString();
            YALE21.Text = YB.GLAT.ToString();
            YALE22.Text = YB.Vmag.ToString();
            YALE23.Text = YB.pmRA.ToString();
            YALE24.Text = YB.pmDE.ToString();
            YALE25.Text = YB.RadVel.ToString();
            YALE26.Text = YB.n_RadVel.ToString();
            YALE27.Text = YB.RotVel.ToString();
            YALE28.Text = NULLTStrings.NULLTToString(new byte[] { (byte)YB.IRflag, 0 });
            YALE29.Text = StarDataHolder.HMSRaToRa(YB.RAh, YB.RAm, YB.RAs).ToString();
            YALE30.Text = StarDataHolder.DMSDecToDec(YB.DEd, YB.DEm, YB.DEs, YB.DE_).ToString();
            YALE31.Text = YB.SpType;
            gbYale5thInfo.Text = string.Format(StarNumberText2, Index, YaleCount);
        }

        public void SetGliese(int Index)
        {
            GlieseBinary GB = new GlieseBinary();
            GB = Gliese.GetStar(Index);
            GLIESE0.Text = GB.Ident;
            GLIESE1.Text = GB.RAh.ToString();
            GLIESE2.Text = GB.RAm.ToString();
            GLIESE3.Text = GB.RAs.ToString();
            if (GB.DE_ == '-') GLIESE4.Text = "-"; else GLIESE4.Text = "+";
            GLIESE5.Text = GB.DEd.ToString();
            GLIESE6.Text = GB.DEm.ToString();
            GLIESE7.Text = GB.pm.ToString();
            GLIESE8.Text = GB.pmPA.ToString();
            GLIESE9.Text = GB.RV.ToString();
            GLIESE10.Text = GB.Sp;
            GLIESE11.Text = GB.V.ToString();
            GLIESE12.Text = GB.Mv.ToString();
            GLIESE13.Text = GB.U.ToString();
            GLIESE14.Text = GB.W.ToString();
            GLIESE15.Text = GB.HD.ToString();
            GLIESE16.Text = GB.DM;
            GLIESE17.Text = GB.Giclas;
            GLIESE18.Text = GB.LHS;
            GLIESE19.Text = GB.Other;
            GLIESE20.Text = StarDataHolder.HMSRaToRa(GB.RAh, GB.RAm, GB.RAs).ToString();
            GLIESE21.Text = StarDataHolder.DMDecToDec(GB.DEd, GB.DEm, GB.DE_).ToString();
            GLIESE22.Text = GB.Remarks;
            GLIESE23.Text = GB.Vmag.ToString();
            gbGliese3rdInfo.Text = string.Format(StarNumberText2, Index, GlieseCount);
        }

        public void InitSearchHyg()
        {
            switch (cmbHygSIndex.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 7:
                case 11:
                    {
                        HygS1.Visible = false;
                        HygSL.Visible = false;
                        HygS0.Width = 528;
                    }
                    break;
                case 5:
                case 6:
                case 8:
                case 9:
                case 10:
                case 12:
                    {
                        HygS1.Visible = true;
                        HygSL.Visible = true;
                        HygS0.Width = 368;
                        if (HygS1.Text.Length == 0) HygS1.Text = "0";
                    }
                    break;
            }
        }

        public void InitSearchYale()
        {
            switch (cmbYaleSIndex.SelectedIndex)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 10:
                case 17:
                case 24:
                case 28:
                    {
                        YaleS1.Visible = false;
                        YaleSL.Visible = false;
                        YaleS0.Width = 528;
                    }
                    break;
                case 7:
                case 8:
                case 9:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 25:
                case 26:
                case 27:
                case 29:
                case 30:
                case 31:
                    {
                        YaleS1.Visible = true;
                        YaleSL.Visible = true;
                        YaleS0.Width = 368;
                        if (YaleS1.Text.Length == 0) YaleS1.Text = "0";
                    }
                    break;
            }
        }

        public void InitSearchGliese()
        {
            switch (cmbGlieseSIndex.SelectedIndex)
            {
                case 0:
                case 4:
                case 10:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                    {
                        GlieseS1.Visible = false;
                        GlieseSL.Visible = false;
                        GlieseS0.Width = 528;
                    }
                    break;
                case 1:
                case 2:
                case 3:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 22:
                case 23:
                    {
                        GlieseS1.Visible = true;
                        GlieseSL.Visible = true;
                        GlieseS0.Width = 368;
                        if (GlieseS1.Text.Length == 0) GlieseS1.Text = "0";
                    }
                    break;
            }
        }

        static int FindDoubleRange(string Val1, string Val2, double SearchVal)
        {
            double SearchVal1, SearchVal2;
            try
            {
                SearchVal1 = Convert.ToDouble(Val1);
            }
            catch (ArgumentException)
            {
                MessageBox.Show(string.Format(InvalidFloatingPointText, Val1));
                return -1;
            }
            catch (FormatException)
            {
                MessageBox.Show(string.Format(InvalidFloatingPointText, Val1));
                return -1;
            }
            catch (OverflowException)
            {
                MessageBox.Show(string.Format(InvalidFloatingPointText, Val1));
                return -1;
            }
            try
            {
                SearchVal2 = Convert.ToDouble(Val2);
            }
            catch (ArgumentException)
            {
                MessageBox.Show(string.Format(InvalidFloatingPointText, Val2));
                return -1;
            }
            catch (FormatException)
            {
                MessageBox.Show(string.Format(InvalidFloatingPointText, Val2));
                return -1;
            }
            catch (OverflowException)
            {
                MessageBox.Show(string.Format(InvalidFloatingPointText, Val2));
                return -1;
            }
            SearchVal2 = Math.Abs(SearchVal2);
            if (InBetween(SearchVal1 - SearchVal2, SearchVal1 + SearchVal2, SearchVal))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static int SameInt(string Val1, int SearchVal)
        {
            int SearchVal1;
            try
            {
                SearchVal1 = Convert.ToInt32(Val1);
            }
            catch (ArgumentException)
            {
                MessageBox.Show(string.Format(InvalidIntegerText, Val1));
                return -1;
            }
            catch (FormatException)
            {
                MessageBox.Show(string.Format(InvalidIntegerText, Val1));
                return -1;
            }
            catch (OverflowException)
            {
                MessageBox.Show(string.Format(InvalidIntegerText, Val1));
                return -1;
            }
            if (SearchVal1 == SearchVal)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static int FindIntRange(string Val1, string Val2, int SearchVal)
        {
            int SearchVal1, SearchVal2;
            try
            {
                SearchVal1 = Convert.ToInt32(Val1);
            }
            catch (ArgumentException)
            {
                MessageBox.Show(string.Format(InvalidIntegerText, Val1));
                return -1;
            }
            catch (FormatException)
            {
                MessageBox.Show(string.Format(InvalidIntegerText, Val1));
                return -1;
            }
            catch (OverflowException)
            {
                MessageBox.Show(string.Format(InvalidIntegerText, Val1));
                return -1;
            }
            try
            {
                SearchVal2 = Convert.ToInt32(Val2);
            }
            catch (ArgumentException)
            {
                MessageBox.Show(string.Format(InvalidIntegerText, Val2));
                return -1;
            }
            catch (FormatException)
            {
                MessageBox.Show(string.Format(InvalidIntegerText, Val2));
                return -1;
            }
            catch (OverflowException)
            {
                MessageBox.Show(string.Format(InvalidIntegerText, Val2));
                return -1;
            }
            SearchVal2 = Math.Abs(SearchVal2);
            if (InBetween(SearchVal1 - SearchVal2, SearchVal1 + SearchVal2, SearchVal))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int ByteInStringUTF7(string Val1, byte[] Bytes)
        {
            if (Val1.Length == 0)
            {
                MessageBox.Show(CanNotSearchEmptyStringText);
                return -1;
            }
            if (Val1.Length > 1)
            {
                MessageBox.Show(WhenSearchingFlagOnlyOneCharacterNeededText);
                return -1;
            }
            if (Bytes == null)
            {
                MessageBox.Show(InternalErrorByteInStrText);
                return -1;
            }
            if (Bytes.Length == 0)
            {
                MessageBox.Show(InternalErrorByteInStrText);
                return -1;
            }
            System.Text.Encoding encoding = System.Text.Encoding.UTF7;
            String Val2 = encoding.GetString(Bytes, 0, 1);
            Val1 = Val1.ToUpper();
            Val2 = Val2.ToUpper();
            if (Val1.IndexOf(Val2) != -1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        static int StringInString(string Val1, string Val2)
        {
            if (Val1.Length == 0)
            {
                return 0;
            }
            if (Val2.Length == 0)
            {
                MessageBox.Show(CanNotSearchEmptyStringText);
                return -1;
            }
            Val1 = Val1.ToUpper();
            Val2 = Val2.ToUpper();
            if (Val1.IndexOf(Val2) != -1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public bool SearchHyg()
        {
            bool Found = false;
            HYGBinary HB;
            int Ret;
            lbHyv11.Items.Clear();
            switch (cmbHygSIndex.SelectedIndex)
            {
                case 0:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = SameInt(HygS0.Text, HB.StarID);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 1:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = SameInt(HygS0.Text, HB.HD);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 2:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = SameInt(HygS0.Text, HB.HR);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 3:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = StringInString(HB.Gliese, HygS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 4:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = StringInString(HB.BayerFlamsteedName, HygS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 5:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = FindDoubleRange(HygS0.Text, HygS1.Text, HB.RA);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 6:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = FindDoubleRange(HygS0.Text, HygS1.Text, HB.Dec);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 7:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = StringInString(HB.ProperName, HygS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 8:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = FindDoubleRange(HygS0.Text, HygS1.Text, HB.Distance);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 9:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = FindDoubleRange(HygS0.Text, HygS1.Text, HB.Mag);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 10:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = FindDoubleRange(HygS0.Text, HygS1.Text, HB.AbsMag);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 11:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = StringInString(HB.Spectrum, HygS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 12:
                    {
                        for (int i = 0; i < HygCount; i++)
                        {
                            HB = Hyg.GetStar(i);
                            Ret = FindDoubleRange(HygS0.Text, HygS1.Text, HB.ColorIndex);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbHyv11.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
            }
            return false;
        }

        public bool SearchYale()
        {
            bool Found = false;
            YaleBinary YB;
            int Ret;
            lbYale5Th.Items.Clear();
            switch (cmbYaleSIndex.SelectedIndex)
            {
                case 0:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = SameInt(YaleS0.Text, YB.HR);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 1:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = StringInString(YB.Name, YaleS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 2:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = StringInString(YB.DM, YaleS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 3:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = SameInt(YaleS0.Text, YB.HD);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 4:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = SameInt(YaleS0.Text, YB.SAO);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 5:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = SameInt(YaleS0.Text, YB.FK5);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 6:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = ByteInStringUTF7(YaleS0.Text, new byte[] { (byte)YB.IRflag });
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 7:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.RAh1900);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 8:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.RAm1900);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 9:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindDoubleRange(YaleS0.Text, YaleS1.Text, YB.RAs1900);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 10:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = ByteInStringUTF7(YaleS0.Text, new byte[] { (byte)YB.DE_1900 });
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 11:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.DEd1900);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 12:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.DEm1900);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 13:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.DEs1900);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 14:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.RAh);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 15:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.RAm);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 16:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindDoubleRange(YaleS0.Text, YaleS1.Text, YB.RAs);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 17:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = ByteInStringUTF7(YaleS0.Text, new byte[] { (byte)YB.DE_ });
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 18:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.DEd);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 19:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.DEm);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 20:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.DEs);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 21:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindDoubleRange(YaleS0.Text, YaleS1.Text, YB.GLON);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 22:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindDoubleRange(YaleS0.Text, YaleS1.Text, YB.GLAT);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 23:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindDoubleRange(YaleS0.Text, YaleS1.Text, YB.Vmag);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 24:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = StringInString(YB.SpType, YaleS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 25:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindDoubleRange(YaleS0.Text, YaleS1.Text, YB.pmRA);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 26:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindDoubleRange(YaleS0.Text, YaleS1.Text, YB.pmDE);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 27:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.RadVel);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 28:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = StringInString(YB.n_RadVel, YaleS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 29:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindIntRange(YaleS0.Text, YaleS1.Text, YB.RotVel);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 30:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindDoubleRange(YaleS0.Text, YaleS1.Text, StarDataHolder.HMSRaToRa(YB.RAh, YB.RAm, YB.RAs));
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 31:
                    {
                        for (int i = 0; i < YaleCount; i++)
                        {
                            YB = Yale.GetStar(i);
                            Ret = FindDoubleRange(YaleS0.Text, YaleS1.Text, StarDataHolder.DMSDecToDec(YB.DEd, YB.DEm, YB.DEs, YB.DE_));
                            if (Ret == 1)
                            {
                                Found = true;
                                lbYale5Th.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }

            }
            return false;
        }

        public bool SearchGliese()
        {
            bool Found = false;
            GlieseBinary GB;
            int Ret;
            lbGliese3rd.Items.Clear();
            switch (cmbGlieseSIndex.SelectedIndex)
            {
                case 0:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = StringInString(GB.Ident, GlieseS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 1:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindIntRange(GlieseS0.Text, GlieseS1.Text, GB.RAh);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 2:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindIntRange(GlieseS0.Text, GlieseS1.Text, GB.RAm);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 3:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindIntRange(GlieseS0.Text, GlieseS1.Text, GB.RAs);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 4:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = ByteInStringUTF7(GlieseS0.Text, new byte[] { (byte)GB.DE_ });
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 5:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindIntRange(GlieseS0.Text, GlieseS1.Text, GB.DEd);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 6:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindDoubleRange(GlieseS0.Text, GlieseS1.Text, GB.DEm);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 7:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindDoubleRange(GlieseS0.Text, GlieseS1.Text, GB.pm);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 8:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindDoubleRange(GlieseS0.Text, GlieseS1.Text, GB.pmPA);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 9:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindDoubleRange(GlieseS0.Text, GlieseS1.Text, GB.RV);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 10:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = StringInString(GB.Sp, GlieseS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 11:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindDoubleRange(GlieseS0.Text, GlieseS1.Text, GB.Vmag);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 12:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindDoubleRange(GlieseS0.Text, GlieseS1.Text, GB.Mv);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 13:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindIntRange(GlieseS0.Text, GlieseS1.Text, GB.U);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 14:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindIntRange(GlieseS0.Text, GlieseS1.Text, GB.V);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 15:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindIntRange(GlieseS0.Text, GlieseS1.Text, GB.W);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 16:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = SameInt(GlieseS0.Text, GB.HD);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 17:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = StringInString(GB.DM, GlieseS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 18:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = StringInString(GB.Giclas, GlieseS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 19:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = StringInString(GB.LHS, GlieseS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 20:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = StringInString(GB.Other, GlieseS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 21:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = StringInString(GB.Remarks, GlieseS0.Text);
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 22:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindDoubleRange(GlieseS0.Text, GlieseS1.Text, StarDataHolder.HMSRaToRa(GB.RAh, GB.RAm, GB.RAs));
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }
                case 23:
                    {
                        for (int i = 0; i < GlieseCount; i++)
                        {
                            GB = Gliese.GetStar(i);
                            Ret = FindDoubleRange(GlieseS0.Text, GlieseS1.Text, StarDataHolder.DMDecToDec(GB.DEd, GB.DEm, GB.DE_));
                            if (Ret == 1)
                            {
                                Found = true;
                                lbGliese3rd.Items.Add(i.ToString());
                            }
                            else if (Ret == -1)
                            {
                                return false;
                            }
                        }
                        return Found;
                    }


            }
            return false;
        }

        public static bool InBetween(double MinVal, double MaxVal, double Val)
        {
            if (Val >= MinVal && Val <= MaxVal) return true;
            return false;
        }

        public static bool InBetween(int MinVal, int MaxVal, int Val)
        {
            if (Val >= MinVal && Val <= MaxVal) return true;
            return false;
        }

        void ListBox1SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ListBox Lb = ((ListBox)sender);
            SetHyg(Convert.ToInt32(Lb.Items[Lb.SelectedIndex]));
        }

        void NumericUpDown1ValueChanged(object sender, System.EventArgs e)
        {
            NumericUpDown NoUD = ((NumericUpDown)sender);
            SetHyg((int)NoUD.Value);
        }

        void NumericUpDown2ValueChanged(object sender, System.EventArgs e)
        {
            NumericUpDown NoUD = ((NumericUpDown)sender);
            SetYale((int)NoUD.Value);
        }

        void ListBox2SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ListBox Lb = ((ListBox)sender);
            SetYale(Convert.ToInt32(Lb.Items[Lb.SelectedIndex]));
        }

        void NumericUpDown3ValueChanged(object sender, System.EventArgs e)
        {
            NumericUpDown NoUD = ((NumericUpDown)sender);
            SetGliese((int)NoUD.Value);
        }

        void ListBox3SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ListBox Lb = ((ListBox)sender);
            SetGliese(Convert.ToInt32(Lb.Items[Lb.SelectedIndex]));
        }

        void HygSIndexSelectedIndexChanged(object sender, System.EventArgs e)
        {
            InitSearchHyg();
        }

        void YaleSIndexSelectedIndexChanged(object sender, System.EventArgs e)
        {
            InitSearchYale();
        }

        void GlieseSIndexSelectedIndexChanged(object sender, System.EventArgs e)
        {
            InitSearchGliese();
        }

        void Button1Click(object sender, System.EventArgs e)
        {
            SearchHyg();
        }

        void Button2Click(object sender, System.EventArgs e)
        {
            SearchYale();
        }

        public void GreekAlphaList()
        {
            string greekAlphaShort = DBLangEngine.GetMessage("msgGreekAlphaShortNames", "Alp;Bet;Gam;Del;Eps;Zet;Eta;The;Iot;Kap;Lam;Mu;Nu;Xi;Omi;Pi;Rho;Sig;Tau;Ups;Phi;Chi;Psi;Ome|Greek alphabet short names");
            string greekAlphaLong = DBLangEngine.GetMessage("msgGreekAlphaLongNames", "Alpha;Beta;Gamma;Delta;Epsilon;Zeta;Eta;Theta;Iota;Kappa;Lamda;Mu;Nu;Xi;Omicron;Pi;Rho;Sigma;Tau;Upsilon;Phi;Chi;Psi;Omega|Greek alphabet long names");
            string greekAlphaLower = DBLangEngine.GetMessage("msgGreekAlphaLower", "αβγδεζηθικλμνξοπρςτυφχψω|Greek alphabet lower case");
            string greekAlphaUpper = DBLangEngine.GetMessage("msgGreekAlphaUpper", "ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ|Greek alphabet upper case");

            string[] alphaShortNames = greekAlphaShort.Split(';');
            string[] alphaLongNames = greekAlphaLong.Split(';');

            colUpperLetter.Text = DBLangEngine.GetMessage("msgUpperLetter", "Upper case letter|As in upper case letter/character");
            colLowerLetter.Text = DBLangEngine.GetMessage("msgLowerLetter", "Lower case letter|As in lower case letter/character");
            colAbbreviation.Text = DBLangEngine.GetMessage("msgLetterAbbreviation", "Abbreviation|An abbreviation of the letter/character name");
            colName.Text = DBLangEngine.GetMessage("msgLetterName", "Name|A name of the letter/character");

            for (int i = 0; i < greekAlphaUpper.Length; i++)
            {
                ListViewItem lvi = new ListViewItem(greekAlphaUpper.Substring(i, 1));
                lvi.SubItems.Add(greekAlphaLower.Substring(i, 1));
                lvi.SubItems.Add(alphaShortNames[i]);
                lvi.SubItems.Add(alphaLongNames[i]);
                lvGreekAlpha.Items.Add(lvi);
            }
        }

        public void SListList(string OpDir)
        {
            string[] shortConstNames = DBLangEngine.GetMessage("msgShortConstNames", "And;Ant;Aps;Aql;Aqr;Ara;Ari;Aur;Boo;Cae;Cam;Cap;Car;Cas;Cen;Cep;Cet;Cha;Cir;CMa;CMi;Cnc;Col;Com;CrA;CrB;Crt;Cru;Crv;CVn;Cyg;Del;Dor;Dra;Equ;Eri;For;Gem;Gru;Her;Hor;Hya;Hyi;Ind;Lac;Leo;Lep;Lib;LMi;Lup;Lyn;Lyr;Men;Mic;Mon;Mus;Nor;Oct;Oph;Ori;Pav;Peg;Per;Phe;Pic;PsA;Psc;Pup;Pyx;Ret;Scl;Sco;Sct;SeC;Ser;Sex;Sge;Sgr;Tau;Tel;TrA;Tri;Tuc;UMa;UMi;Vel;Vir;Vol;Vul|Short constellation names").Split(';');
            string[] longConstNames = DBLangEngine.GetMessage("msgLongConstNames", "Andromeda;Antlia;Apus;Aquila;Aquarius;Ara;Aries;Auriga;Boötes;Caelum;Camelopardalis;Capricornus;Carina;Cassiopeia;Centaurus;Cepheus;Cetus;Chamaeleon;Circinus;Canis Major;Canis Minor;Cancer;Columba;Coma Berenices;Corona Australis;Corona Borealis;Crater;Crux;Corvus;Canes Venatici;Cygnus;Delphinus;Dorado;Draco;Equuleus;Eridanus;Fornax;Gemini;Grus;Hercules;Horologium;Hydra;Hydrus;Indus;Lacerta;Leo;Lepus;Libra;Leo Minor;Lupus;Lynx;Lyra;Mensa;Microscopium;Monoceros;Musca;Norma;Octans;Ophiuchus;Orion;Pavo;Pegasus;Perseus;Phoenix;Pictor;Pisces Austrinus;Pisces;Puppis;Pyxis;Reticulum;Sculptor;Scorpius;Scutum;Serpens Cauda;Serpens Caput;Sextans;Sagitta;Sagittarius;Taurus;Telescopium;Triangulum Australe;Triangulum;Tucana;Ursa Major;Ursa Minor;Vela;Virgo;Volans;Vulpecula|Long constellation names").Split(';');

            colShortName.Text = DBLangEngine.GetMessage("msgConstellationShortName", "Short name|An abbreviation of the constellation name");
            colLongName.Text = DBLangEngine.GetMessage("msgConstellationLongName", "Long name|A name of the constellation");

            for (int i = 0; i < shortConstNames.Length; i++)
            {
                ListViewItem lvi = new ListViewItem(shortConstNames[i]);
                lvi.SubItems.Add(longConstNames[i]);
                lvConstellations.Items.Add(lvi);
            }


        }


        void Button4Click(object sender, System.EventArgs e)
        {
            try
            {
                int D = Convert.ToInt32(DMSD1.Text);
                int M = Convert.ToInt32(DMSD2.Text);
                int S = Convert.ToInt32(DMSD3.Text);
                DMSD4.Text = Convert.ToString(StarDataHolder.DMSDecToDec(D, M, S, DMSD0.Text));
            }
            catch
            {
                MessageBox.Show(ErrorInvalidValues, ErrorDialogCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void Button5Click(object sender, System.EventArgs e)
        {
            try
            {
                double Dec = Convert.ToDouble(DDMS0.Text);
                if (Dec < 0) DDMS1.Text = "-"; else DDMS1.Text = "+";
                Dec = Math.Abs(Dec);
                DDMS2.Text = Convert.ToString((int)Dec);
                Dec -= (int)Dec;
                Dec *= 60;
                DDMS3.Text = Convert.ToString((int)Dec);
                Dec -= Convert.ToInt32((int)Dec);
                Dec *= 60;
                DDMS4.Text = Convert.ToString((int)Dec);
            }
            catch
            {
                MessageBox.Show(ErrorInvalidValue, ErrorDialogCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void Button8Click(object sender, System.EventArgs e)
        {
            try
            {
                double RAB1950 = Convert.ToDouble(BJ0.Text);
                double DecB1950 = Convert.ToDouble(BJ2.Text);
                StarDataHolder.B1950ToJ2000(ref RAB1950, ref DecB1950);
                BJ1.Text = RAB1950.ToString();
                BJ3.Text = DecB1950.ToString();
            }
            catch
            {
                MessageBox.Show(ErrorInvalidValues, ErrorDialogCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private bool Novv = false;
        private bool Nopc = false;
        private bool NoAU = false;
        private bool Nokm = false;

        void VvTextChanged(object sender, System.EventArgs e)
        {
            if (Novv)
            {
                return;
            }
            NoAU = true;
            Nopc = true;
            Nokm = true;
            double Val;
            try
            {
                Val = Convert.ToDouble(vv.Text);
                pc.Text = StellarConver.lyTopc(Val).ToString();
                AU.Text = StellarConver.lyToAU(Val).ToString();
                km.Text = StellarConver.lyTokm(Val).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                pc.Text = Message;
                AU.Text = Message;
                km.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                pc.Text = Message;
                AU.Text = Message;
                km.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                pc.Text = Message;
                AU.Text = Message;
                km.Text = Message;
            }
            NoAU = false;
            Nopc = false;
            Nokm = false;
        }

        void AUTextChanged(object sender, System.EventArgs e)
        {
            if (NoAU)
            {
                return;
            }
            Novv = true;
            Nopc = true;
            Nokm = true;
            double Val;
            try
            {
                Val = Convert.ToDouble(AU.Text);
                pc.Text = StellarConver.AUTopc(Val).ToString();
                vv.Text = StellarConver.AUToly(Val).ToString();
                km.Text = StellarConver.AUTokm(Val).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                pc.Text = Message;
                vv.Text = Message;
                km.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                pc.Text = Message;
                vv.Text = Message;
                km.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                pc.Text = Message;
                vv.Text = Message;
                km.Text = Message;
            }
            Novv = false;
            Nopc = false;
            Nokm = false;
        }

        void PcTextChanged(object sender, System.EventArgs e)
        {
            if (Nopc)
            {
                return;
            }
            Novv = true;
            NoAU = true;
            Nokm = true;
            double Val;
            try
            {
                Val = Convert.ToDouble(pc.Text);
                AU.Text = StellarConver.pcToAU(Val).ToString();
                vv.Text = StellarConver.pcToly(Val).ToString();
                km.Text = StellarConver.pcTokm(Val).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                AU.Text = Message;
                vv.Text = Message;
                km.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                AU.Text = Message;
                vv.Text = Message;
                km.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                AU.Text = Message;
                vv.Text = Message;
                km.Text = Message;
            }
            Novv = false;
            NoAU = false;
            Nokm = false;
        }

        void KmTextChanged(object sender, System.EventArgs e)
        {
            if (Nokm)
            {
                return;
            }
            Novv = true;
            NoAU = true;
            Nopc = true;
            double Val;
            try
            {
                Val = Convert.ToDouble(km.Text);
                AU.Text = StellarConver.kmToAU(Val).ToString();
                vv.Text = StellarConver.kmToly(Val).ToString();
                pc.Text = StellarConver.kmTopc(Val).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                AU.Text = Message;
                vv.Text = Message;
                pc.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                AU.Text = Message;
                vv.Text = Message;
                pc.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                AU.Text = Message;
                vv.Text = Message;
                pc.Text = Message;
            }
            Novv = false;
            NoAU = false;
            Nopc = false;
        }

        private bool NoKmSek = false;
        private bool NoKmMin = false;
        private bool NoKmHour = false;
        void KmPerSekTextChanged(object sender, System.EventArgs e)
        {
            if (NoKmSek)
            {
                return;
            }

            NoKmMin = true;
            NoKmHour = true;

            double Val;
            try
            {
                if (kmPerSek.Text == "c")
                {
                    Val = StellarConver.c_KmPerSek;
                    NoKmSek = true;
                    kmPerSek.Text = Val.ToString();
                    NoKmSek = false;
                }
                else
                {
                    Val = Convert.ToDouble(kmPerSek.Text);
                }
                kmPerMin.Text = Convert.ToDouble(Val * 60).ToString();
                kmPerHour.Text = Convert.ToDouble(Val * 60 * 60).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                kmPerMin.Text = Message;
                kmPerHour.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                kmPerMin.Text = Message;
                kmPerHour.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                kmPerMin.Text = Message;
                kmPerHour.Text = Message;
            }
            NoKmMin = false;
            NoKmHour = false;
            PutTravelTimes();
        }

        void KmPerMinTextChanged(object sender, System.EventArgs e)
        {
            if (NoKmMin)
            {
                return;
            }

            NoKmSek = true;
            NoKmHour = true;

            double Val;
            try
            {
                Val = Convert.ToDouble(kmPerMin.Text);
                kmPerSek.Text = Convert.ToDouble(Val / 60).ToString();
                kmPerHour.Text = Convert.ToDouble(Val * 60).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                kmPerSek.Text = Message;
                kmPerHour.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                kmPerSek.Text = Message;
                kmPerHour.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                kmPerSek.Text = Message;
                kmPerHour.Text = Message;
            }
            NoKmSek = false;
            NoKmHour = false;
            PutTravelTimes();
        }

        void KmPerHourTextChanged(object sender, System.EventArgs e)
        {
            if (NoKmHour)
            {
                return;
            }

            NoKmSek = true;
            NoKmMin = true;

            double Val;
            try
            {
                Val = Convert.ToDouble(kmPerHour.Text);
                kmPerSek.Text = Convert.ToDouble(Val / 60 / 60).ToString();
                kmPerMin.Text = Convert.ToDouble(Val / 60).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                kmPerSek.Text = Message;
                kmPerMin.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                kmPerSek.Text = Message;
                kmPerMin.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                kmPerSek.Text = Message;
                kmPerMin.Text = Message;
            }
            NoKmSek = false;
            NoKmMin = false;
            PutTravelTimes();
        }

        private bool NoDistKm = false;
        private bool NoDistPc = false;
        private bool NoDistVv = false;
        private bool NoDistAU = false;
        void DistKmTextChanged(object sender, System.EventArgs e)
        {
            if (NoDistKm)
            {
                return;
            }
            NoDistVv = true;
            NoDistAU = true;
            NoDistPc = true;
            double Val;
            try
            {
                Val = Convert.ToDouble(distKm.Text);
                distAU.Text = StellarConver.kmToAU(Val).ToString();
                distVv.Text = StellarConver.kmToly(Val).ToString();
                distPc.Text = StellarConver.kmTopc(Val).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                distAU.Text = Message;
                distVv.Text = Message;
                distPc.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                distAU.Text = Message;
                distVv.Text = Message;
                distPc.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                distAU.Text = Message;
                distVv.Text = Message;
                distPc.Text = Message;
            }
            NoDistVv = false;
            NoDistAU = false;
            NoDistPc = false;
            PutTravelTimes();
        }

        void DistPcTextChanged(object sender, System.EventArgs e)
        {
            if (NoDistPc)
            {
                return;
            }
            NoDistVv = true;
            NoDistAU = true;
            NoDistKm = true;
            double Val;
            try
            {
                Val = Convert.ToDouble(distPc.Text);
                distAU.Text = StellarConver.pcToAU(Val).ToString();
                distVv.Text = StellarConver.pcToly(Val).ToString();
                distKm.Text = StellarConver.pcTokm(Val).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                distAU.Text = Message;
                distVv.Text = Message;
                distKm.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                distAU.Text = Message;
                distVv.Text = Message;
                distKm.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                distAU.Text = Message;
                distVv.Text = Message;
                distKm.Text = Message;
            }
            NoDistVv = false;
            NoDistAU = false;
            NoDistKm = false;
            PutTravelTimes();
        }

        void DistVvTextChanged(object sender, System.EventArgs e)
        {
            if (NoDistVv)
            {
                return;
            }
            NoDistPc = true;
            NoDistAU = true;
            NoDistKm = true;
            double Val;
            try
            {
                Val = Convert.ToDouble(distVv.Text);
                distAU.Text = StellarConver.lyToAU(Val).ToString();
                distPc.Text = StellarConver.lyTopc(Val).ToString();
                distKm.Text = StellarConver.lyTokm(Val).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                distAU.Text = Message;
                distKm.Text = Message;
                distPc.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                distAU.Text = Message;
                distKm.Text = Message;
                distPc.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                distKm.Text = Message;
                distVv.Text = Message;
                distPc.Text = Message;
            }
            NoDistPc = false;
            NoDistAU = false;
            NoDistKm = false;
            PutTravelTimes();
        }

        void DistAUTextChanged(object sender, System.EventArgs e)
        {
            if (NoDistAU)
            {
                return;
            }
            NoDistPc = true;
            NoDistVv = true;
            NoDistKm = true;
            double Val;
            try
            {
                Val = Convert.ToDouble(distAU.Text);
                distVv.Text = StellarConver.AUToly(Val).ToString();
                distPc.Text = StellarConver.AUTopc(Val).ToString();
                distKm.Text = StellarConver.AUTokm(Val).ToString();
            }
            catch (ArgumentException)
            {
                string Message = "-";
                distKm.Text = Message;
                distVv.Text = Message;
                distPc.Text = Message;
            }
            catch (FormatException)
            {
                string Message = "-";
                distKm.Text = Message;
                distVv.Text = Message;
                distPc.Text = Message;
            }
            catch (OverflowException)
            {
                string Message = "-";
                distKm.Text = Message;
                distVv.Text = Message;
                distPc.Text = Message;
            }
            NoDistPc = false;
            NoDistVv = false;
            NoDistKm = false;
            PutTravelTimes();
        }

        void PutTravelTimes()
        {
            double t = 0, s = 0, v = 0;
            bool Error = false;
            try
            {
                s = Convert.ToDouble(distKm.Text);
                v = Convert.ToDouble(kmPerSek.Text);
                t = s / v;
            }
            catch (ArgumentException)
            {
                Error = true;
            }
            catch (FormatException)
            {
                Error = true;
            }
            catch (OverflowException)
            {
                Error = true;
            }
            catch (DivideByZeroException)
            {
                Error = true;
            }
            double tmin = t / 60;
            double thour = tmin / 60;
            double tday = thour / 24;
            double tmonth = tday / 30.4375;
            double tyear = tmonth / 12;

            if (Error)
            {
                timeSeconds.Text = ErrorUpperCase;
                timeMinutes.Text = ErrorUpperCase;
                timeHours.Text = ErrorUpperCase;
                timeDays.Text = ErrorUpperCase;
                timeMonths.Text = ErrorUpperCase;
                timeYears.Text = ErrorUpperCase;
            }
            else
            {
                if (v > StellarConver.c_KmPerSek)
                {
                    string Message = String.Format(ErrorSpeedHigherThanLightSpeed, StellarConver.c_KmPerSek);
                    timeSeconds.Text = Message;
                    timeMinutes.Text = Message;
                    timeHours.Text = Message;
                    timeDays.Text = Message;
                    timeMonths.Text = Message;
                    timeYears.Text = Message;
                }
                else if (v <= 0)
                {
                    string Message = ErrorSpeedSmallerThanZero;
                    timeSeconds.Text = Message;
                    timeMinutes.Text = Message;
                    timeHours.Text = Message;
                    timeDays.Text = Message;
                    timeMonths.Text = Message;
                    timeYears.Text = Message;
                }
                else if (s <= 0)
                {
                    string Message = ErrorDistanceSmallerThanZero;
                    timeSeconds.Text = Message;
                    timeMinutes.Text = Message;
                    timeHours.Text = Message;
                    timeDays.Text = Message;
                    timeMonths.Text = Message;
                    timeYears.Text = Message;
                }
                else
                {
                    timeSeconds.Text = Convert.ToString(t);
                    timeMinutes.Text = Convert.ToString(tmin);
                    timeHours.Text = Convert.ToString(thour);
                    timeDays.Text = Convert.ToString(tday);
                    timeMonths.Text = Convert.ToString(tmonth);
                    timeYears.Text = Convert.ToString(tyear);
                }
            }
        }
        void Button7Click(object sender, System.EventArgs e)
        {
            int H = 0;
            int M = 0;
            int S = 0;
            try
            {
                H = Convert.ToInt32(HMSRA0.Text);
                M = Convert.ToInt32(HMSRA1.Text);
                S = Convert.ToInt32(HMSRA2.Text);
                HMSRA3.Text = Convert.ToString((double)H + ((double)M / 60.0) + ((double)S / 3600.0));
            }
            catch
            {
                MessageBox.Show(ErrorInvalidValues, ErrorDialogCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        void Button6Click(object sender, System.EventArgs e)
        {
            int H = 0;
            int M = 0;
            int S = 0;
            double Val = 0;
            try
            {
                Val = Convert.ToDouble(RAHMS0.Text);
                H = (int)Val;
                Val -= (double)H;
                Val *= 60;
                M = (int)Val;
                Val -= (double)M;
                Val *= 60;
                S = (int)Val;
                RAHMS1.Text = H.ToString();
                RAHMS2.Text = M.ToString();
                RAHMS3.Text = S.ToString();
            }
            catch
            {
                MessageBox.Show(ErrorInvalidValue, ErrorDialogCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //		void YaleS0KeyDown(object sender, System.EventArgs e) {}
        //		void GlieseS0KeyDown(object sender, System.EventArgs e) {}
        //		void HygS0KeyDown(object sender, System.EventArgs e) {}

        void HygS0Enter(object sender, System.EventArgs e)
        {
            AcceptButton = button1;
        }

        void YaleS0Enter(object sender, System.EventArgs e)
        {
            AcceptButton = button2;
        }

        void GlieseS0Enter(object sender, System.EventArgs e)
        {
            AcceptButton = button3;
        }

        void Button3Click(object sender, System.EventArgs e)
        {
            SearchGliese();
        }

        void DMSD0Enter(object sender, System.EventArgs e)
        {
            AcceptButton = btDeclination1;
        }

        void DDMS0Enter(object sender, System.EventArgs e)
        {
            AcceptButton = btDeclination2;
        }

        void BJ0Enter(object sender, System.EventArgs e)
        {
            AcceptButton = btJ1950toJ2000;
        }

        void HMSRA0Enter(object sender, System.EventArgs e)
        {
            AcceptButton = btHMSRAtoRA;
        }

        void RAHMS0Enter(object sender, System.EventArgs e)
        {
            AcceptButton = btRAtoHMSRA;
        }

    }
}
