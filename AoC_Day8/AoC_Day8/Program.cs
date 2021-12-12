using System;
using System.Collections.Generic;

namespace AoC_Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"D:\C# Projects\Advent_of_Code\AoC_2021\AoC_Day8\input.txt");

            string[][][] lines = new string[input.Length][][];

            for (int i = 0; i < input.Length; i++)
            {

                lines[i] = new string[2][];                
                string[] digits = input[i].Substring(0, input[i].IndexOf(" | ")).Split(" ");
                string[] output = input[i].Substring(input[i].IndexOf(" | ") + 3).Split(" ");

                lines[i][0] = digits;
                lines[i][1] = output;
                
            }

            int[] digitCounts = new int[10];

            /*            foreach (string[][] line in lines)
                        {
                            foreach (string digit in line[1])
                            {
                                switch (digit.Length)
                                {
                                    case 2:
                                        digitCounts[1]++;
                                        break;
                                    case 3:
                                        digitCounts[7]++;
                                        break;
                                    case 4:
                                        digitCounts[4]++;
                                        break;
                                    case 7:
                                        digitCounts[8]++;
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }*/

            /*Console.WriteLine("{0}, {1}, {2}, {3}", digitCounts[1], digitCounts[4], digitCounts[7], digitCounts[8]);
            Console.WriteLine(digitCounts[1] + digitCounts[4] + digitCounts[7] + digitCounts[8]);*/

            int totalOutput = 0;

            foreach (string[][] line in lines)
            {
                string[] digits = new string[10];

                Array.Sort(line[0], (x, y) => x.Length.CompareTo(y.Length));

                digits[1] = line[0][0];
                digits[7] = line[0][1];
                digits[4] = line[0][2];
                digits[8] = line[0][9];

                for (int i = 3; i < 9; i++)
                {
                    int exclusively1 = 0;
                    int exclusively4 = 0;
                    
                    foreach (char wire in digits[1].ToCharArray())
                    {
                        if (!line[0][i].Contains(wire))
                        {
                            exclusively1++;
                        }
                    }

                    foreach (char wire in digits[4].ToCharArray())
                    {
                        if (!line[0][i].Contains(wire))
                        {
                            exclusively4++;
                        }
                    }

                    switch (line[0][i].Length)
                    {
                        case 5:
                            if (exclusively4 == 2)
                            {
                                digits[2] = line[0][i];
                            }
                            else if (exclusively1 == 1)
                            {
                                digits[5] = line[0][i];
                            }
                            else
                            {
                                digits[3] = line[0][i];
                            }
                            break;
                        case 6:
                            if (exclusively1 == 1)
                            {
                                digits[6] = line[0][i];
                            }
                            else if (exclusively4 == 1)
                            {
                                digits[0] = line[0][i];
                            }
                            else
                            {
                                digits[9] = line[0][i];
                            }
                            break;
                        default:
                            break;
                    }
                }

                string outputDigits = "";
                foreach (string output in line[1])
                {
                    
                    for (int i = 0; i < 10; i++)
                    {
                        bool equivalentDigit = true;
                        if (digits[i].Length == output.Length)
                        {
                            
                            foreach (char segment in digits[i])
                            {
                                if (!output.Contains(segment))
                                {
                                    equivalentDigit = false;
                                }
                            }
                        }
                        else
                        {
                            equivalentDigit = false;
                        }

                        if (equivalentDigit)
                        {
                            outputDigits += i.ToString();
                        }
                    }
                    
                }

                totalOutput += Int32.Parse(outputDigits);
                
            }

            Console.WriteLine(totalOutput);

        }


    }
}
