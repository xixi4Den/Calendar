using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using AutoMapper;
using Calendar.DataAccess;
using Calendar.Entities;
using Calendar.Models;

namespace Calendar.Business
{
    public class EventService: IEventService
    {
        private readonly IRepository<Event> eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public EventListViewModel GetEventsOnDate(DateTime date, string userId)
        {
            Contract.Assert(date != default(DateTime), "Incorrect date");
            Contract.Assert(!String.IsNullOrWhiteSpace(userId), "userId should not be null or empty");

            var events = eventRepository.Get(x => x.ApplicationUser.Id == userId &&
                                     ((x.StartDate.HasValue && x.StartDate.Value.Year == date.Year && x.StartDate.Value.Month == date.Month && x.StartDate.Value.Day == date.Day) ||
                                      (x.EndDate.HasValue && x.EndDate.Value.Year == date.Year && x.EndDate.Value.Month == date.Month && x.EndDate.Value.Day == date.Day))).ToList();
            var eventViewModels = Mapper.Map<IEnumerable<EventViewModel>>(events);
            var result = new EventListViewModel
            {
                UserId = userId,
                Day = date,
                Events = eventViewModels,
            };
            return result;
        }
    }
}