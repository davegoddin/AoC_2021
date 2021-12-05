using System;
using System.Collections.Generic;

namespace AoC_Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"D:\C# Projects\Advent_of_Code\AoC_2021\AoC_Day5\input.txt");
            List<int[]> lines = new List<int[]>();

            int maxX = 0;
            int maxY = 0;
            
            foreach (string line in input)
            {
                
                string[] coords = line.Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                int[] points = new int[coords.Length];
                for (int i = 0; i < coords.Length; i++)
                {
                    points[i] = Int32.Parse(coords[i]);

                    if (i == 0 || i == 2)
                    {
                        if (points[i] > maxX)
                        {
                            maxX = points[i];
                        }
                    }
                    if (i == 1 || i == 3)
                    {
                        if (points[i] > maxY)
                        {
                            maxY = points[i];
                        }
                    }
                }
                
                lines.Add(points);

                
            }

            Grid grid = new Grid(maxX, maxY);

            foreach (int[] line in lines)
            {

                Console.WriteLine("{0}, {1}, {2}, {3}", line[0], line[1], line[2], line[3]);
                grid.AddLine(line);

            }



            Console.WriteLine(grid.CountOverlaps());
        }
    }
}
