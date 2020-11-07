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
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        public ActionResult GetMovies()
        {
            var allMovies = _ticketService.GetFullMoviesInfo();
            return View("~/Views/Tickets/MoviesList.cshtml", allMovies);
        }

        public ActionResult GetHallInfo(int timeSlotId)
        {
            //return null;

            var timeSlot = _ticketService.GetTimeSlotById(timeSlotId);
            var currentTariff = _ticketService.GetTariffById(timeSlot.TariffId);
            var model = new HallInfo
            {
                CurrentTariff = currentTariff,
                CurrentTimeslotId = timeSlotId
            };
            return View("~/Views/Tickets/HallInfo.cshtml", model);
        }

        public string ProcessRequest(SeatsProcessRequests request)
        {
            var requestProcessingResult = _ticketService.AddRequestedSeatsToTimeSlot(request);
            return JsonConvert.SerializeObject(new
            {
                requestResult = requestProcessingResult
            });
        }
    }
}