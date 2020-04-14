using System;
using System.Text;

namespace B20_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            Ex2(7,7,true);
           
        }

        private static void Ex2(int i_totalNumberOfLines, int i_currentNumberOfStar, bool dscOrder)
        {
            int i;
            StringBuilder strToPrint = new StringBuilder();

            if (dscOrder)
            {
                if (i_currentNumberOfStar < 1)
                {
                    dscOrder = !true;
                    
                }
                else
                {
                    for (i = 0; i < (i_totalNumberOfLines - (i_currentNumberOfStar - 2)) / 2; i++)
                    {
                        strToPrint.Append(" ");
                    }
                    for (i = 0; i < i_currentNumberOfStar; i++)
                    {
                        strToPrint.Append("*");
                    }
                    for (i = 0; i < (i_totalNumberOfLines - (i_currentNumberOfStar - 2)) / 2; i++)
                    {
                        strToPrint.Append(" ");
                    }
                    Console.WriteLine(strToPrint.ToString());
                    Ex2(i_totalNumberOfLines, i_currentNumberOfStar - 2, dscOrder);
                   Ex2(i_totalNumberOfLines, i_currentNumberOfStar + 2, !dscOrder);
                }
            }
            else
            {
                if (i_totalNumberOfLines < i_currentNumberOfStar)
                {
                    return;
                }
                else
                {
                    for (i = 0; i < (i_totalNumberOfLines - (i_currentNumberOfStar - 2)) / 2; i++)
                    {
                        strToPrint.Append(" ");
                    }
                    for (i = 0; i < i_currentNumberOfStar; i++)
                    {
                        strToPrint.Append("*");
                    }
                    for (i = 0; i < (i_totalNumberOfLines - (i_currentNumberOfStar - 2)) / 2; i++)
                    {
                        strToPrint.Append(" ");
                    }
                    Console.WriteLine(strToPrint.ToString());
                    Ex2(i_totalNumberOfLines , i_currentNumberOfStar + 2, dscOrder);


                }
            }
        }

    }
}
