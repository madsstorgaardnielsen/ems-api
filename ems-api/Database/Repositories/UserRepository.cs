namespace ems_api.Database.Repositories;

public class UserRepository : IUserRepository {
    private readonly UserContext _context;

    public UserRepository(UserContext context) {
        _context = context;
    }

    public IEnumerable<UserEntity> GetAllUsers() {
        return _context.Users.ToList();
    }

    public UserEntity GetUserById(int userId) {
        return _context.Users.Find(userId);
    }

    public UserEntity GetUserByEmail(string email) {
        return _context.Users.SingleOrDefault(user => user.Email == email);
    }

    public int AddUser(UserEntity userEntity) {
        int result = -1;

        if (userEntity != null) {
            _context.Users.Add(userEntity);
            _context.SaveChanges();
            result = userEntity.UserId;
        }

        return result;
    }

    public int UpdateUser(UserEntity userEntity) {
        int result = -1;

        if (userEntity != null) {
            _context.Entry(userEntity).State = EntityState.Modified;
            _context.SaveChanges();
            result = userEntity.UserId;
        }

        return result;
    }


    private bool _disposed;

    protected virtual void Dispose(bool disposing) {
        if (!_disposed) {
            if (disposing) {
                _context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose() {
        Dispose(true);

        GC.SuppressFinalize(this);
    }


    public void DeleteUser(int userId) {
        UserEntity userEntity = _context.Users.Find(userId);
        _context.Users.Remove(userEntity);
        _context.SaveChanges();
    }
}