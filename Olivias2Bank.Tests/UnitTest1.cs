using Microsoft.VisualStudio.TestTools.UnitTesting;
using OliviasBank.DataLayer;
using OliviasBank.Models.BankModels;
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
            Customer oneCustomer = bankRepository.GetAllCustomers().First();
            Account account = oneCustomer.AccountList.First();
            
            //Arrange
            decimal currentBalance = account.Balance;
            decimal amount = 100;
            decimal expectedResult = currentBalance + amount;

            //Act
            bankRepository.Deposit(account.AccountNumber, amount);

            //Assert
            var result = account.Balance;
            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AfterWithrawalAccountShouldHaveUpdatedBalanceTest()
        {
            BankRepository bankRepository = new BankRepository();
            Customer oneCustomer = bankRepository.GetAllCustomers().First();
            Account account = oneCustomer.AccountList.First();

            //Arrange
            decimal currentBalance = account.Balance;
            decimal amount = 100;
            decimal expectedResult = currentBalance - amount;

            //Act
            bankRepository.Withdrawal(account.AccountNumber, amount);

            //Assert
            var result = account.Balance;
            Assert.AreEqual(expectedResult, result);
        }
       
        //[TestMethod]
        //public void WithdrawMoreMoneyThanBalace()
        //{
        //    //Mening är att vi ska plocka fram ett account
        //    var bankRepository = new BankRepository();
        //    var oneCustomer = bankRepository.GetAllCustomers().First();
        //    var account = oneCustomer.AccountList.First();

        //    //Förväntar oss att saldo blir samma som innan
        //    var expectedResult = account.Balance;
        //    bankRepository.Withdrawal(account.AccountNumber, account.Balance + 100);

        //    var result = account.Balance;

        //    //Förväntar oss: har 98, försöker ta 100, då ska det finnas 98 kvar (har misslyckats)
        //    Assert.AreEqual(expectedResult, result);
        //}
    }
}
