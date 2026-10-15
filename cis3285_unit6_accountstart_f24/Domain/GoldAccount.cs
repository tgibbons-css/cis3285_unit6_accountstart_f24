using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    // Gold accounts award points for both the existing balance and this transaction.
    public class GoldAccount : AccountBase
    {
        public override int CalculateRewardPoints(decimal amount)
        {
            if (amount < 0)
            {
                return 0;
            }
            // Combine both contributions, then discard any fractional point.
            return (int)decimal.Floor((Balance / GoldBalanceCostPerPoint) + (amount / GoldTransactionCostPerPoint));
        }

        private const int GoldTransactionCostPerPoint = 5;
        private const int GoldBalanceCostPerPoint = 2000;
    }
}
