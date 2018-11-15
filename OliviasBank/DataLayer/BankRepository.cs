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

        

        //public List<Account> GetAccountsForCurrentCustomer(int currentId)
        //{
        //    int id = currentId;
        //    List<Account> accountList = new List<Account>();

        //    switch (id)
        //    {
        //        case 1:
        //            accountList.Add(new Account { Id = 1, Balance = 2000, Owner = })
        //    }
        //    int caseSwitch = 1;

        //    switch (caseSwitch)
        //    {
        //        case 1:
        //            Console.WriteLine("Case 1");
        //            break;
        //        case 2:
        //            Console.WriteLine("Case 2");
        //            break;
        //        default:
        //            Console.WriteLine("Default case");
        //            break;
        //    }
        //}
    }
}
