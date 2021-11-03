using System;
using System.Collections.Generic;
using System.Text;

namespace TourismAppV2.Models
{
    public class BookingModel
    {
        public string Id { get; set; }
        public string ItemId { get; set; }
        public string UserId { get; set; }
        public string ServiceProvider { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Charge { get; set; }
        public int AmountPaid { get; set; }
        public int Balance { get; set; }
        public DateTime BookingDate { get; set; }
        public bool Status { get; set; }
    }
}
