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

namespace Stellar
{
    /// <summary>
    /// Description of StellarConver.
    /// </summary>
    public class StellarConver
    {
        public const double AUkm = 0.1495979e9;
        public const double lykm = 9.46055e12;
        public const double pckm = 3.085678e13;

        public const double c_KmPerSek = 2.99792458e5;
        public const double c_MPerSek = 2.99792458e8;

        public static double kmToAU(double km)
        {
            return km / AUkm;
        }

        public static double kmTopc(double km)
        {
            return km / pckm;
        }

        public static double kmToly(double km)
        {
            return km / lykm;
        }

        public static double pcTokm(double pc)
        {
            return pc * pckm;
        }

        public static double pcToAU(double pc)
        {
            return kmToAU(pcTokm(pc));
        }

        public static double pcToly(double pc)
        {
            return kmToly(pcTokm(pc));
        }

        public static double lyTokm(double ly)
        {
            return ly * lykm;
        }

        public static double lyToAU(double ly)
        {
            return kmToAU(lyTokm(ly));
        }

        public static double lyTopc(double ly)
        {
            return kmTopc(lyTokm(ly));
        }

        public static double AUTokm(double AU)
        {
            return AU * AUkm;
        }

        public static double AUToly(double AU)
        {
            return kmToly(AUTokm(AU));
        }

        public static double AUTopc(double AU)
        {
            return kmTopc(AUTokm(AU));
        }

        public static double Tok(double Val) // kilo
        {
            return Val / 1e3;
        }

        public static double ToM(double Val) // mega
        {
            return Val / 1e6;
        }

        public static double ToG(double Val) // giga
        {
            return Val / 1e9;
        }

        public static double ToT(double Val) // tera
        {
            return Val / 1e12;
        }

        public static double ToP(double Val) // peta
        {
            return Val / 1e15;
        }

        public static double ToE(double Val) // eksa
        {
            return Val / 1e18;
        }

    }
}
