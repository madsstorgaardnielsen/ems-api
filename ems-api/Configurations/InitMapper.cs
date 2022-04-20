using AutoMapper;
using ems_api.Models.DAOs;
using ems_api.Models.DTOs;

namespace ems_api.Configurations;

public class InitMapper : Profile {
    public InitMapper() {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, UserDAO>().ReverseMap();
        CreateMap<UserDTO, User>().ReverseMap();
        
        CreateMap<Workday, WorkdayDAO>().ReverseMap();
    }
}