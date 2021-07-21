using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourismAppV2.Models
{
    public class ProfileModel : INotifyPropertyChanged
    {
        private string fullname;
        private string email;
        private string contact;
        private string gender;

        public string Fullname { get => fullname; set { fullname = value; OnPropertyChanged("Fullname"); } }
        public string Email { get => email; set{ email = value; OnPropertyChanged("Email"); } }
        public string Contact { get => contact; set { contact = value; OnPropertyChanged("Contact"); } }
        public string Gender { get => gender; set{ gender = value; OnPropertyChanged("Gender"); } }
        private void OnPropertyChanged(string member) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
