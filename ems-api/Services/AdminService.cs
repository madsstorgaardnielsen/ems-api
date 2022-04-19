using ems_api.Utils;

namespace ems_api.Services;

using Database.Repositories;
using DTOs;
using Security;

public class AdminService {
    private readonly IUserRepository _userRepository;
    private readonly PasswordUtils _pwUtils;
    private readonly AutoMapperUtils _autoMapper;

    public AdminService() {
        _userRepository = new UserRepository(new ApplicationDbContext());
        _pwUtils = new PasswordUtils();
        _autoMapper = new AutoMapperUtils();
    }

    public async Task<int> CreateUser(UserDto userDto) {
        var pwHash = _pwUtils.CreatePasswordHash(userDto.Password);
        userDto.Password = pwHash;
        var entity = _autoMapper.UserDtoToUserEntityMapper(userDto);
        return await _userRepository.CreateUser(entity);
    }

    public async Task<bool> DeleteUser(int userId) {
        return await _userRepository.DeleteUser(userId);
    }
    
    public async Task<UserDtoProjection> GetUserById(int userId) {
        var userEntity = await _userRepository.GetUserById(userId);
        var userDto = _autoMapper.UserEntityToUserDtoMapper(userEntity);
        var userDtoProjection = _autoMapper.UserDtoToUserDtoProjection(userDto);
        return userDtoProjection;
    }

    public async Task<List<UserDtoProjection>> GetAllUsers() {
        var entities = await _userRepository.GetAllUsers();

        var userDtoProjection = from user in entities
            select new UserDtoProjection {
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Phone = user.Phone,
                Role = user.Role,
            };
        
        return userDtoProjection.ToList();
    }

    public async Task<int> UpdateUser(UserDto userDto) {
        var entity = _autoMapper.UserDtoToUserEntityMapper(userDto); 
        var pwHash = _pwUtils.CreatePasswordHash(userDto.Password);
        entity.Password = pwHash;
        return await _userRepository.UpdateUser(entity);
    }
}
//     private readonly EmployeeContext _db;
//
//     public AdminService() {
//         _db = new EmployeeContext();
//         _db.Database.EnsureCreated();
//     }
//
//     public Employee Create(Employee employee) {
//         var result = _db.Employees.Add(employee).Entity;
//         _db.SaveChanges();
//         return result;
//     }
//
//     public Employee Get(int employeeId) {
//         return _db.Employees.Find(employeeId);
//     }
//
//     public Employee Update(Employee employee) {
//         var e = _db.Employees.Find(employee.Id);
//
//         if (e == null) {
//             return null;
//         }
//         
//         _db.Entry(e).CurrentValues.SetValues(employee);
//         _db.SaveChanges();
//         return _db.Employees.Find(employee.Id);
//     }
//
//     public Employee Delete(int id) {
//         var employee = _db.Employees.Find(id);
//         return _db.Employees.Remove(employee!).Entity;
//     }
//
//     public List<Employee> Employees() {
//         return _db.Employees.ToList();
//     }
// }