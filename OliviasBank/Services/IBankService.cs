using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OliviasBank.Services
{
    public interface IBankService
    {
        bool Deposit(int accountNo, decimal amountToDeposit);

        bool Withdrawal(int accountNr, decimal amount);

        bool Transfer(int fromAccountId, int toAccountId, decimal sum, out string message);
    }
}
