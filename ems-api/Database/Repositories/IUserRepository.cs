

namespace ems_api.Database.Repositories;

public interface IUserRepository : IDisposable {
    IEnumerable<UserEntity> GetAllUsers();
    UserEntity GetUserById(int userId);
    UserEntity GetUserByEmail(string email);
    int AddUser(UserEntity userEntity);
    int UpdateUser(UserEntity userEntity);
    void DeleteUser(int userId);
}