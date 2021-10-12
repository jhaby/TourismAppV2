using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TourismAppV2.Models
{
    public class ProfileModel : INotifyPropertyChanged
    {

        private bool agreement;
        private string confirmPassword;
        private string country;
        private string email;
        private string firstname;
        private bool isRegularUser;
        private bool isServiceProvider;
        private string lastname;
        private string password;
        private string phone;
        private string photoUri;
        private string userId;
        private string organisation;

        public string UserId { get => userId; set => userId = value; }
        public string PhotoUri { get => photoUri; set => photoUri = value; }
        public bool Agreement { get => agreement; set => agreement = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        public string Country { get => country; set => country = value; }
        public string Email { get => email; set => email = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public bool IsRegularUser { get => isRegularUser; set => isRegularUser = value; }
        public bool IsServiceProvider { get => isServiceProvider; set => isServiceProvider = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Password { get => password; set => password = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Organisation { get => organisation; set => organisation = value; }
        private void OnPropertyChanged(string member) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member));

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
