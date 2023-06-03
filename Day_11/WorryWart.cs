using System.Collections.Generic;

namespace AdventOfCodeAdventure.Day_11;

public class WorryWart
{
    public int MonkeyBusinessLevel()
    {
        int rounds = 10000;
        
        Monkey monkey0 = new Monkey(new List<long> { 83, 88, 96, 79, 86, 88, 70 }, (x) => x * 5, 11);
        Monkey monkey1 = new Monkey(new List<long> { 59, 63, 98, 85, 68, 72 }, (x) => x * 11, 5);
        Monkey monkey2 = new Monkey(new List<long> { 90, 79, 97, 52, 90, 94, 71, 70 }, (x) => x + 2, 19);
        Monkey monkey3 = new Monkey(new List<long> { 97, 55, 62 }, (x) => x + 5, 13);
        Monkey monkey4 = new Monkey(new List<long> { 74, 54, 94, 76 }, (x) => x * x, 7);
        Monkey monkey5 = new Monkey(new List<long> { 58 }, (x) => x + 4, 17);
        Monkey monkey6 = new Monkey(new List<long> { 66, 63 }, (x) => x + 6, 2);
        Monkey monkey7 = new Monkey(new List<long> { 56, 56, 90, 96, 68 }, (x) => x + 7, 3);
        
        monkey0.AddInterestedMonkey(monkey2);
        monkey0.AddBoredMonkey(monkey3);
        
        monkey1.AddInterestedMonkey(monkey4);
        monkey1.AddBoredMonkey(monkey0);
        
        monkey2.AddInterestedMonkey(monkey5);
        monkey2.AddBoredMonkey(monkey6);
        
        monkey3.AddInterestedMonkey(monkey2);
        monkey3.AddBoredMonkey(monkey6);
        
        monkey4.AddInterestedMonkey(monkey0);
        monkey4.AddBoredMonkey(monkey3);
        
        monkey5.AddInterestedMonkey(monkey7);
        monkey5.AddBoredMonkey(monkey1);
        
        monkey6.AddInterestedMonkey(monkey7);
        monkey6.AddBoredMonkey(monkey5);
        
        monkey7.AddInterestedMonkey(monkey4);
        monkey7.AddBoredMonkey(monkey1);

        Monkey[] monkeys = { monkey0, monkey1, monkey2, monkey3, monkey4, monkey5, monkey6, monkey7 };

        for (int i = 0; i < rounds; i++)
        {
            foreach (Monkey currentMonkey in monkeys)
            {
                while (currentMonkey.GetItemCount() > 0)
                {
                    currentMonkey.InspectItem();
                }
            }
        }

        foreach (Monkey currentMonkey in monkeys)
        {
            System.Console.WriteLine(currentMonkey.GetInspectCount());
        }

        return 0;
    }
}