using Microsoft.VisualStudio.TestTools.UnitTesting;
using OliviasBank.DataLayer;
using System.Linq;

namespace OliviasBank.Tests
{
    [TestClass]
    public class BankRepositoryTests
    {
        [TestMethod]
        public void AfterDepositAccountShouldHaveUpdatedBalance()
        {
            //Mening �r att vi ska plocka fram ett account
            var bankRepository = new BankRepository();
            var oneCustomer = bankRepository.GetAllCustomers().First();
            var account = oneCustomer.AccountList.First();

            //Kolla vad saldot �r
            var aktuellSaldo = account.Balance;
            var expectedResult = aktuellSaldo + 100;

            //S�ttta in 100kr
            bankRepository.Deposit(account.AccountNumber, 100);

            //Verifiera att saldot nu �r gamla saldo + 100
            var result = account.Balance;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AfterWathdraealAccountShouldHaveUpdatedBalance()
        {
            //Mening �r att vi ska plocka fram ett account
            var bankRepository = new BankRepository();
            var oneCustomer = bankRepository.GetAllCustomers().First();
            var account = oneCustomer.AccountList.First();

            //Kolla vad saldot �r
            var aktuellSaldo = account.Balance;
            var expectedResult = aktuellSaldo - 100;

            //S�ttta in 100kr
            bankRepository.Withdrawal(account.AccountNumber, 100);

            //Verifiera att saldot nu �r gamla saldo + 100
            var result = account.Balance;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WithdrawMoreMoneyThanBalace()
        {
            //Mening �r att vi ska plocka fram ett account
            var bankRepository = new BankRepository();
            var oneCustomer = bankRepository.GetAllCustomers().First();
            var account = oneCustomer.AccountList.First();

            //F�rv�ntar oss att saldo blir samma som innan
            var expectedResult = account.Balance;
            bankRepository.Withdrawal(account.AccountNumber, account.Balance+100);

            var result = account.Balance;

            //F�rv�ntar oss: har 98, f�rs�ker ta 100, d� ska det finnas 98 kvar (har misslyckats)
            Assert.AreEqual(expectedResult, result);
        }
    }

    //VArje test ska bara testa en enda sak och det fina �r att nu n�r vi k�r alla tester s�
    //funkar den vi la till men vi 
}
