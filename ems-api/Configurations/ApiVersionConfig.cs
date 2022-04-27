using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace ems_api.Configurations; 

public static class ApiVersionConfig {
    public static void ConfigureAPIVersioning(this IServiceCollection services) {
        services.AddApiVersioning(options => {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
            options.ApiVersionReader = new HeaderApiVersionReader("api-version");
        });
    }
}