using ems_api.Database.Models;
using ems_api.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ems_api.Utils; 

public class PwHasher {

    public string GetPasswordHash(User user, UserDTO userDto) {
        var hasher = new PasswordHasher<User>();
        return hasher.HashPassword(user, userDto.Password);
    }
}