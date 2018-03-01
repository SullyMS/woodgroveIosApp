using Foundation;
using System;
using UIKit;

namespace WoodgroveBankApp
{
    public partial class AboutScreenViewController : UIViewController
    {
        public AboutScreenViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            //set the navigation bar color
            NavigationBar.BackgroundColor = Common.ScreenColors.TitleBarBackground;
            VersonLabel.Text = $"Version: {NSBundle.MainBundle.InfoDictionary["CFBundleShortVersionString"].ToString()}";
            ContentView.BackgroundColor = UIColor.White;
            View.BackgroundColor = Common.ScreenColors.TitleBarBackground;
        }
    }
}