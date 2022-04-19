using AutoMapper;

namespace ems_api.Utils;

public class WorkdayMapperUtil {
    private readonly Mapper _dtoToEntity;
    private readonly Mapper _entityToDto;

    public WorkdayMapperUtil() {
        _entityToDto = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<WorkdayEntity, WorkdayDto>()));

        _dtoToEntity = new Mapper(new MapperConfiguration(cfg =>
            cfg.CreateMap<WorkdayDto, WorkdayEntity>()));
    }

    public WorkdayDto EntityToDto(WorkdayEntity entity) {
        return _entityToDto.Map<WorkdayEntity, WorkdayDto>(entity);
    }

    public WorkdayEntity DtoToEntity(WorkdayDto dto) {
        return _dtoToEntity.Map<WorkdayDto, WorkdayEntity>(dto);
    }
}