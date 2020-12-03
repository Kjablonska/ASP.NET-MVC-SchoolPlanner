using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolPlanner.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolPlanner.Controllers
{
    public class HomeController : Controller
    {
        SchoolPlannerModel schoolPlanner;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.schoolPlanner = new SchoolPlannerModel();
            schoolPlanner.deserializeJsonFile();
        }

        public IActionResult Index()
        {

            IEnumerable<SelectListItem> roomsItems = schoolPlanner.getRoomList().Select(m => new SelectListItem { Text = m, Value = m });
            ViewBag.Rooms = new SelectList(roomsItems, "Value" , "Text");

            if (HttpContext.Request.Query.TryGetValue("room", out var roomParameter))
                schoolPlanner.currentRoom = (string)roomParameter;
            else
                schoolPlanner.currentRoom = roomsItems.First().Value;


            return View(schoolPlanner);
        }

        public IActionResult UpdateRoom(string room) {
            schoolPlanner.currentRoom = room;
            return RedirectToAction(nameof(Index), new { room });
        }

        [HttpPost]
        public IActionResult SaveEntry() {
            var group = Request.Form["group"].ToString();
            // add the rest.
            return RedirectToAction(nameof(Index), new {schoolPlanner.currentRoom});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult EditDictionary()
        {
            return View();
        }

        public IActionResult EditEntry()
        {
            return View(schoolPlanner);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public ActionResult DefaultRoom() {
            IEnumerable<SelectListItem> roomsItems = schoolPlanner.getRoomList().Select(m => new SelectListItem { Text = m, Value = m });
            ViewBag.Rooms = new SelectList(roomsItems, "Value" , "Text");

            schoolPlanner.currentRoom = roomsItems.First().Value;

            return RedirectToAction(nameof(Index), new {schoolPlanner.currentRoom});
        }

    }
}
