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
    [Register ("HomeViewController")]
    partial class HomeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView BackGroundImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView ClientImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIPageControl PicPageControl { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIScrollView PictureScrollView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView PictureView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView ProgressRing { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WelcomeLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BackGroundImage != null) {
                BackGroundImage.Dispose ();
                BackGroundImage = null;
            }

            if (ClientImage != null) {
                ClientImage.Dispose ();
                ClientImage = null;
            }

            if (PicPageControl != null) {
                PicPageControl.Dispose ();
                PicPageControl = null;
            }

            if (PictureScrollView != null) {
                PictureScrollView.Dispose ();
                PictureScrollView = null;
            }

            if (PictureView != null) {
                PictureView.Dispose ();
                PictureView = null;
            }

            if (ProgressRing != null) {
                ProgressRing.Dispose ();
                ProgressRing = null;
            }

            if (WelcomeLabel != null) {
                WelcomeLabel.Dispose ();
                WelcomeLabel = null;
            }
        }
    }
}