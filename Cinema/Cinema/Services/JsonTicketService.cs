using Cinema.Models.Tickets;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Web;

namespace Cinema.Services
{
    public class JsonTicketService : ITicketService
    {
        private HttpContext Context { get; set; }
        private const string PathToJson = "/Bd/Tickets.json";

        public JsonTicketService(HttpContext context)
        {
            Context = context;
        }

        public bool UpdateMovie(Movie updatedMovie)
        {
            var fullModel = GetDataFromFile();
            var movieToUpdate = fullModel.Movies.FirstOrDefault(movie => movie.Id == updatedMovie.Id);
            if (movieToUpdate == null)
                return false;

            movieToUpdate.Name = updatedMovie.Name;
            movieToUpdate.Description = updatedMovie.Description;
            if (updatedMovie.Genres != null)
                movieToUpdate.Genres = updatedMovie.Genres;
            movieToUpdate.ImageUrl = updatedMovie.ImageUrl;
            movieToUpdate.MinAge = updatedMovie.MinAge;
            movieToUpdate.Duration = updatedMovie.Duration;
            movieToUpdate.Rating = updatedMovie.Rating;
            if (updatedMovie.Types != null)
                movieToUpdate.Types = updatedMovie.Types;

            SaveDataToFile(fullModel);
            return true;
        }

        public bool UpdateHall(Hall updatedHall)
        {
            var fullModel = GetDataFromFile();
            var hallToUpdate = fullModel.Halls.FirstOrDefault(hall => hall.Id == updatedHall.Id);
            if (hallToUpdate == null)
                return false;

            hallToUpdate.Name = updatedHall.Name;
            SaveDataToFile(fullModel);
            return true;
        }

        public bool UpdateTariff(Tariff updatedTariff)
        {
            var fullModel = GetDataFromFile();
            var tariffToUpdate = fullModel.Tariffs.FirstOrDefault(tariff => tariff.Id == updatedTariff.Id);
            if (tariffToUpdate == null)
                return false;

            tariffToUpdate.Name = updatedTariff.Name;
            tariffToUpdate.Cost = updatedTariff.Cost;

            SaveDataToFile(fullModel);
            return true;
        }

        public bool UpdateTimeSlot(TimeSlot updatedTimeSlot)
        {
            var fullModel = GetDataFromFile();
            var timeSlotToUpdate = fullModel.TimeSlots.FirstOrDefault(movie => movie.Id == updatedTimeSlot.Id);
            if (timeSlotToUpdate == null)
                return false;

            timeSlotToUpdate.StartTime = updatedTimeSlot.StartTime;
            timeSlotToUpdate.MovieId = updatedTimeSlot.MovieId;
            timeSlotToUpdate.HallId = updatedTimeSlot.HallId;
            timeSlotToUpdate.TariffId = updatedTimeSlot.TariffId;

            SaveDataToFile(fullModel);
            return true;
        }

        private void SaveDataToFile(TicketsJsonModel fullModel)
        {
            var jsonFilePath = Context.Server.MapPath(PathToJson);
            var serialiazedModel = JsonConvert.SerializeObject(fullModel);
            System.IO.File.WriteAllText(jsonFilePath, serialiazedModel);

        }

        public Hall[] GetAllHalls()
        {
            var fullModel = GetDataFromFile();
            return fullModel.Halls;
        }

        public Movie[] GetAllMovies()
        {
            var fullModel = GetDataFromFile();
            return fullModel.Movies;
        }

        public Tariff[] GetAllTariffs()
        {
            var fullModel = GetDataFromFile();
            return fullModel.Tariffs;
        }

        public TimeSlot[] GetAllTimeSlots()
        {
            var fullModel = GetDataFromFile();
            return fullModel.TimeSlots;
        }

        public TimeSlot[] GetTimeSlotsByMovieId(int id)
        {
            var fullModel = GetDataFromFile();
            return fullModel.TimeSlots.Where(timeSlots => timeSlots.MovieId == id).ToArray();
        }

        public Hall GetHallById(int id)
        {
            var fullModel = GetDataFromFile();
            return fullModel.Halls.FirstOrDefault(halls => halls.Id == id);
        }

        public Movie GetMovieById(int id)
        {
            var fullModel = GetDataFromFile();
            return fullModel.Movies.FirstOrDefault(movie => movie.Id == id);
        }

        public Tariff GetTariffById(int id)
        {
            var fullModel = GetDataFromFile();
            return fullModel.Tariffs.FirstOrDefault(tariffs => tariffs.Id == id);
        }

        public TimeSlot GetTimeSlotById(int id)
        {
            var fullModel = GetDataFromFile();
            return fullModel.TimeSlots.FirstOrDefault(timeSlots => timeSlots.Id == id);
        }



