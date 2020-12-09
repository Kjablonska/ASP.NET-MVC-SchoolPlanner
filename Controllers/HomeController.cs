using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolPlanner.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolPlanner.Entities;

namespace SchoolPlanner.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext plannerData;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {

            this.plannerData = new DataContext();
            _logger = logger;
        }

        public IActionResult Index(string room)
        {

            SchoolPlannerViewModel schoolTimeTable = new SchoolPlannerViewModel();
            schoolTimeTable.roomData = plannerData.schoolData;

            ViewBag.Rooms = new SelectList(plannerData.GetRooms(), "Value" , "Text");

            if (room != null)
                schoolTimeTable.currentRoom = room;
            else
                schoolTimeTable.currentRoom = plannerData.GetRooms().Any() ?  plannerData.GetRooms().First().Value : string.Empty;

            return View(schoolTimeTable);
        }

        public IActionResult UpdateRoom(string room) {
            if (String.IsNullOrEmpty(room))
                return RedirectToAction("Index");
            return RedirectToAction("Index", new {room = room});
        }

        [HttpPost]
        public IActionResult SaveDictionary(List<string> items, string dictionary) {
            if (items != null && items.Count != 0 && String.IsNullOrEmpty(dictionary)) {
                plannerData.SaveDictionary(dictionary, items);
                return RedirectToAction("EditDictionary", new {dictionary=dictionary});
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SaveEntry(string group, string clas, string teacher, string room, int? slot, string day) {
            if (String.IsNullOrEmpty(room) || String.IsNullOrEmpty(day) || !slot.HasValue || String.IsNullOrEmpty(group) || String.IsNullOrEmpty(clas) || String.IsNullOrEmpty(teacher))
                return RedirectToAction(nameof(Index));

            plannerData.AddActivity(room, slot.Value, day, group, clas, teacher);
            return RedirectToAction("Index", new {room = room});
        }

        public IActionResult UnassignEntry(string room, int? slot, string day) {
            if (String.IsNullOrEmpty(room) || String.IsNullOrEmpty(day) || !slot.HasValue)
                return RedirectToAction("Index");

            plannerData.RemoveActivity(room, slot.Value, day);
            return RedirectToAction("Index", new {room = room});
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

        public IActionResult EditDictionaryItem(string dictionary, string item) {
            EditDictionaryItemViewModel editItem = new EditDictionaryItemViewModel();

            editItem.dictionaryName = dictionary;
            editItem.item = item;

            return View(editItem);
        }

        public IActionResult SaveDictionaryItem(string editedItem, string item, string dictionary) {
            if (String.IsNullOrEmpty(editedItem))
                plannerData.AddDictionaryItem(dictionary, item);
            else
                plannerData.EditDictionaryItem(dictionary, editedItem, item);

            return RedirectToAction("EditDictionary", new {dictionary = dictionary});
        }

        public IActionResult RemoveDictionaryItem(string item, string dictionary) {
            plannerData.RemoveDictionaryItem(dictionary, item);
            return RedirectToAction("EditDictionary", new {dictionary = dictionary});
        }

        public IActionResult EditEntry(string room, int? slot, string day)
        {
            if (String.IsNullOrEmpty(room) || String.IsNullOrEmpty(day) || !slot.HasValue)
                return RedirectToAction(nameof(Index));

            EditEntryViewModel editEntry = new EditEntryViewModel();

            editEntry.classesItems = plannerData.GetClasses();
            editEntry.groupsItems = plannerData.GetGroups();
            editEntry.teachersItems = plannerData.GetTeachers();

            ActivityData selectedActivity = plannerData.getActivity(room, slot.Value, day);

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
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
