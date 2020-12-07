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
                } catch (JsonException) {
                    schoolData = new SchoolData();
                }
            } else {
                File.Create(jsonFile);
                schoolData = new SchoolData();;
                SerializeData();
            }
        }

        private void CheckDataCorrectness() {
            if (schoolData.classes == null || schoolData.rooms == null || schoolData.teachers == null || schoolData.groups == null || schoolData.activities == null) {
                schoolData = new SchoolData();
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

        public void addActivity(string room, int slot, string day, string group, string clas, string teacher) {
            if (ValidateNewActivity(room, slot, day, group, clas, teacher)) {
                schoolData.activities.Add(new ActivityData(room, slot, day, group, clas, teacher));
                SerializeData();
            }
        }

        private bool ValidateNewActivity(string room, int slot, string day, string group, string clas, string teacher) {
            foreach(var activity in schoolData.activities) {
                if (activity.room != room && activity.day == day && activity.slot == slot && (activity.group == group || activity.teacher == teacher))
                    return false;
            }
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

        public void EditDictionaryItem(string dictionaryName, string oldItem, string newItem) {
            switch(dictionaryName) {
                case "teachers":
                    EditTeacher(oldItem, newItem);
                break;
                case "rooms":
                    EditRoom(oldItem, newItem);
                break;
                case "classes":
                    EditClass(oldItem, newItem);
                break;
                case "groups":
                    EditGroup(oldItem, newItem);
                break;
                default:
                break;
            }
            SerializeData();
        }

        public void AddDictionaryItem(string dictionaryName, string newItem) {
            switch(dictionaryName) {
                case "teachers":
                    AddTeacher(newItem);
                break;
                case "rooms":
                    AddRoom(newItem);
                break;
                case "classes":
                    AddClass(newItem);
                break;
                case "groups":
                    AddGroup(newItem);
                break;
                default:
                break;
            }
            SerializeData();
        }


        private void AddTeacher(string newTeacher) {
            if (schoolData.teachers.Contains(newTeacher))
                return;
            else
                schoolData.teachers.Add(newTeacher);
        }

        private void AddClass(string newClass) {
            if (schoolData.classes.Contains(newClass))
                return;
            else
                schoolData.classes.Add(newClass);
        }

        private void AddRoom(string newRoom) {
            if (schoolData.rooms.Contains(newRoom))
                return;
            else
                schoolData.rooms.Add(newRoom);
        }

        private void AddGroup(string newGroup) {
            if (schoolData.groups.Contains(newGroup))
                return;
            else
                schoolData.groups.Add(newGroup);
        }


        public void RemoveDictionaryItem(string dictionaryName, string item) {
            switch(dictionaryName) {
                case "teachers":
                    schoolData.teachers.Remove(item);
                    RemoveTeacherActivities(item);
                break;
                case "rooms":
                    schoolData.rooms.Remove(item);
                    RemoveRoomActivities(item);
                break;
                case "classes":
                    schoolData.classes.Remove(item);
                    RemoveClassActivities(item);
                break;
                case "groups":
                    schoolData.groups.Remove(item);
                    RemoveGroupActivities(item);
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

        private void EditTeacher(string oldTeacherName, string newTeacherName) {
            if (!schoolData.teachers.Contains(oldTeacherName) || schoolData.teachers.Contains(newTeacherName))
                return;

            schoolData.teachers[schoolData.teachers.FindIndex(i => i.Equals(oldTeacherName))] =  newTeacherName;

            foreach (var activity in schoolData.activities) {
                if (activity.teacher == oldTeacherName)
                    activity.teacher = newTeacherName;
            }
        }

        private void EditRoom(string oldRoomName, string newRoomName) {
            if (!schoolData.rooms.Contains(oldRoomName) || schoolData.rooms.Contains(newRoomName))
                return;

            schoolData.rooms[schoolData.rooms.FindIndex(i => i.Equals(oldRoomName))] =  newRoomName;

            foreach (var activity in schoolData.activities) {
                if (activity.room == oldRoomName)
                    activity.room = newRoomName;
            }
        }

        private void EditClass(string oldClassName, string newClassName) {
            if (!schoolData.classes.Contains(oldClassName) || schoolData.classes.Contains(newClassName))
                return;

            schoolData.classes[schoolData.classes.FindIndex(i => i.Equals(oldClassName))] =  newClassName;

            foreach (var activity in schoolData.activities) {
                if (activity.teacher == oldClassName)
                    activity.teacher = newClassName;
            }
        }

        private void EditGroup(string oldGroupName, string newGroupName) {
            if (!schoolData.groups.Contains(oldGroupName) || schoolData.groups.Contains(newGroupName))
                return;

            schoolData.groups[schoolData.groups.FindIndex(i => i.Equals(oldGroupName))] =  newGroupName;

            foreach (var activity in schoolData.activities.ToList()) {
                if (activity.group == oldGroupName)
                    activity.group = newGroupName;
            }
        }

        private void RemoveTeacherActivities(string teacher) {
            foreach (var activity in schoolData.activities.ToList()) {
                if (activity.teacher == teacher)
                    schoolData.activities.Remove(activity);
            }
        }

        private void RemoveRoomActivities(string room) {
            foreach (var activity in schoolData.activities.ToList()) {
                if (activity.room == room)
                    schoolData.activities.Remove(activity);
            }
        }

        private void RemoveClassActivities(string clas) {
            foreach (var activity in schoolData.activities.ToList()) {
                if (activity.clas == clas)
                    schoolData.activities.Remove(activity);
            }
        }

        private void RemoveGroupActivities(string group) {
            foreach (var activity in schoolData.activities.ToList()) {
                if (activity.group == group)
                    schoolData.activities.Remove(activity);
            }
        }

    }
}