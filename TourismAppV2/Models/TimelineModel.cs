using System;
using System.Collections.Generic;
using System.Text;

namespace TourismAppV2.Models
{
    public class TimelineModel
    {
        public string ItemId { get; set; }
        public string CardAuthor { get; set; }
        public string Icon { get; set; }
        public string CardImage { get; set; }
        public string CardTitle { get; set; }
        public string CardDetails { get; set; }
        public int Cost { get; set; }
        public string DateTime { get; set; }
    }
}
