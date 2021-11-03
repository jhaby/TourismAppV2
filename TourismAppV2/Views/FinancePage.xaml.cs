using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Services;
using TourismAppV2.Dialogs.CustomDialogs;
using TourismAppV2.ViewModels;
using Newtonsoft.Json;
using TourismAppV2.Models;
using Flutterwave.Net;

namespace TourismAppV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinancePage : ContentPage
    {
        private ProfileModel profile;

        //private readonly string apiKey = "FLWSECK-df4c34ca9bfcc0756d68c65c564bae61-X"
        private FinanceViewModel viewModel;
        public FinancePage()
        {
            InitializeComponent();
            profile = JsonConvert.DeserializeObject<ProfileModel>(
                Preferences.Get("userdata", null));
            viewModel = new FinanceViewModel(profile);

            viewModel.LoadFinanceData();
            BindingContext = viewModel;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (profile.IsRegularUser)
            {
                bool response = await DisplayAlert("Payment", "You are about to be redirected to a secure site to make a payment. Do you want to continue?", "Yes", "No");
                if (response)
                {
                    await Browser.OpenAsync("https://flutterwave.com/pay/tourismguidepayment");
                }
                else
                {
                    return;
                }
            }
        }

    }
}