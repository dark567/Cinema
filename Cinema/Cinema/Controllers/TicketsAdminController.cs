using Cinema.Attributes;
using Cinema.Models.Tickets;
using Cinema.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Type = Cinema.Models.Tickets.Type;


namespace Cinema.Controllers
{
    public class TicketsAdminController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketsAdminController()
        {
            _ticketService = new JsonTicketService(System.Web.HttpContext.Current);
        }


        public ActionResult GetMoviesList()
        {
            var movies = _ticketService.GetAllMovies();
            return View("~/Views/TicketsAdmin/MovieList.cshtml", movies);
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            return View("~/Views/TicketsAdmin/AddMovie.cshtml");
        }

        [HttpPost]
        public ActionResult AddMovie(Movie newMovie)
        {
            var createResult = _ticketService.CreateMovie(newMovie);
            if (createResult)
                return RedirectToAction("GetMoviesList");

            return Content("Update failed, please contact administaration");
        }

        [HttpGet]
        public ActionResult EditMovie(int movieId)
        {
            var movie = _ticketService.GetMovieById(movieId);
            return View("~/Views/TicketsAdmin/EditMovie.cshtml", movie);
        }

        [HttpPost]
        public ActionResult EditMovie(Movie updatedMovie)
        {
            var updateResult = _ticketService.UpdateMovie(updatedMovie);
            if (updateResult)
                return RedirectToAction("GetMoviesList");

            return Content("Update failed, please contact administaration");
        }


        public ActionResult RemoveMovie(int movieId)
        {
            var removeResult = _ticketService.RemoveMovie(movieId);
            if (removeResult)
                return RedirectToAction("GetMoviesList");

            return Content("Update failed, please contact administaration");
        }

        public ActionResult GetHallsList()
        {
            var halls = _ticketService.GetAllHalls();
            return View("~/Views/TicketsAdmin/HallList.cshtml", halls);
        }

        [HttpGet]
        public ActionResult EditHall(int hallId)
        {
            var hall = _ticketService.GetHallById(hallId);
            return View("~/Views/TicketsAdmin/EditHall.cshtml", hall);
        }

        [HttpPost]
        public ActionResult EditHall(Hall updatedHall)
        {
            var updateResult = _ticketService.UpdateHall(updatedHall);
            if (updateResult)
                return RedirectToAction("GetHallsList");

            return Content("Update failed, please contact administaration");
        }

        public ActionResult GetTariffsList()
        {
            var tariff = _ticketService.GetAllTariffs();
            return View("~/Views/TicketsAdmin/TariffList.cshtml", tariff);
        }

        [HttpGet]
        public ActionResult EditTariff(int tariffId)
        {
            var tariff = _ticketService.GetTariffById(tariffId);
            return View("~/Views/TicketsAdmin/EditTariff.cshtml", tariff);
        }

        [HttpPost]
        public ActionResult EditTariff(Tariff updatedTariff)
        {
            var updateResult = _ticketService.UpdateTariff(updatedTariff);
            if (updateResult)
                return RedirectToAction("GetTariffsList");

            return Content("Update failed, please contact administaration");
        }



        public ActionResult GetTimeSlotsList()
        {
            var timeSlots = _ticketService.GetAllTimeSlots();
            var resultModel = ProcessTimeSLot(timeSlots);
            return View("~/Views/TicketsAdmin/TimeSlotList.cshtml", resultModel);
        }


        public ActionResult GetMovieTimeSlotsList(int movieId)
        {
            var timeSlots = _ticketService.GetTimeSlotsByMovieId(movieId);
            var resultModel = ProcessTimeSLot(timeSlots);
            return View("~/Views/TicketsAdmin/TimeSlotList.cshtml", resultModel);
        }


        private TimeSlotGridRow[] ProcessTimeSLot(TimeSlot[] timeSlots)
        {
            var movies = _ticketService.GetAllMovies();
            var halls = _ticketService.GetAllHalls();
            var tariffs = _ticketService.GetAllTariffs();

            var resultModels = new List<TimeSlotGridRow>();
            foreach (var timeSlot in timeSlots)
            {
                resultModels.Add(new TimeSlotGridRow
                {
                    Id = timeSlot.Id,
                    StartTime = timeSlot.StartTime,
                    MovieName = movies.FirstOrDefault(movie => movie.Id == timeSlot.MovieId)?.Name ?? "Data Not Found",
                    HallName = halls.FirstOrDefault(hall => hall.Id == timeSlot.HallId)?.Name ?? "Data Not Found",
                    TariffName = tariffs.FirstOrDefault(tariff => tariff.Id == timeSlot.TariffId)?.Name ?? "Data Not Found"
                });
            }

            return resultModels.ToArray();
        }

        [HttpGet]
        [PopulateMoviesList, PopulateHallsList, PopulateTariffsList]
        public ActionResult AddTimeSlot()
        {
            return View("~/Views/TicketsAdmin/AddTimeSlot.cshtml");
        }

