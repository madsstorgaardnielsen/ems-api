using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ems_api.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace ems_api.Utils; 

public class TokenUtils {
    
    private readonly IConfiguration _configuration;

    public TokenUtils(IConfiguration configuration) {
        _configuration = configuration;
    }
    
    
    public string CreateToken(UserDto user) {
        var claims = new List<Claim> {
            // new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, user.Role),
        };

        var key = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(claims: claims, expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials);

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        
        return jwt;
    }
}