using ems_api.Database.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ems_api.Database;

public class DatabaseContext : IdentityDbContext<User> {
    public DatabaseContext(DbContextOptions<DatabaseContext> options) :
        base(options) {
    }

    public DatabaseContext() {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (optionsBuilder.IsConfigured) return;

        const string appSettings = "appsettings.json";

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(appSettings)
            .Build();

        var connectionString = configuration
            .GetConnectionString("DefaultConnection");

        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder builder) {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new RoleConfiguration());
        builder.ApplyConfiguration(new AdminConfiguration());
        builder.ApplyConfiguration(new AssignAdminRoleConfig());
        
        builder.Entity<Workday>().HasData(
            new Workday {
                WorkdayId = -1,
                UserId = "-1"
            },
            new Workday {
                WorkdayId = -2,
                UserId = "-1"
            }
        );

        // modelBuilder.Entity<UserEntity>().Property(u => u.Firstname).IsRequired().HasMaxLength(255);
    }

    // public override int SaveChanges()
    // {
    //     try
    //     {
    //         return base.SaveChanges();
    //     }
    //     catch (DbEntityValidationException ex)
    //     {
    //         // Retrieve the error messages as a list of strings.
    //         var errorMessages = ex.EntityValidationErrors
    //             .SelectMany(x => x.ValidationErrors)
    //             .Select(x => x.ErrorMessage);
    //
    //         // Join the list to a single string.
    //         var fullErrorMessage = string.Join("; ", errorMessages);
    //
    //         // Combine the original exception message with the new one.
    //         var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);
    //
    //         // Throw a new DbEntityValidationException with the improved exception message.
    //         throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
    //     }
    // }

    // public DbSet<User> Users { get; set; }
    public DbSet<Workday> Workdays { get; set; }
}