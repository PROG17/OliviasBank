using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OliviasBank.DataLayer;
using OliviasBank.Services;
using OliviasBank.ViewModels.BankViewModels;

namespace OliviasBank.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        public IActionResult Index(IndexViewModel viewModel)
        {
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Deposit(IndexViewModel viewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    _bankRepository.Deposit(viewModel.AccountNo, viewModel.Amount);
            //    return View(nameof(Index), new IndexViewModel
            //    {
            //        AccountNo = viewModel.AccountNo,
            //        Amount = viewModel.Amount,
            //        Balance = viewModel.Balance
            //    });
            //}
            _bankService.Deposit(viewModel.AccountNo, viewModel.Amount);


            return View(nameof(Index), new IndexViewModel
            {
                AccountNo = viewModel.AccountNo,
                Amount = viewModel.Amount,
                Balance = viewModel.Balance
            });
        }

        public IActionResult Withrawal(IndexViewModel viewModel)
        {
            return View();
        }
    }
}