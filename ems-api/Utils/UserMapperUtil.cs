// using AutoMapper;
// using ems_api.DAOs;
// using ems_api.DTOs;
//
// namespace ems_api.Utils;
//
// public class UserMapperUtil {
//     private readonly Mapper _entityToDto;
//     private readonly Mapper _dtoToEntity;
//     private readonly Mapper _dtoToDAO;
//     private readonly Mapper _entityListToDAOList;
//
//     public UserMapperUtil() {
//         _entityToDto = new Mapper(new MapperConfiguration(cfg =>
//             cfg.CreateMap<User, UserDAO>()));
//
//         _dtoToEntity = new Mapper(new MapperConfiguration(cfg =>
//             cfg.CreateMap<UserDto, User>()));
//
//         _dtoToDAO = new Mapper(new MapperConfiguration(cfg =>
//             cfg.CreateMap<UserDto, UserDAO>()));
//
//         _entityListToDAOList = new Mapper(new MapperConfiguration(cfg =>
//             cfg.CreateMap<IEnumerable<User>, List<UserDAO>>()));
//     }
//
//     public List<UserDAO> EntityListToDtoProjectionList(IEnumerable<User> entities) {
//         return _entityListToDAOList.Map<IEnumerable<User>, List<UserDAO>>(entities);
//     }
//
//     public UserDto EntityToDto(User entity) {
//         return _entityToDto.Map<User, UserDto>(entity);
//     }
//
//     public User DtoToEntity(UserDto dto) {
//         return _dtoToEntity.Map<UserDto, User>(dto);
//     }
//
//     public UserDAO DtoToDtoProjection(UserDto dto) {
//         return _dtoToDAO.Map<UserDto, UserDAO>(dto);
//     }
// }