using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Services
{
    public interface IAccountServices
    {
        List<string> GetAllAccounts();
        void CreateAccount(string accountName, AccountType accountType);
        decimal GetAccountBalance(string accountName);
        int GetRewardPoints(string accountName);
        void Deposit(string accountName, decimal amount);
        void Withdrawal(string accountName, decimal amount);
    }
}
