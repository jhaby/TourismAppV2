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

namespace TourismAppV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinancePage : ContentPage
    {
        public FinancePage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            bool response = await DisplayAlert("Deposit funds", "You will be redirect to a secure page to make your deposit, is that ok with you?", "Continue", "No, cancel");
            if (response)
            {
                await Browser.OpenAsync("https://flutterwave.com/pay/huktsurczsaf");
            }
            else
                return;
        }

        private async void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            CrossToastPopUp.Current.ShowToastWarning("Refreshing account...");

            await PopupNavigation.Instance.PushAsync(new LoadingDialog("Loading financial records..."));
            await Task.Delay(10000);
            CrossToastPopUp.Current.ShowToastSuccess("Account refreshed");

            await PopupNavigation.Instance.PopAsync();
        }
    }
}