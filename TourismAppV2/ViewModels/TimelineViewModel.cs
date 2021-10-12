using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Firebase;
using TourismAppV2.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using TourismAppV2.Dialogs.CustomDialogs;

namespace TourismAppV2.ViewModels
{
    public class TimelineViewModel : BaseViewModel
    {
        public ObservableCollection<TimelineModel> TimelineItems
        {
            get => timelineItems;
            set
            {
                timelineItems = value;
                OnPropertyChanged(nameof(TimelineItems));
            }
        }
        public ObservableCollection<DestinationModel> destinationItems { get; set; }

        private FirebaseDatabaseRequests firebase;
        private ProfileModel profile;
        private ObservableCollection<TimelineModel> timelineItems;

        public Command<TimelineModel> BookingCommand { get; set; }
        public Command<DestinationModel> ReservationCommand { get; set; }
        public TimelineViewModel()
        {
            profile = new ProfileModel();
            BookingCommand = new Command<TimelineModel>(BookingTapped);
            ReservationCommand = new Command<DestinationModel>(MakeResevation);
            TimelineItems = new ObservableCollection<TimelineModel>();
            destinationItems = new ObservableCollection<DestinationModel>();
            firebase = new FirebaseDatabaseRequests();
            string userdata = Preferences.Get("userdata", null);
            profile = JsonConvert.DeserializeObject<ProfileModel>(userdata);
            LoadTimelineData();

        }

        private void MakeResevation(DestinationModel item)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    bool response = await Application.Current.MainPage.DisplayAlert("Confirm",
                        $"You are about to book a room with {item.CardAuthor} at ${item.Cost}, do you want to continue?", "YES", "NO");

                    if (response)
                    {
                        await PopupNavigation.Instance.PushAsync(new LoadingDialog("Sending booking data..."));
                        BookingModel book = new BookingModel
                        {
                            UserId = profile.UserId,
                            Description = item.CardDetails,
                            Title = item.CardTitle,
                            BookingDate = DateTime.Now,
                            Category = "Accomodation",
                            Status = false,
                            Charge = item.Cost,
                            ItemId = item.ItemId,
                            ServiceProvider = item.CardAuthor
                        };

                        await firebase.SaveBookingData(book, "Accomodation");
                        await PopupNavigation.Instance.PopAsync();
                    }

                }
                catch
                {
                    return;
                }
            });
        }

        private void BookingTapped(TimelineModel item)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    bool response = await Application.Current.MainPage.DisplayAlert("Confirm", 
                        $"You are about to book a room with {item.CardAuthor} at ${item.Cost}, do you want to continue?", "YES", "NO");

                    if (response)
                    {
                        await PopupNavigation.Instance.PushAsync(new LoadingDialog("Sending booking data..."));
                        BookingModel book = new BookingModel
                        {
                            UserId = profile.UserId,
                            Description = item.CardDetails,
                            Title = item.CardTitle,
                            BookingDate = DateTime.Now,
                            Category = "Accomodation",
                            Status = false,
                            Charge = item.Cost,
                            ItemId = item.ItemId,
                            ServiceProvider = item.CardAuthor
                        };
                       
                        await firebase.SaveBookingData(book, "Accomodation");
                        await PopupNavigation.Instance.PopAsync();
                    }
                    
                }
                catch
                {
                    return;
                }
            });
        }

        public async void LoadTimelineData()
        {
            TimelineItems.Add(new TimelineModel
            {
                ItemId = "1",
                CardAuthor = "Jeremiah Travels",
                CardTitle = "Virunga Hotels and Bar",
                CardDetails = "Come enjoy the luxury of Mt. Mufumbiro with the lovely view of our hotel rooms",
                Cost = 200,
                DateTime = DateTime.Now.ToString(),
                Icon = "home.png",
                CardImage = "hotel1.jpg"
            });

            await Task.Run(async () =>
            {
                var data = await firebase.GetTimelineData();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var item in data)
                    {
                        TimelineItems.Add(item);
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
