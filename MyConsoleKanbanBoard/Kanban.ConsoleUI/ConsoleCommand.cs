using System;

namespace Kanban.ConsoleUI;

public class ConsoleCommand
{
    public string Title { get; init; }
    
    public ConsoleKey CommandKey { get; init; }

    public virtual void Execute()
    {
        
    }
}

public class CreateTaskCommand : ConsoleCommand
{
    public string Title => "Create a task";
    public ConsoleKey CommandKey => ConsoleKey.A;
    public override void Execute()
    {
        Console.WriteLine();
    }
}