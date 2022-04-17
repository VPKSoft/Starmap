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

namespace SMap
{
    public static class SiderealTime
    {
        public static double CalcSiderealTime(DateTime dt, bool corrected, double dLong, bool toUTC = true)
        {
            DateTime dtC = toUTC ? dt.ToUniversalTime() : dt;

            double y = dtC.Year;
            double m = dtC.Month;
            double day = dtC.Day;
            double h = dtC.Hour;
            double mins = dtC.Minute;
            double seconds = dtC.Second;


            double dwhole = 367.0 * y - Math.Truncate(7.0 * (y + Math.Truncate((m + 9.0) / 12.0)) / 4.0) + Math.Truncate(275.0 * m / 9.0) + day - 730531.5;
            double dfrac = (h + mins / 60.0 + seconds / 3600.0) / 24.0;

            double d = dwhole + dfrac;

            double t = d / 36525.0;
            double tC = Math.Pow(t, 2) * 0.000388;

            if (!corrected)
            {
                tC = 0.0;
            }

            double GMST = 280.46061837 + 360.98564736629 * d + tC + dLong;

            GMST /= 360.0;
            GMST = ToValidDegree(GMST);
            GMST = Fraction(GMST);
            return 24.0 * GMST;
        }

        public static double GMST(bool corrected = true)
        {
            return CalcSiderealTime(DateTime.Now, corrected, 0);
        }

        public static double GMST(DateTime dt, bool corrected = true)
        {
            return CalcSiderealTime(dt, corrected, 0, false);
        }


        public static double LMST(double dLong, bool corrected = true)
        {
            return CalcSiderealTime(DateTime.Now, corrected, dLong);
        }

        public static double LMST(DateTime dt, double dLong, bool corrected = true)
        {
            return CalcSiderealTime(dt, corrected, dLong);
        }

        public static double Fraction(double d)
        {
            return d - Math.Truncate(d);
        }

        public static decimal Fraction(decimal d)
        {
            return d - Math.Truncate(d);
        }

        public static string ToTimeString(double d)
        {
            string hh = Math.Truncate(d).ToString();
            hh = hh.PadLeft(2, '0');
            string mm = Math.Truncate(Fraction(d) * 60.0).ToString();
            mm = mm.PadLeft(2, '0');
            string ss = Math.Truncate(Fraction(Fraction(d) * 60.0) * 60.0).ToString();
            ss = ss.PadLeft(2, '0');
            return hh + ":" + mm + ":" + ss;
        }

        public static double ToValidDegree(double d)
        {
            while (d < 0.0)
            {
                d += 360.0;
            }

            while (d > 360.0)
            {
                d -= 360.0;
            }
            return d;
        }

        public static decimal ToValidDegree(decimal d)
        {
            while (d < 0.0m)
            {
                d += 360.0m;
            }

            while (d > 360.0m)
            {
                d -= 360.0m;
            }
            return d;
        }
    }
}
