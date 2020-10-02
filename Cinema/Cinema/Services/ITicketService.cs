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
        bool CreateMovie(Movie newMovie);
        bool UpdateHall(Hall updatedHall);
        bool CreateHall(Hall newHall);
        bool UpdateTariff(Tariff updatedTariff);
        bool CreateTariff(Tariff newTariff);
        bool UpdateTimeSlot(TimeSlot updatedTimeSlot);
        bool CreateTimeSlot(TimeSlot newTimeSlot);
        Movie[] GetAllMovies();
        Hall GetHallById(int id);
        Hall[] GetAllHalls();
        Tariff GetTariffById(int id);
        Tariff[] GetAllTariffs();
        TimeSlot GetTimeSlotById(int id);
        TimeSlot[] GetAllTimeSlots();
        TimeSlot[] GetTimeSlotsByMovieId(int id);
    }
}
