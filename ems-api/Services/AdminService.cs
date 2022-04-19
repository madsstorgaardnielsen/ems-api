using ems_api.Database;

namespace ems_api.Services;
using Interfaces;
using Utils;
using Database.Repositories;
using Security;

public class AdminService : IAdminService{
    private readonly IUserRepository _userRepository;
    private readonly PasswordUtils _pwUtils;
    private readonly UserMapperUtil _userMapperUtil;

    public AdminService() {
        _userRepository = new UserRepository(new ApplicationDbContext());
        _pwUtils = new PasswordUtils();
        _userMapperUtil = new UserMapperUtil();
    }

    public async Task<int> CreateUser(UserDto userDto) {
        var pwHash = _pwUtils.CreatePasswordHash(userDto.Password);
        userDto.Password = pwHash;
        var entity = _userMapperUtil.DtoToEntity(userDto);
        return await _userRepository.CreateUser(entity);
    }

    public async Task<bool> DeleteUser(int userId) {
        return await _userRepository.DeleteUser(userId);
    }

    public async Task<UserDtoProjection> GetUserById(int userId) {
        var userEntity = await _userRepository.GetUserById(userId);
        if (userEntity != null) {
            var userDto = _userMapperUtil.EntityToDto(userEntity);
            var userDtoProjection = _userMapperUtil.DtoToDtoProjection(userDto);
            return userDtoProjection;
        }

        return null;
    }

    public async Task<List<UserDtoProjection>> GetAllUsers() {
        var entities = await _userRepository.GetAllUsers();
        var userDtoProjectionList = _userMapperUtil.EntityListToDtoProjectionList(entities);
        return userDtoProjectionList;
    }

    public async Task<int> UpdateUser(UserDto userDto) {
        var entity = _userMapperUtil.DtoToEntity(userDto);
        var pwHash = _pwUtils.CreatePasswordHash(userDto.Password);
        entity.Password = pwHash;
        return await _userRepository.UpdateUser(entity);
    }
}