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
    [Register ("SetLocationViewController")]
    partial class SetLocationViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel BranchNameLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel BranchNumberLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ChangeLocation { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CityLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel FaxLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView Map { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.NSLayoutConstraint MapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel PhoneLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel StreetLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (BranchNameLabel != null) {
                BranchNameLabel.Dispose ();
                BranchNameLabel = null;
            }

            if (BranchNumberLabel != null) {
                BranchNumberLabel.Dispose ();
                BranchNumberLabel = null;
            }

            if (ChangeLocation != null) {
                ChangeLocation.Dispose ();
                ChangeLocation = null;
            }

            if (CityLabel != null) {
                CityLabel.Dispose ();
                CityLabel = null;
            }

            if (FaxLabel != null) {
                FaxLabel.Dispose ();
                FaxLabel = null;
            }

            if (Map != null) {
                Map.Dispose ();
                Map = null;
            }

            if (MapView != null) {
                MapView.Dispose ();
                MapView = null;
            }

            if (PhoneLabel != null) {
                PhoneLabel.Dispose ();
                PhoneLabel = null;
            }

            if (StreetLabel != null) {
                StreetLabel.Dispose ();
                StreetLabel = null;
            }
        }
    }
}