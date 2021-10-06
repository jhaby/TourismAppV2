using System;
using System.Collections.Generic;
using System.Text;

namespace TourismAppV2.Models
{
    public class DestinationModel : TimelineModel
    {
        public int Likes { get; set; }
        public string Location { get; set; }
        public bool BookMark { get; set; }
    }
}
