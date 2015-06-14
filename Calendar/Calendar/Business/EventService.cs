using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using AutoMapper;
using Calendar.DataAccess;
using Calendar.Entities;
using Calendar.Models;
using Microsoft.Ajax.Utilities;

namespace Calendar.Business
{
    public class EventService: IEventService
    {
        private readonly IRepository<Event> eventRepository;
        private readonly IUserService userService;

        public EventService(IRepository<Event> eventRepository,
            IUserService userService)
        {
            this.eventRepository = eventRepository;
            this.userService = userService;
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

        public void CreateEvent(EventViewModel newEventViewModel)
        {
            Contract.Assert(newEventViewModel != null, "newEventViewModel should not be null");
            Contract.Assert(newEventViewModel.Id == Guid.Empty, "newEventViewModel should have empty id");
            Contract.Assert(!newEventViewModel.UserId.IsNullOrWhiteSpace(), "newEventViewModel should have not null and not empty userId");

            var newEvent = Mapper.Map<Event>(newEventViewModel);

            eventRepository.InsertOrUpdate(newEvent);
        }

        public void UpdateEvent(EventViewModel oldEventViewModel)
        {
            Contract.Assert(oldEventViewModel != null, "newEventViewModel should not be null");
            Contract.Assert(oldEventViewModel.Id != Guid.Empty, "newEventViewModel should not have empty id");
            Contract.Assert(!oldEventViewModel.UserId.IsNullOrWhiteSpace(), "newEventViewModel should have not null and not empty userId");

            var newEvent = Mapper.Map<Event>(oldEventViewModel);

            eventRepository.InsertOrUpdate(newEvent);
        }
    }
}