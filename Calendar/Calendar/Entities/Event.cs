using System;
using Calendar.Models;

namespace Calendar.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Descriiption { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsRemoved { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}