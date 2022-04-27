using ems_api.Database.Models;
using ems_api.Database.Repositories;

namespace ems_api.Database.UnitOfWork;

public interface IUnitOfWork : IDisposable {
    IGenericRepository<User> Users { get; }
    IGenericRepository<Workday> Workdays { get; }
    Task Save();
}