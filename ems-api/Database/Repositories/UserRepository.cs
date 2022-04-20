namespace ems_api.Database.Repositories;

public class UserRepository : IUserRepository {
    private readonly DatabaseContext _database;

    public UserRepository(DatabaseContext context) {
        _database = context;
    }

    public async Task<IEnumerable<User>> GetAllUsers() {
        return await _database.Users.ToListAsync();
    }

    public async Task<User> GetUserById(int userId) {
        var entity = await _database.Users.FindAsync(userId);
        return entity ?? null;
    }

    public async Task<string> CreateUser(User user) {
        if (user == null) return "";
        _database.Users.Add(user);
        await _database.SaveChangesAsync();
        return user.Id;
    }

    public async Task<string> UpdateUser(User user) {
        var u = await _database.Users.SingleOrDefaultAsync(u => u.Id == user.Id);
        if (u == null) return "";

        _database.Entry(u).CurrentValues.SetValues(user);
        await _database.SaveChangesAsync();
        return u.Id;
    }

    public async Task<bool> DeleteUser(int userId) {
        var userEntity = await _database.Users.FindAsync(userId);
        if (userEntity == null) return false;
        userEntity.Deleted = true;
        _database.Entry(userEntity);
        await _database.SaveChangesAsync();
        return true;
    }

    private bool _disposed;

    protected virtual void Dispose(bool disposing) {
        if (!_disposed) {
            if (disposing) {
                _database.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose() {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}