using System;
using System.Globalization;
using System.IO;

namespace Pract_Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Nail[] nails = ReadFile();
            int minlength = 0;
            foreach(Nail x in nails) if (x.Tied == false)
                {
                    Nail temp = ClosestTo(ref nails, x);
                    minlength += Nail.Tie(temp, x);
                }
            FileStream fs = new FileStream("OUTPUT.TXT", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write(minlength.ToString());
            sw.Close();
            fs.Close();
        }

        public static Nail ClosestTo(ref Nail[] arr ,Nail x)
        {
            int min = 10001;
            Nail colsestNail = null;
            for(int i = 0; i< arr.Length; i++)
            {
                if (arr[i].Coord != x.Coord && Math.Abs(arr[i].Coord - x.Coord) < min) { min = Math.Abs(arr[i].Coord - x.Coord); colsestNail = arr[i]; }
            }
            return colsestNail;
        }

        public static Nail[] ReadFile()
        {
            FileStream fs = new FileStream("INPUT.TXT", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            int size = int.Parse(sr.ReadLine());
            Nail[] temp = new Nail[size];
            string[] tempstr = sr.ReadLine().Split(' ');
            for (int i = 0; i < temp.Length; i++) temp[i] = new Nail(int.Parse(tempstr[i]));
            sr.Close();
            fs.Close();
            return temp;
        }
    }

    class Nail
    {
        public bool Tied { get; set; }
        public int Coord { get; set; }

        public Nail(int i)
        {
            Tied = false;
            Coord = i;
        } 
        public static int Tie(Nail a, Nail b)
        {
            a.Tied = true;
            b.Tied = true;
            return Math.Abs(a.Coord - b.Coord);
        }


    }
}
