using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OliviasBank.DataLayer;
using OliviasBank.Models.BankModels;
using OliviasBank.Services;
using OliviasBank.ViewModels.BankViewModels;

namespace OliviasBank.Controllers
{
    public class BankController : Controller
    {
        private readonly IBankService _bankService;
        private readonly IBankRepository _bankRepository;

        public BankController(IBankService bankService,
                              IBankRepository bankRepository)
        {
            _bankService = bankService;
            _bankRepository = bankRepository;
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

            bool depositSucceded = _bankService.Deposit(viewModel.AccountNo, viewModel.Amount);

            if (depositSucceded == true)
            {
                Account currentAccount = _bankRepository.GetAccountById(viewModel.AccountNo);
                ViewBag.Message = ("You have successfully made a deposit!");

                return View(nameof(Index), new IndexViewModel
                {
                    AccountNo = viewModel.AccountNo,
                    Amount = viewModel.Amount,
                    Balance = currentAccount.Balance
                });
            }
            else
            {
                ViewBag.Message = ("Deposit has not succeeded!");
            }

            return View();
        }

        public IActionResult Withrawal(IndexViewModel viewModel)
        {
            bool depositSucceded = _bankService.Withdrawal(viewModel.AccountNo, viewModel.Amount);

            if (depositSucceded == true)
            {
                Account currentAccount = _bankRepository.GetAccountById(viewModel.AccountNo);
                ViewBag.Message = ("You have successfully made a withdrawal!");

                return View(nameof(Index), new IndexViewModel
                {
                    AccountNo = viewModel.AccountNo,
                    Amount = viewModel.Amount,
                    Balance = currentAccount.Balance
                });
            }
            else
            {
                ViewBag.Message = ("Withdrawal has not succeeded!");
            }

            return View();
        }
    }
}