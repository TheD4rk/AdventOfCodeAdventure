using System.Collections.Generic;

namespace AdventOfCodeAdventure.Day_06;

public class DeviceFixer
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_06/DataStream.txt";

    public int GetCharacterCount()
    {
        int charCount = 4;
        
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            char[] dataInput = currentLine.ToCharArray();
            for (int i = 0; i < dataInput.Length; i++)
            {
                char[] packet = new char[4];
                packet[0] = dataInput[i];
                packet[1] = dataInput[i + 1];
                packet[2] = dataInput[i + 2];
                packet[3] = dataInput[i + 3];

                if (CheckPacket(packet)) break;
                
                charCount++;
            }
        }

        return charCount;
    }

    public int GetMessageMarker()
    {
        int charCount = 14;
        
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            char[] dataInput = currentLine.ToCharArray();
            for (int i = 0; i < dataInput.Length; i++)
            {
                char[] packet = new char[14];
                for (int j = 0; j < 14; j++)
                {
                    packet[j] = dataInput[i + j];
                }

                if (CheckBigPacket(packet)) break;
                
                charCount++;
            }
        }

        return charCount;
    }

    private bool CheckPacket(char[] packet)
    {
        if (packet[0] == packet[1] || packet[0] == packet[2] || packet[0] == packet[3]) return false;
        if (packet[1] == packet[2] || packet[1] == packet[3]) return false;
        if (packet[2] == packet[3]) return false;
        return true;
    }
    
    private bool CheckBigPacket(char[] packet)
    {
        List<char> charList = new List<char>();
        foreach (var currentChar in packet)
        {
            if (charList.Contains(currentChar)) return false;
            charList.Add(currentChar);
        }
        return true;
    }
}