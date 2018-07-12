using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace converter
{
    class Program
    {
        static void Main(string[] args)
        {
            bool proverka = true;
            string decToBin = "";
            while (proverka)
            {
                Console.WriteLine("enter a decimal integer between 0 and 2147483647");
                decToBin = Console.ReadLine();
                if (decToBin.All(char.IsDigit) && (int.TryParse(decToBin, out int b)))
                {
                    proverka = false;
                }
                else
                {
                    Console.WriteLine("Upps.. You're wrong. Try again. I know you can.");
                }
            }           
            Console.WriteLine("binary number:" + ConvertDecToBin(decToBin));
            proverka = true;
            string binToDec = "";            
            while (proverka)
            {
                Console.WriteLine("enter a binary number between 0 and 1111111111111111111111111111111");
                binToDec = Console.ReadLine();
                StringBuilder binStr = new StringBuilder("");
                binStr.Append(binToDec);
                int index = 0;
                foreach (char c in binToDec)
                {
                    if (c < '0' || c > '1')
                    {
                        proverka = true;
                        Console.WriteLine("Upps.. You're wrong. Try again. I know you can.");
                        break;
                    }
                    if (binToDec[index] == '0')
                        binStr.Remove(0, 1);
                    proverka = false;
                }
                if (binStr.Length > 31)
                {
                    proverka = true;
                    Console.WriteLine("Upps.. You're wrong. Try again. I know you can.");
                }
            }
            Console.WriteLine("decimal number:" + ConvertBinToDec(binToDec));
            Console.WriteLine("Enter to exit");
            string ba = Console.ReadLine();
        }
        public static StringBuilder ConvertDecToBin(string decToBin)
        {
            int ost = 0;
            int decInt = int.Parse(decToBin);
            StringBuilder binNum = new StringBuilder("", 32);
            if (decInt == 1)
            {
                binNum.Append( "1");
            }
            else if (decInt == 0)
            {
                binNum.Append("0");
            }
            while (decInt > 1)
            {
                ost = decInt % 2;
                decInt = decInt / 2;
                binNum.Insert(0,ost.ToString());
                if (decInt == 1)
                {
                    binNum.Insert(0, decInt.ToString());
                }
            }
            return binNum;
        }
        public static string ConvertBinToDec(string binToDec)
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