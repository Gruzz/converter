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
            bool oneMoreTime = true;
            while (oneMoreTime)
            {
                Console.WriteLine("What do you want to convert? (1 - decimal to binary, 2 - binary to decimal, q - exit)");
                string choise = Console.ReadLine();
                if (choise == "1")
                {
                    enterDecimal();
                    oneMoreTime = next();
                }
                else
                {
                    if (choise == "2")
                    {
                        enterBinary();
                        oneMoreTime = next();
                    }
                    else
                    {
                        if (choise == "q")
                        {
                            return;
                        }
                    }
                }
            }
        }
        //перевод положительного целого числа в двоичную сс
        public static StringBuilder ConvertDecToBin(string decToBin)
        {
            int ost = 0;
            int decInt = int.Parse(decToBin);
            StringBuilder binNum = new StringBuilder("", 32);
            if (decInt == 1)
            {
                binNum.Append("1");
            }
            else if (decInt == 0)
            {
                binNum.Append("0");
            }
            while (decInt > 1)
            {
                ost = decInt % 2;
                decInt = decInt / 2;
                binNum.Insert(0, ost.ToString());
                if (decInt == 1)
                {
                    binNum.Insert(0, decInt.ToString());
                }
            }
            return binNum;
        }
        //перевод в десятичную сс
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
        //перевод отрицательного целого числа в двоичную сс
        public static string ConvertDecNegotive(string decNeg)
        {
            StringBuilder otr = new StringBuilder("", 32);
            StringBuilder neg = ConvertDecToBin(decNeg);
            while (neg.Length < 32)
            {
                neg = neg.Insert(0, "0");
            }            
            for (int index = 0; index < 32; index++)
            {
                if (neg[index] == '0')
                {
                    otr.Append("1");
                }
                else
                {
                    otr.Append("0");
                }
            }            
            for (int index = 31; index > 0; index--)
            {
                if (otr[index] == '0')
                {
                    otr.Remove(index, 1);
                    otr.Insert(index, '1');
                    break;
                }
                else
                {
                    otr.Remove(index, 1);
                    otr.Insert(index, '0');
                }
            }
            string negBin = otr.ToString();
            return negBin;
        }
        // ввод десятичного числа
        public static void enterDecimal()
        {
            bool proverka = true;
            string decToBin = "";
            string decOtr = "";
            while (proverka)
            {
                Console.WriteLine("enter a decimal integer between -2147483647 and 2147483647");
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
            }
            if (decOtr == decToBin)
            {
                Console.WriteLine("binary number:" + ConvertDecToBin(decToBin));
            }
            else
            {
                Console.WriteLine("binary number:" + ConvertDecNegotive(decOtr));
            }
        }
        //ввод двоичного числа
        public static void enterBinary()

        {
            bool proverka = true;
            string binToDec = "";
            while (proverka)
            {
                Console.WriteLine("enter a binary number between 10000000000000000000000000000001 and 1111111111111111111111111111111");
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
            Console.WriteLine("decimal number:" + ConvertBinToDec(binToDec));
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