using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OliviasBank.DataLayer;
using OliviasBank.Models.BankModels;
using OliviasBank.Services;
using OliviasBank.ViewModels;
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
            //else
            //{
            //    ViewBag.Message = ("Deposit has not succeeded!");
            //}

            return RedirectToAction("Index", new { message = "AccountNo doesnt exist. Deposit has not succeeded" });
        }

        public IActionResult Withrawal(IndexViewModel viewModel)
        {
            bool depositSucceded = _bankService.Withdrawal(viewModel.AccountNo, viewModel.Amount);
            Account currentAccount = _bankRepository.GetAccountById(viewModel.AccountNo);

            if (depositSucceded == true)
            {
                //Account currentAccount = _bankRepository.GetAccountById(viewModel.AccountNo);
                ViewBag.Message = ("You have successfully made a withdrawal!");

                return View(nameof(Index), new IndexViewModel
                {
                    AccountNo = viewModel.AccountNo,
                    Amount = viewModel.Amount,
                    Balance = currentAccount.Balance
                });
            }

            viewModel.Balance = currentAccount.Balance;
            ViewBag.Message = ("Withdrawal has not succeeded!");

            return View("Index", viewModel);
        }

        [HttpGet]
        public IActionResult Transfer()
        {
            return View(new TransferViewModel());
        }

        public IActionResult Transfer(TransferViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var isSuccess = _bankService.Transfer(vm.FromAccountId, vm.ToAccountId, vm.Sum, out string message);

                if (isSuccess)
                {
                    vm.Message = message;
                    vm.ToAccountBalance = _bankRepository.GetAccountById(vm.ToAccountId).Balance;
                    vm.FromAccountBalance = _bankRepository.GetAccountById(vm.FromAccountId).Balance;
                    return View(vm);
                }
                else
                {
                    vm.Message = message;
                    vm.ToAccountBalance = 0;
                    vm.FromAccountBalance = 0;
                }

            }
            return View(vm);
        }
    }
}