using System;
using System.Collections.Generic;
using Kanban.Core;

namespace Kanban.ConsoleUI;

class Program
{
    static void Main(string[] args)
    {
        var commands = new List<ConsoleCommand>
        {
            new CreateTaskCommand()
        };
        ConsoleKey userPressedKey;
        do
        {
            Console.Clear();
            BoardManager.PrintBoard(BoardTaskManager.GetAll());
            Console.WriteLine();
            PrintMainMenu();

            userPressedKey = Console.ReadKey(true).Key;
            
            switch (userPressedKey)
            {
                case ConsoleKey.D1:
                    CreateTask();
                    break;
                case ConsoleKey.D2:
                    DeleteTask();
                    break;
                case ConsoleKey.D3:
                    OpenTask();
                    break;
                case ConsoleKey.D4:
                    UpdateTask();
                    break;
                case ConsoleKey.D5:
                    MoveTaskInToDo();
                    break;
                case ConsoleKey.D6:
                    MoveTaskToInProgress();
                    break;
                case ConsoleKey.D7:
                    MoveTaskToDone();
                    break;
                default:
                    Console.WriteLine("Ввод неверен");
                    break;
            }
        } while (userPressedKey != ConsoleKey.Escape);

        Console.WriteLine("Пока!");
    }

    private static void MoveTaskToDone()
    {
        Console.Write("Введите номер задачи: ");
        var id = int.Parse(Console.ReadLine());
        
        BoardTaskManager.UpdateTaskStatus(id, Status.Done);
    }

    private static void MoveTaskToInProgress()
    {
        Console.Write("Введите номер задачи: ");
        var id = int.Parse(Console.ReadLine());
        
        BoardTaskManager.UpdateTaskStatus(id, Status.InProgress);
    }

    private static void MoveTaskInToDo()
    {
        Console.Write("Введите номер задачи: ");
        var id = int.Parse(Console.ReadLine());
        
        BoardTaskManager.UpdateTaskStatus(id, Status.ToDo);
    }

    private static void UpdateTask()
    {
        Console.Write("Введите номер задачи: ");
        var id = int.Parse(Console.ReadLine());

        Console.Write("Введите заголовок задачи: ");
        var title = Console.ReadLine();
        BoardTaskManager.UpdateTaskTitle(id, title);

        Console.Write("Введите описание задачи: ");
        var description = Console.ReadLine();
        BoardTaskManager.UpdateTaskDescription(id, description);
    }

    private static void OpenTask()
    {
        Console.Write("Введите номер задачи: ");
        var id = int.Parse(Console.ReadLine());
        
        var task = BoardTaskManager.GetTask(id);

        Console.WriteLine($"Номер: {task.Id}");
        Console.WriteLine($"Дата создания: {task.CreatedOn}");
        Console.WriteLine($"Статус: {task.Status}");
        Console.WriteLine();
        Console.WriteLine($"{task.Title}");
        Console.WriteLine($"Описание: {task.Description}");
    }

    private static void DeleteTask()
    {
        Console.Write("Введите номер задачи: ");
        var id = int.Parse(Console.ReadLine());
        
        BoardTaskManager.DeleteTask(id);
    }

    private static void CreateTask()
    {
        Console.Write("Введите заголовок задачи: ");
        var title = Console.ReadLine();
        Console.Write("Введите описание задачи: ");
        var description = Console.ReadLine();
        
        BoardTaskManager.CreateTask(title, description);
    }

    private static void PrintMainMenu()
    {
        Console.WriteLine("1. Создать задачу\n" +
                          "2. Удалить задачу\n" +
                          "3. Открыть задачу\n" +
                          "4. Изменить задачу\n" +
                          "5. Перевести задачу в ToDo\n" +
                          "6. Перевести задачу в InProgress\n" +
                          "7. Перевести задачу в Done\n");
        Console.WriteLine("Выберите вариант: ");
    }
}