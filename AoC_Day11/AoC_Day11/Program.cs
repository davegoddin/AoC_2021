using System;
using System.Collections.Generic;

namespace AoC_Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"D:\C# Projects\Advent_of_Code\AoC_2021\AoC_Day11\input.txt");
            Octopus[,] octopodes = new Octopus[input[0].Length, input.Length];

            for (int y = 0; y < input.Length; y++)
            {
                string line = input[y];
                for (int x = 0; x < input[0].Length; x++)
                {
                    char energy = line[x];
                    octopodes[x, y] = new Octopus(Int32.Parse(energy.ToString()), x, y, octopodes);
                }
            }

            int steps = 0;
            bool allFlashed = false;

            while (!allFlashed)
            {
                allFlashed = true;
                for (int y = 0; y < input.Length; y++)
                {
                    for (int x = 0; x < input[0].Length; x++)
                    {
                        octopodes[x, y].IncreaseEnergy();
                    }
                }

                

                for (int y = 0; y < input.Length; y++)
                {
                    for (int x = 0; x < input[0].Length; x++)
                    {
                        if (!octopodes[x, y].Flashed)
                        {
                            allFlashed = false;
                        }
                        octopodes[x, y].Reset();
                    }
                }

                steps++;
            }

            Console.WriteLine(steps);



/*            int totalFlashes = 0;

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++)
                {
                    totalFlashes += octopodes[x, y].Flashes;
                }
            }*/

/*            Console.WriteLine(totalFlashes);*/
        }
    }
}
