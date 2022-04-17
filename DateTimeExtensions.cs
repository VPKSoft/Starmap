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

namespace VPKSoft.DateTimeExtensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts the hour, minute, second and millisecond part into a decimal number.
        /// </summary>
        /// <param name="dt">A DateTime value of which decimal hours to get.</param>
        /// <returns>Amount of decimal hours in the given <paramref name="dt">dt</paramref></returns>
        public static double ToDecimalHour(this DateTime dt)
        {
            return (double)dt.Hour + (double)dt.Minute / 60.0 + ((double)dt.Second + (double)dt.Millisecond / 1000.0)  / 3600.0;
        }

        /// <summary>
        /// Converts the hour, minute, second and millisecond part into a decimal number divided by 24.
        /// </summary>
        /// <param name="dt">A DateTime value of which decimal hours to get and divide by 24.</param>
        /// <returns>Amount of decimal hours in the given <paramref name="dt">dt</paramref> divided by 24.</returns>
        public static double ToDecimalHourFraction(this DateTime dt)
        {
            return dt.ToDecimalHour() / 24.0;
        }

    }
}
