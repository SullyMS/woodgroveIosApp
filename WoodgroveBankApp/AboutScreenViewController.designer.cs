// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace WoodgroveBankApp
{
    [Register ("AboutScreenViewController")]
    partial class AboutScreenViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ApiLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CalServiceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ConnectedToLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView ContentView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CrmLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ErrorButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UINavigationBar NavigationBar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ReloadButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel VersonLabel { get; set; }

        [Action ("ReloadButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ReloadButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (ApiLabel != null) {
                ApiLabel.Dispose ();
                ApiLabel = null;
            }

            if (CalServiceLabel != null) {
                CalServiceLabel.Dispose ();
                CalServiceLabel = null;
            }

            if (ConnectedToLabel != null) {
                ConnectedToLabel.Dispose ();
                ConnectedToLabel = null;
            }

            if (ContentView != null) {
                ContentView.Dispose ();
                ContentView = null;
            }

            if (CrmLabel != null) {
                CrmLabel.Dispose ();
                CrmLabel = null;
            }

            if (ErrorButton != null) {
                ErrorButton.Dispose ();
                ErrorButton = null;
            }

            if (NavigationBar != null) {
                NavigationBar.Dispose ();
                NavigationBar = null;
            }

            if (ReloadButton != null) {
                ReloadButton.Dispose ();
                ReloadButton = null;
            }

            if (VersonLabel != null) {
                VersonLabel.Dispose ();
                VersonLabel = null;
            }
        }
    }
}