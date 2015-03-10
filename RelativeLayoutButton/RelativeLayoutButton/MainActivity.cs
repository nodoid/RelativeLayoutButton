using Android.App;
using Android.Widget;
using Android.OS;

namespace RelativeLayoutButton
{
    [Activity(Label = "RelativeLayoutButton", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var button1 = new RelativeLayoutButton(this, Resource.Id.button1);
            button1.Click += delegate
            {
                Toast.MakeText(this, "Relative layout button clicked", ToastLength.Long).Show();
            };

            var button2 = new RelativeLayoutButton(this, Resource.Id.button2);
            button2.SetText(Resource.Id.test_button_text1, "Change");
            button2.SetText(Resource.Id.test_button_text2, "text");

            var button3 = new RelativeLayoutButton(this, Resource.Id.button3);
            button3.SetText(Resource.Id.test_button_text1, "Change");
            button3.SetText(Resource.Id.test_button_text2, "image");
            button3.SetImageResource(Resource.Id.test_button_image, Android.Resource.Drawable.StarBigOn);

        }
    }
}


