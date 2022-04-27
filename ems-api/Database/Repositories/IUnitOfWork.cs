using ems_api.Database.Models;

namespace ems_api.Database.Repositories;

public interface IUnitOfWork : IDisposable {
    IGenericRepository<User> Users { get; }
    IGenericRepository<Workday> Workdays { get; }
    Task Save();
}