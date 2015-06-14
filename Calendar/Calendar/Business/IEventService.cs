using System;
using Calendar.Models;

namespace Calendar.Business
{
    public interface IEventService
    {
        EventListViewModel GetEventsOnDate(DateTime date, string userId);

        void CreateEvent(EventViewModel newEventViewModel);

        void UpdateEvent(EventViewModel oldEventViewModel);
    }
}