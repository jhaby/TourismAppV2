using System;
using TourismAppV1.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TourismAppV2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new string[] { "AppTheme_Experimental", "SwipeView_Experimental", "Brush_Experimental", "RadioButton_Experimental", "IndicatorView_Experimental", "CarouselView_Experimental" });
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