        [HttpPost]
        public ActionResult AddTimeSlot(TimeSlot addTimeSlot)
        {
            var addResult = _ticketService.CreateTimeSlot(addTimeSlot);
            if (addResult)
                return RedirectToAction("GetTimeSlotsList");

            return Content("Update failed, please contact administaration");
        }


        [HttpGet]
        [PopulateMoviesList, PopulateHallsList, PopulateTariffsList]
        public ActionResult EditTimeSlot(int timeSlotId)
        {
            var timeSlot = _ticketService.GetTimeSlotById(timeSlotId);
            return View("~/Views/TicketsAdmin/EditTimeSlot.cshtml", timeSlot);
        }

        [HttpPost]
        public ActionResult EditTimeSlot(TimeSlot updatedTimeSlot)
        {
            var updateResult = _ticketService.UpdateTimeSlot(updatedTimeSlot);
            if (updateResult)
                return RedirectToAction("GetTimeSlotsList");

            return Content("Update failed, please contact administaration");
        }

        public ActionResult FindMovieById(int id)
        {
            var movie = _ticketService.GetMovieById(id);
            if (movie == null)
                return Content("Movie with such Id do not exist");

            var modelJson = JsonConvert.SerializeObject(movie);
            return Content(modelJson, "application/json");
        }

        public ActionResult FindAllMovies()
        {
            var movie = _ticketService.GetAllMovies();
            if (movie == null)
                return Content("Movies do not exist");

            var modelJson = JsonConvert.SerializeObject(movie);
            return Content(modelJson, "application/json");
        }

        public ActionResult FindHallById(int id)
        {
            var hall = _ticketService.GetHallById(id);
            if (hall == null)
                return Content("Hall with such Id do not exist");

            var modelJson = JsonConvert.SerializeObject(hall);
            return Content(modelJson, "application/json");
        }

        public ActionResult FindAllHalls()
        {
            var hall = _ticketService.GetAllHalls();
            if (hall == null)
                return Content("Halls do not exist");

            var modelJson = JsonConvert.SerializeObject(hall);
            return Content(modelJson, "application/json");
        }

        public ActionResult FindTimeSlotById(int id)
        {
            var timeSlot = _ticketService.GetTimeSlotById(id);
            if (timeSlot == null)
                return Content("TimeSlot with such Id do not exist");

            var modelJson = JsonConvert.SerializeObject(timeSlot);
            return Content(modelJson, "application/json");
        }

        public ActionResult FindAllTimeSlots()
        {
            var timeSlot = _ticketService.GetAllTimeSlots();
            if (timeSlot == null)
                return Content("TimeSlots do not exist");

            var modelJson = JsonConvert.SerializeObject(timeSlot);
            return Content(modelJson, "application/json");
        }

        public ActionResult FindTariffById(int id)
        {
            var tariff = _ticketService.GetTariffById(id);
            if (tariff == null)
                return Content("Tariff with such Id do not exist");

            var modelJson = JsonConvert.SerializeObject(tariff);
            return Content(modelJson, "application/json");
        }

        public ActionResult FindAllTariffs()
        {
            var tariff = _ticketService.GetAllTariffs();
            if (tariff == null)
                return Content("Tariffs do not exist");

            var modelJson = JsonConvert.SerializeObject(tariff);
            return Content(modelJson, "application/json");
        }


        #region old
        //private readonly string PathToJson = "/Bd/Tickets.json";

