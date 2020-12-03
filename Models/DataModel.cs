using System.Collections.Generic;

namespace Data.Models
{

    public class ActivityData
    {
        public string clas { get; set; }
        public string day { get; set; }
        public string group { get; set; }
        public string room { get; set; }
        public int slot { get; set; }
        public string teacher { get; set; }
    }

    public class DataModel
    {
        public List<ActivityData> activities { get; set; }
        public List<string> classes { get; set; }
        public List<string> groups { get; set; }
        public List<string> rooms { get; set; }
        public List<string> teachers { get; set; }

        public ActivityData getActivity(string room, int slot, string day) {
            foreach (var activity in activities) {
                if (activity.room == room && activity.slot == slot && activity.day == day)
                    return activity;
            }

            return new ActivityData();
        }

    }

}