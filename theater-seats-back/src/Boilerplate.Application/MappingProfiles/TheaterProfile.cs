using AutoMapper;
using Boilerplate.Application.DTOs.Theater;
using Boilerplate.Domain.Entities.Theater;

namespace Boilerplate.Application.MappingProfiles
{
    public class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
            // Theater mappings
            CreateMap<TimeSlotEntity, TimeSlotGetDto>().ReverseMap();
            CreateMap<TimeSlotInsertDto, TimeSlotEntity>().ReverseMap();
            
            CreateMap<MovieEntity, MovieGetDto>().ReverseMap();
            CreateMap<MovieInsertDto, MovieEntity>();
        }
    }
}