using OliviasBank.Models.BankModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OliviasBank.DataLayer
{
    public interface IBankRepository
    {
        List<Customer> GetAllCustomers();

        bool Withdrawal(int accountNr, decimal amount);

        void Deposit(int accountNr, decimal amount);
    }
}
