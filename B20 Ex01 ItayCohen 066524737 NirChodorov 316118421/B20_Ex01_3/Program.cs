using System;
using Ex2Proj = B20_Ex01_2.Program;
using Ex4Proj = B20_Ex01_4.Program;

namespace B20_Ex01_3
{
    class Program
    {
        public static void Main()
        {
            int numOfStars;
            Console.WriteLine("Please enter the number of stars for the base and the seal :");
            string inputNumOfStars = Console.ReadLine();
            while (!Ex4Proj.IsLanguageByAsciiCodesBounds(inputNumOfStars, '0', '9' ))
            {
                Console.WriteLine("invalid number, Please enter the number of stars for the base and the seal :");
                inputNumOfStars = Console.ReadLine();
            }
            numOfStars = int.Parse(inputNumOfStars);
            if (numOfStars % 2 == 0)
            {
                numOfStars++;
            }
            Ex2Proj.PrintSandTimer(numOfStars, 0);
        }      
    }
}
