using Foundation;
using System;
using UIKit;
using System.Collections.Generic;
using WoodgroveBankApp.Models;

namespace WoodgroveBankApp
{
    public partial class AccountsTableViewController : UITableViewController
    {
        private AccountsSource _tableSource = null;

        public AccountsTableViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            NavigationBar.BackgroundColor = Common.ScreenColors.TitleBarBackground;
            _tableSource = new AccountsSource();
            TableView.Source = _tableSource;
        }
    }

    public class AccountsSource : UITableViewSource
    {
        List<FinancialAccount> DepositAccounts { get; set; }
        List<FinancialAccount> CreditAccounts { get; set; }

        public AccountsSource()
        {
            DepositAccounts = FinancialData.Instance.DepositAccounts;
            CreditAccounts = FinancialData.Instance.CreditAccounts;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            if (section == 0)
            {
                return DepositAccounts.Count;
            }
            else if (section == 1)
            {
                return CreditAccounts.Count;
            }
            return 0;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            if (indexPath.Section == 0)
            {
                AccountCell cell = (AccountCell)tableView.DequeueReusableCell(AccountCell.CELL_ID, indexPath);
                FinancialAccount account = DepositAccounts[indexPath.Row];
                cell.Update(account);
                return cell;
            }
            else if (indexPath.Section == 1)
            {
                AccountCell cell = (AccountCell)tableView.DequeueReusableCell(AccountCell.CELL_ID, indexPath);
                FinancialAccount account = CreditAccounts[indexPath.Row];
                cell.Update(account);
                return cell;
            }

            return null;
        }
    }
}