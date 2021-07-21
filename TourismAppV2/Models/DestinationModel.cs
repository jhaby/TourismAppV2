using System;
using System.Collections.Generic;
using System.Text;

namespace TourismAppV2.Models
{
    public class DestinationModel
    {
        public int ItemId { get; set; }
        public string CardAuthor { get; set; }
        public string CardImage { get; set; }
        public string CardTitle { get; set; }
        public string CardDetails { get; set; }
        public int Likes { get; set; }
        public string Location { get; set; }
        public bool BookMark { get; set; }
        public DateTime DateTime { get; set; }
    }
}
