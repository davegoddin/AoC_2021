using System;
using System.Collections.Generic;

namespace AoC_Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "1,3,4,1,1,1,1,1,1,1,1,2,2,1,4,2,4,1,1,1,1,1,5,4,1,1,2,1,1,1,1,4,1,1,1,4,4,1,1,1,1,1,1,1,2,4,1,3,1,1,2,1,2,1,1,4,1,1,1,4,3,1,3,1,5,1,1,3,4,1,1,1,3,1,1,1,1,1,1,1,1,1,1,1,1,1,5,2,5,5,3,2,1,5,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,5,1,1,1,1,5,1,1,1,1,1,4,1,1,1,1,1,3,1,1,1,1,1,1,1,1,1,1,1,3,1,2,4,1,5,5,1,1,5,3,4,4,4,1,1,1,2,1,1,1,1,1,1,2,1,1,1,1,1,1,5,3,1,4,1,1,2,2,1,2,2,5,1,1,1,2,1,1,1,1,3,4,5,1,2,1,1,1,1,1,5,2,1,1,1,1,1,1,5,1,1,1,1,1,1,1,5,1,4,1,5,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,1,1,1,5,4,5,1,1,1,1,1,1,1,5,1,1,3,1,1,1,3,1,4,2,1,5,1,3,5,5,2,1,3,1,1,1,1,1,3,1,3,1,1,2,4,3,1,4,2,2,1,1,1,1,1,1,1,5,2,1,1,1,2";
            string[] ages = input.Split(",");
            long totalFish = 0;

            long[] calendar = new long[257];

            foreach (string age in ages)
            {
                for (int day = Int32.Parse(age)+1; day <= 256; day +=7)
                {
                    calendar[day]++;
                }
            }

            for (int day = 0; day <= 256; day++)
            {
                if (calendar[day] != 0)
                {
                    for (int day_ = day + 9; day_ <= 256; day_ += 7)
                    {
                        calendar[day_] += calendar[day];
                    }
                }
            }

            totalFish = ages.Length;

            foreach (long day in calendar)
            {
                totalFish += day;
            }

            Console.WriteLine(totalFish);
            
        }

    }
}
