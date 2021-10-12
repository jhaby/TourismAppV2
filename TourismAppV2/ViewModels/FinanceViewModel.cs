using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TourismAppV2.Firebase;
using TourismAppV2.Models;
using Xamarin.Forms;

namespace TourismAppV2.ViewModels
{
    public class FinanceViewModel : BaseViewModel
    {
        private ObservableCollection<BookingModel> financeRecords;
        private ProfileModel profile;
        private FirebaseDatabaseRequests firebase;
        public bool HasHistory { get; set; } = false;
        private string balance;

        public FinanceViewModel(ProfileModel profile)
        {
            FinanceRecords = new ObservableCollection<BookingModel>();
            this.profile = profile;
            firebase = new FirebaseDatabaseRequests();
            ListRefreshCommand = new Command(LoadFinanceData);

        }
        public ObservableCollection<BookingModel> FinanceRecords { get => financeRecords; set => financeRecords = value; }
        public string Balance { get => balance; set => balance = value; }
        public Command ListRefreshCommand { get; set; }
        public async void LoadFinanceData()
        {
            IsBusy = true;
            var result = await firebase.GetAllBookingData(profile.UserId);
            foreach (var i in result)
            {
                financeRecords.Add(i);
            }
            IsBusy = false;
            if(result.Count > 0)
            {
                HasHistory = true;
            }
        }
        //public async void LoadBalance()
        //{
        //    var result = await firebase.LoadBalanceData(profile.UserId);
        //    Balance = result.Value;
        //}
    }
}
