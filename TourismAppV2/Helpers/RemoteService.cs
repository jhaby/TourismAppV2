using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Firebase;
using TourismAppV2.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TourismAppV2.Helpers
{
    public class RemoteService
    {
        private HttpClient _client;
        private FirebaseDatabaseRequests firebase;
        public RemoteService()
        {
            _client = new HttpClient();
            firebase = new FirebaseDatabaseRequests();
        }
        public async Task<string> ValidateCodeAsync(string code)
        {
            string data = null;
            try
            {
                var response = await _client.GetAsync("https://caninesafaris.com/tourism/validate.php?code=" + code);
                response.EnsureSuccessStatusCode();
                data = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    var sam = JsonConvert.DeserializeObject<ServiceProviders>(data);
                    await firebase.CreateNewRegCode(sam);

                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        
                        await Application.Current.MainPage.DisplayAlert("Test", sam.ContactPerson, "Cancel");
                                                
                    });
                    return data;
                }
                else
                {
                    MainThread.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.DisplayAlert("Else", await response.Content.ReadAsStringAsync(), "Cancel");
                    });

                    return null;
                }
            }
            catch
            {
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                   await Application.Current.MainPage.DisplayAlert("Title", data, "Cancel");
                });
                return null;
            }
        }
    }
}
