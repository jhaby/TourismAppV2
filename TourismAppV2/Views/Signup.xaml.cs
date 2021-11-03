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
using TourismAppV2.ViewModels;
using TourismAppV2.Firebase;
using TourismAppV2.Models;
using TourismAppV2.Views;
using Rg.Plugins.Popup.Services;
using TourismAppV2.Dialogs.CustomDialogs;
using Plugin.Toast;

namespace TourismAppV1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        private SignupViewModel viewModel;
        private ServiceProviders result;
        private bool isServiceProvider = false;
        private FirebaseDatabaseRequests firebase;

        public Signup()
        {
            InitializeComponent();
            viewModel = new SignupViewModel();
            BindingContext = viewModel.dataModel;
            firebase = new FirebaseDatabaseRequests();
        }

        private async void SwitchBtn_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Text == "Service provider")
            {
                try
                {
                    isServiceProvider = true;
                    string regCode = await DisplayPromptAsync("Confirm", "Enter your registration code", "Verify", "Cancel", "6 digit code", 6);
                    if (string.IsNullOrEmpty(regCode) || regCode.Length < 5)
                    {
                        await DisplayAlert("Invalid input", "Code must be alteast 6 digits", "Cancel");
                    }
                    else
                    {
                        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                        {
                            await PopupNavigation.Instance.PushAsync(new LoadingDialog("Verifying. Please give us a moment..."));

                            RemoteService httpRequest = new RemoteService();
                            string data = await httpRequest.ValidateCodeAsync(regCode);

                            List<ServiceProviders> record = await firebase.GetRegistrationCodes();
                            result = record.Find(a => a.RegCode == regCode);

                            if (result == null)
                            {
                                return;
                            }
                            else
                            {
                                viewModel.dataModel.Organisation = result.ProviderName;
                                viewModel.dataModel.IsServiceProvider = true;
                                viewModel.dataModel.IsRegularUser = false;
                                viewModel.dataModel.Email = result.ContactEmail;
                                ordinary.TextColor = Color.FromHex("#A5005B");
                                ordinary.BackgroundColor = Color.White;
                                provider.TextColor = Color.White;
                                provider.BackgroundColor = Color.FromHex("#A5005B");

                                //await firebase.CreateNewRegCode(result);
                            }
                        }
                        else
                        {
                            await DisplayAlert("Internet", "No internet connection", "OK");
                        }
                    }
                }
                catch(Exception ex)
                {
                    await DisplayAlert("Error", ex.Message, "Cancel");
                }
                finally
                {
                    await PopupNavigation.Instance.PopAsync();
                }
                
            }
            else
            {
                isServiceProvider = false;
                viewModel.dataModel.IsServiceProvider = false;
                viewModel.dataModel.IsRegularUser = true;
                ordinary.TextColor = Color.White;
                ordinary.BackgroundColor = Color.FromHex("#A5005B");
                provider.TextColor = Color.FromHex("#A5005B");
                provider.BackgroundColor = Color.White;
            }
        }

        private async void Signup_Clicked(object sender, EventArgs e)
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new LoadingDialog("Creating your account. Please give us a moment"));

                if (!isServiceProvider)
                {
                    if (!string.IsNullOrEmpty(viewModel.dataModel.Firstname) && !string.IsNullOrEmpty(viewModel.dataModel.Lastname) && !string.IsNullOrEmpty(viewModel.dataModel.Email) && !string.IsNullOrEmpty(viewModel.dataModel.ConfirmPassword))
                    {
                        if (viewModel.dataModel.ConfirmPassword.Length > 7 && viewModel.dataModel.ConfirmPassword == viewModel.dataModel.Password)
                        {
                            var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseAssets.WebAPIKey));
                            var request = await authProvider.CreateUserWithEmailAndPasswordAsync(viewModel.dataModel.Email, viewModel.dataModel.Password);

                        }
                        else
                            await DisplayAlert("Error Password", "Passwords don't match or too short", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Error", "Some fields are not filled", "OK");
                    }
                }
                else
                {
                    if (viewModel.dataModel.ConfirmPassword.Length > 7 && viewModel.dataModel.ConfirmPassword == viewModel.dataModel.Password)
                    {
                        var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseAssets.WebAPIKey));

                        var request = await authProvider.CreateUserWithEmailAndPasswordAsync(result.ContactEmail, viewModel.dataModel.Password);
                        
                    }
                    else
                    {
                        await DisplayAlert("Error Password", "Passwords don't match or too short", "OK");
                    }
                }
                await firebase.SaveProfileData(viewModel.dataModel);
                CrossToastPopUp.Current.ShowToastSuccess("Account created successfully!");
                await Navigation.PushAsync(new LoginPage());


            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                await PopupNavigation.Instance.PopAsync();
            }
        }
    }
}