using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeAdventure.Day_03;

public class RucksackReArranger
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_03/Rucksack.txt";

    private Dictionary<char, int> lowerCaseAlphabet;
    private Dictionary<char, int> UpperCaseAlphabet;
    
    public int PrioritizeItems()
    {
        lowerCaseAlphabet = PrepareAlphabet("abcdefghijklmnopqrstuvwxyz", 1);
        UpperCaseAlphabet = PrepareAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 27);
        int itemSum = 0;

        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            char[] compartmentOne = currentLine.Substring(0,currentLine.Length / 2).ToCharArray();
            char[] compartmentTwo = currentLine.Substring(currentLine.Length / 2).ToCharArray();
            foreach (char currentItem in compartmentOne)
            {
                if (!compartmentTwo.Contains(currentItem)) continue;
                if (char.IsLower(currentItem))
                {
                    itemSum += lowerCaseAlphabet[currentItem];
                    break;
                }
                itemSum += UpperCaseAlphabet[currentItem];
                break;
            }
        }

        return itemSum;
    }

    public int FindBadge()
    {
        // Init
        lowerCaseAlphabet = PrepareAlphabet("abcdefghijklmnopqrstuvwxyz", 1);
        UpperCaseAlphabet = PrepareAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 27);
        int badgeSum = 0;
        string elfOne = "";
        string elfTwo = "";
        string elfThree = "";
        int counter = 0;

        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            elfThree = elfTwo;
            elfTwo = elfOne;
            elfOne = currentLine;
            counter++;

            // Get the next 3 elves
            if (counter < 3) continue;
            char[] firstInventory = elfOne.ToCharArray();
            char[] secondInventory = elfTwo.ToCharArray();
            char[] thirdInventory = elfThree.ToCharArray();
            counter = 0;

            // Check for same badge
            foreach (char currentItem in firstInventory)
            {
                if (!(secondInventory.Contains(currentItem) && thirdInventory.Contains(currentItem))) continue;
                // Add Points
                if (char.IsLower(currentItem))
                {
                    badgeSum += lowerCaseAlphabet[currentItem];
                    break;
                }
                badgeSum += UpperCaseAlphabet[currentItem];
                break;
            }
        }

        return badgeSum;
    }

    private Dictionary<char, int> PrepareAlphabet(string alphabet, int startValue)
    {
        Dictionary<char, int> alphabetDictionary = new Dictionary<char, int>();
        foreach (var currentCharacter in alphabet)
        {
            alphabetDictionary.Add(currentCharacter, startValue);
            startValue++;
        }

        return alphabetDictionary;
    }
}