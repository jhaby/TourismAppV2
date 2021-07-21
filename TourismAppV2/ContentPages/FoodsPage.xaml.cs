using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TourismAppV2.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodsPage : ContentPage
    {
        public FoodsPage()
        {
            InitializeComponent();
            RestaurantViewModel context = new RestaurantViewModel();
            context.LoadRestaurants();
            BindingContext = context;
            timeline.ItemsSource = context.restaurants;
        }
    }
}