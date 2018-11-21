﻿using OliviasBank.DataLayer;
using OliviasBank.Models.BankModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OliviasBank.Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public void Deposit(int accountNo, decimal amountToDeposit)
        {
            List<Customer> allCustomers = _bankRepository.GetAllCustomers();

            foreach (var customer in allCustomers)
            {
                foreach (var account in customer.AccountList)
                {
                    if (account.AccountNumber == accountNo)
                    {
                        account.Balance += amountToDeposit;
                    }
                }
            }
        }

        public bool Withdrawal(int accountNr, decimal amount)
        {
            List<Customer> allCustomers = _bankRepository.GetAllCustomers();

            foreach (var customer in allCustomers)
            {
                foreach (var account in customer.AccountList)
                {
                    if (account.AccountNumber == accountNr)
                    {
                        if (account.Balance >= amount)
                        {
                            account.Balance -= amount;
                            return true;
                        }
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
