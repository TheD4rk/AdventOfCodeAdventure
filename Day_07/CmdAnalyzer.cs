using System;
using System.Collections.Generic;

namespace AdventOfCodeAdventure.Day_07;

public class CmdAnalyzer
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_07/Commands.txt";

    private Dictionary<string, int> directorySpace;
    private List<string> previousDirectories;

    private Random rand = new Random();

    public int GetDirectoriesTotalSize()
    {
        directorySpace = new Dictionary<string, int>();
        previousDirectories = new List<string>();
        string currentDirectory = "";
        int sum = 0;
        
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            string[] input = currentLine.Split(" ");

            if (input[1] == "ls") continue;
            if (input[1] == "cd")
            {
                if (input[2] == "..") currentDirectory = PreviousDirectory();
                else currentDirectory = NewDirectory(input[2], currentDirectory);
            }
            else if (input[0] != "dir")
            {
                AddSpace(currentDirectory, Int32.Parse(input[0]));

                foreach (string directory in previousDirectories)
                {
                    AddSpace(directory, Int32.Parse(input[0]));
                }
            }
        }

        int directorySizeToDelete = directorySpace["/"];
        int reqSpace = 30000000 - (70000000 - directorySpace["/"]);

        foreach (var keyValuePair in directorySpace)
        {
            if (keyValuePair.Value <= 100000)
            {
                sum += keyValuePair.Value;
            }

            if (keyValuePair.Value >= reqSpace && keyValuePair.Value < directorySizeToDelete)
            {
                directorySizeToDelete = keyValuePair.Value;
            }
        }
        System.Console.WriteLine("Delete directory of size: " + directorySizeToDelete);

        return sum;
    }

    private string PreviousDirectory()
    {
        string directory = previousDirectories[^1];
        previousDirectories.Remove(directory);
        return directory;
    }

    private string NewDirectory(string newDirectory, string currentDirectory)
    {
        if (directorySpace.ContainsKey(newDirectory))
        {
            newDirectory = newDirectory + previousDirectories[^1] + rand.NextInt64(1234);
            directorySpace.Add(newDirectory, 0);
        }
        else
        {
            directorySpace.Add(newDirectory, 0);
        }
        if (currentDirectory != "") previousDirectories.Add(currentDirectory);
        return newDirectory;
    }

    private void AddSpace(string directory, int spaceValue)
    {
        int newValue = directorySpace[directory] + spaceValue;
        directorySpace[directory] = newValue;
    }
}