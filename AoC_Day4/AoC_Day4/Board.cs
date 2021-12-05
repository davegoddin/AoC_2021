using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AoC_Day4
{
    class Board
    {
        static int boardSize = 5;
        KeyValuePair<int, bool>[,] valuesArray = new KeyValuePair<int, bool>[boardSize, boardSize];
        List<int> values = new List<int>();
        bool completed = false;
        
        public bool Completed { get { return completed; } }

        public Board(string[] input)
        {
            for (int x = 0; x < boardSize; x++)
            {
                string[] row = Regex.Split(input[x].Trim(), " +");
                for (int y = 0; y < boardSize; y++)
                {
                    valuesArray[x, y] = new KeyValuePair<int, bool>(Int32.Parse(row[y]), false);
                    values.Add(Int32.Parse(row[y]));
                }
            }
        }



        public bool MarkNumberAndCheckWinner(int number)
        {
            if (!values.Contains(number))
            {
                return false;
            }

            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    if (valuesArray[x, y].Key == number)
                    {
                        valuesArray[x, y] = new KeyValuePair<int, bool>(number, true);
                        if (WinningColumn(x) || WinningRow(y))
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }

            return false;

        }

        private bool WinningColumn(int colNum)
        {
            for (int y = 0; y < boardSize; y++)
            {
                if (!valuesArray[colNum, y].Value)
                {
                    return false;
                }
            }
            completed = true;
            return true;
        }

        private bool WinningRow (int rowNum)
        {
            for (int x = 0; x < boardSize; x++)
            {
                if (!valuesArray[x, rowNum].Value)
                {
                    return false;
                }
            }
            completed = true;
            return true;
        }

        public int Score(int lastValue)
        {
            int score = 0;
            for (int x = 0; x < boardSize; x++)
            {
                for (int y = 0; y < boardSize; y++)
                {
                    if (!valuesArray[x, y].Value)
                    {
                        score += valuesArray[x, y].Key;
                    }
                }
            }

            return score * lastValue;
        }
    }


}
