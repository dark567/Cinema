using Cinema.Models.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Services
{
    public interface ITicketService
    {
        Movie GetMovieById(int id);
        bool UpdateMovie(Movie updatedMovie);
        bool UpdateHall(Hall updatedHall);
        bool UpdateTariff(Tariff updatedTariff);
        bool UpdateTimeSlot(TimeSlot updatedTimeSlot);
        Movie[] GetAllMovies();
        Hall GetHallById(int id);
        Hall[] GetAllHalls();
        Tariff GetTariffById(int id);
        Tariff[] GetAllTariffs();
        TimeSlot GetTimeSlotById(int id);
        TimeSlot[] GetAllTimeSlots();
    }
}
