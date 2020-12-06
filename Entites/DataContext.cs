using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolPlanner.Entities {
    public class DataContext {
        private readonly string jsonFile = "data.json";
        public const string EMPTY_ENTRY = " ";
        public SchoolData schoolData;

        public DataContext() {
            DeserializeData();
            CheckDataCorrectness();
        }

        public void DeserializeData() {
            if (File.Exists(jsonFile)) {
                var jsonData = File.ReadAllText(jsonFile);
                try {
                    schoolData = JsonSerializer.Deserialize<SchoolData>(jsonData);
                } catch (Exception ex) {
                    schoolData = new SchoolData();
                    Console.WriteLine(ex);
                    throw new JsonException("File data incorrect");
                }
            } else {
                File.Create(jsonFile);
                schoolData = new SchoolData();
                SerializeData();
            }
        }

        private void CheckDataCorrectness() {
            if (schoolData.classes == null || schoolData.rooms == null || schoolData.teachers == null || schoolData.groups == null || schoolData.activities == null) {
                throw new InvalidDataException("Null data values.");
            }
        }

        public void SerializeData() {
            var jsonData = JsonSerializer.Serialize<SchoolData>(schoolData);
            File.WriteAllText(jsonFile, jsonData);
        }

         public ActivityData getActivity(string room, int slot, string day) {
            foreach (var activity in schoolData.activities) {
                if (activity.room == room && activity.slot == slot && activity.day == day)
                    return activity;
            }

            return null;
        }

        public string getGroupByRoomAndSlot(string roomName, int slot, string day) {
            ActivityData activity = getActivity(roomName, slot, day);

            if (activity.group != null)
                return activity.group;
            else
                return EMPTY_ENTRY;

        }

        public bool removeActivity(string room, int slot, string day) {
            foreach (var activity in schoolData.activities) {
                if (activity.room == room && activity.slot == slot && activity.day == day) {
                    schoolData.activities.Remove(activity);
                    SerializeData();
                    return true;
                }
            }

            return false;
        }

        public bool addActivity(string room, int slot, string day, string group, string clas, string teacher) {
            schoolData.activities.Add(new ActivityData(room, slot, day, group, clas, teacher));
            SerializeData();

            return true;
        }

        public void SaveDictionary(string dictionaryName, List<string> dictionaryItems) {
            switch(dictionaryName) {
                case "teachers":
                    schoolData.teachers = dictionaryItems;
                break;
                case "rooms":
                    schoolData.rooms = dictionaryItems;
                break;
                case "classes":
                    schoolData.classes = dictionaryItems;
                break;
                case "groups":
                    schoolData.groups = dictionaryItems;
                break;
                default:
                break;
            }
            SerializeData();
        }

        public void RemoveDictionaryItem(string dictionaryName, string item) {
            switch(dictionaryName) {
                case "teachers":
                    schoolData.teachers.Remove(item);
                break;
                case "rooms":
                    schoolData.rooms.Remove(item);
                break;
                case "classes":
                    schoolData.classes.Remove(item);
                break;
                case "groups":
                    schoolData.groups.Remove(item);
                break;
                default:
                break;
            }
            SerializeData();
        }

        public SelectList getGroups() {
            IEnumerable<SelectListItem> groupsItems = schoolData.groups.Select(m => new SelectListItem { Text = m, Value = m });
            return new SelectList(groupsItems, "Value" , "Text");
        }

        public SelectList getTeachers() {
            IEnumerable<SelectListItem> teacherItems = schoolData.teachers.Select(m => new SelectListItem { Text = m, Value = m });
            return new SelectList(teacherItems, "Value" , "Text");
        }

        public SelectList getClasses() {
            IEnumerable<SelectListItem> classesItems = schoolData.classes.Select(m => new SelectListItem { Text = m, Value = m });
            return new SelectList(classesItems, "Value" , "Text");
        }

        public SelectList getRooms() {
            IEnumerable<SelectListItem> roomsItems = schoolData.rooms.Select(m => new SelectListItem { Text = m, Value = m });
            return new SelectList(roomsItems, "Value" , "Text");
        }

    }
}