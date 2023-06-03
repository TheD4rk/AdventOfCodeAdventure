using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace AdventOfCodeAdventure.Day_12;

public class Pathfinder
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_12/Heightmap.txt";
    private int[,] heightmap;
    private Point startPositon, endPosition;
    private int leastStepsTaken = 9999999;
    private Dictionary<Point, int> walkedPoints;

    public int CalculateSteps()
    {
        InitHeightmap();
        walkedPoints = new Dictionary<Point, int>();
        CalculatePossiblePath(startPositon, new List<Point>(), 0);
        return leastStepsTaken;
    }

    public int FindBestStartingSpot()
    {
        InitHeightmap();
        walkedPoints = new Dictionary<Point, int>();
        
        for (int row = 0; row < File.ReadLines(_filePath).Count(); row++)
        {
            for (int column = 0; column < File.ReadLines(_filePath).First().Length; column++)
            {
                if (heightmap[row, column] == 1)
                {
                    Point newStartingPoint = new Point(column, row);
                    System.Console.WriteLine("New Starting Point: (" + newStartingPoint.X + "|" + newStartingPoint.Y + ")");
                    CalculatePossiblePath(newStartingPoint, new List<Point>(), 0);
                }
            }
        }

        return leastStepsTaken;
    }

    private void InitHeightmap()
    {
        int lineAmount = File.ReadLines(_filePath).Count();
        int lineLength = File.ReadLines(_filePath).First().Length;

        heightmap = new int[lineAmount, lineLength];

        int currentRow = 0;

        // Init heightmap with int values instead of chars from a-z
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            int currentColumn = 0;
            foreach (char currentChar in currentLine)
            {
                // Check for starting Position
                if (currentChar.Equals('S'))
                {
                    startPositon = new Point(currentColumn, currentRow);
                    heightmap[currentRow, currentColumn] = 1;
                    currentColumn++;
                    continue;
                }
                // Check for end Position
                if (currentChar.Equals('E'))
                {
                    endPosition = new Point(currentColumn, currentRow);
                    heightmap[currentRow, currentColumn] = 26;
                    currentColumn++;
                    continue;
                }
                
                heightmap[currentRow, currentColumn] = char.ToUpper(currentChar) - 64;
                    
                currentColumn++;
            }
            currentRow++;
        }
        
        System.Console.WriteLine("Starting Positon is: " + startPositon.X + "|" + startPositon.Y);
        System.Console.WriteLine("End Positon is: " + endPosition.X + "|" + endPosition.Y);
    }

    private int CalculatePossiblePath(Point startPoint, List<Point> pointsVisited, int stepsTaken)
    {
        //System.Console.WriteLine("Visit Position: (" + startPoint.X + "|" + startPoint.Y + ") - Steps taken: " +stepsTaken);
        //if (startPoint.X == 0 && startPoint.Y == 0)
        //{
        //    System.Console.WriteLine();
        //}
        
        pointsVisited.Add(startPoint);
        if (walkedPoints.ContainsKey(startPoint)) walkedPoints[startPoint] = stepsTaken;
        else walkedPoints.Add(startPoint, stepsTaken);

        if (GoalReached(startPoint))
        {
            if (stepsTaken < leastStepsTaken)
            {
                System.Console.WriteLine("Steps to reach goal: " + stepsTaken);
                leastStepsTaken = stepsTaken;
            }
            pointsVisited.RemoveAt(pointsVisited.Count - 1);
            return --stepsTaken;
        }
        
        // North
        Point newPoint = new Point(startPoint.X, startPoint.Y + 1);
        if (PointInBounds(newPoint) && !PointVisited(newPoint, pointsVisited) &&
            ElevationHigherEqual(startPoint, newPoint) && WayShorter(newPoint, stepsTaken)) stepsTaken = CalculatePossiblePath(newPoint, pointsVisited, ++stepsTaken);

        // East
        newPoint = new Point(startPoint.X + 1, startPoint.Y);
        if (PointInBounds(newPoint) && !PointVisited(newPoint, pointsVisited) &&
            ElevationHigherEqual(startPoint, newPoint) && WayShorter(newPoint, stepsTaken)) stepsTaken = CalculatePossiblePath(newPoint, pointsVisited, ++stepsTaken);

        // South
        newPoint = new Point(startPoint.X, startPoint.Y - 1);
        if (PointInBounds(newPoint) && !PointVisited(newPoint, pointsVisited) &&
            ElevationHigherEqual(startPoint, newPoint) && WayShorter(newPoint, stepsTaken)) stepsTaken = CalculatePossiblePath(newPoint, pointsVisited, ++stepsTaken);

        // West
        newPoint = new Point(startPoint.X - 1, startPoint.Y);
        if (PointInBounds(newPoint) && !PointVisited(newPoint, pointsVisited) &&
            ElevationHigherEqual(startPoint, newPoint) && WayShorter(newPoint, stepsTaken)) stepsTaken = CalculatePossiblePath(newPoint, pointsVisited, ++stepsTaken);

        pointsVisited.RemoveAt(pointsVisited.Count - 1);
        return --stepsTaken;
    }

    // Check point in Bounds of heightmap
    private bool PointInBounds(Point point)
    {
        if (point.Y < 0 || point.Y > heightmap.GetLength(0) - 1) return false;
        if (point.X < 0 || point.X > heightmap.GetLength(1) - 1) return false;
        return true;
    }

    // Check point already visited
    private bool PointVisited(Point point, List<Point> pointsVisited)
    {
        return pointsVisited.Contains(point);
    }

    // Check Elevation equal or +1 than current Point
    private bool ElevationHigherEqual(Point currentPoint, Point newPoint)
    {
        return (heightmap[currentPoint.Y, currentPoint.X] >= heightmap[newPoint.Y, newPoint.X] - 1);
    }

    private bool WayShorter(Point newPoint, int currentSteps)
    {
        if (!walkedPoints.ContainsKey(newPoint)) return true;
        return currentSteps + 1 < walkedPoints[newPoint];
    }

    private bool GoalReached(Point currentPoint)
    {
        
        return currentPoint.Equals(endPosition);
    }
}