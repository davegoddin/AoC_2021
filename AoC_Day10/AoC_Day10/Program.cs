using System;
using System.Collections.Generic;

namespace AoC_Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"C:\Users\g023191l\OneDrive - Staffordshire University\AoC_Day10\input.txt");

            Dictionary<char, char> chunkDelimiters = new Dictionary<char, char>() { { '<', '>'  }, { '(', ')'}, { '{', '}' }, { '[', ']' } };
            // Dictionary<char, int> characterValues = new Dictionary<char, int>() { { '>', 25137 }, { ')', 3 }, { '}', 1197 }, { ']', 57 } };
            Dictionary<char, int> characterPoints = new Dictionary<char, int>() { { '>', 4 }, { ')', 1 }, { '}', 3 }, { ']', 2 } };

            List<char> chunk = new List<char>();
            /*int score = 0;

            foreach (string line in input)
            {
                foreach (char character in line)
                {
                    if (chunkDelimiters.ContainsKey(character))
                    {
                        chunks.Add(character);
                    }
                    else if (chunkDelimiters.ContainsValue(character))
                    {
                        if (character == chunkDelimiters[chunks[^1]])
                        {
                            chunks.RemoveAt(chunks.Count - 1);
                        }
                        else
                        {
                            score += characterValues[character];
                            break;
                        }
                    }
                }
            }*/

            List<long> scores = new List<long>();

            foreach (string line in input)
            {
                chunk.Clear();
                foreach (char character in line)
                {
                    if (chunkDelimiters.ContainsKey(character))
                    {
                        chunk.Add(character);
                    }
                    else if (chunkDelimiters.ContainsValue(character))
                    {
                        if (character != chunkDelimiters[chunk[^1]])
                        {
                            chunk.Clear();
                            break;
                        }
                        else
                        {
                            chunk.RemoveAt(chunk.Count-1);
                        }
                    }
                }
                                

                long score = 0;

                if (chunk.Count > 0)
                {
                    for (int i = chunk.Count - 1; i >= 0; i--)
                    {
                        score *= 5;
                        score += characterPoints[chunkDelimiters[chunk[i]]];
                    }
                    

                    scores.Add(score);


                }
                
            }

            scores.Sort((x, y) => x.CompareTo(y));

            Console.WriteLine(scores[(scores.Count / 2)]);

            

        }
    }
}
