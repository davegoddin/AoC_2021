using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_Day5
{
    class Grid
    {
        int[,] grid;

        public Grid(int x, int y)
        {
            grid = new int[x+1, y+1];
        }

        public void AddLine(int[] points)
        {
            
            if (points[1] == points[3])
            {
                for (int x = Math.Min(points[0], points[2]); x <= Math.Max(points[0], points[2]); x++)
                {
                    grid[x, points[1]]++;
                }
            } else if (points[0] == points[2])
            {
                for (int y = Math.Min(points[1], points[3]); y <= Math.Max(points[1], points[3]); y++)
                {
                    grid[points[0], y]++;
                }
            }
            else
            {
                int xMin = Math.Min(points[0], points[2]);
                int yStart;
                int yDirection;

                if (points[0] < points[2])
                {
                    yStart = points[1];
                    yDirection = Math.Sign(points[3] - points[1]);
                }
                else
                {
                    yStart = points[3];
                    yDirection = Math.Sign(points[1] - points[3]);
                }

                for (int i = 0; i <= Math.Abs(points[0]-points[2]); i++)
                {
                    grid[xMin + i, yStart + (i*yDirection)]++;
                }
            }
        }

        public int CountOverlaps()
        {
            int overlaps = 0;
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                for (int y = 0; y < grid.GetLength(1); y++)
                {
                    if (grid[x, y] > 1)
                    {
                        overlaps++;
                    }
                }
            }
            return overlaps;
        }
    }
}
