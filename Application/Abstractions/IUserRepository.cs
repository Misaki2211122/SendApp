namespace Application.Abstractions;

/// <summary>
/// Репозиторий пользователей
/// </summary>
public interface IUserRepository
{
    IUser Get(int userId);
}
