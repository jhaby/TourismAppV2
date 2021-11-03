using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using TourismAppV2.Dialogs.CustomDialogs;

namespace TourismAppV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        private ProfileModel profile;

        public ProfilePage()
        {
            InitializeComponent();

            profile = new ProfileModel();
            string userdata = Preferences.Get("userdata", null);
            if (!string.IsNullOrEmpty(userdata))
            {
                profile = JsonConvert.DeserializeObject<ProfileModel>(userdata);
                
                BindingContext = profile;
            }
            else
            {

                BindingContext = profile;
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                if (photo == null)
                {
                    return;
                }
                await PopupNavigation.Instance.PushAsync(new LoadingDialog("Uploading photo..."));
                using (var stream = await photo.OpenReadAsync())
                {
                    var firebaseStorage = new Firebase.FirebaseStorageRequest();
                    var firebaseDB = new Firebase.FirebaseDatabaseRequests();
                    string uri = profile.Lastname + profile.Firstname + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss");
                    string location = await firebaseStorage.SaveImageAsync(stream, "ProfilePics", uri);
                    profile.PhotoUri = location;
                    await firebaseDB.UpdateProfilePhoto(profile);

                }

                await PopupNavigation.Instance.PopAsync();

            }
            catch (PermissionException pEx)
            {
                await DisplayAlert("Permission", "App has no permission to access your gallery", "Cancel");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failed", ex.Message , "Cancel");
            }
        }
    }
}