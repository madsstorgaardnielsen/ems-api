using System.Security.Cryptography;

namespace ems_api.Security;

public class PasswordUtils {
    public bool VerifyPasswordHash(string password, string passwordHash) {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }

    public string CreatePasswordHash(string password) {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}