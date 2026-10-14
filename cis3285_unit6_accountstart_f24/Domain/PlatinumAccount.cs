using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    // Platinum accounts earn points faster and do not subtract points below zero.
    internal class PlatinumAccount : AccountBase
    {
        public override int CalculateRewardPoints(decimal amount)
        {
            // Round the combined balance and transaction points up, with a minimum of zero.
            return Math.Max((int)decimal.Ceiling((Balance / PlatinumBalanceCostPerPoint) + (amount / PlatinumTransactionCostPerPoint)), 0);
        }

        private const int PlatinumTransactionCostPerPoint = 2;
        private const int PlatinumBalanceCostPerPoint = 1000;
    }
}
