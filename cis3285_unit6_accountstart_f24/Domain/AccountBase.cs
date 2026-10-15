using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    // Shared account state and behavior; each account type supplies its own reward rule.
    public abstract class AccountBase
    {
        // Create the requested concrete account while returning the common base type.
        public static AccountBase CreateAccount(AccountType type)
        {
            AccountBase account = null;
            switch(type)
            {
                case AccountType.Silver:
                    account = new SilverAccount();
                    break;
                case AccountType.Gold:
                    account = new GoldAccount();
                    break;
                case AccountType.Platinum:
                    account = new PlatinumAccount();
                    break;
            }
            return account;
        }

        public decimal Balance
        {
            get;
            private set;
        }

        public int RewardPoints
        {
            get;
            private set;
        }

        public void AddTransaction(decimal amount)
        {
            // Deposits can earn reward points. Negative transactions should not.
            if (amount > 0)
            {
                RewardPoints += CalculateRewardPoints(amount);
            }

            Balance += amount;
        }

        // Withdrawals have their own operation instead of being treated as negative deposits.
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        // Subclasses implement the reward calculation for their account type.
        public abstract int CalculateRewardPoints(decimal amount);
    }
}
