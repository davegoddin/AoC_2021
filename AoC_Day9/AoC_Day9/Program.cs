using System;
using System.Collections.Generic;

namespace AoC_Day9
{
    class Program
    {
        static int[,] map;
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"D:\C# Projects\Advent_of_Code\AoC_2021\AoC_Day9\input.txt");
            map = new int[input[0].Length, input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {

                    map[j, input.Length - i - 1] = Int32.Parse(input[i].ToCharArray()[j].ToString());

                }
            }



            // int totalRisk = 0;
            List<int> basins = new List<int>();


            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    if (map[x, y] != 9)
                    {
                        basins.Add(MeasureBasin(x, y));
                    }

                    /*if (IsLowPoint(x, y))
                    {
                        totalRisk += map[x, y] + 1;
                    }*/


                }

            }

            // Console.WriteLine(totalRisk);
            basins.Sort((x, y) => y.CompareTo(x));
            

            Console.WriteLine("{0} * {1} * {2} = {3}", basins[0], basins[1], basins[2], basins[0] * basins[1] * basins[2]);

        }

        static bool IsLowPoint(int x, int y)
        {
            int[][] relativeCoords = new int[4][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };

            foreach (int[] mod in relativeCoords)
            {
                int x_ = Math.Max(Math.Min(map.GetLength(0)-1, x + mod[0]), 0);
                int y_ = Math.Max(Math.Min(map.GetLength(1)-1, y + mod[1]), 0);

                if (x_ == x && y_ == y)
                {
                    continue;
                }

                if (map[x, y] >= map [x_, y_])
                {
                    return false;
                }
            }


            return true;
             
        }

        static int MeasureBasin(int x, int y)
        {
            int basinSize = 0;
            Queue<int[]> cellsToExplore = new Queue<int[]>();
            cellsToExplore.Enqueue(new int[] { x, y });

            while (cellsToExplore.Count > 0)
            {
                int[][] relativeCoords = new int[4][] { new int[] { -1, 0 }, new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { 0, 1 } };
                int[] currentCell = cellsToExplore.Dequeue();

                if (map[currentCell[0], currentCell[1]] != 9) { basinSize++; }

                map[currentCell[0], currentCell[1]] = 9;

                foreach (int[] mod in relativeCoords)
                {                   
                    int x_ = Math.Max(Math.Min(map.GetLength(0) - 1, currentCell[0] + mod[0]), 0);
                    int y_ = Math.Max(Math.Min(map.GetLength(1) - 1, currentCell[1] + mod[1]), 0);

                    if (map[x_, y_] != 9)
                    {
                        cellsToExplore.Enqueue(new int[] { x_, y_ });
                    }
                }
            }

            return basinSize;

        }

    }
}
