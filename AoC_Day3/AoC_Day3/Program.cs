using System;
using System.Collections.Generic;

namespace AoC_Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"D:\C# Projects\Advent_of_Code\AoC_2021\AoC_Day3\input.txt");
            int lineLength = input[0].Length;

            // part 1
            /*            int[] bitCounts = new int[lineLength];
                        string gamma = null;
                        string epsilon = null;

                        foreach (string line in input)
                        {
                            for (int i = 0; i < lineLength; i++)
                            {
                                bitCounts[i] += Int32.Parse(line.ToCharArray()[i].ToString());
                            }
                        }

                        foreach (int count in bitCounts)
                        {
                            if (count*2 > input.Length)
                            {
                                gamma += "1";
                                epsilon += "0";
                            }
                            else
                            {
                                gamma += "0";
                                epsilon += "1";
                            }
                        }

                        Console.WriteLine(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));*/

            // part 2

            List<char[]> oxyLines = new List<char[]>();
            List<char[]> co2Lines = new List<char[]>();

            foreach (string line in input)
            {
                oxyLines.Add(line.ToCharArray());
                co2Lines.Add(line.ToCharArray());
            }

            int bitPosition = 0;

            while (oxyLines.Count > 1 && bitPosition < lineLength)
            {
                
                int[] countValues = GetNumberOfValues(oxyLines, bitPosition);
                char mostCommonValue = MostCommonValue(countValues, '1');

                for (int i = oxyLines.Count - 1; i >= 0; i--)
                {
                    if (oxyLines[i][bitPosition] != mostCommonValue)
                    {
                        oxyLines.RemoveAt(i);
                    }
                }

                bitPosition++;
            }

            bitPosition = 0;

            while (co2Lines.Count > 1 && bitPosition < lineLength)
            {
                int[] countValues = GetNumberOfValues(co2Lines, bitPosition);
                char mostCommonValue = MostCommonValue(countValues, '1');

                for (int i = co2Lines.Count - 1; i >= 0; i--)
                {
                    if (co2Lines[i][bitPosition] == mostCommonValue)
                    {
                        co2Lines.RemoveAt(i);
                        
                    }
                }

                bitPosition++;
            }

            Console.WriteLine((Convert.ToInt32(new string(oxyLines[0]), 2) * Convert.ToInt32(new string(co2Lines[0]), 2)).ToString());




            Console.ReadLine();


        }

        static int[] GetNumberOfValues(List<char[]> input, int bitPos)
        {
            int zero = 0;
            int one = 0;

            foreach (char[] line in input)
            {
                switch (line[bitPos])
                {
                    case '0':
                        zero++;
                        break;
                    case '1':
                        one++;
                        break;
                    default:
                        break;
                }
            }

            return new int[] { zero, one };
            
        }

        static char MostCommonValue(int[] numbers, char priority)
        {
            if (numbers[0] > numbers[1])
            {
                return '0';
            }
            else if (numbers[1] > numbers[0])
            {
                return '1';
            }
            else
            {
                return priority;
            }

        }
    }
}
