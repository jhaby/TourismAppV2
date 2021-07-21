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
    public partial class SitesPage : ContentPage
    {
        public SitesPage()
        {
            InitializeComponent();
            TimelineViewModel context = new TimelineViewModel();
            context.LoadDestinationData();
            timeline.ItemsSource = context.destinationItems;
        }
    }
}