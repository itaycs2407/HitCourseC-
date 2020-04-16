using System;
using System.Collections.Generic;

namespace B20_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            string inputStr = getXCharString(8);
            Console.WriteLine(string.Format("Is the string is polyndrom? {0}", isPolyndrom(inputStr)));
            if (IsLanguageByAsciiCodesBounds(inputStr, '0', '9'))
            {
                Console.WriteLine(string.Format("Is the number devided by 5? {0}", IsDevidedByNum(int.Parse(inputStr), 5)));
            }
            else
            {
                Console.WriteLine(string.Format("The number of uppercase letters in this string is: {0}", countUpperCaseLetters(inputStr)));
            }
            Console.WriteLine("Type any key to exit ..");
            Console.ReadKey();
        }

        private static string getXCharString(int i_x)
        {
            Console.WriteLine("Please type an 8 chars English (A-Z/a-z) only or digits only string: ");
            string inputStr = Console.ReadLine();
            while(inputStr.Length != i_x || (!IsLanguageByAsciiCodesBounds(inputStr.ToUpper(), 'A', 'Z') && !IsLanguageByAsciiCodesBounds(inputStr,'0', '9')))
            {
                Console.WriteLine("Invalid input, Please type again.");
                inputStr = Console.ReadLine();
            }

            return inputStr;
        }

        public static bool IsLanguageByAsciiCodesBounds(string i_inputStr, char i_from, char i_to)
        {
            bool isValidLanguage = true;

            for (int i = 0; i < i_inputStr.Length && isValidLanguage; i++)
            {
                if(i_inputStr[i] < i_from || i_inputStr[i] > i_to)
                {
                    isValidLanguage = !true;
                }
            }

            return isValidLanguage;
        }

        private static bool isPolyndrom(string i_str)
        {
            if (i_str.Length < 2)
            {
                return true; 
            }

            if (i_str[0] == i_str[i_str.Length - 1])
            {
                return isPolyndrom(i_str.Substring(1, i_str.Length - 2)); 
            }

            return !true;
        }

        public static bool IsDevidedByNum(int i_numberToDivide, int i_numberToDivideIn)
        {
            return (i_numberToDivideIn == 0) ? !true: i_numberToDivide % i_numberToDivideIn == 0;
        }

        private static int countUpperCaseLetters(string i_str)
        {
            int upperCaseCounter = 0;
            for (int i = 0; i < i_str.Length; i++)
            {
                if (char.IsUpper(i_str[i]))
                {
                    upperCaseCounter++;
                }
            }

            return upperCaseCounter;
        } 
    }
}