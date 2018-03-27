using System;
using System.Threading.Tasks;
using CalServices.DataSources;
using CalServices.Models;
using Foundation;
using UIKit;
using WoodgroveBankApp.Common;
using System.Linq;
using CalServices.Utils;
using CalServices.Dynamics.Messages;

namespace WoodgroveBankApp
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register("AppDelegate")]
    public class AppDelegate : UIApplicationDelegate
    {
        // class-level declarations

        public override UIWindow Window
        {
            get;
            set;
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            // Override point for customization after application launch.
            // If not required for your application you can safely delete this method
            //add settings notifcation
            SetupAppSettings();

            //change the appearance of the title bar globally
            UINavigationBar.Appearance.BarTintColor = Common.ScreenColors.TitleBarBackground;
            UINavigationBar.Appearance.TintColor = Common.ScreenColors.TitleBarFontColor;
            //load the application settings
            ApplicationSettings.Current.SyncSettings();
            //load application data
            LoadInitialData();


            return true;
        }

        private void LoadInitialData()
        {
            Task loadData = Task.Run(async () =>
            {
                await ApplicationData.Current.LoadApplicationData();
            });

            try
            {
                //wait for data to load
                loadData.Wait();
            }
            catch (Exception ex)
            {
                ApplicationData.Current.Errors.Add(new AppError()
                {
                    ClassName = nameof(AppDelegate),
                    Method = nameof(LoadInitialData),
                    ErrorMessage = ex.Message
                });
            }
        }

        public override void OnResignActivation(UIApplication application)
        {
            // Invoked when the application is about to move from active to inactive state.
            // This can occur for certain types of temporary interruptions (such as an incoming phone call or SMS message) 
            // or when the user quits the application and it begins the transition to the background state.
            // Games should use this method to pause the game.

            //clear the token so the application will re-authenticated after being activated again
            KeyVault.Tokens.Reset();
        }

        public override void DidEnterBackground(UIApplication application)
        {
            // Use this method to release shared resources, save user data, invalidate timers and store the application state.
            // If your application supports background exection this method is called instead of WillTerminate when the user quits.
        }

        public override void WillEnterForeground(UIApplication application)
        {
            // Called as part of the transiton from background to active state.
            // Here you can undo many of the changes made on entering the background.
        }

        public override void OnActivated(UIApplication application)
        {
            // Restart any tasks that were paused (or not yet started) while the application was inactive. 
            // If the application was previously in the background, optionally refresh the user interface.
        }

        private NSObject observer;
        public override void WillTerminate(UIApplication application)
        {
            // Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
            if (observer != null)
            {
                NSNotificationCenter.DefaultCenter.RemoveObserver(observer);
                observer = null;
            }
        }

        private void SetupAppSettings()
        {
            NSDictionary appSettings = new NSDictionary();
            NSUserDefaults.StandardUserDefaults.RegisterDefaults(appSettings);
            //listen for changes
            observer = NSNotificationCenter.DefaultCenter.AddObserver((NSString)"NSUserDefaultsDidChangeNotification", OnDefaultsChange);
            ApplicationSettings.Current.SyncSettings();
        }

        private void OnDefaultsChange(NSNotification obj)
        {
            System.Diagnostics.Debug.WriteLine("defaults change");
            ApplicationSettings.Current.SyncSettings();
            LoadInitialData();
            UIStoryboard storyboard = UIStoryboard.FromName("Main", null);
            UIViewController controller =  storyboard.InstantiateInitialViewController();
            controller.ShowViewController(controller, null);
        }
    }
}

