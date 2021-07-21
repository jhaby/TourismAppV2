using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TourismAppV2.Models;

namespace TourismAppV2.ViewModels
{
    public class TimelineViewModel
    {
        public ObservableCollection<TimelineModel> timelineItems { get; set; }
        public ObservableCollection<DestinationModel> destinationItems { get; set; }
        public TimelineViewModel()
        {
            timelineItems = new ObservableCollection<TimelineModel>();
            destinationItems = new ObservableCollection<DestinationModel>();
            
        }
        public void LoadTimelineData()
        {
            timelineItems.Add(new TimelineModel
            {
                ItemId = 1,
                CardAuthor = "Jeremiah Travels",
                CardTitle = "Virunga Hotels and Bar",
                CardDetails = "Come enjoy the luxury of Mt. Mufumbiro with the lovely view of our hotel rooms",
                Cost = "200USD - 250USD/ room",
                DateTime = DateTime.Now,
                Icon = "home.png",
                CardImage="hotel1.jpg"
            });
            timelineItems.Add(new TimelineModel
            {
                ItemId = 1,
                CardAuthor = "Martin travels LTD",
                CardTitle = "Virunga Hotels and Bar",
                CardDetails = "Come enjoy the luxury of Mt. Mufumbiro with the lovely view of our hotel rooms",
                Cost = "200USD - 250USD/ room",
                DateTime = DateTime.Now,
                Icon = "home.png",
                CardImage = "hotel3.jpg"
            });
            timelineItems.Add(new TimelineModel
            {
                ItemId = 1,
                CardAuthor = "Gorrila Travels Uganda and Sons",
                CardTitle = "Hotel Triangular",
                CardDetails = "Come enjoy the luxury of Mt. Mufumbiro with the lovely view of our hotel rooms",
                Cost = "200USD - 250USD/ room",
                DateTime = DateTime.Now,
                Icon = "hotel4.png",
                CardImage = "hotel4.jpg"
            });
            timelineItems.Add(new TimelineModel
            {
                ItemId = 1,
                CardAuthor = "Gorrila Travels Uganda and Sons",
                CardTitle = "Acacia palms Dar-es-Salaam",
                CardDetails = "Come enjoy the luxury of Mt. Mufumbiro with the lovely view of our hotel rooms",
                Cost = "200USD - 250USD/ room",
                DateTime = DateTime.Now,
                Icon = "hotel4.png",
                CardImage = "hotel5.jpg"
            });
            timelineItems.Add(new TimelineModel
            {
                ItemId = 1,
                CardAuthor = "Gorrila Travels Uganda and Sons",
                CardTitle = "Great Oceans Hotel Zanzibar",
                CardDetails = "Come enjoy the luxury of Mt. Mufumbiro with the lovely view of our hotel rooms",
                Cost = "200USD - 250USD/ room",
                DateTime = DateTime.Now,
                Icon = "hotel4.png",
                CardImage = "hotel6.jpg"
            });
        }

        public void LoadDestinationData()
        {
            destinationItems.Add(new DestinationModel
            {
                ItemId = 1,
                CardAuthor = "Gorrila Tours Uganda",
                CardTitle = "Mgahinga National Park",
                CardDetails = "Located on river Nile and Home of buffalos, with multiple waterfalls, known for its fresh water",
                CardImage = "chimp.jpg",
                BookMark = false,
                Likes = 23,
                Location = "UGANDA - NorthWestern region"
            });
            destinationItems.Add(new DestinationModel
            {
                ItemId = 1,
                CardAuthor = "Matooke Tours LTD",
                CardTitle = "Murchishon Falls",
                CardDetails = "Located on river Nile and Home of buffalos, with multiple waterfalls, known for its fresh water",
                CardImage = "fall1.jpg",
                BookMark = false,
                Likes = 23,
                Location = "UGANDA - NorthWestern region"
            });
            destinationItems.Add(new DestinationModel
            {
                ItemId = 1,
                CardAuthor = "African Pride Tours and travels",
                CardTitle = "Queen Elizabeth NP",
                CardDetails = "Located on river Nile and Home of buffalos, with multiple waterfalls, known for its fresh water",
                CardImage = "photo4.jpg",
                BookMark = false,
                Likes = 23,
                Location = "UGANDA - NorthWestern region"
            });
            destinationItems.Add(new DestinationModel
            {
                ItemId = 1,
                CardAuthor = "African Pride Tours and travels",
                CardTitle = "Queen Elizabeth NP",
                CardDetails = "Located on river Nile and Home of buffalos, with multiple waterfalls, known for its fresh water",
                CardImage = "photo3.jpg",
                BookMark = false,
                Likes = 23,
                Location = "UGANDA - NorthWestern region"
            });
            destinationItems.Add(new DestinationModel
            {
                ItemId = 1,
                CardAuthor = "African Pride Tours and travels",
                CardTitle = "Queen Elizabeth NP",
                CardDetails = "Located on river Nile and Home of buffalos, with multiple waterfalls, known for its fresh water",
                CardImage = "lion.jpg",
                BookMark = false,
                Likes = 23,
                Location = "UGANDA - NorthWestern region"
            });
            destinationItems.Add(new DestinationModel
            {
                ItemId = 1,
                CardAuthor = "African Pride tours and travels",
                CardTitle = "Murchishon Falls",
                CardDetails = "Located on river Nile and Home of buffalos, with multiple waterfalls, known for its fresh water",
                CardImage = "photo2.jpg",
                BookMark = false,
                Likes = 23,
                Location = "UGANDA - NorthWestern region"
            });
        }
    }
}
