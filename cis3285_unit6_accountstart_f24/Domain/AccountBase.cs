
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
        // Create the requested account type.
        public static AccountBase CreateAccount(AccountType type)
        {
            switch (type)
            {
                case AccountType.Silver:
                    return new SilverAccount();

                case AccountType.Gold:
                    return new GoldAccount();

                case AccountType.Platinum:
                    return new PlatinumAccount();

                default:
                    throw new ArgumentException("Invalid account type");
            }
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
            // Only give reward points for positive deposits.
            if (amount > 0)
            {
                RewardPoints += CalculateRewardPoints(amount);
            }

            // Update balance for deposits and withdrawals.
            Balance += amount;
        }

        // Each account type calculates reward points differently.
        public abstract int CalculateRewardPoints(decimal amount);
    }
}
