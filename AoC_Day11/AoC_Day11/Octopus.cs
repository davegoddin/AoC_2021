using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day11
{
    class Octopus
    {
        int energy;
        int[] position;
        bool flashed = false;
        Octopus[,] grid;
        int flashes = 0;

        public int Flashes { get { return flashes; } }
        public bool Flashed { get { return flashed; } }

        public Octopus(int energy, int x, int y, Octopus[,] grid)
        {
            this.energy = energy;
            position = new int[] { x, y };
            this.grid = grid;
        }

        public void IncreaseEnergy()
        {
            if (!flashed)
            {
                energy++;
                if (energy > 9)
                {
                    Flash();
                }
            }
        }

        public void Flash()
        {
            flashed = true;
            flashes++;

            for (int y = position[1]-1; y <= position[1]+1; y++)
            {
                if (y < 0 || y > grid.GetLength(1)-1)
                {
                    continue;
                }

                for (int x = position[0]-1; x<=position[0]+1; x++)
                {
                    if (x < 0 || x > grid.GetLength(0)-1 || (x == position[0] && y == position[1]))
                    {
                        continue;
                    }
                    grid[x, y].IncreaseEnergy();

                    
                }
            }
        }

        public void Reset()
        {
            flashed = false;
            if (energy > 9)
            {
                energy = 0;
            }
        }

        

    }
}
