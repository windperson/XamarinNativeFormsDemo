using Foundation;
using UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using IOSPrj.Views;

namespace IOSPrj
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
	    public static AppDelegate Instance;

        // class-level declarations

        public override UIWindow Window
		{
			get;
			set;
		}

	    UINavigationController _navigation;

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
		    Forms.Init();

		    Instance = this;
		    Window = new UIWindow(UIScreen.MainScreen.Bounds);

		    UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes
		    {
		        TextColor = UIColor.Black
		    });

		    var phonewordPage = new PhonewordPage();
		    var mainPage = phonewordPage.CreateViewController();
		    mainPage.Title = "Phoneword";

		    _navigation = new UINavigationController(mainPage);
		    Window.RootViewController = _navigation;
		    Window.MakeKeyAndVisible();

		    return true;
        }

	    public void NavigateToCallHistoryPage()
	    {
	        var callHistoryPage = new CallHistoryPage().CreateViewController();
	        callHistoryPage.Title = "Call History";
	        _navigation.PushViewController(callHistoryPage, true);
	    }
	}
}


