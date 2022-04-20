using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ems_api.Database;

using Security;

public class ApplicationDbContext : IdentityDbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
        base(options) {
    }

    public ApplicationDbContext() {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        if (optionsBuilder.IsConfigured) return;

        const string appSettings = "appsettings.json";

        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(appSettings)
            .Build();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        var pwUtils = new PasswordUtils();
        var pwHash = pwUtils.CreatePasswordHash("Admin");

        modelBuilder.Entity<UserEntity>().HasData(new UserEntity {
            UserId = -1,
            Email = "Admin",
            Password = pwHash,
            Role = "Admin",
            Address = "Admin",
            Cpr = "0000000000",
            Firstname = "Admin",
            Lastname = "Admin",
            Phone = "00000000",
            Deleted = false,
            Created = DateTime.Now
        });

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

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<WorkdayEntity> Workdays { get; set; }
}