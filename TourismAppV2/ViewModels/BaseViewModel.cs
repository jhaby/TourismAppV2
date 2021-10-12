using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using TourismAppV2.Models;
using Xamarin.Essentials;

namespace TourismAppV2.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy;

        public bool IsBusy {
            get => isBusy;
            set
            {
                isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string member) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member));

        public ProfileModel Userdata = JsonConvert.DeserializeObject<ProfileModel>(Preferences.Get("userdata", null));
    }
}
