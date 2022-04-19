namespace ems_api.Services.Interfaces; 

public interface IAuthService {
    Task<UserDto> AuthenticateUser(LoginRequest loginRequest);
}