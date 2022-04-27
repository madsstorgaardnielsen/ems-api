using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace ems_api.Configurations; 

public static class JwtConfig {
    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration) {
        var jwtSettings = configuration
            .GetSection("JwtToken");
        var key = jwtSettings.GetSection("Key").Value; //if in a real world app, the key shouldnt be set in appsettings
        services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                ValidateAudience = false
            };
        });
    }
}