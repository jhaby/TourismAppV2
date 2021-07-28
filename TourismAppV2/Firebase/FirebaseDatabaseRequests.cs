using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Helpers;
using TourismAppV2.Models;

namespace TourismAppV2.Firebase
{
    public class FirebaseDatabaseRequests
    {
        private FirebaseClient firebase = new FirebaseClient(FirebaseAssets.FirebaseDBUri);
        public FirebaseDatabaseRequests()
        {

        }
        public async Task SaveProfileData(SignupModel data)
        {
            await firebase
                .Child("UserProfiles")
                .PostAsync(data);
        }
        public async Task<List<DestinationModel>> GetDashboardData()
        {
            return (await firebase
                .Child("Dashboard")
                .OnceAsync<DestinationModel>()).Select(item => new DestinationModel { }).ToList();
        }
        public async Task<List<ServiceProviders>> GetRegistrationCodes()
        {
            return (await firebase.Child("ServiceProviders")
                .OnceAsync<ServiceProviders>()).Select(item => new ServiceProviders
                {
                    ActivationStatus = item.Object.ActivationStatus,
                    ContactEmail = item.Object.ContactEmail,
                    ContactPerson = item.Object.ContactPerson,
                    ContactPhone = item.Object.ContactPhone,
                    Location = item.Object.Location,
                    ServiceType = item.Object.ServiceType,
                    ProviderName = item.Object.ProviderName,
                    RegCode = item.Object.RegCode,
                    Username = item.Object.Username
                }).ToList();
        }
        public async Task<ProfileModel> GetProfileData(string email)
        {
            var data = (await firebase
              .Child("UserProfiles")
              .OnceAsync<ProfileModel>()).Select(item => new ProfileModel
              {
                  Email = item.Object.Email,
                  Agreement = item.Object.Agreement,
                  ConfirmPassword = item.Object.ConfirmPassword,
                  Country = item.Object.Country,
                  IsServiceProvider = item.Object.IsServiceProvider,
                  Firstname = item.Object.Firstname,
                  IsRegularUser = item.Object.IsRegularUser,
                  Lastname = item.Object.Lastname,
                  Password = item.Object.Password,
                  Phone = item.Object.Phone
              }).ToList();

            return data.Where(a => a.Email == email).FirstOrDefault();

        }
        //public async Task UploadData()
        //{
        //    var toUpdatePerson = (await firebase
        //      .Child("Persons")
        //      .OnceAsync<DestinationModel>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();

        //    await firebase
        //      .Child("Persons")
        //      .Child(toUpdatePerson.Key)
        //      .PutAsync(new DestinationModel() { PersonId = personId, Name = name });
        //}
    }
}
