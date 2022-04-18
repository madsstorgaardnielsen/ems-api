using ems_api.Database.Repositories;
using ems_api.DTOs;
using ems_api.Security;

namespace ems_api.Services;

//TODO interface
public class UserService {
    private readonly IUserRepository _userRepository;
    private readonly PasswordUtils _pwUtils;
    public UserService() {
        _userRepository = new UserRepository(new UserContext());
        _pwUtils = new PasswordUtils();
    }

    public UserDto AuthenticateUser(LoginRequest loginRequest) {
        var users = _userRepository.GetAllUsers();
        var user = users.SingleOrDefault(u => u.Email == loginRequest.Email);

        if (user != null && _pwUtils.VerifyPasswordHash(loginRequest.Password,user.Password)) {
            var userDto = new UserDto() {Email = user.Email};
            return userDto;
        }
        return null;
    }

    public int AddUser(UserDto user) {
        var pwHash = _pwUtils.CreatePasswordHash(user.Password);
        var userEntity = new UserEntity() {
            Email = user.Email,
            Password = pwHash
        };
        return _userRepository.AddUser(userEntity);
    }
}