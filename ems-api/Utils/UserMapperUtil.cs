using AutoMapper;
using ems_api.DTOs;

namespace ems_api.Utils;

public class UserMapperUtil {
    private readonly Mapper _entityToDto;
    private readonly Mapper _dtoToEntity;
    private readonly Mapper _dtoToDtoProjection;
    private readonly Mapper _entityListToDtoProjectionList;

    public UserMapperUtil() {
        _entityToDto = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<UserEntity, UserDtoProjection>()));

        _dtoToEntity = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<UserDto, UserEntity>()));

        _dtoToDtoProjection = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<UserDto, UserDtoProjection>()));

        _entityListToDtoProjectionList = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<IEnumerable<UserEntity>, List<UserDtoProjection>>()));
    }

    public List<UserDtoProjection> EntityListToDtoProjectionList(IEnumerable<UserEntity> entities) {
        return _entityListToDtoProjectionList.Map<IEnumerable<UserEntity>, List<UserDtoProjection>>(entities);
    }

    public UserDto EntityToDto(UserEntity entity) {
        return _entityToDto.Map<UserEntity, UserDto>(entity);
    }

    public UserEntity DtoToEntity(UserDto dto) {
        return _dtoToEntity.Map<UserDto, UserEntity>(dto);
    }

    public UserDtoProjection DtoToDtoProjection(UserDto dto) {
        return _dtoToDtoProjection.Map<UserDto, UserDtoProjection>(dto);
    }
}