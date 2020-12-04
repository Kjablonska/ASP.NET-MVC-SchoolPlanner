using System.Collections.Generic;

namespace SchoolPlanner.Entities {
    public class SchoolData
    {
        public List<ActivityData> activities { get; set; }
        public List<string> classes { get; set; }
        public List<string> groups { get; set; }
        public List<string> rooms { get; set; }
        public List<string> teachers { get; set; }

    }
}

