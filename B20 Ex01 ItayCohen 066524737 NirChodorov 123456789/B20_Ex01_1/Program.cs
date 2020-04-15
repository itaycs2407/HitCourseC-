using System;
using System.Text;

namespace B20_Ex01_1
{
    //TODO:: check tryparse
    public class Program
    {
        public static void Main()
        {
            int maxDecimalNumber = 0, minDecimalNumber = 0;
            int numOfZero = 0, numOfOne = 0;
            Console.WriteLine("Input the first number.");
            string firstNumberSTR = GetInputForBinaryNumber();
            Console.WriteLine("Input the second number.");
            string secondNumberSTR = GetInputForBinaryNumber();
            Console.WriteLine("Input the third number.");
            string thirdNumberSTR = GetInputForBinaryNumber();
            int firstNumberDec = ConvertToDecimal(firstNumberSTR);
            int secondNumberDec = ConvertToDecimal(secondNumberSTR);
            int thirdNumberDec = ConvertToDecimal(thirdNumberSTR);
            Console.WriteLine(string.Format(@"The first number you enrterd is  : {0} in binary form, it equals to {1} in decimal form.
The second number you enrterd is : {2} in binary form, it equals to {3} in decimal form.
The third number you enrterd is  : {4} in binary form, it equals to {5} in decimal form.
", firstNumberSTR, firstNumberDec, secondNumberSTR, secondNumberDec, thirdNumberSTR, thirdNumberDec));

            GetMaxAndMin(firstNumberDec, secondNumberDec, thirdNumberDec, ref maxDecimalNumber, ref minDecimalNumber);
            numOfOne = CountSpecialChar(firstNumberSTR, '1') + CountSpecialChar(secondNumberSTR, '1') + CountSpecialChar(thirdNumberSTR, '1');
            numOfZero = CountSpecialChar(firstNumberSTR, '0') + CountSpecialChar(secondNumberSTR, '0') + CountSpecialChar(thirdNumberSTR, '0');
            int numofAscDigits = Convert.ToByte(AreDigitsAsc(firstNumberDec)) + Convert.ToByte(AreDigitsAsc(secondNumberDec)) + Convert.ToByte(AreDigitsAsc(thirdNumberDec));
            int pow2Counter = Convert.ToByte(IsPowerOfX(firstNumberDec, 2)) + Convert.ToByte(IsPowerOfX(secondNumberDec, 2)) + Convert.ToByte(IsPowerOfX(thirdNumberDec, 2));
            Console.WriteLine(
                string.Format(@"More statistics : 
The max number is {0} and the minimum is {1} : 
Among the three numbers, you have {2} numbers which are the power of 2.
Among the three numbers, you have {3} numbers which there digits are in growing order
The avg number of 1 is : {4: 0.00}
The avg number of 0 is : {5: 0.00}", maxDecimalNumber, minDecimalNumber, pow2Counter, numofAscDigits, (double)numOfOne / 3, (double)numOfZero / 3));
        }

        public static string GetInputForBinaryNumber()
        {
            int inputNumber;
            string inputNumberStr = string.Empty;
            //string signedBinaryForm = string.Empty;

            Console.WriteLine("Please type a binary 9 digits number");
            inputNumberStr = Console.ReadLine();
            int.TryParse(inputNumberStr, out inputNumber);
            while (inputNumberStr.Length != 9 || inputNumber < 0 || !IsBinary(inputNumberStr))
            {
                Console.WriteLine("Invalid input, please type again");
                inputNumberStr = Console.ReadLine();
                int.TryParse(inputNumberStr, out inputNumber);
            }

            return inputNumberStr;
        }

        public static bool IsBinary(string i_strToCheck)
        {
            int.TryParse(i_strToCheck, out int numToCheck);
            while (numToCheck > 0)
            {
                if (!((numToCheck % 10 == 0) || (numToCheck % 10 == 1)))
                {
                    return !true;
                }
                numToCheck /= 10;
            }
            return true;
        }

        public static int CountSpecialChar(string i_strToCheck, char i_charToCount)
        {
            int specialCharCounter = 0;

            while (i_strToCheck.Length > 0)
            {
                specialCharCounter = (i_strToCheck[0] == i_charToCount) ? specialCharCounter + 1 : specialCharCounter;
                i_strToCheck = i_strToCheck.Substring(1, i_strToCheck.Length - 1);
            }

            return specialCharCounter;
        }

        public static bool IsPowerOfX(int i_numberToCheck, int i_x)
        {
            int powByX = 1;
            while (powByX < i_numberToCheck)
            {
                powByX *= i_x;
            }

            return powByX == i_numberToCheck;
        }

        public static int ConvertToDecimal(string i_numberAsStr)
        {
            int i, addition = 0;

            for (i = 0; i < i_numberAsStr.Length; i++)
            {
                addition = (addition * 2) + Convert.ToInt32(i_numberAsStr[i]) - 48;
            }

            return addition;
        }

        public static bool AreDigitsAsc(int i_number)
        {
            if (i_number < 10)
            {
                return true;
            }
            if (i_number % 10 > (i_number / 10) % 10)
            {
                return AreDigitsAsc(i_number / 10);
            }

            return !true;

        }

        public static void GetMaxAndMin(int i_firstNumber, int i_secondNumber, int i_thirdNumber, ref int o_maxNumber, ref int o_minNumber)
        {
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

            if (i_firstNumber < i_secondNumber)
            {
                if (i_firstNumber < i_thirdNumber)
                {
                    o_minNumber = i_firstNumber;
                }
                else if (i_thirdNumber < i_secondNumber)
                {
                    o_minNumber = i_thirdNumber;
                }
                else
                {
                    o_minNumber = i_secondNumber;
                }
            }
            else
            {
                if (i_secondNumber < i_thirdNumber)
                {
                    o_minNumber = i_secondNumber;
                }
                else
                {
                    o_minNumber = i_thirdNumber;
                }
            }

        }
    }
}
