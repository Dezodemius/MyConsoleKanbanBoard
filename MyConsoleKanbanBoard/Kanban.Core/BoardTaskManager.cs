using System;
using System.Collections.Generic;
using System.Linq;

namespace Kanban.Core;

/// <summary>
/// Точка входа в управление задачами на доске.
/// </summary>
public static class BoardTaskManager
{
    /// <summary>
    /// Хранимые задачи.
    /// </summary>
    private static List<BoardTask> _tasks = [];
    
    /// <summary>
    /// Создать задачу.
    /// </summary>
    /// <param name="title">Заголовок задачи.</param>
    /// <param name="description">Описание задачи.</param>
    /// <param name="status">Статус задачи. По умолчанию создаётся со статусом <see cref="Status.ToDo"/>.</param>
    /// <returns>Созданная и сохранённая задача.</returns>
    public static BoardTask CreateTask(string title, string description, Status status = Status.ToDo)
    {
        var newId = GetNewTaskId();
        
        var task = new BoardTask(newId, title, description, status);
        _tasks.Add(task);

        return task;
    }
    
    /// <summary>
    /// Получить все задачи.
    /// </summary>
    /// <returns>Список всех задач.</returns>
    public static List<BoardTask> GetAll()
    {
        return _tasks;
    }

    /// <summary>
    /// Получить задачу по номеру задачи.
    /// </summary>
    /// <param name="id">Номер задачи.</param>
    /// <returns>Найденная задача.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Возникает, если задача, которую хотелось обновить не найдена.</exception>
    public static BoardTask GetTask(int id)
    {
        var task = _tasks.SingleOrDefault(t => t.Id == id);
        if (task == null)
            throw new ArgumentOutOfRangeException($"Задача c id '{id}' не найдена");
        
        return task;
    }

    /// <summary>
    /// Удалить задачу.
    /// </summary>
    /// <param name="id">Номер задачи.</param>
    /// <remarks>Удаление произойдет только если задача нашлась.</remarks>
    public static void DeleteTask(int id)
    {
        var task = GetTask(id);
        _tasks.Remove(task);
    }

    /// <summary>
    /// Обновить заголовок задачи.
    /// </summary>
    /// <param name="id">Номер задачи.</param>
    /// <param name="newTitle">Новый заголовок.</param>
    public static void UpdateTaskTitle(int id, string newTitle)
    {
        var task = GetTask(id);
        task.Title = newTitle;
    }

    /// <summary>
    /// Обновить описание задачи.
    /// </summary>
    /// <param name="id">Номер задачи.</param>
    /// <param name="newDescription">Новое описание задачи.</param>
    public static void UpdateTaskDescription(int id, string newDescription)
    {
        var task = GetTask(id);
        task.Description = newDescription;
    }

    /// <summary>
    /// Обновить статус задачи.
    /// </summary>
    /// <param name="id">Номер задачи.</param>
    /// <param name="newStatus">Новый статус.</param>
    public static void UpdateTaskStatus(int id, Status newStatus)
    {
        var task = GetTask(id);
        task.Status = newStatus;
    }

    /// <summary>
    /// Получить номер очередной задачи.
    /// </summary>
    /// <returns>Номер очередной задачи.</returns>
    private static int GetNewTaskId()
    {
        if (_tasks.Count != 0)
            return _tasks.Max(t => t.Id) + 1;
        
        return 1;
    }
}