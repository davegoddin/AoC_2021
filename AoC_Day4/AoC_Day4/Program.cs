using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC_Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] boardValues = System.IO.File.ReadAllLines(@"D:\C# Projects\Advent_of_Code\AoC_2021\AoC_Day4\boards.txt");
            string[] input = System.IO.File.ReadAllText(@"D:\C# Projects\Advent_of_Code\AoC_2021\AoC_Day4\input.txt").Split(",");
            List<Board> boards = new List<Board>();

            for (int i = 0; i< boardValues.Length; i+=6)
            {
                string[] boardData = new string[5];
                for (int x = 0; x < 5; x++)
                {
                    boardData[x] = boardValues[i + x];
                }

                boards.Add(new Board(boardData));
                
            }

            // bool winnerFound = false;
            int lastScore = -1;
            foreach (string number in input)
            {

                foreach (Board board in boards)
                {
                    if (!board.Completed)
                    {
                        if (board.MarkNumberAndCheckWinner(Int32.Parse(number)))
                        {
                            // winnerFound = true;
                            lastScore = board.Score(Int32.Parse(number));
                            // break;
                        }
                    }

                }
                // if (winnerFound) { break; }
            }

            Console.WriteLine(lastScore.ToString());
            


        }
    }
}
