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
        bool RemoveMovie(int id);
        bool UpdateHall(Hall updatedHall);
        bool CreateHall(Hall newHall);
        bool RemoveHall(int id);
        bool UpdateTariff(Tariff updatedTariff);
        bool CreateTariff(Tariff newTariff);
        bool RemoveTariff(int id);
        bool UpdateTimeSlot(TimeSlot updatedTimeSlot);
        bool CreateTimeSlot(TimeSlot newTimeSlot);
        bool RemoveTimeSlot(int id);
        Movie[] GetAllMovies();
        Hall GetHallById(int id);
        Hall[] GetAllHalls();
        Tariff GetTariffById(int id);
        Tariff[] GetAllTariffs();
        TimeSlot GetTimeSlotById(int id);
        TimeSlot[] GetAllTimeSlots();
        TimeSlot[] GetTimeSlotsByMovieId(int id);


        MovieListItem[] GetFullMoviesInfo();
        TimeSlotTag[] GetTimeSlotTagsByMovieId(int movid);
        bool AddRequestedSeatsToTimeSlot(SeatsProcessRequests request);
    }
}
