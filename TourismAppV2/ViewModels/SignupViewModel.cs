using Firebase.Auth;
using Newtonsoft.Json;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Dialogs.CustomDialogs;
using TourismAppV2.Firebase;
using TourismAppV2.Helpers;
using TourismAppV2.Models;
using TourismAppV2.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TourismAppV2.ViewModels
{
    public class SignupViewModel
    {
        public SignupModel dataModel = new SignupModel();
        public SignupViewModel()
        {
            dataModel.GenderSet = new Command((value) => dataModel.GenderValue = (string)value);
            
        }
       
    }
}
