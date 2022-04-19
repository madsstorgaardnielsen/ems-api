using AutoMapper;
using ems_api.DTOs;

namespace ems_api.Utils;

public class AutoMapperUtils {
    private readonly Mapper _userEntityToDto;
    private readonly Mapper _userDtoToEntity;
    private readonly Mapper _userDtoToUserDtoProjection;

    public AutoMapperUtils() {
        _userEntityToDto = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<UserEntity, UserDtoProjection>()));

        _userDtoToEntity = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<UserDto, UserEntity>()));
        
        _userDtoToUserDtoProjection = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<UserDto, UserDtoProjection>()));
    }

    public List<UserDtoProjection> UserEntityListToUserDtoProjectionListMapper(IEnumerable<UserEntity> entities) {
        return _userEntityToDto.Map<IEnumerable<UserEntity>, List<UserDtoProjection>>(entities);
    }

    public UserDto UserEntityToUserDtoMapper(UserEntity entity) {
        return _userEntityToDto.Map<UserEntity, UserDto>(entity);
    }

    public UserEntity UserDtoToUserEntityMapper(UserDto dto) {
        return _userDtoToEntity.Map<UserDto, UserEntity>(dto);
    }

    public UserDtoProjection UserDtoToUserDtoProjection(UserDto dto) {
        return _userDtoToUserDtoProjection.Map<UserDto, UserDtoProjection>(dto);
    }
}