namespace ems_api.Database.Repositories;

public interface IUserRepository : IDisposable {
    Task<IEnumerable<UserEntity>> GetAllUsers();
    Task<UserEntity> GetUserById(int userId);
    Task<int> CreateUser(UserEntity userEntity);
    Task<int> UpdateUser(UserEntity userEntity);
    Task<bool> DeleteUser(int userId);
}