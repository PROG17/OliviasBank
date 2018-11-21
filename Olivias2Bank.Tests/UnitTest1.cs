using Microsoft.VisualStudio.TestTools.UnitTesting;
using OliviasBank.DataLayer;
using OliviasBank.Models.BankModels;
using OliviasBank.Services;
using System.Linq;

namespace Olivias2Bank.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AfterDepositAccountShouldHaveUpdateBalanceTest()
        {
            BankRepository bankRepository = new BankRepository();
            BankService bankService = new BankService(bankRepository);

            Customer oneCustomer = bankRepository.GetAllCustomers().First();
            Account account = oneCustomer.AccountList.First();
            
            //Arrange
            decimal currentBalance = account.Balance;
            decimal amount = 100;
            decimal expectedResult = currentBalance + amount;

            //Act
            bankService.Deposit(account.AccountNumber, amount);

            //Assert
            var result = account.Balance;
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AfterWithrawalAccountShouldHaveUpdatedBalanceTest()
        {
            BankRepository bankRepository = new BankRepository();
            BankService bankService = new BankService(bankRepository);

            Customer oneCustomer = bankRepository.GetAllCustomers().First();
            Account account = oneCustomer.AccountList.First();

            //Arrange
            decimal currentBalance = account.Balance;
            decimal amount = 100;
            decimal expectedResult = currentBalance - amount;

            //Act
            bankService.Withdrawal(account.AccountNumber, amount);

            //Assert
            var result = account.Balance;
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WithdrawalMoreMoneyThanBalanceTest()
        {
            //Arrange
            BankRepository bankRepository = new BankRepository();
            BankService bankService = new BankService(bankRepository);

            Customer oneCustomer = bankRepository.GetAllCustomers().First();
            Account account = oneCustomer.AccountList.First();
            decimal amount = 100;
            decimal expectedResult = account.Balance;

            //Act
            bankService.Withdrawal(account.AccountNumber, account.Balance + amount);

            //Assert
            decimal result = account.Balance;
            Assert.AreEqual(expectedResult, result);
        }
    }
}
