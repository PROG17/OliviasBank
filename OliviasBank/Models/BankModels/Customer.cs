using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OliviasBank.Models.BankModels
{
    public class Customer
    {
        public Customer()
        {
            this.AccountList = new List<Account>();
        }

        public Customer(int id, string name)
        {
            this.Id = id;
            this.Name = name;
            this.AccountList = new List<Account>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Account> AccountList { get; set; }
    }
}
