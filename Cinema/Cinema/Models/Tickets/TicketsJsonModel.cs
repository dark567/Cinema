namespace Cinema.Models.Tickets
{
    public class TicketsJsonModel
    {
        public Movie[] Movies { get; set; }
        public Hall[] Halls { get; set; }
        public TimeSlot[] TimeSlots { get; set; }
        public Tariff[] Tariffs { get; set; }
    }
}