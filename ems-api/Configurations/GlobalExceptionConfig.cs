using ems_api.Models;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;

namespace ems_api.Configurations; 

public static class GlobalExceptionConfig {
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