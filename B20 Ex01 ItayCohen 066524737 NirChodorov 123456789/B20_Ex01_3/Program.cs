using System;
using Ex2Proj = B20_Ex01_2.Program;

namespace B20_Ex01_3
{
    class Program
    {
        public static void Main(string[] args)
        {
            int inputNumberOfStars;
            System.Console.WriteLine("Please enter the number of stars for the base and the seal :");
            inputNumberOfStars = int.Parse(Console.ReadLine());
            while (inputNumberOfStars < 0)
            {
                System.Console.WriteLine("invalid number, Please enter the number of stars for the base and the seal :");
                inputNumberOfStars = int.Parse(Console.ReadLine());
            }
            if (inputNumberOfStars % 2 == 0)
            { 
                inputNumberOfStars++;
            }
            Ex2Proj.SandTimer(inputNumberOfStars, inputNumberOfStars, true);         
        }      
    }
}
