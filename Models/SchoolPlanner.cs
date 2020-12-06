using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolPlanner.Entities;

namespace SchoolPlanner.Models
{
    public class SchoolPlannerViewModel
    {
        public string currentRoom {get; set;}
        public SchoolData roomData;
        public SchoolPlannerViewModel() {

        }
        public string getGroup(string room, int slot, string day) {
            foreach(var data in roomData.activities) {
                if (data.room == room && data.slot == slot && data.day == day)
                    return data.group;
            }

            return " ";
        }

    }
}
