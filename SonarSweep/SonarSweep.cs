using System;
using System.IO;

namespace AdventOfCodeAdventure.SonarSweep
{
    public class SonarSweep
    {
        static void Main(string[] args)
        {
            SonarSweep sonarSweep = new SonarSweep();
            sonarSweep.ScanFile();
        }

        private void ScanFile()
        {
            string filePath = "D:/Repository/AdventOfCodeAdventure/SonarSweep/SonarSweepLines.txt";
            Console.WriteLine(filePath);
            
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