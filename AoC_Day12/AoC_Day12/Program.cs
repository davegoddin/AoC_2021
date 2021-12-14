using System;
using System.Collections.Generic;

namespace AoC_Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"C:\Users\g023191l\Source\Repos\AoC_2021\AoC_Day12\input.txt");

            Dictionary<string, Cave> caves = new Dictionary<string, Cave>();
            

            foreach (string line in input)
            {
                string[] caveIDs = line.Split("-");

                for (int i = 0; i < 2; i++)
                {
                    if (!caves.ContainsKey(caveIDs[i]))
                    {
                        caves.Add(caveIDs[i], new Cave(caveIDs[i]));
                    }
                }

                if (!caves[caveIDs[0]].Connections.Contains(caves[caveIDs[1]]))
                {
                    caves[caveIDs[0]].AddConnection(caves[caveIDs[1]]);
                }

                if (!caves[caveIDs[1]].Connections.Contains(caves[caveIDs[0]]))
                {
                    caves[caveIDs[1]].AddConnection(caves[caveIDs[0]]);
                }
            }

            Queue<Path> paths = new Queue<Path>();
            List<Path> completePaths = new List<Path>();

            paths.Enqueue(new Path(new List<Cave> { caves["start"] }));

            while (paths.Count > 0)
            {
                Path currentPath = paths.Dequeue();
                List<Path> newBranches = currentPath.CreateBranches();
                foreach (Path branch in newBranches)
                {
                    // Console.WriteLine(branch.Caves.Count + " - " + branch.Complete);
                    if (branch.Complete)
                    {
                        completePaths.Add(branch);
                    }
                    else
                    {
                        paths.Enqueue(branch);
                    }
                }
            }
            


            Console.WriteLine(completePaths.Count);
        }
    }
}
