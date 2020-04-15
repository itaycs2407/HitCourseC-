using System;
using Ex4Proj = B20_Ex01_4.Program;
namespace B20_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            string inputStr = GetXCharInt(9);
            int inputNum = int.Parse(inputStr);
            Console.WriteLine("Max digit in number is : {0}", GetMaxDigit(inputNum));
            Console.WriteLine("Min digit in number is : {0}", GetMinDigit(inputNum));
            Console.WriteLine("The amount of digits devided by 3 is : {0}", CountDigitsDividedByNum(inputStr, 3));
            Console.WriteLine("The amount of digits greater than the unit place is : {0}", CountGreaterThanDigit(inputNum, inputNum % 10));
      
        }

        public static int CountGreaterThanDigit(int i_number, int i_digitToCompare)
        {
           if(i_number <= 0)
            {
                return 0;
            }
            return (i_number % 10 > i_digitToCompare) ? CountGreaterThanDigit(i_number /10, i_digitToCompare) + 1 : CountGreaterThanDigit(i_number / 10, i_digitToCompare);
        }

        public static int CountDigitsDividedByNum(string i_numToDivideStr, int i_numToDivideIn)
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

        public static string GetXCharInt(int i_numOfDigits)
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

        public static int GetMaxDigit(int i_number)
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

        public static int GetMinDigit(int i_number)
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