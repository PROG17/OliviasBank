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
            //Mening är att vi ska plocka fram ett account
            var bankRepository = new BankRepository();
            var oneCustomer = bankRepository.GetAllCustomers().First();
            var account = oneCustomer.AccountList.First();

            //Kolla vad saldot är
            var aktuellSaldo = account.Balance;
            var expectedResult = aktuellSaldo + 100;

            //Sättta in 100kr
            bankRepository.Deposit(account.AccountNumber, 100);

            //Verifiera att saldot nu är gamla saldo + 100
            var result = account.Balance;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void AfterWathdraealAccountShouldHaveUpdatedBalance()
        {
            //Mening är att vi ska plocka fram ett account
            var bankRepository = new BankRepository();
            var oneCustomer = bankRepository.GetAllCustomers().First();
            var account = oneCustomer.AccountList.First();

            //Kolla vad saldot är
            var aktuellSaldo = account.Balance;
            var expectedResult = aktuellSaldo - 100;

            //Sättta in 100kr
            bankRepository.Withdrawal(account.AccountNumber, 100);

            //Verifiera att saldot nu är gamla saldo + 100
            var result = account.Balance;

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void WithdrawMoreMoneyThanBalace()
        {
            //Mening är att vi ska plocka fram ett account
            var bankRepository = new BankRepository();
            var oneCustomer = bankRepository.GetAllCustomers().First();
            var account = oneCustomer.AccountList.First();

            //Förväntar oss att saldo blir samma som innan
            var expectedResult = account.Balance;
            bankRepository.Withdrawal(account.AccountNumber, account.Balance+100);

            var result = account.Balance;

            //Förväntar oss: har 98, försöker ta 100, då ska det finnas 98 kvar (har misslyckats)
            Assert.AreEqual(expectedResult, result);
        }
    }

    //VArje test ska bara testa en enda sak och det fina är att nu när vi kör alla tester så
    //funkar den vi la till men vi 
}
