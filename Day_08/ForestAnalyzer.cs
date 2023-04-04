using System;
using System.IO;
using System.Linq;

namespace AdventOfCodeAdventure.Day_08;

public class ForestAnalyzer
{
    private readonly string _filePath = "D:/Repositories/AdventOfCodeAdventure/Day_08/Forest.txt";
    private int[,] forestGrid;

    public int GetVisibleTrees()
    {
        var lineCount = File.ReadLines(_filePath).Count();
        var columnCount = File.ReadLines(_filePath).Take(1).First().Count();
        forestGrid = new int[lineCount, columnCount];
        InitForest();

        int treesVisible = 99 + 99 + 97 + 97;

        for (int i = 1; i < lineCount - 1; i++)
        {
            for (int j = 1; j < columnCount - 1; j++)
            {
                if (VisibleAbove(i,j))
                {
                    treesVisible++;
                    continue;
                }
                if (VisibleRight(i,j))
                {
                    treesVisible++;
                    continue;
                }
                if (VisibleBelow(i,j))
                {
                    treesVisible++;
                    continue;
                }
                if (VisibleLeft(i,j))
                {
                    treesVisible++;
                    continue;
                }
            }
        }

        return treesVisible;
    }

    public int GetHighestScenicScore()
    {
        var lineCount = File.ReadLines(_filePath).Count();
        var columnCount = File.ReadLines(_filePath).Take(1).First().Count();
        forestGrid = new int[lineCount, columnCount];
        InitForest();
        
        int highscore = 0;
        
        for (int i = 1; i < lineCount - 1; i++)
        {
            for (int j = 1; j < columnCount - 1; j++)
            {
                int newScore = ScoreAbove(i, j) * ScoreRight(i, j) * ScoreBelow(i, j) * ScoreLeft(i, j);
                if (newScore > highscore) highscore = newScore;
            }
        }

        return highscore;
    }

    private void InitForest()
    {
        int currentForestLine = 0;
        int currentForestColumn = 0;
        
        // Init forest matrix
        foreach (string currentLine in System.IO.File.ReadLines(_filePath))
        {
            foreach (var tree in currentLine)
            {
                forestGrid[currentForestLine, currentForestColumn] = Int32.Parse(tree.ToString());
                currentForestColumn++;
            }
            currentForestLine++;
            currentForestColumn = 0;
        }
    }

    #region TreeVisibility

    private bool VisibleAbove(int i, int j)
    {
        for (int k = i - 1; k >= 0; k--)
        {
            if (forestGrid[i, j] <= forestGrid[k, j]) return false;
        }

        return true;
    }
    
    private bool VisibleRight(int i, int j)
    {
        for (int k = j + 1; k < forestGrid.GetLength(1); k++)
        {
            if (forestGrid[i, j] <= forestGrid[i, k]) return false;
        }

        return true;
    }
    
    private bool VisibleBelow(int i, int j)
    {
        for (int k = i + 1; k < forestGrid.GetLength(0); k++)
        {
            if (forestGrid[i, j] <= forestGrid[k, j]) return false;
        }

        return true;
    }
    
    private bool VisibleLeft(int i, int j)
    {
        for (int k = j - 1; k >= 0; k--)
        {
            if (forestGrid[i, j] <= forestGrid[i, k]) return false;
        }

        return true;
    }

    #endregion

    #region TreeScore

    private int ScoreAbove(int i, int j)
    {
        int viewDistance = 0;
        for (int k = i - 1; k >= 0; k--)
        {
            viewDistance++;
            if (forestGrid[i, j] <= forestGrid[k, j]) return viewDistance;
        }

        return viewDistance;
    }
    
    private int ScoreRight(int i, int j)
    {
        int viewDistance = 0;
        for (int k = j + 1; k < forestGrid.GetLength(1); k++)
        {
            viewDistance++;
            if (forestGrid[i, j] <= forestGrid[i, k]) return viewDistance;
        }

        return viewDistance;
    }
    
    private int ScoreBelow(int i, int j)
    {
        int viewDistance = 0;
        for (int k = i + 1; k < forestGrid.GetLength(0); k++)
        {
            viewDistance++;
            if (forestGrid[i, j] <= forestGrid[k, j]) return viewDistance;
        }

        return viewDistance;
    }
    
    private int ScoreLeft(int i, int j)
    {
        int viewDistance = 0;
        for (int k = j - 1; k >= 0; k--)
        {
            viewDistance++;
            if (forestGrid[i, j] <= forestGrid[i, k]) return viewDistance;
        }

        return viewDistance;
    }

    #endregion
    
}