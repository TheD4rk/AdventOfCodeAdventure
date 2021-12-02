using System;
using System.IO;

namespace AdventOfCodeAdventure.Day01
{
    public class SumSonar
    {
        public void CalculateSums()
        {
            string filePath = "D:/Repository/AdventOfCodeAdventure/Day01/SonarSweepLines.txt";

            if (File.Exists(filePath))
            {
                int[] sumArray = new int[3];
                int counter = 0, lines = 0;
                int oldSum = 0;

                int increases = 0;
                
                foreach (string currentLine in File.ReadLines(filePath))
                {
                    int nextDepth = Int32.Parse(currentLine);
                    sumArray[counter] = nextDepth;
                    counter++;
                    lines++;
                    counter %= 3;

                    if (lines == 2)
                    {
                        oldSum = sumArray[0] + sumArray[1] + sumArray[2];
                    }
                    
                    if (lines >= 3)
                    {

                        int newSum = sumArray[0] + sumArray[1] + sumArray[2];
                        if (NewSumHigher(oldSum, newSum)) increases++;
                        oldSum = newSum;
                    }
                }
                Console.WriteLine(increases - 1);
            }
            else
            {
                Console.WriteLine("File not Found!");
            }
        }

        private bool NewSumHigher(int oldSum, int newSum)
        {
            return newSum > oldSum;
        }
    }
}