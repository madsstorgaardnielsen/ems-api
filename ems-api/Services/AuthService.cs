using ems_api.Database;

namespace ems_api.Services;

using Database.Repositories;
using Security;

public class AuthService {
    private readonly IUserRepository _userRepository;
    private readonly PasswordUtils _pwUtils;

    public AuthService() {
        _userRepository = new UserRepository(new ApplicationDbContext());
        _pwUtils = new PasswordUtils();
    }

    public async Task<UserDto> AuthenticateUser(LoginRequest loginRequest) {
        var users = await _userRepository.GetAllUsers();
        var user = users.SingleOrDefault(u => u.Email == loginRequest.Email);

        if (user == null) return null;

        if (!_pwUtils.VerifyPasswordHash(loginRequest.Password, user.Password)) return null;
        var userDto = new UserDto {Role = user.Role};
        return userDto;
    }
}