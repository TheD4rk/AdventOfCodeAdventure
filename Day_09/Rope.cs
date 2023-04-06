using System;
using System.Collections.Generic;

namespace AdventOfCodeAdventure.Day_09;

public class Rope
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_09/Path.txt";
    
    public int GetPointsVisited()
    {
        List<string> pts = new List<string>();
        int headX = 0, headY = 0, tailX = 0, tailY = 0;
        int[,] tails = InitTails();
        pts.Add("(" + tailX + "|" + tailY + ")");

        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            string[] input = currentLine.Split(" ");
            int moves = Int32.Parse(input[1]);
            for (int i = 0; i < moves; i++)
            {
                switch (input[0])
                {
                    case "U": headY++;
                        break;
                    case "R": headX++;
                        break;
                    case "D": headY--;
                        break;
                    case "L": headX--;
                        break;
                }
                //MoveTail(ref tailX, ref tailY, headX, headY);
                //if (!pts.Contains("(" + tailX + "|" + tailY + ")")) pts.Add("(" + tailX + "|" + tailY + ")");
                
                MoveTail(ref tails[0,0], ref tails[0,1], headX, headY);
                for (int j = 0; j < 8; j++)
                {
                    MoveTail(ref tails[j + 1,0], ref tails[j + 1,1], tails[j,0], tails[j,1]);
                    if (j == 7 && !pts.Contains("(" + tails[8,0] + "|" + tails[8,1] + ")")) pts.Add("(" + tails[8,0] + "|" + tails[8,1] + ")");
                }
            }
        }
        
        return pts.Count;
    }

    private void MoveTail(ref int tailX, ref int tailY, int headX, int headY)
    {
        double c = Math.Sqrt(Math.Pow(headX - tailX, 2));
        double d = Math.Sqrt(Math.Pow(headY - tailY, 2));
        if (c >= 2 && d >= 2)
        {
            tailX += (headX - tailX) / 2;
            tailY += (headY - tailY) / 2;
        }
        else if (c > 1)
        {
            if (Math.Abs(Math.Abs(headY) - Math.Abs(tailY)) >= 1)
            {
                tailY = headY;
            }
            tailX += (headX - tailX) / 2;
        }
        else if (d  > 1)
        {
            if (Math.Abs(Math.Abs(headX) - Math.Abs(tailX)) >= 1)
            {
                tailX = headX;
            }
            tailY += (headY - tailY) / 2;
        }
    }

    private int[,] InitTails()
    {
        int[,] tails = new int[9,2];
        for (int i = 0; i < 9; i++)
        {
            tails[i, 0] = 0;
            tails[i, 1] = 0;
        }

        return tails;
    }
}