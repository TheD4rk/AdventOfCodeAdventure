using System;

namespace AdventOfCodeAdventure.Day_04;

public class Cleanup
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_04/SectionAssignments.txt";
    
    public int FindOverlappingAssignments()
    {
        int sumOfPairsContainedFully = 0;
        int sumOfPairsContainedPartially = 0;
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            int elfOneMin = Int32.Parse(currentLine.Substring(0,currentLine.IndexOf("-")));
            int elfOneMax = Int32.Parse(currentLine.Substring(currentLine.IndexOf("-") + 1,currentLine.IndexOf(",") - (currentLine.IndexOf("-") + 1)));
            int elfTwoMin = Int32.Parse(currentLine.Substring(currentLine.IndexOf(",") + 1,currentLine.LastIndexOf("-") - (currentLine.IndexOf(",") + 1)));
            int elfTwoMax = Int32.Parse(currentLine.Substring(currentLine.LastIndexOf("-") + 1,currentLine.Length - 1 - currentLine.LastIndexOf("-")));
            
            // Possibility 1: Elf1 in Elf2
            if (elfOneMin >= elfTwoMin && elfOneMax <= elfTwoMax) sumOfPairsContainedFully++;
            // Possibility 2: Elf2 in Elf1
            else if (elfTwoMin >= elfOneMin && elfTwoMax <= elfOneMax) sumOfPairsContainedFully++;

            if (elfOneMax >= elfTwoMin && elfTwoMin >= elfOneMin) sumOfPairsContainedPartially++;
            else if (elfOneMin <= elfTwoMax && elfOneMin >= elfTwoMin) sumOfPairsContainedPartially++;
        }
        System.Console.WriteLine("Assignments contained partially: " + sumOfPairsContainedPartially);
        return sumOfPairsContainedFully;
    }
}