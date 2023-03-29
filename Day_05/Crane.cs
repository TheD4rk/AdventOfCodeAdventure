using System;
using System.Collections.Generic;

namespace AdventOfCodeAdventure.Day_05;

public class Crane
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_05/Cargo.txt";

    private List<List<char>> cargo;

    public string GetTopCrates()
    {
        InitCrates();
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            // TODO: Re-Arrange Crates
            int moves = Int32.Parse(currentLine.Substring(currentLine.IndexOf(" "), currentLine.IndexOf("f") - currentLine.IndexOf(" ")));
            int moveFrom = Int32.Parse(currentLine.Substring(currentLine.LastIndexOf("m") + 1, currentLine.IndexOf("t") - currentLine.LastIndexOf("m") - 1)) - 1;
            int moveTo = Int32.Parse(currentLine.Substring(currentLine.LastIndexOf("o") + 1, currentLine.Length - 1 - currentLine.LastIndexOf("o"))) - 1;

            for (int i = 0; i < moves; i++)
            {
                cargo[moveTo].Add(cargo[moveFrom][cargo[moveFrom].Count - 1]);
                cargo[moveFrom].RemoveAt(cargo[moveFrom].Count - 1);
            }
        }

        string solution = "";
        foreach (List<char> currentList in cargo)
        {
            solution += currentList[currentList.Count - 1].ToString();
        }
        return solution;
    }
    
    public string GetTopCratesWithNewCrane()
    {
        InitCrates();
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            int moves = Int32.Parse(currentLine.Substring(currentLine.IndexOf(" "), currentLine.IndexOf("f") - currentLine.IndexOf(" ")));
            int moveFrom = Int32.Parse(currentLine.Substring(currentLine.LastIndexOf("m") + 1, currentLine.IndexOf("t") - currentLine.LastIndexOf("m") - 1)) - 1;
            int moveTo = Int32.Parse(currentLine.Substring(currentLine.LastIndexOf("o") + 1, currentLine.Length - 1 - currentLine.LastIndexOf("o"))) - 1;

            for (int i = moves; i > 0; i--)
            {
                cargo[moveTo].Add(cargo[moveFrom][cargo[moveFrom].Count - i]);
                cargo[moveFrom].RemoveAt(cargo[moveFrom].Count - i);
            }
        }

        string solution = "";
        foreach (List<char> currentList in cargo)
        {
            solution += currentList[currentList.Count - 1].ToString();
        }
        return solution;
    }

    private void InitCrates()
    {
        cargo = new List<List<char>>();
        cargo.Add(new List<char>
        {
            'H', 
            'T', 
            'Z', 
            'D' 
        });
        cargo.Add(new List<char>
        {
            'Q', 
            'R', 
            'W', 
            'T', 
            'G', 
            'C', 
            'S' 
        });
        cargo.Add(new List<char>
        {
            'P', 
            'B', 
            'F', 
            'Q', 
            'N', 
            'R', 
            'C', 
            'H' 
        });
        cargo.Add(new List<char>
        {
            'L',
            'C', 
            'N', 
            'F', 
            'H', 
            'Z' 
        });
        cargo.Add(new List<char>
        {
            'G', 
            'L', 
            'F',
            'Q', 
            'S'
        });
        cargo.Add(new List<char>
        {
            'V', 
            'P', 
            'W', 
            'Z', 
            'B', 
            'R', 
            'C', 
            'S'  
        });
        cargo.Add(new List<char>
        {
            'Z', 
            'F', 
            'J'
        });
        cargo.Add(new List<char>
        {
            'D', 
            'L', 
            'V', 
            'Z', 
            'R', 
            'H', 
            'Q'  
        });
        cargo.Add(new List<char>
        {
            'B', 
            'H', 
            'G', 
            'N',
            'F',
            'Z',
            'L',
            'D', 
        });
    }
}