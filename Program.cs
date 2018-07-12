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
            bool a = true;
            string decToBin = "";
            while (a)
            {
                Console.WriteLine("enter decimal number greater than 0");
                decToBin = Console.ReadLine();
                if (decToBin.All(char.IsDigit))
                {
                    if (int.TryParse(decToBin, out int b))
                    {
                        if (int.Parse(decToBin) > 0)
                        {
                            a = false;
                        }
                        else
                        {
                            Console.WriteLine("number must be from 0 to 2147483647");
                        }

                    }
                    else
                    {
                        Console.WriteLine("too big number. enter number from 0 to 2147483647");
                    }
                }
                else
                {
                    Console.WriteLine("not a decimal number! Try again!");
                }
            }
            Console.WriteLine("binary number:" + ConvertDecToBin(decToBin));
            Console.WriteLine("enter binary number");
            string binToDec = Console.ReadLine();
            Console.WriteLine("decimal number:" + ConvertBinToDec(binToDec));
            string ba= Console.ReadLine();
        }
        public static string ConvertDecToBin ( string decToBin )
        {
            int ost = 0;
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
            return binStr;
        }
        public static string ConvertBinToDec ( string binToDec)
        {
            int len = binToDec.Length;
            int num = len - 1;
            int dec = 0;
            int index = 0;
            while (num >= 0)
            {
                int i = 1;
                for (int abc = 1; abc <= (num); abc++)
                {
                    i = i * 2;
                }
                dec = dec + ((int)char.GetNumericValue(binToDec[index]) * i);
                num = num - 1;
                index++;
            }
            string decNum = dec.ToString();
            return decNum;
        }
    }
}
