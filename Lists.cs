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
using System.IO;

namespace ListClasses
{
    /// <summary>
    /// Description of StringList.
    /// </summary>
    public class StringList
    {
        public string[] Strings = null;

        string LineFeed = Convert.ToString('\u000D') + Convert.ToString('\u000A');

        public StringList()
        {
        }

        public StringList(string FileName)
        {
            LoadFromFile(FileName);
        }

        public StringList(Stream St)
        {
            LoadFromStream(St);
        }

        public string GetLineFeed()
        {
            return LineFeed;
        }

        public void SetLineFeed(string LfStr)
        {
            LineFeed = LfStr;
        }

        public void Add(string Str)
        {
            if (Strings == null)
            {
                Strings = new string[] { Str };
            }
            else
            {
                string[] TempStrings = new string[Strings.Length + 1];
                Strings.CopyTo(TempStrings, 0);
                TempStrings[Strings.Length] = Str;
                Strings = TempStrings;
            }
        }

        public void Add(StringList Sl)
        {
            if (Sl.Strings == null)
            {
                return;
            }
            for (int i = 0; i < Sl.Strings.Length; i++)
            {
                Add(Sl.Strings[i]);
            }
        }

        void ValidIndex(int Index)
        {
            if (Strings == null)
            {
                throw new Exception("Index out of bounds: " + Index.ToString());
            }
            else if (Index < 0 || Index >= Strings.Length)
            {
                throw new Exception("Index out of bounds: " + Index.ToString());
            }
        }

        public void Insert(int Index, string Str)
        {
            ValidIndex(Index);
            string[] TempStrings = new string[Strings.Length + 1];
            int j = 0;
            for (int i = 0; i < Strings.Length; i++)
            {
                if (j == Index)
                {
                    TempStrings[j] = Str;
                    j++;
                }
                else
                {
                    TempStrings[j] = Strings[i];
                }
                j++;
            }
            Strings = TempStrings;
        }

        public void Insert(int Index, StringList Sl)
        {
            ValidIndex(Index);
            if (Sl.Strings == null)
            {
                return;
            }
            for (int i = 0; i < Sl.Strings.Length; i++)
            {
                Insert(Index + i, Sl.Strings[i]);
            }
        }

        public void Delete(int Index)
        {
            ValidIndex(Index);
            if (Strings.Length == 1)
            {
                Strings = null;
            }
            else
            {
                string[] TempStrings = new string[Strings.Length - 1];
                int j = 0;
                for (int i = 0; i < TempStrings.Length; i++)
                {
                    if (j == Index)
                    {
                        j++;
                    }
                    TempStrings[i] = Strings[j];
                    j++;
                }
                Strings = TempStrings;
            }
        }

        public void LoadFromFile(string FileName)
        {
            StreamReader Sr = File.OpenText(FileName);
            String Input;
            Strings = null;
            while ((Input = Sr.ReadLine()) != null)
            {
                Add(Input);
            }
        }

        public void LoadFromStream(Stream St)
        {
            StreamReader Sr = new StreamReader(St);
            St.Position = 0;
            String Input;
            Strings = null;
            while ((Input = Sr.ReadLine()) != null)
            {
                Add(Input);
            }
        }


        public void SaveToFile(string FileName)
        {
            if (Strings == null)
            {
                return;
            }
            using (StreamWriter Sw = File.CreateText(FileName))
            {
                for (int i = 0; i < Strings.Length; i++)
                {
                    Sw.WriteLine(Strings[i]);
                }
            }
        }

        public void SaveToStream(Stream St)
        {
            if (Strings == null)
            {
                return;
            }
            using (StreamWriter Sw = new StreamWriter(St))
            {
                for (int i = 0; i < Strings.Length; i++)
                {
                    Sw.WriteLine(Strings[i]);
                }
            }
        }

        public int Count()
        {
            if (Strings == null)
            {
                return 0;
            }
            else
            {
                return Strings.Length;
            }
        }

        public void Clear()
        {
            Strings = null;
        }

        public void Sort()
        {
            if (Strings != null)
            {
                if (Strings.Length >= 2)
                {
                    Array.Sort(Strings);
                }
            }
        }

