using System;

namespace SchoolPlanner.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public string message {get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}