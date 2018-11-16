﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OliviasBank.Models.BankModels;

namespace OliviasBank.DataLayer
{
    public class BankRepository : IBankRepository
    {
        private static List<Customer> _allCustomers;

        public List<Customer> GetAllCustomers()
        {
            if (_allCustomers == null)
            {
                _allCustomers = new List<Customer>
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

            }

            return _allCustomers;
        }

        public void Deposit(int accountNo, decimal amountToDeposit)
        {
            foreach (var customer in GetAllCustomers())
            {
                foreach (var account in customer.AccountList)
                {
                    if (account.AccountNumber == accountNo)
                    {
                        account.Balance += amountToDeposit;
                        return;
                    }
                }
            }
        }

        //public void Deposit2(int accountNr, decimal amount)
        //{
        //    foreach (var customer in GetAllCustomers())
        //    {
        //        foreach (var account in customer.AccountList)
        //        {
        //            if (account.AccountNumber == accountNr)
        //            {
        //                account.Balance += amount;
        //                return;
        //            }
        //        }
        //    }
        //}
    }
}
