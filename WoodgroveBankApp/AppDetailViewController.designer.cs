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
    [Register ("AppDetailViewController")]
    partial class AppDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Address1Label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel Address2Label { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView AdvisorImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel BranchLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton CheckInButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ConfNumLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel DateLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel EmailLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FullNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MobileLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PhoneLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PurposeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StatusLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TimeLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel TitleLabel { get; set; }

        [Action ("CheckInButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void CheckInButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (Address1Label != null) {
                Address1Label.Dispose ();
                Address1Label = null;
            }

            if (Address2Label != null) {
                Address2Label.Dispose ();
                Address2Label = null;
            }

            if (AdvisorImage != null) {
                AdvisorImage.Dispose ();
                AdvisorImage = null;
            }

            if (BranchLabel != null) {
                BranchLabel.Dispose ();
                BranchLabel = null;
            }

            if (CheckInButton != null) {
                CheckInButton.Dispose ();
                CheckInButton = null;
            }

            if (ConfNumLabel != null) {
                ConfNumLabel.Dispose ();
                ConfNumLabel = null;
            }

            if (DateLabel != null) {
                DateLabel.Dispose ();
                DateLabel = null;
            }

            if (EmailLabel != null) {
                EmailLabel.Dispose ();
                EmailLabel = null;
            }

            if (FullNameLabel != null) {
                FullNameLabel.Dispose ();
                FullNameLabel = null;
            }

            if (MobileLabel != null) {
                MobileLabel.Dispose ();
                MobileLabel = null;
            }

            if (PhoneLabel != null) {
                PhoneLabel.Dispose ();
                PhoneLabel = null;
            }

            if (PurposeLabel != null) {
                PurposeLabel.Dispose ();
                PurposeLabel = null;
            }

            if (StatusLabel != null) {
                StatusLabel.Dispose ();
                StatusLabel = null;
            }

            if (TimeLabel != null) {
                TimeLabel.Dispose ();
                TimeLabel = null;
            }

            if (TitleLabel != null) {
                TitleLabel.Dispose ();
                TitleLabel = null;
            }
        }
    }
}