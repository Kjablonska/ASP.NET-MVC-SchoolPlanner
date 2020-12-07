using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolPlanner.Models
{
    public class EditDictionaryItemViewModel {
        public string dictionaryName { get; set; }
        public string item {get; set;}
    }
}