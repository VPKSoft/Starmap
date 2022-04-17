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

using Plotter;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using VPKSoft.LangLib;

namespace SMap
{
    /// <summary>
    /// Description of Form1.
    /// </summary>
    public partial class JumpToTime : DBLangEngineWinforms
    {
        public JumpToTime()
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
        }

        private static MainForm MainF;
        private double longitude;

        public static void Execute(ref MainForm Mf, double longitude)
        {
            MainF = Mf;
            JumpToTime jump = new JumpToTime();
            int SaveMode = MainF.DrawMode;
            jump.longitude = longitude;
            if (jump.ShowDialog() != DialogResult.Yes)
            {
                MainF.DrawMode = SaveMode;
            }
        }

        void Button1Click(object sender, System.EventArgs e)
        {
            MainF.DrawMap(Plot.NoDayLight(dtpJump.Value));
        }

        private List<KeyValuePair<double, DateTime>> sidereals = new List<KeyValuePair<double, DateTime>>();

        private DateTime lastDate = new DateTime();

        private void Recalc()
        {
            sidereals.Clear();
            DateTime dtStart = new DateTime(dtpJump.Value.Year, dtpJump.Value.Month, dtpJump.Value.Day, 0, 0, 0, DateTimeKind.Local);
            DateTime dtEnd = new DateTime(dtpJump.Value.Year, dtpJump.Value.Month, dtpJump.Value.Day, 23, 59, 0, DateTimeKind.Local);
            int tbSiderealIndex = 0, iCount = 0;
            while (dtStart <= dtEnd)
            {
                sidereals.Add(new KeyValuePair<double, DateTime>(Plot.SiderealTime(Plot.NoDayLight(dtStart), longitude), dtStart));
                if (dtStart == dtpJump.Value)
                {
                    tbSiderealIndex = iCount;
                }
                iCount++;
                dtStart = dtStart.AddMinutes(1);
            }
            tbSidereal.Scroll -= tbSidereal_Scroll;
            tbSidereal.Value = tbSiderealIndex;
            tbSidereal.Scroll += tbSidereal_Scroll;
            tbSiederealTime.TextChanged -= tbSiederealTime_TextChanged;
            KeyValuePair<double, DateTime> sidereal = sidereals.Find(t => t.Value == dtpJump.Value);
            tbSiederealTime.Text = sidereal.Key.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            tbSiederealTime.TextChanged += tbSiederealTime_TextChanged;
        }

        private void dtpJump_ValueChanged(object sender, EventArgs e)
        {
            if (lastDate.Year != dtpJump.Value.Year || lastDate.Month != dtpJump.Value.Month || lastDate.Day != dtpJump.Value.Day)
            {
                Recalc();
            }
            else
            {
                tbSidereal.Scroll -= tbSidereal_Scroll;
                tbSidereal.Value = sidereals.FindIndex(t => t.Value == dtpJump.Value);
                tbSidereal.Scroll += tbSidereal_Scroll;
            }
            tbSiederealTime.TextChanged -= tbSiederealTime_TextChanged;
            KeyValuePair<double, DateTime> sidereal = sidereals.Find(t => t.Value == dtpJump.Value);
            tbSiederealTime.Text = sidereal.Key.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            tbSiederealTime.TextChanged += tbSiederealTime_TextChanged;
            lastDate = dtpJump.Value;
        }

        private void tbSidereal_Scroll(object sender, EventArgs e)
        {
            double sidereal = sidereals[tbSidereal.Value].Key;
            dtpJump.ValueChanged -= dtpJump_ValueChanged;
            tbSiederealTime.TextChanged -= tbSiederealTime_TextChanged;
            tbSiederealTime.Text = sidereal.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);
            dtpJump.Value = sidereals[tbSidereal.Value].Value;
            tbSiederealTime.TextChanged += tbSiederealTime_TextChanged;
            dtpJump.ValueChanged += dtpJump_ValueChanged;
        }

        private void tbSiederealTime_TextChanged(object sender, EventArgs e)
        {
            dtpJump.ValueChanged -= dtpJump_ValueChanged;
            try
            {
                double dVal = double.Parse(tbSiederealTime.Text, CultureInfo.InvariantCulture);
                KeyValuePair<double, DateTime> sidereal = new KeyValuePair<double, DateTime>(-1, DateTime.MinValue);
                int index = -1;
                for (int i = 0; i < sidereals.Count - 1; i++)
                {
                    if (dVal >= sidereals[i].Key && dVal <= sidereals[i + 1].Key)
                    {
                        sidereal = sidereals[i];
                        index = i;
                        break;
                    }
                }
                if (sidereal.Key != -1)
                {
                    tbSidereal.Value = index;
                    dtpJump.Value = sidereal.Value;
                }
            }
            catch
            {

            }
            dtpJump.ValueChanged += dtpJump_ValueChanged;
        }

        private void JumpToTime_Shown(object sender, EventArgs e)
        {
            MainF.DrawMode = -1;
            DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            dtpJump.Value = dt;
            Recalc();
        }

        private void btCloseHold_Click(object sender, EventArgs e)
        {
            MainF.DrawMode = -1;
            MainF.DrawMap(Plot.NoDayLight(dtpJump.Value));
            DialogResult = DialogResult.Yes;
        }
    }
}
