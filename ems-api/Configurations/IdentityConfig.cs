using ems_api.Database;
using ems_api.Database.Models;
using Microsoft.AspNetCore.Identity;

namespace ems_api.Configurations; 

public static class IdentityConfig {
    public static void ConfigureIdentity(this IServiceCollection services) {
        var builder = services
            .AddIdentityCore<User>(options => { options.User.RequireUniqueEmail = true; });

        builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
        builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();
    }
}