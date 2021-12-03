using Firebase.Auth;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourismAppV2.Helpers;
using TourismAppV2.Models;
using Xamarin.Essentials;

namespace TourismAppV2.Firebase
{
    public class FirebaseDatabaseRequests
    {
        private string email = null;
        private string password = null;
        public FirebaseDatabaseRequests()
        {

        }
        private async Task<FirebaseClient> LoginAsync()
        {
            var authprovider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseAssets.WebAPIKey));
            return new FirebaseClient(FirebaseAssets.FirebaseDBUri);
            //var authrequest = await authprovider.SignInWithEmailAndPasswordAsync(email, password);
            //return new FirebaseClient(FirebaseAssets.FirebaseDBUri, new FirebaseOptions
            //{
            //    AuthTokenAsyncFactory = () => Task.FromResult(authrequest.FirebaseToken)
            //});
        }
        public async Task<dynamic> LoadBalanceData(string userid)
        {
           var firebase = await LoginAsync();

            var response = (await firebase
                .Child("Finances")
                .Child("AccountBalance")
                .Child(userid)
                .OnceAsync<dynamic>()).FirstOrDefault();

            return response;
        }
        public async Task SaveProfileData(SignupModel data)
        {
            var firebase = await LoginAsync();

            await firebase
                .Child("UserProfiles")
                .PostAsync(data);
        }

        public async Task UpdateProfilePhoto(ProfileModel user)
        {
            var firebase = await LoginAsync();

            var profile = (await firebase
             .Child("UserProfiles")
             .OnceAsync<ProfileModel>()).Where(a => a.Key == user.UserId).FirstOrDefault();

            await firebase
                .Child("UserProfiles")
                .Child(profile.Key)
                .PutAsync(user);
        }
        public async Task<List<DestinationModel>> GetDashboardData()
        {
            var firebase = await LoginAsync();

            return (await firebase
                .Child("Dashboard")
                .OnceAsync<DestinationModel>()).Select(item => new DestinationModel { }).ToList();
        }
        public async Task<List<ServiceProviders>> GetRegistrationCodes()
        {
            var firebase = await LoginAsync();

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

        public async Task CreateNewRegCode(ServiceProviders data)
        {
            var firebase = await LoginAsync();

            await firebase.Child("ServiceProviders")
                .PostAsync(data);
        }

        public async Task<ServiceProviders> GetServiceProviderData(string email)
        {
            var firebase = await LoginAsync();

            var data = (await firebase
                .Child("ServiceProviders")
                .OnceAsync<ServiceProviders>())
                .Select(item => new ServiceProviders
                {
                    ActivationStatus = item.Object.ActivationStatus,
                    ContactEmail = item.Object.ContactEmail,
                    ContactPerson = item.Object.ContactPerson,
                    ContactPhone = item.Object.ContactPhone,
                    Location = item.Object.Location,
                    ServiceType = item.Object.ServiceType,
                    ProviderName = item.Object.ProviderName,
                    RegCode = item.Object.RegCode,
                    Username = item.Object.Username,
                    Key = item.Key
                }).ToList();

            return data.Find(a => a.ContactEmail == email);
        }
        public async Task<ProfileModel> GetProfileData(string email)
        {
            var firebase = await LoginAsync();

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

        public async Task SaveTimelineData(DestinationModel data)
        {
            var firebase = await LoginAsync();

            await firebase.Child("UploadedData")
                .Child("Destination")
                .PostAsync(data);
        }

        public async Task SaveTimelineData(TimelineModel data)
        {
            var firebase = await LoginAsync();

            await firebase.Child("UploadedData")
                .Child("Accomodation")
                .PostAsync(data);
        }

        

        public async Task<List<TimelineModel>> GetTimelineData()
        {
            var firebase = await LoginAsync();

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
            var firebase = await LoginAsync();

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
                    Location = item.Object.Location,
                    Likes = item.Object.Likes,
                    Cost = item.Object.Cost
                }).ToList();

            return response;

        }

        public async Task<List<RestaurantModel>> GetRestaurantData()
        {
            var firebase = await LoginAsync();

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

        public async Task SaveBookingData(BookingModel data, string category)
        {
            var firebase = await LoginAsync();

            await firebase
                .Child("Booking")
                .Child(category)
                .PostAsync(data);
        }

        public async Task<List<BookingModel>> GetAllBookingData(string userid)
        {
            var firebase = await LoginAsync();

            var response = (await firebase
                .Child("Booking")
                .Child("Accomodation")
                .OnceAsync<BookingModel>()).Select(item => new BookingModel
                {
                    ItemId = item.Object.ItemId,
                    Status = item.Object.Status,
                    BookingDate = item.Object.BookingDate,
                    Id = item.Key,
                    Description = item.Object.Description,
                    Title = item.Object.Title,
                    Category = item.Object.Category,
                    Charge = item.Object.Charge,
                    UserId = item.Object.UserId,
                }).ToList();

            return response;
        }

        //public async Task UploadData()
        //{
        //var firebase = await LoginAsync();
        //
        //    var toUpdatePerson = (await firebase
        //      .Child("Persons")
        //      .OnceAsync<DestinationModel>()).Where(a => a.Object.PersonId == personId).FirstOrDefault();
        //
        //    await firebase
        //      .Child("Persons")
        //      .Child(toUpdatePerson.Key)
        //      .PutAsync(new DestinationModel() { PersonId = personId, Name = name });
        //}
    }
}
