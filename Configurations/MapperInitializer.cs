using AutoMapper;
using chores_backend.DTOs;
using chores_backend.Models;

namespace chores_backend.Configurations;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<Chore, ChoreDTO>().ReverseMap();
        CreateMap<User, RegisterDTO>().ReverseMap();
    }
}