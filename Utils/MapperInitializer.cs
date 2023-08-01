using chores_backend.DTOs;
using chores_backend.Models;
using Profile = AutoMapper.Profile;

namespace chores_backend.Utils;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<Chore, ChoreDTO>().ReverseMap();
        CreateMap<User, RegisterDTO>().ReverseMap();
    }
}