namespace ems_api.Database.IRepository; 

public interface IUnitOfWork : IDisposable{
    IGenericRepository<User> Users { get; }
    IGenericRepository<Workday> Workdays { get; }
    Task Save();
}