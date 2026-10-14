using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    // The factory uses this value to choose which account subclass to create.
    public enum AccountType
    {
        Silver,
        Gold,
        Platinum
    }
}
