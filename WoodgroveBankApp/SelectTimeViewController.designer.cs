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
    [Register ("SelectTimeViewController")]
    partial class SelectTimeViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DayText { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NextButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PreviousButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView ProgressRing { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITableView TableView { get; set; }

        [Action ("NextButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NextButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("PreviousButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PreviousButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (DayText != null) {
                DayText.Dispose ();
                DayText = null;
            }

            if (NextButton != null) {
                NextButton.Dispose ();
                NextButton = null;
            }

            if (PreviousButton != null) {
                PreviousButton.Dispose ();
                PreviousButton = null;
            }

            if (ProgressRing != null) {
                ProgressRing.Dispose ();
                ProgressRing = null;
            }

            if (TableView != null) {
                TableView.Dispose ();
                TableView = null;
            }
        }
    }
}