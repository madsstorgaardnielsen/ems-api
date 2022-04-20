// using AutoMapper;
//
// namespace ems_api.Utils;
//
// public class WorkdayMapperUtil {
//     private readonly Mapper _dtoToEntity;
//     private readonly Mapper _entityToDto;
//
//     public WorkdayMapperUtil() {
//         _entityToDto = new Mapper(new MapperConfiguration(cfg =>
//             cfg.CreateMap<Workday, WorkdayDto>()));
//
//         _dtoToEntity = new Mapper(new MapperConfiguration(cfg =>
//             cfg.CreateMap<WorkdayDto, Workday>()));
//     }
//
//     public WorkdayDto EntityToDto(Workday entity) {
//         return _entityToDto.Map<Workday, WorkdayDto>(entity);
//     }
//
//     public Workday DtoToEntity(WorkdayDto dto) {
//         return _dtoToEntity.Map<WorkdayDto, Workday>(dto);
//     }
// }