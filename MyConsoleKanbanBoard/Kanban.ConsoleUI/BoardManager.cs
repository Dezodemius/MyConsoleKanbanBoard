using System;
using System.Collections.Generic;
using System.Linq;
using Kanban.Core;

namespace Kanban.ConsoleUI;

public static class BoardManager
{
    public static void PrintBoard(List<BoardTask> tasks)
    {
        PrintColumnTitles();
        PrintTasks(tasks);
    }
    
    private static void PrintColumnTitles()
    {
        foreach (var statusName in Enum.GetNames<Status>())
        {
            Console.Write($"{statusName}\t");
        }

        Console.WriteLine();
    }
    
    private static void PrintTasks(IEnumerable<BoardTask> tasks)
    {
        if (tasks.Count() == 0)
        {
            Console.WriteLine("\tЗадач пока нет\t");
            return;
        }

        var groupedTasks = tasks
             .GroupBy(task => task.Status)
             .OrderBy(group => group.Key);

        var maxColumns = groupedTasks.Max(grouping => grouping.Count());

        for (int i = 0; i < maxColumns; i++)
        {
            foreach (var groupedTask in groupedTasks)
            {
                var boardTask = groupedTask.ElementAtOrDefault(i);
                if (boardTask == null)
                {
                    Console.Write("\t");
                    continue;
                }
                if (boardTask.Title.Length <= 10)
                    Console.Write(boardTask.Id + ": " + boardTask.Title + "\t");
                else
                {
                    Console.Write(boardTask.Id + ": " + boardTask.Title.Substring(0, 7) + "...\t");
                }
            }

            Console.WriteLine();
        }
    }
}