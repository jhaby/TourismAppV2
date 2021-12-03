using Newtonsoft.Json;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using TourismAppV2.Dialogs.CustomDialogs;
using TourismAppV2.Firebase;
using TourismAppV2.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TourismAppV2.ViewModels
{
    public class UploadViewModel : BaseViewModel
    {
        private FirebaseDatabaseRequests firebaseDB;
        private FirebaseStorageRequest firebaseStorage;
        public ServiceProviders serviceProvider = new ServiceProviders();
        private string localImgSrc;
        private string data;
        private FileResult photo;

        public UploadViewModel()
        {
            firebaseDB = new FirebaseDatabaseRequests();
            firebaseStorage = new FirebaseStorageRequest();
            data = Preferences.Get("serviceProvider", null);
            serviceProvider = JsonConvert.DeserializeObject<ServiceProviders>(data);
            UploadCommand = new Command(UploadContent);
            ServiceType = serviceProvider.ServiceType;
            GetPhotoCommand = new Command(AttachPhoto);
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public string ServiceType { get; set; }
        public string LocalImgSrc
        {
            get => localImgSrc;
            set
            {
                localImgSrc = value;
                OnPropertyChanged("LocalImgSrc");
            }
        }
        public string ImgUrl { get; set; }

        public Command GetPhotoCommand { get; set; }
        public Command UploadCommand { get; set; }

        private void UploadContent()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await PopupNavigation.Instance.PushAsync(new LoadingDialog("Uploading content..."));

                    if (string.IsNullOrEmpty(LocalImgSrc) || string.IsNullOrEmpty(Title) || string.IsNullOrEmpty(Description))
                    {
                        await Application.Current.MainPage.DisplayAlert("Info", "You are missing some important fields" , "cancel");
                    }
                    else
                    {
                        using (var stream = await photo.OpenReadAsync())
                        {
                            string uri = serviceProvider.Key + DateTime.Now.ToString("dd_MM_yyyy_hh_mm_ss");
                            ImgUrl = await firebaseStorage.SaveImageAsync(stream, serviceProvider.ServiceType, uri);

                            if (serviceProvider.ServiceType == "Destination")
                            {
                                DestinationModel dModel = new DestinationModel()
                                {
                                    CardAuthor = serviceProvider.ProviderName,
                                    CardTitle = Title,
                                    CardDetails = Description,
                                    Cost = Cost,
                                    CardImage = ImgUrl,
                                    DateTime = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss"),
                                    Icon = Userdata.PhotoUri,
                                    Location = serviceProvider.Location,
                                    Likes = 0
                                };

                                await firebaseDB.SaveTimelineData(dModel);
                                
                            }
                            else if(serviceProvider.ServiceType == "Accomodation")
                            {
                                TimelineModel aModel = new TimelineModel()
                                {
                                    CardAuthor = serviceProvider.ProviderName,
                                    CardTitle = Title,
                                    CardDetails = Description,
                                    Cost = Cost,
                                    CardImage = ImgUrl,
                                    DateTime = DateTime.Now.ToString("dd/MM/yyyy h:mm:ss"),
                                    Icon = Userdata.PhotoUri
                                    
                                };
                                await firebaseDB.SaveTimelineData(aModel);
                            }

                            await Application.Current.MainPage.DisplayAlert("Success", "Content uploaded", "OK");
                            Title = "";
                            Description = "";
                            Cost = 0;
                            LocalImgSrc = "";
                        }

                    }
                    await PopupNavigation.Instance.PopAsync();
                }
                catch(Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Failed", ex.Message, "OK");
                }
            });
        }
        private void AttachPhoto()
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    photo = await MediaPicker.PickPhotoAsync();
                    if (photo == null)
                    {
                        return;
                    }
                    LocalImgSrc = photo.FullPath;
                    //await PopupNavigation.Instance.PushAsync(new LoadingDialog("Uploading photo..."));
                    //await PopupNavigation.Instance.PopAsync();


                }
                catch (PermissionException)
                {
                    await Application.Current.MainPage.DisplayAlert("Permission", "App has no permission to access your gallery", "Cancel");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Failed", ex.Message, "Cancel");
                }
            });
        }
    }
}
