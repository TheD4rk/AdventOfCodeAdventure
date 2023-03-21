
using System;

namespace AdventOfCodeAdventure.Day_01
{
    public class GluttonousElf
    {
        private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_01/Calories.txt";
        private int[] _topElves = {0,0,0};

        public int FindMostCalories()
        {
            int currentMax = 0;
            int currentSum = 0;

            foreach (string currentLine in System.IO.File.ReadLines(_filePath))
            {
                if (currentLine.Length == 0)
                {
                    if (currentSum > currentMax) currentMax = currentSum;
                    CheckForTop3(currentSum);
                    currentSum = 0;
                }
                else
                {
                    currentSum += Int32.Parse(currentLine);
                }
            }

            int top3Sum = _topElves[0] + _topElves[1] + _topElves[2];
            System.Console.WriteLine("Top 3 Elves have: " + top3Sum + " Calories.");

            return currentMax;
        }

        private void CheckForTop3(int newElf)
        {
            if (newElf < _topElves[0]) return;
            if (newElf < _topElves[1])
            {
                _topElves[0] = newElf;
                return;
            }

            if (newElf < _topElves[2])
            {
                _topElves[0] = _topElves[1];
                _topElves[1] = newElf;
                return;
            }

            _topElves[0] = _topElves[1];
            _topElves[1] = _topElves[2];
            _topElves[2] = newElf;
        }
    }
}