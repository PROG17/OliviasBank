using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OliviasBank.Services
{
    public interface IBankService
    {
        decimal Deposit(int accountNo, decimal amountToDeposit);

        bool Withdrawal(int accountNr, decimal amount);
    }
}
