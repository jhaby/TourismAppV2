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
            string userdata = Preferences.Get("userdata", null);
            if (!string.IsNullOrEmpty(userdata))
            {
                dynamic data = JsonConvert.DeserializeObject(userdata);
                ProfileModel profile = new ProfileModel
                {
                    Fullname = data.Firstname +" "+ data.Lastname,
                    Email = data.Email,
                    Contact = data.Phone,
                    Gender = data.Gender
                };

                BindingContext = profile;
            }
            else
            {

                BindingContext = new ProfileModel();
            }
        }
    }
}