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

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Diagnostics;
using ListClasses;
using VPKSoft.LangLib;

namespace SMap
{
    /// <summary>
    /// Description of Form1.
    /// </summary>
    public partial class ConfigForm : DBLangEngineWinforms
    {
        StringList LangShortList = new StringList();
        StringList LangLongList = new StringList();
        StringList LangResourceNamesList = new StringList();

        static MainForm MainF;

        public ConfigForm()
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
            lbSysTZSysValue.Text = Convert.ToString(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalHours * -1);
        }

        string GetLanguageSetting(string LangNameLong)
        {
            int Index = LangLongList.IndexOf(LangNameLong);
            if (Index >= 0)
            {
                return LangShortList.Strings[Index];
            }
            else
            {
                return "en-US";
            }
        }

        static SettingsConfig Conf;

        public void SetConf(ref SettingsConfig Config)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            SettingCfg cfg = Config.Cfg;
            cfg.PlaceName = tbLocationName.Text;
            cfg.Latitude = Convert.ToDouble(tbLat.Text, nfi);
            cfg.Longitude = Convert.ToDouble(tbLong.Text, nfi);
            //			Cfg.UTCBias = Convert.ToDouble(Utc.Text)/24.0;
            cfg.ConsLineCol = pnConstellationColor.BackColor.ToArgb();
            cfg.ConsNameCol = pnConstellationNameColor.BackColor.ToArgb();
            cfg.StarCol = pnStarColor.BackColor.ToArgb();
            cfg.StarMapCol = pnStarmapBackgroundColor.BackColor.ToArgb();

            cfg.UseConventionalCelestial = rbUseConventional.Checked; // 27.10.17

            if (rbYaleSmall.Checked)
            {
                cfg.StarDBIndex = 0;
            }
            else if (rbHYGv11.Checked)
            {
                cfg.StarDBIndex = 1;
            }
            else if (rbYaleLarge.Checked)
            {
                cfg.StarDBIndex = 2;
            }
            else if (rbGliese3rd.Checked)
            {
                cfg.StarDBIndex = 3;
            }
            else
            {
                cfg.StarDBIndex = -1;
            }

            if (rbConstNameShort.Checked)
            {
                cfg.StarNameIndex = 0;
            }
            else if (rbConstNameLong.Checked)
            {
                cfg.StarNameIndex = 1;
            }
            else
            {
                cfg.StarNameIndex = -1;
            }

            cfg.NoConsLines = cbHideCons.Checked;
            cfg.NoSolSys = cbHideSolSys.Checked;

            cfg.MagLimit = Convert.ToDouble(cmbMagLimit.Text, nfi);
            cfg.FlipX = cbFlipX.Checked;
            cfg.FlipY = cbFlipY.Checked;
            cfg.Language = CultureInfo.CurrentCulture.ToString();
            Config.Cfg = cfg;
        }

        public void PutConf(ref SettingsConfig Config)
        {
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";

            SettingCfg Cfg = Config.Cfg;
            tbLocationName.Text = Cfg.PlaceName;
            tbLat.Text = Convert.ToString(Cfg.Latitude, nfi);
            tbLong.Text = Convert.ToString(Cfg.Longitude, nfi);
            //			Utc.Text=Convert.ToString(Cfg.UTCBias*24.0);
            pnConstellationColor.BackColor = Color.FromArgb(Cfg.ConsLineCol);
            pnConstellationNameColor.BackColor = Color.FromArgb(Cfg.ConsNameCol);
            pnStarColor.BackColor = Color.FromArgb(Cfg.StarCol);
            pnStarmapBackgroundColor.BackColor = Color.FromArgb(Cfg.StarMapCol);

            rbUseConventional.Checked = Cfg.UseConventionalCelestial; // 27.10.17
            rbUseImages.Checked = !rbUseConventional.Checked; // 27.10.17

            switch (Cfg.StarDBIndex)
            {
                case 0:
                    rbYaleSmall.Checked = true;
                    break;
                case 1:
                    rbHYGv11.Checked = true;
                    break;
                case 2:
                    rbYaleLarge.Checked = true;
                    break;
                case 3:
                    rbGliese3rd.Checked = true;
                    break;
                default:
                    {
                        // ?						
                    }
                    break;
            }

            switch (Cfg.StarNameIndex)
            {
                case 0:
                    rbConstNameShort.Checked = true;
                    break;
                case 1:
                    rbConstNameLong.Checked = true;
                    break;
                default:
                    {
                        // ?						
                    }
                    break;
            }


            cbHideCons.Checked = Cfg.NoConsLines;
            cbHideSolSys.Checked = Cfg.NoSolSys;

            cmbMagLimit.Text = Convert.ToString(Cfg.MagLimit, nfi);
            cbFlipX.Checked = Cfg.FlipX;
            cbFlipY.Checked = Cfg.FlipY;
        }

        public static DialogResult Execute(ref SettingsConfig Config, MainForm Mf)
        {
            Conf = Config;
            MainF = Mf;
            ConfigForm AsetusIk = new ConfigForm();
            return AsetusIk.ShowDialog();
        }

        void Button1Click(object sender, System.EventArgs e)
        {
        }

        void Button2Click(object sender, System.EventArgs e)
        {
            SetConf(ref Conf);
            Conf.Save();
            DialogResult = DialogResult.OK;
        }

        void Col0Click(object sender, System.EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                ((Panel)sender).BackColor = colorDialog1.Color;
            }
        }

        void AsetusIkkunaLoad(object sender, System.EventArgs e)
        {
            PutConf(ref Conf);
        }

        private void btFind_Click(object sender, EventArgs e)
        {
            double latitude, longitude;
            string name;
            if (FormSelectLocation.Execute(out latitude, out longitude, out name))
            {
                tbLocationName.Text = name;
                tbLat.Text = latitude.ToString("F", CultureInfo.InvariantCulture);
                tbLong.Text = longitude.ToString("F", CultureInfo.InvariantCulture);
            }
        }
    }
}
