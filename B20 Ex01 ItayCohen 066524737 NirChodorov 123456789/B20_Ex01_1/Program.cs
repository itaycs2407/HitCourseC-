using System;

namespace B20_Ex01_1
{
    public class Program
    {
        public static void Main()
        {
            Ex1();
        }

        public static void Ex1()
        {
            int maxDecimalNumber, minDecimalNumber;
            Console.WriteLine("Input the first number.");
            string firstNumberSTR = GetInputForBinaryNumber();
            Console.WriteLine("Input the second number.");
            string thirdNumberSTR = GetInputForBinaryNumber();
            Console.WriteLine("Input the third number.");
            string secondNumberSTR = GetInputForBinaryNumber();
            int firstNumberDec = ConvertToDecimal(firstNumberSTR);
            int secondNumberDec = ConvertToDecimal(secondNumberSTR);
            int thirdNumberDec = ConvertToDecimal(thirdNumberSTR);

            System.Console.WriteLine(CheckForSpecialChar(firstNumberSTR, '0'));
            System.Console.ReadLine();
        }

        public static string GetInputForBinaryNumber()
        {
            int inputNumber, numberTocheckForBinaryDigit;
            string inputNumberStr;
            bool notVerifed = true;
            
            do
            {
                Console.WriteLine("Please enter 9 digit binary number : ");
                inputNumberStr = Console.ReadLine();
                int.TryParse(inputNumberStr, out inputNumber);
                if (inputNumberStr.Length != 9)
                {
                    Console.WriteLine("Not a 9 digit Number. Try again");
                    notVerifed = !true;
                }
                else if (inputNumber < 0)
                {
                    Console.WriteLine("Not positive Number. Try again");
                    notVerifed = !true;
                }
                else
                {
                    numberTocheckForBinaryDigit = inputNumber;
                    notVerifed = true;
                    while (numberTocheckForBinaryDigit > 0 && notVerifed)
                    {
                        if ((numberTocheckForBinaryDigit % 10 == 0) || (numberTocheckForBinaryDigit % 10 == 1))
                        {
                            numberTocheckForBinaryDigit /= 10;
                        }
                        else
                        {
                            Console.WriteLine("Not Binary Number. Try again");
                            notVerifed = !(numberTocheckForBinaryDigit > 0);
                        }            
                    }
                }
            } 
            while (!notVerifed);

            return inputNumberStr;
        }

        public static int CheckForSpecialChar(string i_numberToCheckStr, char i_whatToCount)
        {
            int specialCharCounter = 0;
            while (i_numberToCheckStr.Length > 0)
            {
                specialCharCounter = (i_numberToCheckStr[i_numberToCheckStr.Length - 1]  == i_whatToCount) ? specialCharCounter + 1 : specialCharCounter;
                i_numberToCheckStr = i_numberToCheckStr.Substring(0, i_numberToCheckStr.Length - 1);
            }

            return specialCharCounter;
        }

        public static int CheckForPowerOfTwo(int i_numberToCheck)
        {
            int multiTemp = 1;
            while (multiTemp < i_numberToCheck)
            {
                multiTemp *= 2;
            }

            return Convert.ToInt32(multiTemp == i_numberToCheck); 
        }

        public static int ConvertToDecimal(string i_numberAsStr)
        {
            int i, addition = 0;

            for (i = 0; i < i_numberAsStr.Length; i++)
            {
                addition = (addition * 2) + i_numberAsStr[i];
            }

            return addition;
        }
        // maybe to do for down series
        public static bool CheckForUpperSeries(int i_number)
        {
            if (i_number < 10)
            {
                return true;
            }
            else if (i_number % 10 > (i_number / 10) % 10)
            {
                return CheckForUpperSeries(i_number / 10);
            }
            else
            {
                return !true;
            }
        }

        public static void CheckForMaxMin(int i_firstNumber, int i_secondNumber, int i_thirdNumber, ref int o_maxNumber, ref int o_minNumber)
        {
            o_maxNumber = i_firstNumber > i_secondNumber ? i_firstNumber > i_thirdNumber ? i_firstNumber : i_thirdNumber > i_secondNumber ? i_thirdNumber : i_secondNumber : i_secondNumber > i_thirdNumber ? i_secondNumber : i_thirdNumber;
            o_minNumber = i_firstNumber < i_secondNumber ? i_firstNumber < i_thirdNumber ? i_firstNumber : i_thirdNumber < i_secondNumber ? i_thirdNumber : i_secondNumber : i_secondNumber < i_thirdNumber ? i_secondNumber : i_thirdNumber;
            /*
            if (i_firstNumber > i_secondNumber)
            {
                if (i_firstNumber > i_thirdNumber)
                {
                    o_maxNumber = i_firstNumber;
                }
                else if (i_thirdNumber > i_secondNumber)
                {
                    o_maxNumber = i_thirdNumber;
                }
                else
                {
                    o_maxNumber = i_secondNumber;
                }
            }
            else
            {
                if (i_secondNumber > i_thirdNumber)
                {
                    o_maxNumber = i_secondNumber;
                }
                else
                {
                    o_maxNumber = i_thirdNumber;
                }
            } 
            */
        }
    }
}
