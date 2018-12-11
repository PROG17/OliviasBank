using OliviasBank.DataLayer;
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

        public bool Deposit(int accountNo, decimal amountToDeposit)
        {
            List<Customer> allCustomers = _bankRepository.GetAllCustomers();
            bool depositSucceeded = false;

            foreach (var customer in allCustomers)
            {
                foreach (var account in customer.AccountList)
                {
                    if (account.AccountNumber == accountNo)
                    {
                        account.Balance += amountToDeposit;
                        depositSucceeded = _bankRepository.SaveAccount(accountNo);

                        return depositSucceeded;
                    }
                }
            }

            return depositSucceeded;
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


        public bool Transfer(int fromAccountId, int toAccountId, decimal sum, out string message)
        {
            List<Customer> allCustomers = _bankRepository.GetAllCustomers();
            if (sum <= 0)
            {
                message = "Summan måste vara högre än 0.";
                return false;
            }

            var toAccount = GetAccount(toAccountId);
            if (toAccount == null)
            {
                message = "Till-kontonumret finns inte, kontrollera att siffrorna stämmer.";
                return false;
            }

            var isWithdrawn = Withdrawal(fromAccountId, sum);
            if (!isWithdrawn)
            {
                message = $"Det fanns inte tillräckligt med pengar på konto med kontonummer {fromAccountId}";
                return false;
            }

            var isDeposit = Deposit(toAccountId, sum);

            if (!isDeposit)
            {
                message = "Någonting gick fel när pengar skulle överföras. Prova igen senare.";
            }

            message = $"{sum.ToString("C")} har överförts från konto {fromAccountId} till konto {toAccountId}";
            return true;
        }

        public Account GetAccount(int bankKontoNummer)
        {
             List<Customer> allCustomers = _bankRepository.GetAllCustomers();
            return allCustomers.SelectMany(r => r.AccountList).FirstOrDefault(a => a.AccountNumber == bankKontoNummer);
        }
    }
}
