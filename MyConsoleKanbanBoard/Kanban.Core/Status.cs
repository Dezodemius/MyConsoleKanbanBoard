namespace Kanban.Core;

/// <summary>
/// Статусы задач.
/// </summary>
public enum Status
{
    /// <summary>
    /// Можно взят в работу.
    /// </summary>
    ToDo,
    
    /// <summary>
    /// В работе.
    /// </summary>
    InProgress,
    
    /// <summary>
    /// Выполнено.
    /// </summary>
    Done
}