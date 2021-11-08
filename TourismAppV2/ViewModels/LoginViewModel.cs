using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Firebase.Auth;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TourismAppV2.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {

        }
        public async Task<bool> Login(string email, string pass)
        {
            var authprovider = new FirebaseAuthProvider(new FirebaseConfig(Helpers.FirebaseAssets.WebAPIKey));
            try
            {
                var authrequest = await authprovider.SignInWithEmailAndPasswordAsync(email, pass);
                var response = await authrequest.GetFreshAuthAsync();
                var credentials = JsonConvert.SerializeObject(response);

                Preferences.Set("email", email);
                Preferences.Set("password", pass);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
