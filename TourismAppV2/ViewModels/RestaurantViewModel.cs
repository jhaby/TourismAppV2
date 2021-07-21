using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TourismAppV2.Models;

namespace TourismAppV2.ViewModels
{
    public class RestaurantViewModel
    {
        public ObservableCollection<RestaurantModel> restaurants { get; set; }
        public RestaurantViewModel()
        {
            restaurants = new ObservableCollection<RestaurantModel>();
        }
        public void LoadRestaurants()
        {
            restaurants.Add(new RestaurantModel
            {
                RestaurantId = 1,
                Name = "Nicoz Lounge and Bar",
                Location = "Uganda- Mbarara City",
                Category = "Restaurant",
                Image = "food.jpg",
                WorkingHours = "6:00AM - 4:00AM",
                Likes = 300
            });

            restaurants.Add(new RestaurantModel
            {
                RestaurantId = 1,
                Name = "Spicy African Cuisine",
                Location = "Uganda- Kampala",
                Category = "Restaurant",
                Image = "food3.jpg",
                WorkingHours = "6:00AM - 4:00AM",
                Likes = 78
            });
            restaurants.Add(new RestaurantModel
            {
                RestaurantId = 1,
                Name = "Vegas Club and Hangout Place",
                Location = "Uganda- Mbarara City",
                Category = "Club",
                Image = "food4.jpg",
                WorkingHours = "6:00AM - 4:00AM",
                Likes = 54
            });
            restaurants.Add(new RestaurantModel
            {
                RestaurantId = 1,
                Name = "Nicoz Lounge and Bar",
                Location = "Uganda- Mbarara City",
                Category = "Club",
                Image = "food2.jpg",
                WorkingHours = "6:00AM - 4:00AM",
                Likes = 10
            });
            restaurants.Add(new RestaurantModel
            {
                RestaurantId = 1,
                Name = "Baguma and Sons",
                Location = "Uganda- Mbarara City",
                Category = "Club",
                Image = "food4.jpg",
                WorkingHours = "6:00AM - 4:00AM",
                Likes = 43
            });
        }
    }
}
