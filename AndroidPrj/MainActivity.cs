using Android.App;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using AndroidPrj.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace AndroidPrj
{
    [Activity(Label = "AndroidPrj", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
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
            SupportActionBar.Title = "Phoneword";

            var phonewordPage = new PhonewordPage();
            var mainPage = phonewordPage.CreateFragment(this);
            FragmentManager
                .BeginTransaction()
                .Replace(Resource.Id.fragment_frame_layout, mainPage)
                .Commit();

            FragmentManager.BackStackChanged += (sender, e) =>
            {
                bool hasBack = FragmentManager.BackStackEntryCount > 0;
                SupportActionBar.SetHomeButtonEnabled(hasBack);
                SupportActionBar.SetDisplayHomeAsUpEnabled(hasBack);
                SupportActionBar.Title = hasBack ? "Call History" : "Phoneword";
            };
        }

        public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
        {
            if (item.ItemId == global::Android.Resource.Id.Home && FragmentManager.BackStackEntryCount > 0)
            {
                FragmentManager.PopBackStack();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        public void NavigateToCallHistoryPage()
        {
            var callHistoryPage = new CallHistoryPage().CreateFragment(this);
            FragmentManager
                .BeginTransaction()
                .AddToBackStack(null)
                .Replace(Resource.Id.fragment_frame_layout, callHistoryPage)
                .Commit();
        }
    }
}

