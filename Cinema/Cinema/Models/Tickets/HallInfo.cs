using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cinema.Models.Tickets
{
    public class HallInfo
    {
        public Tariff CurrentTariff { get; set; }
        public int CurrentTimeslotId { get; set; }
        public TimeSlotSeatRequest[] RequestedSeats { get; set; }
    }
}