namespace ems_api.Database.Repositories;

public interface IUserRepository : IDisposable {
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetUserById(int userId);
    Task<string> CreateUser(User user);
    Task<string> UpdateUser(User user);
    Task<bool> DeleteUser(int userId);
}