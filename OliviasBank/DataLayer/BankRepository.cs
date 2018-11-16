using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OliviasBank.Models.BankModels;

namespace OliviasBank.DataLayer
{
    public class BankRepository : IBankRepository
    {
        public List<Customer> GetAllCustomers()
        {
            var allCustomers = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Olivia Denbu",
                    AccountList = new List<Account>
                    {
                        new Account
                        {
                            AccountNumber = 101,
                            Balance = 2000,
                            OwnerId = 1
                        },
                        new Account
                        {
                            AccountNumber = 102,
                            Balance = 4500,
                            OwnerId = 1
                        }
                    }
                },
                new Customer
                {
                    Id = 2,
                    Name = "Anna-Maria Nordström",
                     AccountList = new List<Account>
                    {
                        new Account
                        {
                            AccountNumber = 202,
                            Balance = 2000,
                            OwnerId = 2
                        }
                    }
                },
                new Customer
                {
                    Id = 3,
                    Name = "Andreas Blom",
                     AccountList = new List<Account>
                    {
                        new Account
                        {
                            AccountNumber = 303,
                            Balance = 2000,
                            OwnerId = 3
                        }
                    }
                }
            };

            return allCustomers;
        }

        public void Deposit(int accountNumber, decimal amountToDeposit)
        {
            throw new NotImplementedException();
        }
    }
}
