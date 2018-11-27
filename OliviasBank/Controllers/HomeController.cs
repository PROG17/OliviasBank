using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OliviasBank.DataLayer;
using OliviasBank.Models;
using OliviasBank.Models.BankModels;

namespace OliviasBank.Controllers
{
    public class HomeController : Controller
    {
        private IBankRepository _bankRepository;
        private IHostingEnvironment _environment;
        private IConfiguration _config;

        public HomeController(IBankRepository bankRepository,
                              IHostingEnvironment environment,
                              IConfiguration config)
        {
            _bankRepository = bankRepository;
            _environment = environment;
            _config = config;
        }

        public IActionResult Index()
        {
            List<Customer> allCustomers = _bankRepository.GetAllCustomers();

            ViewData["AppTitle"] = _config.GetValue<string>("AppTitle");
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
