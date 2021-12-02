using System;
using System.Collections.Generic;

namespace AoC_Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"D:/C# Projects/Advent_of_Code/AoC_Day1/input.txt");


            Console.WriteLine(Part1(input).ToString());
            Console.WriteLine(Part2(input).ToString());

            Console.ReadLine();
        }

        private static int Part1(string[] input)
        {

            int countIncrease = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (i < input.Length - 1)
                {
                    if (Int32.Parse(input[i]) < Int32.Parse(input[i + 1]))
                    {
                        countIncrease++;
                    }
                }
            }

            return countIncrease;
        }

        private static int Part2(string[] input)
        {
            List<string> windows = new List<string>();

            for (int i = 0; i < input.Length - 2; i++)
            {
                windows.Add((Int32.Parse(input[i]) + Int32.Parse(input[i + 1]) + Int32.Parse(input[i + 2])).ToString());
            }

            int countIncrease = 0;

            for (int i = 0; i < windows.Count; i++)
            {
                if (i < windows.Count - 1)
                {
                    if (Int32.Parse(windows[i]) < Int32.Parse(windows[i + 1]))
                    {
                        countIncrease++;
                    }
                }
            }

            return countIncrease;
        }

    }



}
