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

        public IActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            return View(viewModel);
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

            //bool depositSucceeded = _bankService.Deposit(viewModel.AccountNo, viewModel.Amount);
            decimal newBalance = _bankService.Deposit(viewModel.AccountNo, viewModel.Amount);

            ViewBag.Message = ("You have successfully made a deposit!");

            return View(nameof(Index), new IndexViewModel
            {
                AccountNo = viewModel.AccountNo,
                Amount = viewModel.Amount,
                Balance = newBalance
            });
            //if (depositSucceeded == true)
            //{
            //    ViewBag.Message = ("You have successfully made a deposit!");

            //    return View(nameof(Index), new IndexViewModel
            //    {
            //        AccountNo = viewModel.AccountNo,
            //        Amount = viewModel.Amount,
            //        Balance = viewModel.Balance,
            //    });
            //}

            return View();
        }

        public IActionResult Withrawal(IndexViewModel viewModel)
        {
            return View();
        }
    }
}