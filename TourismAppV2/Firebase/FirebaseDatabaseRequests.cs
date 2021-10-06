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

        public async Task UpdateProfilePhoto(ProfileModel user)
        {
            var profile = (await firebase
             .Child("UserProfiles")
             .OnceAsync<ProfileModel>()).Where(a => a.Object.UserId == user.UserId).FirstOrDefault();

            await firebase
                .Child("UserProfiles")
                .Child(profile.Key)
                .PutAsync(user);
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
                  Phone = item.Object.Phone,
                  PhotoUri = item.Object.PhotoUri,
                  UserId = item.Key
              }).ToList();

            return data.Where(a => a.Email == email).FirstOrDefault();

        }

        public async Task SaveTimelineData(dynamic data, string location)
        {
            await firebase.Child("UploadedData")
                .Child(location)
                .PostAsync(data);
        }

        public async Task<List<TimelineModel>> GetTimelineData()
        {
                var response = (await firebase
                    .Child("UploadedData")
                    .Child("Accomodation")
                    .OnceAsync<TimelineModel>()).Select(item => new TimelineModel
                    {
                        ItemId = item.Key,
                        CardAuthor = item.Object.CardAuthor,
                        CardImage = item.Object.CardImage,
                        CardDetails = item.Object.CardDetails,
                        CardTitle = item.Object.CardTitle,
                        Cost = item.Object.Cost,
                        DateTime = item.Object.DateTime,
                        Icon = item.Object.Icon
                    }).ToList();

                return response;
            
        }

        public async Task<List<DestinationModel>> GetDestinationData()
        {
            var response = (await firebase
                .Child("UploadedData")
                .Child("Destination")
                .OnceAsync<DestinationModel>()).Select(item => new DestinationModel
                {
                    ItemId = item.Key,
                    CardAuthor = item.Object.CardAuthor,
                    CardImage = item.Object.CardImage,
                    CardDetails = item.Object.CardDetails,
                    CardTitle = item.Object.CardTitle,
                    DateTime = item.Object.DateTime,
                    Icon = item.Object.Icon,
                    BookMark = item.Object.BookMark,
                    Location = item.Object.Location,
                    Likes = item.Object.Likes
                }).ToList();

            return response;

        }

        public async Task<List<RestaurantModel>> GetRestaurantData()
        {
            var response = (await firebase
                .Child("UploadedData")
                .Child("Restaurants")
                .OnceAsync<RestaurantModel>()).Select(item => new RestaurantModel
                {
                    Category = item.Object.Category,
                    RestaurantId = item.Key,
                    Image = item.Object.Image,
                    Likes = item.Object.Likes,
                    Location = item.Object.Location,
                    Name = item.Object.Name,
                    WorkingHours = item.Object.WorkingHours
                }).ToList();

            return response;
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
