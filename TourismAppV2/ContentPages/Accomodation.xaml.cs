using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Models;
using TourismAppV2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TourismAppV2.ContentPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Accomodation : ContentPage
    {
        private TimelineViewModel context;

        public Accomodation()
        {
            InitializeComponent();
        }

        private async void timeline_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TimelineModel item = e.CurrentSelection.FirstOrDefault() as TimelineModel;
            await DisplayAlert("selected", item.CardDetails, "ok");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("selected", "sample", "ok");
        }
    }
}