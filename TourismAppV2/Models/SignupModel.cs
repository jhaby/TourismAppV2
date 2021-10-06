using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace TourismAppV2.Models
{
    public class SignupModel : INotifyPropertyChanged
    {
        private bool isServiceProvider = false;
        private string firstname;
        private string lastname;
        private string email;
        private string country;
        private string phone;
        private string password;
        private bool agreement;
        private string username;
        private string genderValue;
        private bool isRegularUser = true;
        private string organisation;
        private string confirmPassword;

        public string PhotoUri { get; set; } = "lion.jpg";
        public bool IsServiceProvider { get => isServiceProvider; set { isServiceProvider = value; OnPropertyChaged("IsServiceProvider"); } }
        public bool IsRegularUser { get => isRegularUser; set { isRegularUser = value; OnPropertyChaged("IsRegularUser"); } }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Email { get => email; set => email = value; }
        public Command GenderSet { get; set; }
        public string GenderValue { get => genderValue; set => genderValue = value; }
        public Command SignUp { get; set; }
        public string Country { get => country; set => country = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }
        public string ConfirmPassword { get => confirmPassword; set => confirmPassword = value; }
        public bool Agreement { get => agreement; set => agreement = value; }
        public string Username { get => username; set => username = value; }
        public string Organisation { get => organisation; set => organisation = value; }



        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChaged(string member) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member));
    }
}
