using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolPlanner.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolPlanner.Entities;

namespace SchoolPlanner.Controllers
{
    public class HomeController : Controller
    {
        DataContext plannerData;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? room)
        {
            try {
                this.plannerData = new DataContext();
            } catch (Exception ex) {
                return RedirectToAction(nameof(Error), new {message = ex.Message});
            }

            SchoolPlannerViewModel schoolTimeTable = new SchoolPlannerViewModel();
            schoolTimeTable.roomData = plannerData.schoolData;

            ViewBag.Rooms = new SelectList(plannerData.getRooms(), "Value" , "Text");

            if (HttpContext.Request.Query.TryGetValue("room", out var roomParameter))
                schoolTimeTable.currentRoom = (string)roomParameter;
            else
                schoolTimeTable.currentRoom = plannerData.getRooms().First().Value;

            return View(schoolTimeTable);
        }

        public IActionResult UpdateRoom(int? room) {
            return RedirectToAction(nameof(Index), new { room });
        }

        [HttpPost]
        public IActionResult SaveDictionary(List<string> items, string dictionary) {
            if (items != null && items.Count != 0 && dictionary != null && dictionary != string.Empty) {
                plannerData.SaveDictionary(dictionary, items);
                return RedirectToAction(nameof(EditDictionary), new {dictionary=dictionary});
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult SaveEntry(string group, string clas, string teacher, string room, int slot, string day) {

            if (group != null || clas != null ) {
                // DO NOT SAVE
                plannerData.addActivity(room, slot, day, group, clas, teacher);
            }

            return RedirectToAction("Index", new {room = room});
        }

        [HttpPost]
        public IActionResult UnassignEntry(string room, int slot, string day) {
            plannerData.removeActivity(room, slot, day);
            return RedirectToAction("Index", new {room = room});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult EditDictionary(string dictionary)
        {
            EditDictionaryViewModel editDictionary = new EditDictionaryViewModel();

            switch(dictionary) {
                case "teachers":
                    editDictionary.dictionaryItem = plannerData.schoolData.teachers;
                break;
                case "rooms":
                    editDictionary.dictionaryItem = plannerData.schoolData.rooms;
                break;
                case "classes":
                    editDictionary.dictionaryItem = plannerData.schoolData.classes;
                break;
                case "groups":
                    editDictionary.dictionaryItem = plannerData.schoolData.groups;
                break;
                default:
                break;
            }

            editDictionary.dictionaryName = dictionary;
            return View(editDictionary);
        }

        public IActionResult AddDictionaryItem() {
            return RedirectToAction("EditDictionary");
        }

        public IActionResult RemoveDictionaryItem(string item, string dictionary) {
            plannerData.RemoveDictionaryItem(dictionary, item);
            return RedirectToAction("EditDictionary", new {dictionary = dictionary});
        }

        public IActionResult EditEntry(string room, int slot, string day)
        {
            EditEntryViewModel editEntry = new EditEntryViewModel();

            editEntry.classesItems = plannerData.getClasses();
            editEntry.groupsItems = plannerData.getGroups();
            editEntry.teachersItems = plannerData.getTeachers();

            ActivityData selectedActivity = plannerData.getActivity(room, slot, day);

            if (selectedActivity != null) {
                editEntry.clas = selectedActivity.clas;
                editEntry.group = selectedActivity.group;
                editEntry.teacher = selectedActivity.teacher;
            } else {
                editEntry.clas = "select class";
                editEntry.group = "select group";
                editEntry.teacher = "select teacher";
            }

            return View(editEntry);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string message)
        {
            return View(new ErrorViewModel { message = message, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
