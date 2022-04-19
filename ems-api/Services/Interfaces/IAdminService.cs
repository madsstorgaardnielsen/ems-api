namespace ems_api.Services.Interfaces;

public interface IAdminService {
    Task<int> CreateUser(UserDto userDto);
    Task<bool> DeleteUser(int userId);
    Task<UserDtoProjection> GetUserById(int userId);
    Task<List<UserDtoProjection>> GetAllUsers();
    Task<int> UpdateUser(UserDto userDto);
}