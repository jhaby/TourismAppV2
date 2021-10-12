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

namespace TourismAppV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinancePage : ContentPage
    {
        private FinanceViewModel viewModel;
        public FinancePage()
        {
            InitializeComponent();
            viewModel = new FinanceViewModel(JsonConvert.DeserializeObject<ProfileModel>(
                Preferences.Get("userdata", null)));

            viewModel.LoadFinanceData();
            BindingContext = viewModel;
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            bool response = await DisplayAlert("Payment", "You are about to be redirected to a secure site to make a payment. Do you want to continue?", "Yes", "No");
            if (response)
            {
                await Browser.OpenAsync("https://flutterwave.com/pay/huktsurczsaf");
            }
            else
            {
                return;
            }
        }

    }
}