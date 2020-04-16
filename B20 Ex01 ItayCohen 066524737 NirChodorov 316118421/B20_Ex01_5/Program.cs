using System;
using Ex4Proj = B20_Ex01_4.Program;
namespace B20_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            string inputStr = getXCharInt(9);
            int inputNum = int.Parse(inputStr);
            Console.WriteLine("Max digit in number is : {0}", getMaxDigit(inputNum));
            Console.WriteLine("Min digit in number is : {0}", getMinDigit(inputNum));
            Console.WriteLine("The amount of digits devided by 3 is : {0}", countDigitsDividedByNum(inputStr, 3));
            Console.WriteLine("The amount of digits greater than the unit place is : {0}", countGreaterThanDigit(inputNum, inputNum % 10));
            Console.WriteLine("Type any key to exit ..");
            Console.ReadKey();
        }

        private static int countGreaterThanDigit(int i_number, int i_digitToCompare)
        {
           if(i_number <= 0)
            {
                return 0;
            }

            return (i_number % 10 > i_digitToCompare) ? countGreaterThanDigit(i_number /10, i_digitToCompare) + 1 : countGreaterThanDigit(i_number / 10, i_digitToCompare);
        }

        private static int countDigitsDividedByNum(string i_numToDivideStr, int i_numToDivideIn)
        {
            int dividedByNumCounter = 0;
            while (i_numToDivideStr.Length > 0)
            {
                if (Ex4Proj.IsDevidedByNum((i_numToDivideStr[0] - '0'), i_numToDivideIn))
                {
                    dividedByNumCounter++;
                }
                i_numToDivideStr = i_numToDivideStr.Substring(1, i_numToDivideStr.Length -1);
            }

            return dividedByNumCounter;
        }

        private static string getXCharInt(int i_numOfDigits)
        {
            Console.WriteLine("Please type a 9 digits number");
            string inputStr = Console.ReadLine();
            while (inputStr.Length != 9 || !Ex4Proj.IsLanguageByAsciiCodesBounds(inputStr, '0', '9'))
            {
                Console.WriteLine("Invalid input, Please type again");
                inputStr = Console.ReadLine();
            }

            return inputStr;
        }

        private static int getMaxDigit(int i_number)
        {
            int maxDigit = i_number % 10;
            while(i_number > 0)
            {
                if(maxDigit < i_number% 10)
                {
                    maxDigit = i_number % 10;
                }
                i_number /= 10;
            }
            return maxDigit;
        }

        private static int getMinDigit(int i_number)
        {
            int minDigit = i_number % 10;
            while (i_number > 0)
            {
                if (minDigit > i_number % 10)
                {
                    minDigit = i_number % 10;
                }
                i_number /= 10;
            }
            return minDigit;
        }
    }
}