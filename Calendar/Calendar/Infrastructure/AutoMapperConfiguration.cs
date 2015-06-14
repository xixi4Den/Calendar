using AutoMapper;
using Calendar.Entities;
using Calendar.Models;

namespace Calendar.Infrastructure
{
    public class AutoMapperConfiguration
    {
        public static void RegisterMappings()
        {
            Mapper.CreateMap<Event, EventViewModel>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.ApplicationUser.Id));
        }
    }
}