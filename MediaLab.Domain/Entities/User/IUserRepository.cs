namespace MediaLab.Domain.Entities.User;

public interface IUserRepository
{
    Task<User?> GetEmailAsync(string email);
    Task<IEnumerable<User>> GetAllUsers();
    Task Add(User user);
    
}