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
    [Register ("AccountCell")]
    partial class AccountCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel AccountNumberLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel BalanceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel ProductLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (AccountNumberLabel != null) {
                AccountNumberLabel.Dispose ();
                AccountNumberLabel = null;
            }

            if (BalanceLabel != null) {
                BalanceLabel.Dispose ();
                BalanceLabel = null;
            }

            if (ProductLabel != null) {
                ProductLabel.Dispose ();
                ProductLabel = null;
            }
        }
    }
}