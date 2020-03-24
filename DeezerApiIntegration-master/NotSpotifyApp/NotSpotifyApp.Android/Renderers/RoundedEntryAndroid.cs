using Xamarin.Forms;
using Android.Content;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using NotSpotifyApp.Controls;
using NotSpotifyApp.Droid.Renderers;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryAndroid))]
namespace NotSpotifyApp.Droid.Renderers
{
   public class RoundedEntryAndroid : EntryRenderer
   {
        public RoundedEntryAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            
            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(60f);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.Rgb(244, 67, 54));
                gradientDrawable.SetColor(Android.Graphics.Color.WhiteSmoke);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);

            }
        }
   }
}