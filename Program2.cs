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

            Console.WriteLine(convertToBase(-10, 16));
            Console.WriteLine(convertToBase(15, 16));
            Console.WriteLine(convertToBase(16, 16));
            Console.ReadLine();

            /* bool oneMoreTime = true;
            while (oneMoreTime)
            {
                Console.WriteLine("What do you want to convert? (1 - decimal to binary, 2 - binary to decimal, q - exit)");
                string choise = Console.ReadLine();
                if (choise == "1")
                {
                    string decNum = enterDecimal();
                    int decIn = Convert.ToInt32(decNum);
                    Console.WriteLine("binary number:" + getBin(decIn));
                    oneMoreTime = next();
                }
                else
                {
                    if (choise == "2")
                    {
                        string binNum = enterBinary();
                        Console.WriteLine("decimal number:" + getDec(binNum).ToString());
                        oneMoreTime = next();
                    }
                    else
                    {
                        if (choise == "q")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Enter 1,2 or q. Nothing else will work. ");
                        }
                    }
                }
            }*/
        }
       /* static string convertToBaseGr10(int decNum, int b)
        {

            return "0";
        }*/
        /// <summary>
        /// convert decimal to binary
        /// </summary>
        /// <param name="decIn">decimal number</param>
        /// <returns></returns>
        static string getBin(int decIn)
        {            
            char[] bin = new char[sizeof(int) * 8];
            for (int i = 31; i >= 0; i--)
            {
                if ((decIn & 1) == 1)
                    bin[i] = '1';
                else
                    bin[i] = '0';
                decIn >>= 1;
            }            
            return new string(bin);
        }
        /// <summary>
        /// convert from binary to decimal
        /// </summary>
        /// <param name="binToDec">binary number</param>
        /// <returns></returns>
        static int getDec(string binToDec)
        {
            int res = 0;
            for (int i = 0; i < binToDec.Length; i++)
            {
                if (binToDec[i] == '1') res += 1;
                if (i != binToDec.Length - 1) res <<= 1;
            }
            return res;
        }
        /// <summary>
        /// convert from desimal to another number system
        /// </summary>
        /// <param name="decNum">decimal number</param>
        /// <param name="b">number system</param>
        /// <returns></returns>
        static string convertToBase(int decNum, int b)
        {
            string s="";
            if (decNum == 0) return "0";
            bool neg = ((decNum <0) ? true:false);
            int t = 0;
            while (Math.Abs(decNum) > 0)
                {
                    t = Math.Abs(decNum) % b;               
                    decNum /= b;
                if (t<9)
                    s = t + s;
                else
                {
                    s = (char)((char)t + '7') + s;
                }
                if ((decNum == 0) && (neg)) s = "-" + s;
                }                       
            return s;
        }
        // ввод десятичного числа
        public static string enterDecimal()
        {
            bool proverka = true;
            string decToBin = "";
            string decOtr = "";
            while (proverka)
            {
                Console.WriteLine("enter a decimal integer between -2147483648 and 2147483647");
                decToBin = Console.ReadLine();
                decOtr = decToBin;
                if (decToBin[0] != '-')
                {
                    if (decToBin.All(char.IsDigit) && (int.TryParse(decToBin, out int b)))
                    {
                        proverka = false;
                    }
                    else
                    {
                        Console.WriteLine("Upps.. You're wrong. Try again. I know you can.");
                    }
                }
                else
                {
                    if (decToBin != "-2147483648")
                    {
                        decOtr = decOtr.Remove(0, 1);
                        if (decOtr.All(char.IsDigit) && (int.TryParse(decOtr, out int b)))
                        {
                            proverka = false;
                        }
                        else
                        {
                            Console.WriteLine("Upps.. You're wrong. Try again. I know you can.");
                        }
                    }
                    else
                    {
                        proverka = false;
                    }
                }
            }
            return decToBin;
        }
        //ввод двоичного числа
        public static string enterBinary()

        {
            bool proverka = true;
            string binToDec = "";
            while (proverka)
            {
                Console.WriteLine("enter a binary number between 10000000000000000000000000000000 and 1111111111111111111111111111111");
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
                if (binStr.Length > 32)
                {
                    proverka = true;
                    Console.WriteLine("Upps.. You're wrong. Try again. I know you can.");
                }
            }
            return binToDec;
        }
        //продолжить или закрыть
        public static bool next()
        {
            bool again = true;
            bool proverka = true;
            while (proverka)
            {
                Console.WriteLine("Want to continue? (y/n)");
                string cont = Console.ReadLine();
                if (cont == "n")
                {
                    again = false;
                    return again;
                }
                else
                {
                    if (cont == "y")
                    {
                        again = true;
                        return again;
                    }
                }
            }
            return again;
        }
    }

}