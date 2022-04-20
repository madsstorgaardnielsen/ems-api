using ems_api.Models.DAOs;

namespace ems_api.Services.Interfaces;

public interface IAdminService {
    Task<string> CreateUser(UserDto userDto);
    Task<bool> DeleteUser(int userId);
    Task<UserDAO> GetUserById(int userId);
    Task<List<UserDAO>> GetAllUsers();
    Task<string> UpdateUser(UserDto userDto);
}