using System;
using System.Text;

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
           
            int maxDecimalNumber = 0, minDecimalNumber = 0;
            int numOfZero = 0, numOfOne = 0;
            Console.WriteLine("Input the first number.");
            string firstNumberSTR = GetInputForBinaryNumber();
     //     string firstNumberSTR = "111011000"; 
            Console.WriteLine("Input the second number.");
            string thirdNumberSTR = GetInputForBinaryNumber();
     //     string thirdNumberSTR = "111010010";
            Console.WriteLine("Input the third number.");
            string secondNumberSTR = GetInputForBinaryNumber();
     //     string secondNumberSTR = "111010100"; 
            int firstNumberDec = ConvertToDecimal(firstNumberSTR);
            int secondNumberDec = ConvertToDecimal(secondNumberSTR);
            int thirdNumberDec = ConvertToDecimal(thirdNumberSTR);
            Console.WriteLine(String.Format("The first number you enrterd is  : {0} in binary form, it equals to {1} in decimal form.", firstNumberSTR, firstNumberDec));
            Console.WriteLine(String.Format("The second number you enrterd is : {0} in binary form, it equals to {1} in decimal form.", secondNumberSTR, secondNumberDec));
            Console.WriteLine(String.Format("The third number you enrterd is  : {0} in binary form, it equals to {1} in decimal form.", thirdNumberSTR, thirdNumberDec));
            Console.WriteLine("============================================");
            CheckForMaxMin(firstNumberDec, secondNumberDec, thirdNumberDec, ref maxDecimalNumber, ref minDecimalNumber);
            Console.WriteLine(" More statistics : ");
            Console.WriteLine("The max number is {0} and the minimum is {1} : ", maxDecimalNumber, minDecimalNumber);
            Console.WriteLine("Among the three numbers, you have {0} numbers which are the power of 2.",CheckForPowerOfTwo(firstNumberDec) + CheckForPowerOfTwo(secondNumberDec) + CheckForPowerOfTwo(thirdNumberDec));
            Console.WriteLine("Among the three numbers, you have {0} numbers which there digits are in growing order", Convert.ToInt32(CheckForUpperSeries(firstNumberDec)) + Convert.ToInt32(CheckForUpperSeries(secondNumberDec)) + Convert.ToInt32(CheckForUpperSeries(thirdNumberDec)));
            numOfOne = CheckForSpecialChar(firstNumberSTR, '1') + CheckForSpecialChar(secondNumberSTR, '0') + CheckForSpecialChar(thirdNumberSTR, '0');
            numOfZero = CheckForSpecialChar(firstNumberSTR, '0') + CheckForSpecialChar(secondNumberSTR, '1') + CheckForSpecialChar(thirdNumberSTR, '1');
            Console.WriteLine("The avg number of 1 is : {0: 0.00}",(double)numOfOne / 3);
            Console.WriteLine("The avg number of 0 is : {0: 0.00}", (double)numOfZero / 3);
            Console.WriteLine("Press any key to exit....");           
            System.Console.ReadLine();
        }

        public static string GetInputForBinaryNumber()
        {
            int inputNumber, numberTocheckForBinaryDigit;
            string inputNumberStr = string.Empty;
            string signedBinaryForm = string.Empty;
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

                    // the binary number is ok - check for negetive signed
                    if (notVerifed)
                    {
                        if (ConvertTwoCompliment(inputNumberStr, ref signedBinaryForm))
                        {
                            Console.WriteLine(string.Format(@"Pay attention : in Signed binary form, the number you entered is {0}, negetive.
In the assignment orders, it was written to input ONLY positive number! 
In unsigned binary form the number is {1}.
if you want to proceed with the unsigned form, enter 1. to input diffrent number, enter 0.", 
                                                              ConvertToDecimal(signedBinaryForm) * -1 ,ConvertToDecimal(inputNumberStr)));
                            notVerifed = int.Parse(Console.ReadLine()) == 1 ? true : !true;                                        
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
                addition = (addition * 2) + Convert.ToInt32(i_numberAsStr[i]) - 48 ;
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

        public static bool ConvertTwoCompliment(string i_numberStr, ref string o_signedNumber)
        {
            int i, carry = 1;
            StringBuilder oneCompliment = new StringBuilder();
            StringBuilder twoCompliment = new StringBuilder();
            bool isNegetive = !true;
            char charToAdd = '0', currentCharFromStr = '0';

            // check if the number represent negitive in SIGNED form : 0-positive; 1-negetive
            if (i_numberStr[0] == '0')
            {
                isNegetive = !true;
                o_signedNumber = string.Empty;
            }
            else
            {
                for (i = 0 ; i < i_numberStr.Length; i++)
                {
                    currentCharFromStr = i_numberStr[i];
                    charToAdd = currentCharFromStr.Equals('0') ? '1' : '0';
                    oneCompliment.Append(charToAdd);
                }
                i = 0;
                StringBuilder reversedString = new StringBuilder(ReverseString(oneCompliment.ToString()));
                while ((carry == 1) && (i < reversedString.Length))
                {
                    currentCharFromStr = reversedString[i];
                    charToAdd = (currentCharFromStr - '0' + carry == 2) ? '0' : '1';
                    twoCompliment.Append(charToAdd);
                    carry = (currentCharFromStr - '0' + carry == 2) ? 1 : 0;
                    i++;
                }
                while (i < reversedString.Length)
                {
                    twoCompliment.Append(reversedString[i] - '0');
                    i++;
                }
                o_signedNumber = ReverseString(twoCompliment.ToString());
                isNegetive = true;
                
            }
            return isNegetive;
        }
        
        public static string ReverseString(string i_stringToReverse)
        {
            StringBuilder reversedString = new StringBuilder(i_stringToReverse.Length);
            int i;
            char currentChar = '0';

            for (i = i_stringToReverse.Length -1;i >= 0; i--)
            {
                currentChar = i_stringToReverse[i];
                reversedString.Append(currentChar);
            }

            return reversedString.ToString();
        }
    }

}
