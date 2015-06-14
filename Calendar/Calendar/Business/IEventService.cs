using System;
using System.Collections.Generic;
using Calendar.Models;

namespace Calendar.Business
{
    public interface IEventService
    {
        EventListViewModel GetEventsOnDate(DateTime date, string userId);
    }
}