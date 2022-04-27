using AutoMapper;
using ems_api.Database.Models;
using ems_api.Models.DAOs;
using ems_api.Models.DTOs;

namespace ems_api.Utils;

public class ObjectMapper : Profile {
    public ObjectMapper() {
        CreateMap<User, UserDTO>().ReverseMap();
        CreateMap<User, UserDAO>().ReverseMap();
        CreateMap<UserDTO, User>().ReverseMap();
        
        CreateMap<Workday, WorkdayDAO>().ReverseMap();
    }
}