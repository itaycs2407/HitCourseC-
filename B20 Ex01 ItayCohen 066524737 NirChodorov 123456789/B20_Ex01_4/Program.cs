using System;

namespace B20_Ex01_4
{
    public class Program
    {
        public static void Main()
        {
            Ex4();
        }

        public static void Ex4() 
        {
            string strToTest = Get8CharsrString();  
        }

        // TODO : fix the input function
        public static string Get8CharsrString()
        {
            string inputFromUser = string.Empty;
            bool stringVerifeid = !true;
            int i;

            do
            {
                Console.WriteLine("Please enter string with 8 chars : ");
                inputFromUser = System.Console.ReadLine();
                if (inputFromUser.Length == 8)
                {
                    i = 0;
                    while (i < inputFromUser.Length && char.IsLetterOrDigit(inputFromUser, i))
                    {
                        i++;
                    }

                    stringVerifeid = !(i == 8);
                }
                else
                {
                    Console.WriteLine("NOT 8 chars string !!! try again....");
                }
            }
            while (stringVerifeid);

            return inputFromUser;
        }

        public static bool CheckForPolyndrom(string i_str)
        {
            if (i_str.Length < 2)
            {
                return true; 
            }

            if (i_str[0] == i_str[i_str.Length - 1])
            {
                return CheckForPolyndrom(i_str.Substring(1, i_str.Length - 1)); 
            }
            else
            {
                return !true;
            }
        }

        public static bool CheckForDivideInNumber(int i_numberToDivide, int i_numberToDivideIn) => (i_numberToDivide % i_numberToDivideIn == 0);

        public static int CheckForUpperCase(string i_str)
        {
            int i, upperCaseCounter = 0;
            for (i = 0; i < i_str.Length; i++)
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