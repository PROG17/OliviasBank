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
        public void AfterDepositAccountShouldHaveUpdateBalance()
        {
            BankRepository bankRepository = new BankRepository();
            Customer oneCustomer = bankRepository.GetAllCustomers().First();
            Account account = oneCustomer.AccountList.First();
            
            //Arrange
            decimal currentBalance = account.Balance;
            decimal amountToDeposit = 100;
            decimal expectedResult = currentBalance + amountToDeposit;

            //Act
            bankRepository.Deposit(account.AccountNumber, amountToDeposit);

            //Assert
            var result = account.Balance;
            Assert.AreEqual(expectedResult, result);
        }

        //[TestMethod]
        //public void AfterDepositAccountShouldHaveUpdatedBalance2()
        //{
        //    //Mening �r att vi ska plocka fram ett account
        //    var bankRepository = new BankRepository();
        //    var oneCustomer = bankRepository.GetAllCustomers().First();
        //    var account = oneCustomer.AccountList.First();

        //    //Kolla vad saldot �r
        //    var aktuellSaldo = account.Balance;
        //    var expectedResult = aktuellSaldo + 100;

        //    //S�ttta in 100kr
        //    bankRepository.Deposit2(account.AccountNumber, 100);

        //    //Verifiera att saldot nu �r gamla saldo + 100
        //    var result = account.Balance;

        //    Assert.AreEqual(expectedResult, result);
        //}

        //[TestMethod]
        //public void AfterWathdraealAccountShouldHaveUpdatedBalance()
        //{
        //    //Mening �r att vi ska plocka fram ett account
        //    var bankRepository = new BankRepository();
        //    var oneCustomer = bankRepository.GetAllCustomers().First();
        //    var account = oneCustomer.AccountList.First();

        //    //Kolla vad saldot �r
        //    var aktuellSaldo = account.Balance;
        //    var expectedResult = aktuellSaldo - 100;

        //    //S�ttta in 100kr
        //    bankRepository.Withdrawal(account.AccountNumber, 100);

        //    //Verifiera att saldot nu �r gamla saldo + 100
        //    var result = account.Balance;

        //    Assert.AreEqual(expectedResult, result);
        //}

        //[TestMethod]
        //public void WithdrawMoreMoneyThanBalace()
        //{
        //    //Mening �r att vi ska plocka fram ett account
        //    var bankRepository = new BankRepository();
        //    var oneCustomer = bankRepository.GetAllCustomers().First();
        //    var account = oneCustomer.AccountList.First();

        //    //F�rv�ntar oss att saldo blir samma som innan
        //    var expectedResult = account.Balance;
        //    bankRepository.Withdrawal(account.AccountNumber, account.Balance + 100);

        //    var result = account.Balance;

        //    //F�rv�ntar oss: har 98, f�rs�ker ta 100, d� ska det finnas 98 kvar (har misslyckats)
        //    Assert.AreEqual(expectedResult, result);
        //}
    }
}
