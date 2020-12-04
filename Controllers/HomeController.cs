using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolPlanner.Models;
using Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolPlanner.Entities;

namespace SchoolPlanner.Controllers
{
    public class HomeController : Controller
    {
        DataContext schoolData;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.schoolData = new DataContext();
        }

        public IActionResult Index()
        {
            SchoolPlannerViewModel schoolTimeTable = new SchoolPlannerViewModel();
            schoolTimeTable.roomData = schoolData.schoolData;

            ViewBag.Rooms = new SelectList(schoolData.getRooms(), "Value" , "Text");

            if (HttpContext.Request.Query.TryGetValue("room", out var roomParameter))
                schoolTimeTable.currentRoom = (string)roomParameter;
            else
                schoolTimeTable.currentRoom = schoolData.getRooms().First().Value;

            return View(schoolTimeTable);
        }

        public IActionResult UpdateRoom(int? room) {
            // if (HttpContext.Request.Query.TryGetValue("room", out var roomParameter)) {
            //     return RedirectToAction("Index", "Home", new { room });
            // } else {
            //     return RedirectToAction("Index", "Home", new { room });
            // }

            return RedirectToAction(nameof(Index), new { room });
        }

        [HttpPost]
        public IActionResult SaveEntry() {
            var group = Request.Form["group"].ToString();
            var clas = Request.Form["class"].ToString();
            var teacher = Request.Form["teacher"].ToString();
            var room = Request.Form["room"].ToString();
            var slot = int.Parse(Request.Form["slot"]);
            var day = Request.Form["day"].ToString();

            schoolData.addActivity(room, slot, day, group, clas, teacher);
 
            return RedirectToAction("Index", new {room = room});
        }

        [HttpPost]
        public IActionResult UnassignEntry(string? room, int slot, string? day) {
            schoolData.removeActivity(room, slot, day);
            return RedirectToAction("Index", new {room = room});
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
            EditEntryViewModel editEntryViewModel = new EditEntryViewModel();

            editEntryViewModel.classesItems = schoolData.getClasses();
            editEntryViewModel.groupsItems = schoolData.getGroups();
            editEntryViewModel.teachersItems = schoolData.getTeachers();

            return View(editEntryViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
