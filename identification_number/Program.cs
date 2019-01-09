using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace identification_number
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputEGN = null;
            string boyOrGirl = null;
            string sex = null;
            string year = null;
            string month = null;
            string day = null;
            Console.WriteLine("Въведете 10 цифри за да продължите!");
            inputEGN = Console.ReadLine();

            int substringLastChar = int.Parse(inputEGN.Substring(9, 1));
            bool lastChar = character10(substringLastChar, inputEGN);

            if (correctEGN(inputEGN) == true && lastChar == true)
            {
                year = inputEGN.Substring(0, 2);
                month = inputEGN.Substring(2, 2);
                day = inputEGN.Substring(4, 2);
                sex = inputEGN.Substring(8, 1);

                int numberYear = int.Parse(month);
                numberYear = Year(numberYear, year);

                if (Check(month, day) == true)
                {
                    Console.WriteLine("Дата на раждане: {0}.{1}.{2}", day, month, numberYear);
                    MaleOrFemale(sex, boyOrGirl);
                }
                else
                {
                    Console.WriteLine("Няма такъв човек.");
                }
            }
            else
            {
                Console.WriteLine("Няма такова ЕГН.");
                Environment.Exit(0);
            }         
        } 

      public static bool correctEGN(string EGN)
        {
            if (EGN.Length != 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
      public static bool Check(string inputedMonth, string inputedDay)
        {
            if (int.Parse(inputedMonth) > 52 || int.Parse(inputedMonth) < 1)
            {
                return false;
            }
            else if (int.Parse(inputedDay) > 31 || int.Parse(inputedDay) < 1)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        public static int Year(int numberYear, string year)
        {
            int result = 0;
            if (numberYear >= 21 && numberYear <= 32)
            {
                return result = 1800 + int.Parse(year);
            }
            else if (numberYear >= 41 && numberYear <= 52)
            {
                return result = 2000 + int.Parse(year);
            }
            else
            {
                return result = 1900 + int.Parse(year);
            }  
        }

        public static void MaleOrFemale(string sex, string boyOrGirl)
        {
            if (int.Parse(sex) % 2 == 0)
            {
                Console.WriteLine("Пол: мъж");
            }
            else
            {
                Console.WriteLine("Пол: жена");
            }
        }

        public static bool character10(int finalChar, string EGN)
        {
            int sum = 0;
            int temporary = 0;
            int pernament = 0;

            int[] numbers = new int[10];
            for (int i = 0; i < 10; i++)
            {
                numbers[i] = int.Parse(EGN.Substring(i, 1));
            }

            sum = numbers[0] * 2 + numbers[1] * 4 + numbers[2] * 8 + numbers[3] * 5 + numbers[4] * 10 + numbers[5] * 9 + numbers[6] * 7 + numbers[7] * 3 + numbers[8] * 6;

            temporary = sum / 11;
            temporary = temporary * 11;
            pernament = sum - temporary;

            if (finalChar == pernament)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
