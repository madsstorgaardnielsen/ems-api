using ems_api.Models.DTOs;

namespace ems_api.Services; 

public interface IAuthManager {
    Task<bool> ValidateUser(LoginUserDTO loginUserDto);
    Task<string> CreateToken();


}