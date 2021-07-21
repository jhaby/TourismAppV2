using Android.Content;
using Android.Graphics;
using CustomRenderer.Android;
using TourismAppV2.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace CustomRenderer.Android
{
    class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            //if (Control != null)
            //{
            //    Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
            //    Control.Background.SetColorFilter(Color.White, PorterDuff.Mode.SrcAtop);
            //}
        }
    }
}