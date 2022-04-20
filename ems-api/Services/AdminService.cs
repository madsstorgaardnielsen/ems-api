using ems_api.Configurations;
using ems_api.Database;
using ems_api.Database.IRepository;
using ems_api.Models.DAOs;
using Microsoft.AspNetCore.Mvc;

namespace ems_api.Services;

using Interfaces;
using Utils;
using Database.Repositories;
using Security;

public class AdminService {
    private readonly IUserRepository _userRepository;
    private readonly PasswordUtils _pwUtils;

    private readonly InitMapper _mapper;

    public AdminService(IUnitOfWork unitOfWork, ILogger logger, InitMapper mapper) {


        // _userRepository = new UserRepository(new DatabaseContext());
        // _pwUtils = new PasswordUtils();
        // _userMapperUtil = new UserMapperUtil();
    }

    public async Task<IList<UserDAO>> GetAllUsers() {
        // var entities = await _userRepository.GetAllUsers();
        // var userDtoProjectionList = _userMapperUtil.EntityListToDtoProjectionList(entities);
        // return userDtoProjectionList;
     

        return null;
    }

    public async Task<string> CreateUser(UserDto userDto) {
        // var pwHash = _pwUtils.CreatePasswordHash(userDto.Password);
        // userDto.Password = pwHash;
        // var entity = _userMapperUtil.DtoToEntity(userDto);
        // return await _userRepository.CreateUser(entity);
        return null;
    }

    public async Task<bool> DeleteUser(int userId) {
        // return await _userRepository.DeleteUser(userId);
        return false;
    }

    public async Task<UserDAO> GetUserById(int userId) {
        // var userEntity = await _userRepository.GetUserById(userId);
        // if (userEntity != null) {
        //     var userDto = _userMapperUtil.EntityToDto(userEntity);
        //     var userDtoProjection = _userMapperUtil.DtoToDtoProjection(userDto);
        //     return userDtoProjection;
        // }

        return null;
    }


    public async Task<string> UpdateUser(UserDto userDto) {
        // var entity = _userMapperUtil.DtoToEntity(userDto);
        // var pwHash = _pwUtils.CreatePasswordHash(userDto.Password);
        // entity.PasswordHash = pwHash;
        // return await _userRepository.UpdateUser(entity);
        return null;
    }
}