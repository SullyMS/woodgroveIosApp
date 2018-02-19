using Foundation;
using System;
using UIKit;
using WoodgroveBankApp.Datasources;


namespace WoodgroveBankApp
{
    public partial class BranchViewController : UIViewController
    {
        private BranchViewSource _viewsource = null;

        public BranchViewController (IntPtr handle) : base (handle)
        {
            _viewsource = new BranchViewSource();
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //load the branch data
            BranchTableView.Source = _viewsource;
        }
    }
}