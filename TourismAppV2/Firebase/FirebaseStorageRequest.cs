using System;
using System.Collections.Generic;
using System.Text;
using TourismAppV2.Helpers;
using Firebase.Storage;
using System.Threading.Tasks;
using System.IO;

namespace TourismAppV2.Firebase
{
    public class FirebaseStorageRequest
    {
        private FirebaseStorage firebase;
        public FirebaseStorageRequest()
        {
            firebase = new FirebaseStorage(FirebaseAssets.FirebaseStorageUri);
        }

        public async Task<string> SaveImageAsync(Stream imgStream, string uri)
        {
            var stroageImage = await firebase
                .Child("Images")
                .Child(uri+".jpg")
                .PutAsync(imgStream);
            string imgurl = stroageImage;
            return imgurl;
        }
    }
}
