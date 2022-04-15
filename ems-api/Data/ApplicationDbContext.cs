namespace ems_api.Data;

public class EmployeeContext : DbContext {
    public EmployeeContext(DbContextOptions<EmployeeContext> options) :
        base(options) {
    }

    public EmployeeContext() {
    }
    
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        const string connectionString = "Server=localhost;Database=csharpprojdb;User=root;Password=123;";
        optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Employee>(entity => {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.EmployeeEmail).IsRequired();
            entity.Property(e => e.EmployeePassword).IsRequired();
        });
    }
}