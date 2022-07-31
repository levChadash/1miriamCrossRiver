using AutoMapper;
using CoronaApp.Dal.Models;
using CoronaApp.Services.DTO;

namespace CoronaApp.Api
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<LocationPostDTO, Location>()
                       .ReverseMap();
        }
       
    }
}
