﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OliviasBank.DataLayer;
using OliviasBank.Models;
using OliviasBank.Models.BankModels;

namespace OliviasBank.Controllers
{
    public class HomeController : Controller
    {
        private IBankRepository _bankRepository;

        public HomeController(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            List<Customer> allCustomers = _bankRepository.GetAllCustomers();

            return View(allCustomers);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
