using System;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCodeAdventure.Day_14;

public class FallingSand
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_14/Scan.txt";
    private List<Point> _caveSystem = new List<Point>();
    private bool _reachedAbyss = false;
    private int bedrockLayer = 0;

    public void InitCave()
    {
        int deepestYCoordinate = 0;
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            string[] input = currentLine.Split(" -> ");

            for (int i = 0; i < input.Length - 1; i++)
            {
                string[] pointA = input[i].Split(",");
                string[] pointB = input[i + 1].Split(",");
                Point a = new Point(Int32.Parse(pointA[0]), Int32.Parse(pointA[1]));
                Point b = new Point(Int32.Parse(pointB[0]), Int32.Parse(pointB[1]));

                if (deepestYCoordinate < a.Y) deepestYCoordinate = a.Y;
                if (deepestYCoordinate < b.Y) deepestYCoordinate = b.Y;
                

                AddRange(a, b);
            }
        }

        bedrockLayer = deepestYCoordinate + 2;
        System.Console.WriteLine("Deepest Y Coordinate is: " + deepestYCoordinate);
        System.Console.WriteLine("Therefore Bedrock can be found at: " + bedrockLayer);
        AddBedrock();
    }

    // Part 2
    private void AddBedrock()
    {
        for (int i = 0; i < 2000; i++)
        {
            AddBlock(new Point(i, bedrockLayer));
        }
        System.Console.WriteLine("Finished building Bedrock!");
    }

    public int DropSand()
    {
        InitCave();

        int sandAmount = 0; // subtract 1 for the sand that reaches the abyss in Part 1!

        for (; sandAmount < 99999; sandAmount++)
        {
            if (_reachedAbyss) return sandAmount;
            AddBlock(Fall(new Point(500, 0)));
        }
        
        System.Console.WriteLine("More than a million Sand!");

        return sandAmount;
    }

    private Point Fall(Point sandPoint)
    {
        // Part 1
        if (sandPoint.Y >= 200)
        {
            System.Console.WriteLine("Bedrock not enough");
            _reachedAbyss = true;
            return sandPoint;
        }
        
        // Part 2
        if (_caveSystem.Contains(new Point(501, 1)))
        {
            _reachedAbyss = true;
            return sandPoint;
        }
        
        
        // Fall 1 step vertical
        if (!_caveSystem.Contains(new Point(sandPoint.X, sandPoint.Y + 1)))
        {
            return Fall(new Point(sandPoint.X, sandPoint.Y + 1));
        }
        else if (!_caveSystem.Contains(new Point(sandPoint.X - 1, sandPoint.Y + 1))) // Fall 1 step left diagonal
        {
            return Fall(new Point(sandPoint.X - 1, sandPoint.Y + 1));
        }
        else if (!_caveSystem.Contains(new Point(sandPoint.X + 1, sandPoint.Y + 1))) // Fall 1 step right diagonal
        {
            return Fall(new Point(sandPoint.X + 1, sandPoint.Y + 1));
        } 

        // Nowhere to Fall, place sand
        return sandPoint;
    }

    private void AddRange(Point a, Point b)
    {
        if (a.X != b.X)
        {
            if (a.X < b.X)
            {
                // a.X is smaller than b.X, so keep adding every x including up to b 
                for (int i = a.X; i <= b.X; i++)
                {
                    AddBlock(new Point(i,a.Y));
                }

                return;
            }
            
            // b.X is bigger than a.X, so keep adding every x including up to a
            for (int i = b.X; i <= a.X; i++)
            {
                AddBlock(new Point(i, a.Y));
            }

            return;
        }

        if (a.Y < b.Y)
        {
            // a.X is smaller than b.X, so keep adding every x including up to b 
            for (int i = a.Y; i <= b.Y; i++)
            {
                AddBlock(new Point(a.X, i));
            }

            return;
        }
        
        // a.X is smaller than b.X, so keep adding every x including up to b 
        for (int i = b.Y; i <= a.Y; i++)
        {
            AddBlock(new Point(a.X, i));
        }
    }

    private void AddBlock(Point point)
    {
        //System.Console.WriteLine("Trying to Add Point: (" + point.X + "|" + point.Y + ")");
        if (_caveSystem.Contains(point)) return;
        _caveSystem.Add(point);
    }
}