﻿
using AdventOfCodeAdventure.Day_01;
using AdventOfCodeAdventure.Day_02;

namespace AdventOfCodeAdventure
{
    public class EntryPoint
    {
        static void Main(string[] args)
        {
            // Day 01 - Find Elf with most Calories
            // GluttonousElf gluttonousElf = new GluttonousElf();
            // System.Console.WriteLine(gluttonousElf.FindMostCalories());
            
            // Day 02 - Rock Paper Scissors
            RockPaperScissors rockPaperScissors = new RockPaperScissors();
            System.Console.WriteLine(rockPaperScissors.CalculateStrategyGuide());
            System.Console.WriteLine("Real Strategy Guide: " + rockPaperScissors.CalculateRealStrategyGuide());
        }
    }
}