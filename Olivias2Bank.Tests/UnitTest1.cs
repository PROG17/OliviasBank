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

        [TestMethod]
        public void Transfer_Between_Accounts_Are_Successful()
        {
            BankRepository bankRepository = new BankRepository();
            BankService bankService = new BankService(bankRepository);

            Customer fromCustomer = bankRepository.GetAllCustomers().First();
            Customer toCustomer = bankRepository.GetAllCustomers().Last();
            Account fromAccount = fromCustomer.AccountList.First();
            Account toAccount = toCustomer.AccountList.First();

            decimal sum = 500;
            var expectedBalanceOnFromAccount = fromAccount.Balance - sum;
            var expectedBalanceOnToAccont = toAccount.Balance + sum;

            // Act
            var isSuccess = bankService.Transfer(fromAccount.AccountNumber, toAccount.AccountNumber, sum, out string message);

            // Assert
            Assert.AreEqual(expectedBalanceOnFromAccount, fromAccount.Balance);
            Assert.AreEqual(expectedBalanceOnToAccont, toAccount.Balance);
        }

        [TestMethod]
        public void Transfer_Cannot_Be_Made_When_Insufficient_Funds()
        {
            // Arrange
            BankRepository bankRepository = new BankRepository();
            BankService bankService = new BankService(bankRepository);

            Customer fromCustomer = bankRepository.GetAllCustomers().First();
            Customer toCustomer = bankRepository.GetAllCustomers().Last();
            Account fromAccount = fromCustomer.AccountList.First();
            Account toAccount = toCustomer.AccountList.First();

            decimal sum = fromAccount.Balance + 1;
            var expectedBalanceOnFromAccount = fromAccount.Balance;
            var expectedBalanceOnToAccount = toAccount.Balance;

            // Act
            var isSuccess = bankService.Transfer(fromAccount.AccountNumber, toAccount.AccountNumber, sum, out string message);

            // Assert
            Assert.IsFalse(isSuccess);
            Assert.AreEqual(expectedBalanceOnFromAccount, fromAccount.Balance);
            Assert.AreEqual(expectedBalanceOnToAccount, toAccount.Balance);



        }
    }
}
