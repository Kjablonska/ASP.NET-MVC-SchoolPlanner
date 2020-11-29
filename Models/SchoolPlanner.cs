using System;
using System.Collections.Generic;
using Data.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace SchoolPlanner.Models
{
    public class SchoolPlannerModel
    {
        Dictionary<string, int> DAY_TO_INT = new Dictionary<string, int> { { "Monday", 0 }, { "Tuesday", 1 }, { "Wednesday", 2 }, { "Thursday", 3 }, { "Friday", 4 } };
        private string currentRoom;
        private DataModel schoolData;
        private string jsonData = "/home/kj/projects/elka/EGUI/lab2_ASP/SchoolPlanner/data.json";


        public ActivityData getActivityByRoomAndSlot(string roomName, int slot, string day) {
            return new ActivityData();
        }

        public void deserializeJsonFile() {
            var jsonString = File.ReadAllText(jsonData);
            schoolData = JsonSerializer.Deserialize<DataModel>(jsonString);
        }

        public List<string> getRoomList()
        {
            return schoolData.rooms;
        }

    }
}
