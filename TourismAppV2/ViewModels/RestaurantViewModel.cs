using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Firebase;
using TourismAppV2.Models;
using Xamarin.Essentials;

namespace TourismAppV2.ViewModels
{
    public class RestaurantViewModel
    {
        public ObservableCollection<RestaurantModel> restaurants { get; set; }

        private FirebaseDatabaseRequests firebase;

        public RestaurantViewModel()
        {
            restaurants = new ObservableCollection<RestaurantModel>();
            firebase = new FirebaseDatabaseRequests();
        }
        public async void LoadRestaurants()
        {
            restaurants.Add(new RestaurantModel
            {
                RestaurantId = "1",
                Name = "Nicoz Lounge and Bar",
                Location = "Uganda- Mbarara City",
                Category = "Restaurant",
                Image = "food.jpg",
                WorkingHours = "6:00AM - 4:00AM",
                Likes = 300
            });

            await Task.Run(async () =>
            {
                var data = await firebase.GetRestaurantData();
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var item in data)
                    {
                        restaurants.Add(item);
                    }
                });
            });
        }
    }
}
