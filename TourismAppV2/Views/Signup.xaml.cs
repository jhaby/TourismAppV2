using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TourismAppV2.Helpers;
using Xamarin.Essentials;
using Newtonsoft.Json;

namespace TourismAppV1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        public string gender = "Male";
        public Signup()
        {
            InitializeComponent();
        }

        private async void Signup_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Email.Text))
            {
                Email.Focus();
            }
            else if (string.IsNullOrEmpty(Password.Text) || Password.Text.Length < 8)
            {
                Password.Focus();
            }
            else if(Password.Text != confirmPass.Text)
            {
                confirmPass.Focus();
            }
            else
            {
                indicator.IsVisible = true;
                try
                {
                    var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseAssets.WebAPIKey));
                    var request = await authProvider.CreateUserWithEmailAndPasswordAsync(Email.Text, Password.Text);
                    var response = request.RefreshToken;

                    dynamic details = new
                    {
                        Firstname = fname.Text,
                        Lastname = lname.Text,
                        Country = country.Text,
                        Phone = phone.Text,
                        Email = Email.Text,
                        Gender = gender

                    };
                    string userdata = JsonConvert.SerializeObject(details);
                    Preferences.Set("userdata", userdata);

                    await DisplayAlert("Created", "Account has been successfully created", "OK");
                    await Navigation.PopAsync();
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Failed", ex.Message, "OK");
                }
                indicator.IsVisible = false;
            }
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            RadioButton radio = (RadioButton)sender;
            gender = (string)radio.Value;
        }
    }
}