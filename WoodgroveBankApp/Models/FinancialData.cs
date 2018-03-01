using System;
using System.Collections.Generic;

namespace WoodgroveBankApp.Models
{
    public class FinancialData
    {
        public FinancialData()
        {
            DepositAccounts = new List<FinancialAccount>();
            DepositAccounts.Add(new FinancialAccount { Balance = 1234.23m, AccountNumber = "78765-0987654", ProductName = "Checking Account" }); 
            DepositAccounts.Add(new FinancialAccount { Balance = 15169.97m, AccountNumber = "87783-7850463", ProductName = "Savings Account" });
            DepositAccounts.Add(new FinancialAccount { Balance = 215179.91m, AccountNumber = "87783-7850463", ProductName = "Freedom Investor" });
            CreditAccounts = new List<FinancialAccount>();
            CreditAccounts.Add(new FinancialAccount { Balance = -2345.12m, AccountNumber = "5667 6789 7654 7664", ProductName = "Visa Card" });
            CreditAccounts.Add(new FinancialAccount { Balance = -245789.42m, AccountNumber = "78954-456875", ProductName = "Mortgage" });
        }

        private static FinancialData _instance;
        public static FinancialData Instance => _instance ?? (_instance = new FinancialData());

        public List<FinancialAccount> DepositAccounts { get; private set; }
        public List<FinancialAccount> CreditAccounts { get; set; }
    }

    public class FinancialAccount
    {
        public decimal Balance { get; set; }
        public string AccountNumber { get; set; }
        public string ProductName { get; set; }
    }


}
