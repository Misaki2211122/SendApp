namespace Application.Abstractions;

/// <summary>
/// Сообщение для доставки пользователю
/// </summary>
public interface IMessage
{
    /// <summary>
    /// Идентификатор пользователя, которому надо доставить сообщение
    /// </summary>
    int UserId { get; }
    /// <summary>
    /// Текст сообщения
    /// </summary>
    string MessageText { get; }
}