        public int IndexOf(string Str)
        {
            if (Strings == null)
            {
                return -1;
            }
            for (int i = 0; i < Strings.Length; i++)
            {
                if (Strings[i].Length >= Str.Length)
                {
                    if (Strings[i].Substring(0, Str.Length) == Str)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public int IndexOfAnyCase(string Str)
        {
            if (Strings == null)
            {
                return -1;
            }
            for (int i = 0; i < Strings.Length; i++)
            {
                if (Strings[i].Length >= Str.Length)
                {
                    if (Strings[i].Substring(0, Str.Length).ToUpper() == Str.ToUpper())
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public string[] GetStringArray()
        {
            if (Strings == null)
            {
                return null;
            }
            string[] RetStrings = new string[Strings.Length];
            Strings.CopyTo(RetStrings, 0);
            return RetStrings;
        }

        public void Set(int Index, string Str)
        {
            ValidIndex(Index);
            Strings[Index] = Str;
        }

        public string GetText()
        {
            string RetText = string.Empty;
            if (Strings == null)
            {
                return string.Empty;
            }
            for (int i = 0; i < Strings.Length; i++)
            {
                RetText += Strings[i] + LineFeed;
            }
            return RetText;
        }

        public void SetText(string Str)
        {
            Clear();
            if (Str == null)
            {
                return;
            }
            int Index;
            while ((Index = Str.IndexOf(LineFeed)) >= 0)
            {
                Add(Str.Substring(0, Str.IndexOf(LineFeed)));
                Str = Str.Substring(Str.IndexOf(LineFeed) + LineFeed.Length, Str.Length - Str.IndexOf(LineFeed) - LineFeed.Length);
            }
            Add(Str);
        }

        public void Swap(int Index1, int Index2)
        {
            ValidIndex(Index1);
            ValidIndex(Index2);
            string TempStr = Strings[Index1];
            Strings[Index1] = Strings[Index2];
            Strings[Index2] = TempStr;
        }
    }



    public class IntList
    {
        public int[] Ints = null;

        public IntList()
        {
        }

        public IntList(string FileName)
        {
            LoadFromFile(FileName);
        }

        public IntList(Stream St)
        {
            LoadFromStream(St);
        }

        public void Add(int Intr)
        {
            if (Ints == null)
            {
                Ints = new int[] { Intr };
            }
            else
            {
                int[] TempInts = new int[Ints.Length + 1];
                Ints.CopyTo(TempInts, 0);
                TempInts[Ints.Length] = Intr;
                Ints = TempInts;
            }
        }

        public void Add(IntList Il)
        {
            if (Il.Ints == null)
            {
                return;
            }
            for (int i = 0; i < Il.Ints.Length; i++)
            {
                Add(Il.Ints[i]);
            }
        }

        void ValidIndex(int Index)
        {
            if (Ints == null)
            {
                throw new Exception("Index out of bounds: " + Index.ToString());
            }
            else if (Index < 0 || Index >= Ints.Length)
            {
                throw new Exception("Index out of bounds: " + Index.ToString());
            }
        }

        public void Insert(int Index, int Intr)
        {
            ValidIndex(Index);
            int[] TempInts = new int[Ints.Length + 1];
            int j = 0;
            for (int i = 0; i < Ints.Length; i++)
            {
                if (j == Index)
                {
                    TempInts[j] = Intr;
                    j++;
                }
                else
                {
                    TempInts[j] = Ints[i];
                }
                j++;
            }
            Ints = TempInts;
        }

        public void Insert(int Index, IntList Il)
        {
            ValidIndex(Index);
            if (Il.Ints == null)
            {
                return;
            }
            for (int i = 0; i < Il.Ints.Length; i++)
            {
                Insert(Index + i, Il.Ints[i]);
            }
        }

        public void Delete(int Index)
        {
            ValidIndex(Index);
            if (Ints.Length == 1)
            {
                Ints = null;
            }
            else
            {
                int[] TempInts = new int[Ints.Length - 1];
                int j = 0;
                for (int i = 0; i < TempInts.Length; i++)
                {
                    if (j == Index)
                    {
                        j++;
                    }
                    TempInts[i] = Ints[j];
                    j++;
                }
                Ints = TempInts;
            }
        }

        public void LoadFromFile(string FileName)
        {
            BinaryReader Br = new BinaryReader(File.Open(FileName, FileMode.Open, FileAccess.Read));
            Ints = null;

            int Count = Br.ReadInt32();

            for (int i = 0; i < Count; i++)
            {
                Add(Br.ReadInt32());
            }
        }

        public void LoadFromStream(Stream St)
        {
            BinaryReader Br = new BinaryReader(St);
            Ints = null;

            int Count = Br.ReadInt32();

            for (int i = 0; i < Count; i++)
            {
                Add(Br.ReadInt32());
            }
        }


        public void SaveToFile(string FileName)
        {
            if (Ints == null)
            {
                return;
            }
            BinaryWriter Bw = new BinaryWriter(File.Create(FileName));
            Bw.Write(Ints.Length);
            for (int i = 0; i < Ints.Length; i++)
            {
                Bw.Write(Ints[i]);
            }
            Bw.Close();
        }

        public void SaveToStream(Stream St)
        {
            if (Ints == null)
            {
                return;
            }
            BinaryWriter Bw = new BinaryWriter(St);
            Bw.Write(Ints.Length);
            for (int i = 0; i < Ints.Length; i++)
            {
                Bw.Write(Ints[i]);
            }
        }

        public int Count()
        {
            if (Ints == null)
            {
                return 0;
            }
            else
            {
                return Ints.Length;
            }
        }

        public void Clear()
        {
            Ints = null;
        }

        public void Sort()
        {
            if (Ints != null)
            {
                if (Ints.Length >= 2)
                {
                    Array.Sort(Ints);
                }
            }
        }

        public int IndexOf(int Intr)
        {
            if (Ints == null)
            {
                return -1;
            }
            for (int i = 0; i < Ints.Length; i++)
            {
                if (Ints[i] == Intr)
                {
                    return i;
                }
            }
            return -1;
        }

        public int[] GetIntArray()
        {
            if (Ints == null)
            {
                return null;
            }
            int[] RetInts = new int[Ints.Length];
            Ints.CopyTo(RetInts, 0);
            return RetInts;
        }

        public void Set(int Index, int Intr)
        {
            ValidIndex(Index);
            Ints[Index] = Intr;
        }

        public void Swap(int Index1, int Index2)
        {
            ValidIndex(Index1);
            ValidIndex(Index2);
            int TempIntr = Ints[Index1];
            Ints[Index1] = Ints[Index2];
            Ints[Index2] = TempIntr;
        }
    }



}
