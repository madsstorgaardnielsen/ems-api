namespace ems_api.Database.Models;

public class UserContext : DbContext {
    public UserContext(DbContextOptions<UserContext> options) :
        base(options) {
    }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
    //     const string connectionString = "Server=localhost;Database=csharpprojdb;User=root;Password=123;";
    //     optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    // }

    public UserContext() {
    }

    public DbSet<UserEntity> Users { get; set; }
}