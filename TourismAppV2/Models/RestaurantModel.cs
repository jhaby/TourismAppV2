using System;
using System.Collections.Generic;
using System.Text;

namespace TourismAppV2.Models
{
    public  class RestaurantModel
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string WorkingHours { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public int Likes { get; set; }
    }
}
