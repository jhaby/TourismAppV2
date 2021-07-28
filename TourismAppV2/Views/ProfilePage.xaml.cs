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

namespace TourismAppV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

            ProfileModel profile = new ProfileModel();
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
    }
}