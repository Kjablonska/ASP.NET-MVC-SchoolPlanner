using System.Collections.Generic;
using System.ComponentModel;

namespace SchoolPlanner.Entities {
    public class SchoolData
    {
        public List<ActivityData> activities { get; set; }
        [DefaultValue("")]
        public List<string> classes { get; set; }
        [DefaultValue("")]
        public List<string> groups { get; set; }
        [DefaultValue("")]
        public List<string> rooms { get; set; }
        [DefaultValue("")]
        public List<string> teachers { get; set; }

    }
}

