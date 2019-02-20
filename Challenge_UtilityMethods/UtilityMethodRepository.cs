using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_UtilityMethods
{
    public class UtilityMethodRepository
    {
        public bool ReturnBooleanFromString(string input)
        {
            if (input.ToLower().Contains("y"))
                return true;
            else
                return false;
        }

        public string GetDateAsString()
        {
            Console.Write("Month #: ");
            bool isMonth = false;
            int month = 0;
            while (!isMonth)
            {
                isMonth = int.TryParse(Console.ReadLine(), out month);
                if (!isMonth)
                    Console.WriteLine("Please enter the month in the correct format:");
            }
            isMonth = false;
            int day = 0;
            while (!isMonth)
            {
                Console.Write("Date: ");

                isMonth = int.TryParse(Console.ReadLine(), out day);
                if (!isMonth)
                    Console.WriteLine("Please enter the day in the correct format:");
                else if (month == 2 && day > 29)
                    Console.WriteLine("Please enter a correct date for february: ");
                else if (GetMaxDaysBool(month) && day >= 31)
                    Console.WriteLine("Please enter a date less than 31.");
                else if (!GetMaxDaysBool(month) && day >= 30)
                    Console.WriteLine("Please enter a date less than 30.");
            }

            Console.Write("Year: ");
            var year = Console.ReadLine();
            while (year.Length != 4)
            {
                Console.WriteLine("Please enter the year in the correct format:");
                year = Console.ReadLine();
            }
            return $"{month}/{day}/{year}";
        }
    }
}
