using System;
using UIKit;
using CalServices.Models;
using CalServices.DataSources;
using CoreGraphics;

namespace WoodgroveBankApp.Datasources
{
    public class BranchViewSource : UITableViewSource
    {
        private BranchDataSource _datasource = null;

        public BranchViewSource()
        {
            _datasource = new BranchDataSource();
        }

        public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
        {
            UITableViewCell cell = new UITableViewCell(UITableViewCellStyle.Subtitle, null);
            Branch branch = _datasource.Branches[indexPath.Row];
            cell.TextLabel.Text = branch.Name;
            cell.DetailTextLabel.Text = branch.Address;


            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return _datasource.Branches.Count;
        }
    }
}
