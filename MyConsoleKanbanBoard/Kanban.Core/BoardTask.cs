using System;

namespace Kanban.Core;

/// <summary>
/// Задача на канбан-доске.
/// </summary>
public class BoardTask
{
    /// <summary>
    /// Номер задачи.
    /// </summary>
    public int Id { get; init; }

    /// <summary>
    /// Заголовок задачи.
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Описание задачи.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Статус задачи.
    /// </summary>
    public Status Status { get; set; }
    
    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreatedOn { get; init; }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="id">Номер задачи.</param>
    /// <param name="title">Заголовок задачи.</param>
    /// <param name="description">Описание задачи.</param>
    /// <param name="status">Статус задачи.</param>
    internal BoardTask(int id, string title, string description, Status status)
    {
        this.Id = id;
        this.Title = title;
        this.Description = description;
        this.Status = status;
        this.CreatedOn = DateTime.Now;
    }
}