        //public ActionResult SaveTickets()
        //{
        //    var movies = new Movie[]
        //        {
        //          new Movie
        //          {
        //             Id=1,
        //             Name= "Дэдпул 2",
        //             Description ="Болтливый опытный наёмник в обтягивающем костюме сумел расправиться со всеми своими обидчиками, и казалось на это супергеройские дни закончились. Дэдпул не остановился, и решил истребить всех присутствующих на планете плохишей. Киллер жаждал уничтожить опасного и влиятельного наркобарона, но его спецоперация развалилась, что привело к нелицеприятным последствиям. Уэйд не выдерживает натиска вины, и даже имея любовь и признание городских жителей хочет расстаться с жизнью. Профессор Колос видел все страдания героя, и пытался любой ценой помочь ему. Главной целью ученого было завлечь его в героическую команду людей со сверх способностями, но Дэдпул категорически отказывался. Великая честь не для него, а точнее он не хочет делиться славой за спасение невинных людей с напарниками, предпочитая работать в одиночку....",
        //             Duration = 110,
        //             Genres = new []{Genre.Action, Genre.Comedy },
        //             Types = new []{Type.D2 },
        //             MinAge = 18,
        //             Rating = 4.33f,
        //             ImageUrl = "https://i109.fastpic.ru/big/2019/0219/d0/898755dde692dfb1a02cf5e446591dd0.jpg?r=1"
        //            },
        //            new Movie
        //         {
        //             Id=2,
        //             Name= "Перевозчик: Наследие",
        //             Description ="Фрэнк Мартин — самый высококвалифицированный перевозчик, которого только можно нанять за деньги. Ставки выше, технологии поднялись на более высокий уровень, но правила те же: никогда не изменять условия сделки, никаких имен и никогда не открывать груз.Когда Фрэнка нанимает хитроумная красотка Анна и ее три очаровательные сообщницы, он быстро выясняет, что его водят за нос. Анна и ее команда похитили его отца, чтобы заставить Фрэнка помочь им разобраться с группой безжалостных торговцев людьми.",
        //             Duration = 95,
        //             Genres = new []{Genre.Action, Genre.Comedy },
        //             Types = new []{Type.D2 },
        //             MinAge = 16,
        //             Rating = 5.33f,
        //             ImageUrl = "http://i6.imageban.ru/out/2018/01/30/974c5761f892caa8a4039bfbae19243b.jpg"
        //            },
        //            new Movie
        //         {
        //             Id=3,
        //             Name= "Хищник",
        //             Description ="Прошло несколько десятилетий с того дня, как инопланетный Хищник уничтожил группу американских солдат, а после подорвал себя. Бывший морской пехотинец Куинн Маккенна узнает о существовании инопланетян, которых принято называть Хищники. Участвуя в спецоперации по уничтожению наркокартеля, отряд Маккенны забирается глубоко в джунгли. В этот момент с неба падает небольшой металлический объект, внутри которого находится Хищник. Инопланетянина уничтожают, но герой подозревает, что это не единственный засланный на Землю экземпляр. Куинну никто не верит, военное руководство отправляет парня в психиатрическую клинику, считая, что у него съехала крыша....",
        //             Duration = 110,
        //             Genres = new []{Genre.Action },
        //             Types = new []{Type.D2 },
        //             MinAge = 18,
        //             Rating = 4.33f,
        //             ImageUrl = "https://i112.fastpic.ru/big/2020/0917/1d/6e64ceac23f8f340fdc87efea4b54c1d.jpg?r=1"
        //            },
        //        };

        //    var tariffs = new Tariff[]
        //        {
        //            new Tariff
        //            {
        //            Id = 1,
        //            Name = "Standart",
        //            Cost =220
        //            },
        //            new Tariff
        //            {
        //            Id = 1,
        //            Name = "DBox",
        //            Cost =440
        //            }
        //        };

        //    var halls = new[]
        //    {
        //        new Hall
        //         {
        //         Id= 1,
        //         Name= "Hall 1"
        //         },
        //         new Hall
        //         {
        //         Id= 2,
        //         Name= "Hall 1"
        //         },
        //         new Hall
        //         {
        //         Id = 3,
        //           Name = "Hall 1"
        //         }
        //    };

        //    var timeSlot = new[]
        //    {
        //    new TimeSlot
        //    {
        //        Id= 1,
        //        HallId =1,
        //        MovieId =1,
        //        StartTime = DateTime.Now.AddHours(-1),
        //        TariffId = 1
        //    },
        //    new TimeSlot
        //    {
        //        Id= 2,
        //        HallId =1,
        //        MovieId =1,
        //        StartTime = DateTime.Now,
        //        TariffId = 1
        //    },
        //    new TimeSlot
        //    {
        //        Id= 3,
        //        HallId =2,
        //        MovieId =2,
        //        StartTime = DateTime.Now.AddHours(1),
        //        TariffId = 2
        //    },
        //    new TimeSlot
        //    {
        //        Id= 4,
        //        HallId =1,
        //        MovieId =1,
        //        StartTime = DateTime.Now.AddHours(-1),
        //        TariffId = 1
        //    },
        //    new TimeSlot
        //    {
        //        Id= 5,
        //        HallId =2,
        //        MovieId =2,
        //        StartTime = DateTime.Now,
        //        TariffId = 1
        //    },
        //    new TimeSlot
        //    {
        //        Id= 6,
        //        HallId =2,
        //        MovieId =2,
        //        StartTime = DateTime.Now.AddHours(1),
        //        TariffId = 2
        //    },
        //    };

        //    var jsonModel = new TicketsJsonModel
        //    {
        //        Halls = halls,
        //        Movies = movies,
        //        Tariffs = tariffs,
        //        TimeSlots = timeSlot
        //    };

        //    var json = JsonConvert.SerializeObject(jsonModel);

        //    var jsonFilePath = HttpContext.Server.MapPath(PathToJson);

        //    //if (!System.IO.File.Exists(jsonFilePath))
        //    //    return null;

        //    System.IO.File.WriteAllText(jsonFilePath, json);

        //    return Content(json, "application/json");
        //}

        //public ActionResult GetAllTickets()
        //{
        //    var jsonFilePath = HttpContext.Server.MapPath(PathToJson);

        //    if (!System.IO.File.Exists(jsonFilePath))
        //        return Content("File do not exists", "application/json");

        //    var jsonModel = System.IO.File.ReadAllText(jsonFilePath);
        //    var deserializedModel = JsonConvert.DeserializeObject<TicketsJsonModel>(jsonModel);
        //    return Content(jsonModel, "application/json");
        //}
        #endregion

    }
}