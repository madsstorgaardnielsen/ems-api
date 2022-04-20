using ems_api.Database.IRepository;

namespace ems_api.Database.Repositories;

public class UnitOfWork : IUnitOfWork {
    private readonly DatabaseContext _context;
    private IGenericRepository<User> _users;
    private IGenericRepository<Workday> _workdays;

    public UnitOfWork(DatabaseContext context) {
        _context = context;
    }

    public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);
    public IGenericRepository<Workday> Workdays => _workdays ??= new GenericRepository<Workday>(_context);
    
    public async Task Save() {
        await _context.SaveChangesAsync();
    }

    public void Dispose() {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}