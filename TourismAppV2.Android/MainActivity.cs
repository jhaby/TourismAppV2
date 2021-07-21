using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;

namespace TourismAppV2.Droid
{
    [Activity(Label = "TourismAppV2", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.SetFlags(new string[] { "AppTheme_Experimental", "SwipeView_Experimental", "Brush_Experimental", "RadioButton_Experimental", "IndicatorView_Experimental", "CarouselView_Experimental" });
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LeoJHarris.FormsPlugin.Droid.EnhancedEntryRenderer.Init(this);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}