        private TicketsJsonModel GetDataFromFile()
        {
            var jsonFilePath = Context.Server.MapPath(PathToJson);
            if (!System.IO.File.Exists(jsonFilePath))
                return null;

            var jsonModel = System.IO.File.ReadAllText(jsonFilePath);
            var deserializedModel = JsonConvert.DeserializeObject<TicketsJsonModel>(jsonModel);
            return deserializedModel;

        }

        public bool CreateMovie(Movie newMovie)
        {
            var fullModel = GetDataFromFile();

            try
            {
                var newMovieId = !fullModel.Movies.Any() ? 1 : fullModel.Movies.Max(movie => movie.Id) + 1;
                newMovie.Id = newMovieId;
                var existingMovieList = fullModel.Movies.ToList();
                existingMovieList.Add(newMovie);
                fullModel.Movies = existingMovieList.ToArray();
                SaveDataToFile(fullModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;

        }

        public bool CreateHall(Hall newHall)
        {
            var fullModel = GetDataFromFile();

            try
            {
                var newHallId = !fullModel.Halls.Any() ? 1 : fullModel.Halls.Max(movie => movie.Id) + 1;
                newHall.Id = newHallId;
                var existingHallsList = fullModel.Halls.ToList();
                existingHallsList.Add(newHall);
                fullModel.Halls = existingHallsList.ToArray();
                SaveDataToFile(fullModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool CreateTariff(Tariff newTariff)
        {
            var fullModel = GetDataFromFile();

            try
            {
                var newTariffId = !fullModel.Tariffs.Any() ? 1 : fullModel.Tariffs.Max(timeSlot => timeSlot.Id) + 1;
                newTariff.Id = newTariffId;
                var existingnewTariffList = fullModel.Tariffs.ToList();
                existingnewTariffList.Add(newTariff);
                fullModel.Tariffs = existingnewTariffList.ToArray();
                SaveDataToFile(fullModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool CreateTimeSlot(TimeSlot newTimeSlot)
        {
            var fullModel = GetDataFromFile();

            try
            {
                var newTimeSlotId = !fullModel.TimeSlots.Any() ? 1 : fullModel.TimeSlots.Max(timeSlot => timeSlot.Id) + 1;
                newTimeSlot.Id = newTimeSlotId;
                var existingnewTimeSlotList = fullModel.TimeSlots.ToList();
                existingnewTimeSlotList.Add(newTimeSlot);
                fullModel.TimeSlots = existingnewTimeSlotList.ToArray();
                SaveDataToFile(fullModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool RemoveMovie(int id)
        {
            var fullModel = GetDataFromFile();

            try
            {
                var findMovieId = fullModel.Movies.First(movie => movie.Id == id);
                var existingMovieList = fullModel.Movies.ToList();
                existingMovieList.Remove(findMovieId);
                fullModel.Movies = existingMovieList.ToArray();

                //delete relativies TimeToSlot
                var existingTimeSlotsList = fullModel.TimeSlots.ToList();
                existingTimeSlotsList.RemoveAll(timeSlot => timeSlot.MovieId == id);
                fullModel.TimeSlots = existingTimeSlotsList.ToArray();
                SaveDataToFile(fullModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool RemoveHall(int id)
        {
            var fullModel = GetDataFromFile();

            try
            {
                var findHallId = fullModel.Halls.First(movie => movie.Id == id);
                var existingHallList = fullModel.Halls.ToList();
                existingHallList.Remove(findHallId);
                fullModel.Halls = existingHallList.ToArray();

                //delete relativies TimeToSlot
                var existingTimeSlotsList = fullModel.TimeSlots.ToList();
                existingTimeSlotsList.RemoveAll(timeSlot => timeSlot.MovieId == id);
                fullModel.TimeSlots = existingTimeSlotsList.ToArray();
                SaveDataToFile(fullModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool RemoveTariff(int id)
        {
            var fullModel = GetDataFromFile();

            try
            {
                var findTariffId = fullModel.Tariffs.First(tariff => tariff.Id == id);
                var existingTariffList = fullModel.Tariffs.ToList();
                existingTariffList.Remove(findTariffId);
                fullModel.Tariffs = existingTariffList.ToArray();

                //delete relativies TimeToSlot
                var existingTimeSlotsList = fullModel.TimeSlots.ToList();
                existingTimeSlotsList.RemoveAll(timeSlot => timeSlot.MovieId == id);
                fullModel.TimeSlots = existingTimeSlotsList.ToArray();
                SaveDataToFile(fullModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool RemoveTimeSlot(int id)
        {
            var fullModel = GetDataFromFile();

            try
            {
                var findTimeSlotId = fullModel.TimeSlots.First(timeSlot => timeSlot.Id == id);
                var existingTimeSlotsList = fullModel.TimeSlots.ToList();
                existingTimeSlotsList.Remove(findTimeSlotId);
                fullModel.TimeSlots = existingTimeSlotsList.ToArray();
                SaveDataToFile(fullModel);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}