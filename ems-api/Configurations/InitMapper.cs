using AutoMapper;
using ems_api.Models.DAOs;

namespace ems_api.Configurations;

public class InitMapper : Profile {
    public InitMapper() {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserDAO>().ReverseMap();
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<Workday, WorkdayDAO>().ReverseMap();
    }
}