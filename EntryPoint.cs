
using AdventOfCodeAdventure.Day_01;

namespace AdventOfCodeAdventure
{
    public class EntryPoint
    {
        static void Main(string[] args)
        {
            // Day 01 - Find Elf with most Calories
            GluttonousElf gluttonousElf = new GluttonousElf();
            System.Console.WriteLine(gluttonousElf.FindMostCalories());
        }
    }
}