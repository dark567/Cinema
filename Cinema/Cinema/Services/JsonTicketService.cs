using Cinema.Models.Tickets;
using Newtonsoft.Json;
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
    }
}