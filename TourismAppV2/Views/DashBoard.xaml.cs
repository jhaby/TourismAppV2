using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TourismAppV2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoard : TabbedPage
    {
        private ServiceProviders serviceProvider;
        private ProfileModel profile;

        public DashBoard()
        {
            InitializeComponent();
            profile = JsonConvert.DeserializeObject<ProfileModel>(Preferences.Get("userdata", null));

            if (profile.IsServiceProvider)
            {
                serviceProvider = JsonConvert.DeserializeObject<ServiceProviders>(Preferences.Get("serviceProvider", null));
                
            }
        }
    }
}