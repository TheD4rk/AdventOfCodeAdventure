using System;
using System.IO;

namespace AdventOfCodeAdventure.Day01
{
    public class SonarSweep
    {
        public void ScanFile()
        {
            string filePath = "D:/Repository/AdventOfCodeAdventure/SonarSweep/SonarSweepLines.txt";

            if (File.Exists(filePath))
            {
                int measurements = 0;
                int currentHigh = 0;
                foreach (string currentLine in File.ReadLines(filePath))
                {
                    int newHight = Int32.Parse(currentLine);

                    if (currentHigh < newHight)
                    {
                        measurements++;
                    }
                    currentHigh = newHight;
                }
                Console.WriteLine(measurements - 1); // Remove the first comparison of "0 vs First File Line"
            }
            else
            {
                Console.WriteLine("File not Found!");
            }
        }
    }
}