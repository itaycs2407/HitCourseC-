namespace B20_Ex01_5
{
    public class Program
    {
        public static void Main()
        {
            Ex5();
        }

        public static void Ex5() => CheckNineDigitNumber(GetInputFromUser());

        private static void CheckNineDigitNumber(int i_number)
        {
            int maxDigit, minDigit, divideIn3Ctr = 0, greaterFromUnitPlaceCtr = 0, unitPlace;
            unitPlace = maxDigit = minDigit = i_number % 10;

            // get all answers in the loop
            while (i_number > 0)
            {
                int digitToCheck = i_number % 10;
                maxDigit = digitToCheck > maxDigit ? digitToCheck : maxDigit;
                minDigit = digitToCheck < minDigit ? digitToCheck : minDigit;
                greaterFromUnitPlaceCtr = digitToCheck > unitPlace ? greaterFromUnitPlaceCtr + 1 : greaterFromUnitPlaceCtr;
                divideIn3Ctr = (digitToCheck % 3 == 0) ? divideIn3Ctr + 1 : divideIn3Ctr;
                i_number /= 10;
            }

            // print all the answers
            System.Console.WriteLine("Tha maximun digit in the number is : " + maxDigit);
            System.Console.WriteLine("Tha minimum digit in the number is : " + minDigit);
            System.Console.WriteLine("Tha number of digits that greater then the unit place is : ", greaterFromUnitPlaceCtr);
            System.Console.WriteLine("Tha number of digits divide by 3 is : ", divideIn3Ctr);
        }

        private static int GetInputFromUser()
        {
                bool goodInput = !true;
                string inputNumber = string.Empty;
                int number;
               
                do
                {
                    System.Console.WriteLine("Please input 9 digit number and press enter !");
                    inputNumber = System.Console.ReadLine();
                    int.TryParse(inputNumber, out number);

                    // System.Console.WriteLine(number);
                    if (int.TryParse(inputNumber, out number))
                    {
                        goodInput = true;
                    }
                    else
                    {
                        System.Console.WriteLine("You entered not VALID number !!!");
                    }
                } 
                while (!goodInput);

                return number;
            }   
        }
    }