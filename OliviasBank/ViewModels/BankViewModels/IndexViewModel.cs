using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OliviasBank.ViewModels.BankViewModels
{
    public class IndexViewModel
    {
        public int AccountNo { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }
    }
}
