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

        public TicketsController()
        {
            _ticketService = new JsonTicketService(System.Web.HttpContext.Current);
        }

        public ActionResult GetMovies()
        {
            var allMovies = _ticketService.GetFullMoviesInfo();
            return View("~/Views/Tickets/MoviesList.cshtml", allMovies);
        }

        public ActionResult GetHallInfo()
        {
            return null;
        }

    }
}