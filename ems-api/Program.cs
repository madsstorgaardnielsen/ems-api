using System.Reflection.Metadata;
using System.Text;
using ems_api.Configurations;
using ems_api.Database;
using ems_api.Database.IRepository;
using ems_api.Database.Repositories;
using ems_api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.ConfigureIdentity();

builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.ConfigureCors();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(typeof(InitMapper));

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer token", new OpenApiSecurityScheme {
        Description = "JWT Auth using Bearer scheme, type: Bearer [space] token, below to authenticate",
        Name = "Auth",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "0auth2",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });
    options.SwaggerDoc("v1", new OpenApiInfo {Title = "Employee Management System API", Version = "v1"});
});

var logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(builder.Configuration)
    .Enrich
    .FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors("CorsPolicyAllowAll");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

try {
    logger.Information("\n");
    logger.Information("\n");
    logger.Information("ems-api is starting");
    app.Run();
}
catch (Exception e) {
    logger.Fatal(e, "ems-api failed to start");
}
finally {
    logger.Information("disposing logger");
    logger.Dispose();
}