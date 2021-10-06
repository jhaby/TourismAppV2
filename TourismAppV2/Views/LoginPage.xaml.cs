using Firebase.Auth;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TourismAppV2.Helpers;
using TourismAppV2.Firebase;
using Xamarin.Essentials;
using Rg.Plugins.Popup.Services;
using TourismAppV2.Dialogs.CustomDialogs;

namespace TourismAppV1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Signup());
        }

        private async void Login_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                Email.Focus();
            }
            else if (string.IsNullOrEmpty(Password.Text))
            {
                Password.Focus();
            }
            else
            {
                await PopupNavigation.Instance.PushAsync(new LoadingDialog("Logging in..."));
                var authprovider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseAssets.WebAPIKey));
                try
                {
                    var authrequest = await authprovider.SignInWithEmailAndPasswordAsync(Email.Text, Password.Text);
                    var response =  authrequest.User;

                    var firebase = new FirebaseDatabaseRequests();
                    var userdata = await firebase.GetProfileData(Email.Text);
                    if (Preferences.ContainsKey("userdata"))
                    {
                        Preferences.Remove("userdata");
                    }
                    Preferences.Set("userdata", JsonConvert.SerializeObject(userdata));

                    if (userdata.IsRegularUser)
                    {
                        await Navigation.PushAsync(new HomePage());
                    }
                    else
                    {
                        return;
                    }

                    
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Access denied", ex.Message, "OK");
                }
                finally
                {
                    await PopupNavigation.Instance.PopAsync();
                }
            }
            
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var response = await DisplayPromptAsync("Forgot password", "Enter your email to receive reset code", "Ok", "Cancel", "Email*");
        }
    }
}