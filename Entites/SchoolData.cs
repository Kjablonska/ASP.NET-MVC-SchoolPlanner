using System.Collections.Generic;

namespace SchoolPlanner.Entities
{
    public class SchoolData
    {
        public List<ActivityData> activities { get; set; }
        public List<string> classes { get; set; }
        public List<string> groups { get; set; }
        public List<string> rooms { get; set; }
        public List<string> teachers { get; set; }

        public SchoolData()
        {
            activities = new List<ActivityData>();
            classes = new List<string>();
            groups = new List<string>();
            rooms = new List<string>();
            teachers = new List<string>();
        }

    }
}

