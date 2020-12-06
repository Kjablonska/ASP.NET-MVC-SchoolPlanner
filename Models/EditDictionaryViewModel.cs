using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SchoolPlanner.Models
{
    public class EditDictionaryViewModel {
        public string dictionaryName { get; set; }
        public List<string> dictionaryItem {get; set;}
    }
}