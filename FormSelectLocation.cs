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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SQLite;
using VPKSoft.LangLib;
using VPKSoft.Utils;

namespace SMap
{
    public partial class FormSelectLocation : DBLangEngineWinforms
    {
        internal class CityEntry
        {
            public string Name { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }

            private string LatString
            {
                get
                {
                    return Latitude > 0 ? Latitude.ToString("F2", CultureInfo.InvariantCulture) + " N°" : (-Latitude).ToString("F2", CultureInfo.InvariantCulture) + " S°";
                }
            }

            private string LongString
            {
                get
                {
                    return Longitude > 0 ? Longitude.ToString("F2", CultureInfo.InvariantCulture) + " E°" : (-Longitude).ToString("F2", CultureInfo.InvariantCulture) + " W°";
                }
            }

            public override string ToString()
            {
                return Name + " (" + LatString + ", " + LongString + ")";
            }

            public CityEntry(string name, double latitude, double longitude)
            {
                Name = name;
                Latitude = latitude;
                Longitude = longitude;
            }

        }

        double latitude = 0;
        double longitude = 0;
        string name = string.Empty;

        private string MKLatString(double dValue)
        {
            return dValue > 0 ? dValue.ToString("F2", CultureInfo.InvariantCulture) + " N°" : (-dValue).ToString("F2", CultureInfo.InvariantCulture) + " S°";
        }

        private string MKLongString(double dValue)
        {
            return dValue > 0 ? dValue.ToString("F2", CultureInfo.InvariantCulture) + " E°" : (-dValue).ToString("F2", CultureInfo.InvariantCulture) + " W°";
        }

        private string LatString
        {
            get
            {
                return MKLatString(latitude);
            }
        }

        private string LongString
        {
            get
            {
                return MKLongString(longitude);
            }
        }

        private string NameLatLonText
        {
            get
            {
                return name == string.Empty ? LatString + ", " + LongString:
                                              name + " (" + LatString + ", " + LongString + ")";
            }
        }

        private string LatLonText
        {
            get
            {
                return LatString + ", " + LongString;
            }
        }

        private string MKLatLonText(double lat, double lon)
        {
            return MKLatString(lat) + ", " + MKLongString(lon);
        }

        private List<CityEntry> cities = new List<CityEntry>();

        public FormSelectLocation()
        {
            InitializeComponent();
            if (VPKSoft.LangLib.Utils.ShouldLocalize() != null)
            {
                DBLangEngine.InitalizeLanguage("SMap.Messages", VPKSoft.LangLib.Utils.ShouldLocalize(), false);
                return; // After localization don't do anything more.
            }
            DBLangEngine.InitalizeLanguage("SMap.Messages");

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=" + VPKSoft.Utils.Paths.AppInstallDir + @"WorldCities\WorldCities.sqlite3;Pooling=true;FailIfMissing=true"))
            {
                conn.Open();
                using (SQLiteCommand command = new SQLiteCommand("SELECT NAME, LATITUDE, LONGITUDE FROM WORLDCITIES ORDER BY NAME COLLATE NOCASE ", conn))
                {
                    using (SQLiteDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cities.Add(new CityEntry(dr.GetString(0), dr.GetDouble(1), dr.GetDouble(2)));
                        }
                    }
                }
            }
        }

        private void pbPickLocation_MouseMove(object sender, MouseEventArgs e)
        {
            double lon = ((double)pbPickLocation.Width / 2.0 - (double)e.X) / (double)pbPickLocation.Width;
            double lat = ((double)pbPickLocation.Height / 2.0 - (double)e.Y) / (double)pbPickLocation.Height;
            lat *= 90 * 2;
            lon *= 180 * 2 * -1;
            lbMouseLatLon.Text = DBLangEngine.GetMessage("msgSelectLocation", "Select your location [{0}]|As in the caption of the window and the location with latitude and longitude", MKLatLonText(lat, lon));
        }

        private void pbPickLocation_MouseDown(object sender, MouseEventArgs e)
        {
            double lon = ((double)pbPickLocation.Width / 2.0 - (double)e.X) / (double)pbPickLocation.Width;
            double lat = ((double)pbPickLocation.Height / 2.0 - (double)e.Y) / (double)pbPickLocation.Height;
            lat *= 90 * 2;
            lon *= 180 * 2 * -1;
            latitude = lat;
            longitude = lon;
            name = DBLangEngine.GetMessage("msgFromMap", "From map|As a world map which was used to pick a location (lat/lon)");
            Text = DBLangEngine.GetMessage("msgSelectLocation", "Select your location [{0}]|As in the caption of the window and the location with latitude and longitude", LatLonText);
        }

        private void tbFindLocation_TextChanged(object sender, EventArgs e)
        {
            cmbSelectLocation.Items.Clear();
            List<CityEntry> found = cities.FindAll(s => s.Name.ToLower().Contains(tbFindLocation.Text.ToLower()));
            cmbSelectLocation.Items.AddRange(found.ToArray());
            if (cmbSelectLocation.Items.Count > 0 &&
                cmbSelectLocation.SelectedItem == null)
            {
                cmbSelectLocation.SelectedIndex = 0;
            }
        }

        public static bool Execute(out double latidute, out double longitude, out string name)
        {
            FormSelectLocation frm = new FormSelectLocation();
            bool retval = frm.ShowDialog() == DialogResult.OK;
            latidute = frm.latitude;
            longitude = frm.longitude;
            name = frm.name;
            return retval;
        }

        private void cmbSelectLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectLocation.SelectedItem != null)
            {
                latitude = (cmbSelectLocation.SelectedItem as CityEntry).Latitude;
                longitude = (cmbSelectLocation.SelectedItem as CityEntry).Longitude;
                name = (cmbSelectLocation.SelectedItem as CityEntry).Name;
            }
            else
            {
                latitude = 0;
                longitude = 0;
                name = string.Empty;
            }
            Text = DBLangEngine.GetMessage("msgSelectLocation", "Select your location [{0}]|As in the caption of the window and the location with latitude and longitude", NameLatLonText);
        }
    }
}
