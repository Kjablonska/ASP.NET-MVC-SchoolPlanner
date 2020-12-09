using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolPlanner.Models
{
    public class EditEntryViewModel
    {
        public IEnumerable<SelectListItem> groupsItems { get; set; }
        public IEnumerable<SelectListItem> classesItems { get; set; }
        public IEnumerable<SelectListItem> teachersItems { get; set; }

        public string group { get; set; }
        public string clas { get; set; }
        public string teacher { get; set; }

    }
}