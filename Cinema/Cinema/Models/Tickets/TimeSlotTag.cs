using System;

namespace Cinema.Models.Tickets
{
    public class TimeSlotTag
    {
        public int TimeSlotId { get; set; }
        public DateTime StartTime { get; set; }
        public decimal Cost { get; set; }

    }
}