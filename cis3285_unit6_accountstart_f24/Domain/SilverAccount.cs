using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    // Silver accounts award one point per 10 units of transaction amount.
    internal class SilverAccount : AccountBase
    {
        public override int CalculateRewardPoints(decimal amount)
        {
            // Floor discards any fractional point.
            return (int)decimal.Floor(amount / SilverTransactionCostPerPoint);
        }

        private const int SilverTransactionCostPerPoint = 10;
    }
}
