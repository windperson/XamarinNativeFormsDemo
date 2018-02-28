using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using OpenGLDemo;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace AndroidPrj
{
    [Activity(Label = "Native Forms OpenGLView", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AppCompatActivity
    {
        public static MainActivity Instance;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Forms.Init(this, savedInstanceState);
            Instance = this;

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "OpenGL Demo";

            var openGLViewPage = new OpenGlTutoTextured();
            var mainPage = openGLViewPage.CreateFragment(this);
            FragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.fragment_frame_layout, mainPage)
                .Commit();


            
        }
        
    }
}

