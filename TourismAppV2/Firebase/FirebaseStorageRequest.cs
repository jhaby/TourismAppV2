using System;
using System.Collections.Generic;
using System.Text;
using TourismAppV2.Helpers;
using Firebase.Storage;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Essentials;
using Firebase.Auth;

namespace TourismAppV2.Firebase
{
    public class FirebaseStorageRequest
    {
        private FirebaseStorage firebase;
        private FirebaseAuthProvider auth;

        public FirebaseStorageRequest()
        {
            firebase = new FirebaseStorage(FirebaseAssets.FirebaseStorageUri,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(Preferences.Get("fToken", null)),
                    ThrowOnCancel = false
                });

        }

        public async Task<string> SaveImageAsync(Stream imgStream, string location, string uri)
        {
            var storageImage = await firebase
                .Child("Images")
                .Child(location)
                .Child(uri + ".jpg")
                .PutAsync(imgStream);

            return storageImage;
        }
    }
}
