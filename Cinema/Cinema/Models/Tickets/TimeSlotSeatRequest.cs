using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.Tickets
{
    public class TimeSlotSeatRequest
    {
        public int Row { get; set; }
        public int Seat { get; set; }
        public RequestStatus Status { get; set; }

    }
}