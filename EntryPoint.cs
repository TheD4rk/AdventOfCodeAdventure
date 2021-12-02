using AdventOfCodeAdventure.Day01;

namespace AdventOfCodeAdventure
{
    public class EntryPoint
    {
        static void Main(string[] args)
        {
            //  -- Day 01 - Part 01 --
            //SonarSweep sonarSweep = new SonarSweep();
            //sonarSweep.ScanFile();
            
            // -- Day 01 - Part 02 --
            SumSonar sumSonar = new SumSonar();
            sumSonar.CalculateSums();
        }
    }
}