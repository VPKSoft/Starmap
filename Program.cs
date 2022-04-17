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
using System.Threading.Tasks;
using System.Windows.Forms;
using VPKSoft.LangLib;
using VPKSoft.PosLib;

namespace SMap
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBLangEngine.DBName = "Starmap.sqlite";

            if (Utils.ShouldLocalize() != null) // Localize and exit.
            {
                new ConfigForm();
                new SolarSystem();
                new BrowseDatabase();
                new ConstellationView();
                new JumpToTime();
                new Compass();
                new MainForm();
                new CharacterExplanations();
                new PlanetInfo();
                new ShowRaDec();
                new FormSelectLocation();
                new FormHTMLView();
                return;
            }

            PositionCore.Bind(); // attach the PosLib to the application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            PositionCore.UnBind(); // release the event handlers used by the PosLib and save the default data
        }
    }
}
