using ems_api.Models.DTOs;

namespace ems_api.Services; 

public interface IAuthService {
    Task<bool> ValidateUser(LoginUserDTO loginUserDto);
    Task<string> CreateToken();


}