using System;
using System.Text;

namespace B20_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            PrintSandTimer(5, 0);
            Console.WriteLine("Type any key to exit ..");
            Console.ReadKey();
        }

        public static void PrintSandTimer(int i_numOfRows, int i_numOfSpaces)
        {
            if (i_numOfRows < 2)
            {
                printRow(i_numOfRows, i_numOfSpaces);

                return;
            }
            printRow(i_numOfRows, i_numOfSpaces);
            PrintSandTimer(i_numOfRows - 2, i_numOfSpaces + 1);
            printRow(i_numOfRows, i_numOfSpaces);
        }

        private static void printRow(int i_numOfRows, int i_numOfSpaces)
        {
            StringBuilder starsToPrint = new StringBuilder();
            starsToPrint.Append(' ', i_numOfSpaces);
            starsToPrint.Append('*', i_numOfRows);
            Console.WriteLine(starsToPrint);
        }
    }
}