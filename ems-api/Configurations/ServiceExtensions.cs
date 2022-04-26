using System.Text;
using ems_api.Database;
using ems_api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace ems_api.Configurations;

public static class ServiceExtensions {
    public static void ConfigureIdentity(this IServiceCollection services) {
        var builder = services
            .AddIdentityCore<User>(u => u.User.RequireUniqueEmail = true);

        builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
        builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
    }

    public static void ConfigureCors(this IServiceCollection services) {
        services.AddCors(options => {
            options.AddPolicy("CorsPolicyAllowAll",
                policy => {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
    }

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

    public static void ConfigureExceptionHandler(this IApplicationBuilder app) {
        app.UseExceptionHandler(error => {
            error.Run(async context => {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null) {
                    Log.Error($"Error in {contextFeature.Error}");
                    await context.Response.WriteAsync(new Error {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal server error"
                    }.ToString());
                }
            });
        });
    }
}