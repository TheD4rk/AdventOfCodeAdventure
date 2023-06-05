
using AdventOfCodeAdventure.Day_01;
using AdventOfCodeAdventure.Day_02;
using AdventOfCodeAdventure.Day_03;
using AdventOfCodeAdventure.Day_04;
using AdventOfCodeAdventure.Day_05;
using AdventOfCodeAdventure.Day_06;
using AdventOfCodeAdventure.Day_07;
using AdventOfCodeAdventure.Day_08;
using AdventOfCodeAdventure.Day_09;
using AdventOfCodeAdventure.Day_10;
using AdventOfCodeAdventure.Day_11;
using AdventOfCodeAdventure.Day_12;
using AdventOfCodeAdventure.Day_13;

namespace AdventOfCodeAdventure
{
    public class EntryPoint
    {
        static void Main(string[] args)
        {
            // Day 01 - Find Elf with most Calories
            // GluttonousElf gluttonousElf = new GluttonousElf();
            // System.Console.WriteLine(gluttonousElf.FindMostCalories());
            
            // Day 02 - Rock Paper Scissors
            // RockPaperScissors rockPaperScissors = new RockPaperScissors();
            // System.Console.WriteLine(rockPaperScissors.CalculateStrategyGuide());
            // System.Console.WriteLine("Real Strategy Guide: " + rockPaperScissors.CalculateRealStrategyGuide());
            
            // Day 03 - Rucksack Re-Arrangement
            // RucksackReArranger rucksackReArranger = new RucksackReArranger();
            // System.Console.WriteLine(rucksackReArranger.PrioritizeItems());
            // System.Console.WriteLine(rucksackReArranger.FindBadge());
            
            // Day 04 - Cleanup Assignments
            // Cleanup cleanup = new Cleanup();
            // System.Console.WriteLine(cleanup.FindOverlappingAssignments());
            
            // Day 05 - Cargo Re-Arrangement
            // Crane crane = new Crane();
            // System.Console.WriteLine(crane.GetTopCrates());
            // System.Console.WriteLine(crane.GetTopCratesWithNewCrane());
            
            // Day 06 - Device Data Stream
            // DeviceFixer deviceFixer = new DeviceFixer();
            // System.Console.WriteLine(deviceFixer.GetCharacterCount());
            // System.Console.WriteLine(deviceFixer.GetMessageMarker());
            
            // Day 07 - File Deletion
            // CmdAnalyzer cmdAnalyzer = new CmdAnalyzer();
            // System.Console.WriteLine(cmdAnalyzer.GetDirectoriesTotalSize());
            
            // Day 08 - Treehouse
            // ForestAnalyzer forestAnalyzer = new ForestAnalyzer();
            // System.Console.WriteLine(forestAnalyzer.GetVisibleTrees());
            // System.Console.WriteLine(forestAnalyzer.GetHighestScenicScore());
            
            // Day 09 - Rope Bridge
            // Rope rope = new Rope();
            // System.Console.WriteLine(rope.GetPointsVisited());
            
            // Day 10 - CPU Cycles
            // CPUCommunication cpuCommunication = new CPUCommunication();
            // System.Console.WriteLine(cpuCommunication.SignalStrength());
            // cpuCommunication.DrawCRT();
            
            // Day 11 - Monkeys
            // WorryWart worryWart = new WorryWart();
            // System.Console.WriteLine(worryWart.MonkeyBusinessLevel());
            
            // Day 12 - Pathfinding
            // Pathfinder pathfinder = new Pathfinder();
            // System.Console.WriteLine(pathfinder.CalculateSteps());
            // System.Console.WriteLine(pathfinder.FindBestStartingSpot());
            
            // Day 13 - Packet checking
            PacketChecker packetChecker = new PacketChecker();
            // System.Console.WriteLine(packetChecker.SumCorrectPackets());
            System.Console.WriteLine(packetChecker.IndexSpecificPackets());
        }
    }
}