using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OliviasBank.Models.BankModels
{
    public class Account
    {
        public int AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public int OwnerId { get; set; }
    }
}
