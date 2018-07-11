using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace converter
{
    class Program
    {
        static void Main(string[] args)
        {
            int ost = 0;
            Console.WriteLine("enter decimal number");
            string decToBin = Console.ReadLine();
            string binStr = "";
            int decInt = int.Parse(decToBin);
            if (decInt == 1)
            {
                binStr = "1";
            }
            else if (decInt == 0)
            {
                binStr = "0";
            }
            while (decInt > 1)
            {
                ost = decInt % 2;
                decInt = decInt / 2;
                binStr = ost.ToString() + binStr;
                if (decInt == 1)
                {
                    binStr = decInt.ToString() + binStr;
                }
            }
            Console.WriteLine(binStr);
            Console.WriteLine("enter binary number");
            string binToDec = Console.ReadLine();
            int len = binToDec.Length;
            int num = len-1;
            int dec = 0;
            int index = 0;
            while (num >= 0)
            {
                int i = 1;
                for (int abc = 1; abc <= (num); abc++)
                {
                    i = i * 2;
                }
                dec = dec + ((int)char.GetNumericValue( binToDec[index] ) * i);
                num = num - 1;
                index++;
            }
            Console.WriteLine(dec.ToString());
            string ba= Console.ReadLine();
        }

    }
}
