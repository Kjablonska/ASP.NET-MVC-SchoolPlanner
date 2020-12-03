using System;
using System.Collections.Generic;
using Data.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolPlanner.Models
{
    public class SchoolPlannerModel
    {
        public const string EMPTY_ENTRY = " ";
        public string currentRoom {get; set;}
        private DataModel schoolData;


        private string jsonData = "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/data.json";

        public string getActivityByRoomAndSlot(string roomName, int slot, string day) {
            ActivityData activity = schoolData.getActivity(roomName, slot, day);

            if (activity.group != null)
                return activity.group;
            else
                return EMPTY_ENTRY;

        }

        public ActivityData getActivityByRoomSlotDay(string roomName, int slot, string day) {
            ActivityData activity = schoolData.getActivity(roomName, slot, day);

            if (activity.group != null)
                return activity;
            else
                return new ActivityData();
        }

        public SelectList getGroups() {
            IEnumerable<SelectListItem> roomsItems = schoolData.groups.Select(m => new SelectListItem { Text = m, Value = m });
            return new SelectList(roomsItems, "Value" , "Text");
        }

        public SelectList getTeachers() {
            IEnumerable<SelectListItem> roomsItems = schoolData.teachers.Select(m => new SelectListItem { Text = m, Value = m });
            return new SelectList(roomsItems, "Value" , "Text");
        }

        public SelectList getClasses() {
            IEnumerable<SelectListItem> roomsItems = schoolData.classes.Select(m => new SelectListItem { Text = m, Value = m });
            return new SelectList(roomsItems, "Value" , "Text");
        }

        public void deserializeJsonFile() {
            var jsonString = File.ReadAllText(jsonData);
            schoolData = JsonSerializer.Deserialize<DataModel>(jsonString);
        }

        public List<string> getRoomList()
        {
            return schoolData.rooms;
        }

        public List<string> getGroupList()
        {
            return schoolData.groups;
        }

        public List<string> getTeacherList()
        {
            return schoolData.teachers;
        }

        public List<string> getClassList()
        {
            return schoolData.classes;
        }
    }
}
