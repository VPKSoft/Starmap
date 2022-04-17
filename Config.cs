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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Globalization;
using VPKSoft.ConfLib;

namespace SMap
{
    public struct SettingCfg
    {
        public string PlaceName;
        public double Latitude;
        public double Longitude;
        public double UTCBias;
        public int ConsLineCol;
        public int StarCol;
        public int ConsNameCol;
        public int StarMapCol;
        public int StarDBIndex;
        public bool NoSolSys;
        public bool NoConsLines;
        public double MagLimit;
        public int StarNameIndex;
        public bool FlipX;
        public bool FlipY;
        public string CompassObjName;
        public double CompassObjRA;
        public double CompassObjDec;
        public string Language;
        public bool UseConventionalCelestial;
    }

    public class SettingsConfig
    {

        private SettingCfg cfg;
        private static Conflib config;
        public SettingsConfig()
        {
            config = new Conflib();
            config.AutoCreateSettings = true;
            cfg = new SettingCfg();
            Defaults();
            Load();
        }

        public SettingCfg Cfg
        {
            get
            {
                return cfg;
            }

            set
            {
                cfg = value;
            }
        }


        public void Defaults()
        {
            cfg.PlaceName = "Helsinki";
            cfg.Latitude = 60.1756;
            cfg.Longitude = 24.9342;
            cfg.UTCBias = -0.0833333333333333;
            cfg.ConsLineCol = Color.White.ToArgb();
            cfg.StarCol = Color.White.ToArgb();
            cfg.ConsNameCol = Color.Aquamarine.ToArgb();
            cfg.StarMapCol = Color.Black.ToArgb();
            cfg.StarDBIndex = 0;
            cfg.NoSolSys = false;
            cfg.NoConsLines = false;
            cfg.MagLimit = 6.0;
            cfg.StarNameIndex = 1;
            cfg.FlipX = false;
            cfg.FlipY = false;
            cfg.CompassObjName = "Alnilam/Epsilon Orion";
            cfg.CompassObjDec = -1.20191725;
            cfg.CompassObjRA = 5.60355904;
            cfg.Language = "en-US";
            cfg.UseConventionalCelestial = true;
        }

        public void Load()
        {
            if (config["ValuesSet", "0"] == "0")
            {
                Save();
            }
            cfg.PlaceName = config["PlaceName"];
            cfg.Latitude = double.Parse(config["Latitude"]);
            cfg.Longitude = double.Parse(config["Longitude"]);
            cfg.UTCBias = double.Parse(config["UTCBias"]);
            cfg.ConsLineCol = int.Parse(config["ConsLineCol"]);
            cfg.StarCol = int.Parse(config["StarCol"]);
            cfg.ConsNameCol = int.Parse(config["ConsNameCol"]);
            cfg.StarMapCol = int.Parse(config["StarMapCol"]);
            cfg.StarDBIndex = int.Parse(config["StarDBIndex"]);
            cfg.NoSolSys = bool.Parse(config["NoSolSys"]);
            cfg.NoConsLines = bool.Parse(config["NoConsLines"]);
            cfg.MagLimit = double.Parse(config["MagLimit"]);
            cfg.StarNameIndex = int.Parse(config["StarNameIndex"]);
            cfg.FlipX = bool.Parse(config["FlipX"]);
            cfg.FlipY = bool.Parse(config["FlipY"]);
            cfg.CompassObjName = config["CompassObjName"];
            cfg.CompassObjRA = double.Parse(config["CompassObjRA"]);
            cfg.CompassObjDec = double.Parse(config["CompassObjDec"]);
            cfg.Language = config["Language"];
            cfg.UseConventionalCelestial = bool.Parse(config["ConventionalPlanetImages", true.ToString()]);
        }

        public void Save()
        {
            config["ValuesSet"] = "1";
            config["PlaceName"] = cfg.PlaceName;
            config["Latitude"] = cfg.Latitude.ToString();
            config["Longitude"] = cfg.Longitude.ToString();
            config["UTCBias"] = cfg.UTCBias.ToString();
            config["ConsLineCol"] = cfg.ConsLineCol.ToString();
            config["StarCol"] = cfg.StarCol.ToString();
            config["ConsNameCol"] = cfg.ConsNameCol.ToString();
            config["StarMapCol"] = cfg.StarMapCol.ToString();
            config["StarDBIndex"] = cfg.StarDBIndex.ToString();
            config["NoSolSys"] = cfg.NoSolSys.ToString();
            config["NoConsLines"] = cfg.NoConsLines.ToString();
            config["MagLimit"] = cfg.MagLimit.ToString();
            config["StarNameIndex"] = cfg.StarNameIndex.ToString();
            config["FlipX"] = cfg.FlipX.ToString();
            config["FlipY"] = cfg.FlipY.ToString();
            config["CompassObjName"] = cfg.CompassObjName;
            config["CompassObjRA"] = cfg.CompassObjRA.ToString();
            config["CompassObjDec"] = cfg.CompassObjDec.ToString();
            config["Language"] = cfg.Language;
            config["ConventionalPlanetImages"] = cfg.UseConventionalCelestial.ToString();
        }
    }
}
