using System;
using System.Collections.Generic;

namespace Calendar.Models
{
    public class EventListViewModel
    {
        public string UserId { get; set; }
        public DateTime Day { get; set; }
        public IEnumerable<EventViewModel> Events { get; set; }
    }
}