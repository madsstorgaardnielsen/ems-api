using ems_api.Security;

namespace ems_api.Database.Models;

public class ApplicationDbContext : DbContext {
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
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<WorkdayEntity> Workdays { get; set; }
}