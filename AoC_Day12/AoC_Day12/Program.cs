using System;
using System.Collections.Generic;

namespace AoC_Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"D:\C# Projects\Advent_of_Code\AoC_2021\AoC_Day12\input.txt");

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


            
            List<string> completePaths = new List<string>();

            foreach (Cave cave in caves.Values)
            {
                

                if (!cave.Big && cave.Id != "start" && cave.Id != "end")
                {
                    
                    Queue<Path> paths = new Queue<Path>();
                    paths.Enqueue(new Path(new List<Cave> { caves["start"] }, cave));

                    while (paths.Count > 0)
                    {
                        Path currentPath = paths.Dequeue();
                        List<Path> newBranches = currentPath.CreateBranches();
                        foreach (Path branch in newBranches)
                        {
                            // Console.WriteLine(branch.Caves.Count + " - " + branch.Complete);
                            if (branch.Complete)
                            {
                                string path = "";
                                foreach (Cave c in branch.Caves)
                                {
                                    path += c.Id;
                                }

                                if (!completePaths.Contains(path))
                                {
                                    completePaths.Add(path);
                                }
                                
                                
                            }
                            else
                            {
                                paths.Enqueue(branch);
                            }
                        }
                    }
                }

                

            }

            Console.WriteLine(completePaths.Count);
        }
    }
}
