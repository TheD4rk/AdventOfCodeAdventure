using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeAdventure.Day_13;

public class PacketChecker
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_13/Packets.txt";

    public int SumCorrectPackets()
    {
        int lineAmount = File.ReadLines(_filePath).Count();
        int currentLineIndex = 0, correctSum = 0;
        int packetPairIndex = 1;
        while (currentLineIndex < lineAmount)
        {
            string firstPacket = File.ReadLines(_filePath).Skip(currentLineIndex).Take(1).First();
            string secondPacket = File.ReadLines(_filePath).Skip(currentLineIndex + 1).Take(1).First();
            
            //System.Console.WriteLine("First Packet: " + firstPacket);
            //System.Console.WriteLine("Second Packet: " + secondPacket);

            if (CheckPackets(firstPacket, secondPacket))
            {
                correctSum += packetPairIndex;
                System.Console.WriteLine("Pair: " + packetPairIndex + " was sorted correctly");
            }

            currentLineIndex += 3;
            packetPairIndex++;
        }

        return correctSum;
    }

    public int IndexSpecificPackets()
    {
        int correctSum = 0;

        // Fill Array with Packets
        List<List<object>> packets = new List<List<object>>();
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            if (currentLine.Length > 1) packets.Add(ParsePacket(currentLine));
        }
        
        // Merge Sort
        packets = MergeSort(packets);
        
        // Find Packets' Index and multiply
        List<object> decoder1 = ParsePacket("[[2]]");
        List<object> decoder2 = ParsePacket("[[6]]");

        int a = 0, b = 0;
        
        foreach (List<object> packet in packets)
        {
            // Add +1 to not start index at "0"
            if (CompareLists(packet, decoder1) == 0) a = packets.IndexOf(packet) + 1;
            if (CompareLists(packet, decoder2) == 0) b = packets.IndexOf(packet) + 1;
        }

        return a * b;
    }

    private List<List<object>> MergeSort(List<List<object>> list)
    {
        // Divide
        if (list.Count <= 1)
        {
            return list;
        }

        List<List<object>> listA = MergeSort(list.GetRange(0, list.Count / 2));
        List<List<object>> listB = MergeSort(list.GetRange( list.Count / 2, (list.Count + 1) / 2));
        
        // Conquer
        List<List<object>> sortedList = new List<List<object>>();
        int indexA = 0, indexB = 0;
        for (; indexA < listA.Count && indexB < listB.Count;)
        {
            // If list ended, add rest of values
            int c = CompareLists(listA[indexA], listB[indexB]);
            switch (c)
            {
                case -1: sortedList.Add(listB[indexB]);
                    indexB++;
                    break;
                case 1: sortedList.Add(listA[indexA]);
                    indexA++;
                    break;
                default: sortedList.Add(listA[indexA]);
                    indexA++;
                    break;
            }
        }
        if (indexA < listA.Count) sortedList.AddRange(listA.GetRange(indexA, listA.Count - indexA));
        else if (indexB < listB.Count) sortedList.AddRange(listB.GetRange(indexB, listB.Count - indexB));

        return sortedList;
    }

    private bool CheckPackets(string firstPacket, string secondPacket)
    {
        // Parse Input to Lists with Lists or integers
        List<object> firstPacketList = ParsePacket(firstPacket);
        List<object> secondPacketList = ParsePacket(secondPacket);

        // Compare both Lists
        switch (CompareLists(firstPacketList, secondPacketList))
        {
            case -1: return false;
            case 1: return true;
            default: return true;
        }
    }

    private int CompareLists(List<object> a, List<object> b)
    {
        // Check if either or both Lists are empty
        if (a.Count < 1 && b.Count < 1) return 0;
        if (a.Count < 1) return 1;
        if (b.Count < 1) return -1;
        
        // Iterate through both lists
        for (int listIndex = 0; listIndex < a.Count && listIndex < b.Count; listIndex++)
        {
            Type aType = a[listIndex].GetType();
            Type bType = b[listIndex].GetType();

            if (aType == typeof(List<object>) && bType == typeof(List<object>))
            {
                // Compare next Lists
                int c = CompareLists(a[listIndex] as List<object>, b[listIndex] as List<object>);
                if (c != 0) return c;
            }

            else if (aType == typeof(Int32) && bType == typeof(Int32))
            {
                // Compare both int
                int c = Compare(Int32.Parse(a[listIndex].ToString()), Int32.Parse(b[listIndex].ToString()));
                if (c != 0) return c;
            }
            else
            {
                // Find int and put it into a list
                if (aType == typeof(Int32))
                {
                    List<object> newList = new List<object>();
                    newList.Add(Int32.Parse(a[listIndex].ToString()));
                    int c = CompareLists(newList, b[listIndex] as List<object>);
                    if (c != 0) return c;
                }
                else
                {
                    List<object> newList = new List<object>();
                    newList.Add(Int32.Parse(b[listIndex].ToString()));
                    int c = CompareLists(a[listIndex] as List<object>, newList);
                    if (c != 0) return c;
                }
            }
        }

        if (a.Count < b.Count) return 1;
        if (b.Count < a.Count) return -1;

        return 0;
    }
    

    private List<object> ParsePacket(string packet)
    {
        List<object> packetList = new List<object>();
        List<object> currentList = packetList;
        
        Stack<List<object>> listStack = new Stack<List<object>>();
        listStack.Push(currentList);

        bool skip = false;

        for (int currentCharIndex = 1; currentCharIndex < packet.Length - 1; currentCharIndex++)
        {
            if (skip)
            {
                skip = false;
                continue;
            }
            
            // Iterate through packet [[][[2][][3]]
            switch (packet.ToCharArray()[currentCharIndex])
            {
                case '[':
                    List<object> newList = new List<object>(); // Create new List
                    currentList.Add(newList);
                    listStack.Push(currentList);
                    currentList = newList; // Set current List to newly created one
                    break;
                case ',': break;
                case ']':
                    currentList = listStack.Peek();
                    listStack.Pop();
                    break;
                default:
                    if (currentCharIndex + 1 < packet.ToCharArray().Length && packet.ToCharArray()[currentCharIndex + 1] != ','
                                                                           && packet.ToCharArray()[currentCharIndex + 1] != ']')
                    {
                        currentList.Add(Int32.Parse(packet.ToCharArray()[currentCharIndex].ToString() + packet.ToCharArray()[currentCharIndex + 1].ToString())); // Think about 10
                        skip = true;
                        break;
                    }
                    currentList.Add(Int32.Parse(packet.ToCharArray()[currentCharIndex].ToString()));
                    break;
            }
        }

        return packetList;
    }

    private int Compare(int a, int b)
    {
        if (a < b) return 1; // sorted correctly
        if (b < a) return -1; // sorted incorrectly
        return 0; // Same value, continue
    }
}