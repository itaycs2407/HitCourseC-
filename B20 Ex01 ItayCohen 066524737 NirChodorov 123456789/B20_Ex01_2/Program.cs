using System;
using System.Text;

namespace B20_Ex01_2
{
    public class Program
    {
        public static void Main()
        {
            SandTimer(5, 5, true);
        }

        private static void MakeChars(int i_numberOfItaration, char charToType, ref StringBuilder strToBuild)
        {
            for (int i = 0; i < i_numberOfItaration; i++)
            {
                strToBuild.Append(charToType);
            }
        }

        public static void SandTimer(int i_numberOfRows, int i_numberOfStar, bool isDsc)
        {
            if (isDsc)
            {
                if (i_numberOfStar < 5)
                {
                    isDsc = !true;
                }
                StringBuilder strToPrint = new StringBuilder();
                MakeChars((i_numberOfRows - i_numberOfStar) / 2, ' ', ref strToPrint);
                MakeChars(i_numberOfStar, '*', ref strToPrint);
                MakeChars((i_numberOfRows - i_numberOfStar) / 2, ' ', ref strToPrint);
                Console.WriteLine(strToPrint.ToString());
                SandTimer(i_numberOfRows, i_numberOfStar - 2, isDsc);
            }
            else
            {
                if (i_numberOfRows < i_numberOfStar)
                {
                    return;
                }
                StringBuilder strToPrint = new StringBuilder();
                MakeChars((i_numberOfRows - i_numberOfStar) / 2, ' ', ref strToPrint);
                MakeChars(i_numberOfStar, '*', ref strToPrint);
                MakeChars((i_numberOfRows - i_numberOfStar) / 2, ' ', ref strToPrint);
                Console.WriteLine(strToPrint.ToString());
                SandTimer(i_numberOfRows, i_numberOfStar + 2, isDsc);
            }
        }
    }
}
      

