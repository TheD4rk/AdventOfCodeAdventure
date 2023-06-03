using System;
using System.Collections.Generic;

namespace AdventOfCodeAdventure.Day_11;

public class Monkey
{
    public Monkey(List<long> startingItems, Func<long, long> inspectOperation, long dividableByTest)
    {
        items = startingItems;
        operation = inspectOperation;
        dividableBy = dividableByTest;
    }

    private List<long> items;
    private Func<long, long> operation;
    private long dividableBy;
    private Monkey interestedMonkey;
    private Monkey boredMonkey;
    private long inspectionCount = 0;
    
    public void InspectItem()
    {
        inspectionCount++;
        items[0] = operation(items[0]);
        items[0] %= 9699690;
        if (items[0] % dividableBy == 0)
        {
            interestedMonkey.AddItem(items[0]);
        }
        else
        {
            boredMonkey.AddItem(items[0]);
        }
        RemoveItem();
    }

    public void AddItem(long newItem)
    {
        items.Add(newItem);
    }

    public void RemoveItem()
    {
        items.RemoveAt(0);
    }

    public void AddInterestedMonkey(Monkey newMonkey)
    {
        interestedMonkey = newMonkey;
    }
    
    public void AddBoredMonkey(Monkey newMonkey)
    {
        boredMonkey = newMonkey;
    }

    public long GetItemCount()
    {
        return items.Count;
    }

    public long GetInspectCount()
    {
        return inspectionCount;
    }
}