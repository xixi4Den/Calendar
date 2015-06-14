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
                .ForMember(x => x.UserId, opt => opt.MapFrom(y => y.ApplicationUserId));
            Mapper.CreateMap<EventViewModel, Event>()
                .ForMember(x => x.ApplicationUserId, opt => opt.MapFrom(y => y.UserId)); ;
        }
    }
}