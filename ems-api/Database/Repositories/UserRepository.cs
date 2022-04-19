using ems_api.DTOs;

namespace ems_api.Database.Repositories;

public class UserRepository : IUserRepository {
    private readonly ApplicationDbContext _database;

    public UserRepository(ApplicationDbContext context) {
        _database = context;
    }

    public async Task<IEnumerable<UserEntity>> GetAllUsers() {
        return await _database.Users.ToListAsync();
    }

    public async Task<UserEntity> GetUserById(int userId) {
        var entity = await _database.Users.FindAsync(userId);
        return entity ?? null;
    }

    public async Task<int> CreateUser(UserEntity userEntity) {
        if (userEntity == null) return -1;
        _database.Users.Add(userEntity);
        await _database.SaveChangesAsync();
        return userEntity.UserId;
    }

    public async Task<int> UpdateUser(UserEntity userEntity) {
        var user = await _database.Users.SingleOrDefaultAsync(user => user.UserId == userEntity.UserId);
        if (user == null) return -1;

        _database.Entry(user).CurrentValues.SetValues(userEntity);
        await _database.SaveChangesAsync();
        return user.UserId;
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