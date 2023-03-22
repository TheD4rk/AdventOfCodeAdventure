namespace AdventOfCodeAdventure.Day_02;

public class RockPaperScissors
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_02/StrategyGuide.txt";
    
    public int CalculateStrategyGuide()
    {
        int sum = 0;
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            string[] charLine = currentLine.Split(' ');

            if ((charLine[0] == "A" && charLine[1] == "X") || (charLine[0] == "B" && charLine[1] == "Y") || (charLine[0] == "C" && charLine[1] == "Z")) sum += 3;
            else if ((charLine[0] == "A" && charLine[1] == "Y") || (charLine[0] == "B" && charLine[1] == "Z") ||
                     (charLine[0] == "C" && charLine[1] == "X")) sum += 6;
            
            switch (charLine[1])
            { 
                case "X": sum += 1;
                    break;
                case "Y": sum += 2;
                    break;
                case "Z": sum += 3;
                    break;
            }

        }

        return sum;
    }
    
    public int CalculateRealStrategyGuide()
    {
        int sum = 0;
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            string[] charLine = currentLine.Split(' ');

            if ((charLine[0] == "A" && charLine[1] == "X") || (charLine[0] == "B" && charLine[1] == "Z") ||
                (charLine[0] == "C" && charLine[1] == "Y")) sum += 3;
            else if ((charLine[0] == "B" && charLine[1] == "Y") || (charLine[0] == "C" && charLine[1] == "X") ||
                     (charLine[0] == "A" && charLine[1] == "Z")) sum += 2;
            else sum += 1;
            
            switch (charLine[1])
            { 
                case "X": sum += 0;
                    break;
                case "Y": sum += 3;
                    break;
                case "Z": sum += 6;
                    break;
            }
        }

        return sum;
    }
}