using System;

namespace AdventOfCodeAdventure.Day_10;

public class CPUCommunication
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_10/Instructions.txt";

    public int SignalStrength()
    {
        int signalSum = 0;
        int signalStrength = 1;
        int cycle = 1;
        
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            string[] input = currentLine.Split(" ");
            
            signalSum += CheckCycle(cycle, signalStrength);
            cycle++;
            if (input[0].Equals("noop"))
            {
                continue;
            }
            
            signalSum += CheckCycle(cycle, signalStrength);
            cycle++;
            signalStrength += Int32.Parse(input[1]);

        }

        return signalSum;
    }

    public void DrawCRT()
    {
        int cycle = 1;
        int signalStrength = 1;
        string currentCRTLine = "> ";
        
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            string[] input = currentLine.Split(" ");

            currentCRTLine += AddPixel(cycle - 1, signalStrength);
            if (CRTLineAtEnd(cycle)) currentCRTLine = PrintCurrentCRTLine(currentCRTLine);
            cycle++;
            
            if (input[0].Equals("noop"))
            {
                continue;
            }
            
            currentCRTLine += AddPixel(cycle - 1, signalStrength);
            if (CRTLineAtEnd(cycle)) currentCRTLine = PrintCurrentCRTLine(currentCRTLine);
            cycle++;
            signalStrength += Int32.Parse(input[1]);
        }
    }

    private int CheckCycle(int currentCycle, int currentSignalStrength)
    {
        if (currentCycle == 20 || currentCycle % 40 == 20)
        {
            return currentCycle * currentSignalStrength;
        }

        return 0;
    }

    private bool CRTLineAtEnd(int currentCycle)
    {
        if (currentCycle % 40 == 0) return true;
        return false;
    }

    private string AddPixel(int currentCycle, int currentSignalValue)
    {
        if ((currentCycle % 40) - 1 <= currentSignalValue && (currentCycle % 40) + 1 >= currentSignalValue) return "#";
        return ".";
    }

    private string PrintCurrentCRTLine(string currentLine)
    {
        currentLine += " <";
        System.Console.WriteLine(currentLine);
        return "> ";
    }
}