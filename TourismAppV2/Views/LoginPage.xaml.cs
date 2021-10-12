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
using TourismAppV2.Views.ServiceProviderViews;

namespace TourismAppV1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private FirebaseDatabaseRequests firebase;

        public LoginPage()
        {
            InitializeComponent();
            firebase = new FirebaseDatabaseRequests();
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

                    var userdata = await firebase.GetProfileData(Email.Text);

                    Preferences.Clear();
                    Preferences.Set("userdata", JsonConvert.SerializeObject(userdata));

                    if (userdata.IsServiceProvider)
                    {
                        var data = await firebase.GetServiceProviderData(userdata.Email);
                        Preferences.Set("serviceProvider", JsonConvert.SerializeObject(data));

                        await Navigation.PushAsync(new SpMainPage());
                    }
                    else
                    {
                        await Navigation.PushAsync(new HomePage());
                    }

                    

                }
                catch(Exception ex)
                {
                    await DisplayAlert("Access denied", "Wrong username or password", "OK");
                }
                finally
                {
                    await PopupNavigation.Instance.PopAsync();
                }
            }
            
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //await PopupNavigation.Instance.PushAsync(new LoadingDialog("creating user..."));
            //await firebase.CreateNewRegCode();
            //await PopupNavigation.Instance.PopAsync();
            var response = await DisplayPromptAsync("Forgot password", "Enter your email to receive reset code", "Ok", "Cancel", "Email*");
        }
    }
}