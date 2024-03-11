using AutoMapper;
using DotNetCoreWebAPI.Data;
using DotNetCoreWebAPI.Models;

namespace DotNetCoreWebAPI.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<UserSaveDto, Users>()
                .ReverseMap();
        }
    }
}
