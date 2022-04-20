using System.Text;
using ems_api.Configuration;
using ems_api.Configurations;
using ems_api.Database;
using ems_api.Database.IRepository;
using ems_api.Database.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication();

builder.Services.ConfigureIdentity();



builder.Services.ConfigureCors();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(typeof(InitMapper));



var logger = new LoggerConfiguration()
    .ReadFrom
    .Configuration(builder.Configuration)
    .Enrich
    .FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters =
            new TokenValidationParameters {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey =
                    new SymmetricSecurityKey(
                        Encoding
                            .UTF8
                            .GetBytes(builder
                                .Configuration
                                .GetSection("AppSettings:Token")
                                .Value)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
    });

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
// app.UseAuthentication();
// app.UseAuthorization();
app.MapControllers();

try {
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