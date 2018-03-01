using Foundation;
using System;
using UIKit;
using WoodgroveBankApp.Models;

namespace WoodgroveBankApp
{
    public partial class AccountCell : UITableViewCell
    {
        public AccountCell (IntPtr handle) : base (handle)
        {
        }

        public void Update(FinancialAccount Account)
        {
            ProductLabel.Text = Account.ProductName;
            AccountNumberLabel.Text = Account.AccountNumber;
            BalanceLabel.Text = Account.Balance.ToString("C");
        }

        public const string CELL_ID = "AccountCell";
    }
}