using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Firebase;
using TourismAppV2.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TourismAppV2.ViewModels
{
    public class TimelineViewModel
    {
        public ObservableCollection<TimelineModel> timelineItems { get; set; }
        public ObservableCollection<DestinationModel> destinationItems { get; set; }

        private FirebaseDatabaseRequests firebase;

        public Command<string> BookingCommand { get; set; }
        public Command<string> ReservationCommand { get; set; }
        public TimelineViewModel()
        {
            BookingCommand = new Command<string>(BookingTapped);
            ReservationCommand = new Command<string>(MakeResevation);
            timelineItems = new ObservableCollection<TimelineModel>();
            destinationItems = new ObservableCollection<DestinationModel>();
            firebase = new FirebaseDatabaseRequests();
            
        }

        private void MakeResevation(string obj)
        {
            return;
        }

        private void BookingTapped(string id)
        {
            return;
        }

        public async void LoadTimelineData()
        {
            timelineItems.Add(new TimelineModel
            {
                ItemId = "1",
                CardAuthor = "Jeremiah Travels",
                CardTitle = "Virunga Hotels and Bar",
                CardDetails = "Come enjoy the luxury of Mt. Mufumbiro with the lovely view of our hotel rooms",
                Cost = "200USD - 250USD/ room",
                DateTime = DateTime.Now,
                Icon = "home.png",
                CardImage="hotel1.jpg"
            });

            await Task.Run(async() =>
            {
                var data = await firebase.GetTimelineData();
                MainThread.BeginInvokeOnMainThread(()=>
                {
                    foreach(var item in data)
                    {
                        timelineItems.Add(item);
                    }
                });
            });
            
        }

        public async void LoadDestinationData()
        {
            destinationItems.Add(new DestinationModel
            {
                ItemId = "1",
                CardAuthor = "Gorrila Tours Uganda",
                CardTitle = "Mgahinga National Park",
                CardDetails = "Located on river Nile and Home of buffalos, with multiple waterfalls, known for its fresh water",
                CardImage = "chimp.jpg",
                BookMark = false,
                Likes = 23,
                Location = "UGANDA - NorthWestern region"
            });

            await Task.Run(async () =>
            {
                var data = await firebase.GetDestinationData();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var item in data)
                    {
                        destinationItems.Add(item);
                    }
                });
            });

        }
    }
}
