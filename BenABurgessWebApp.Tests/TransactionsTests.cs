using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BenABurgessWebApp.Controllers;
using BenABurgessWebApp.Models;
using System.Web;
using System.Security.Principal;


namespace BenABurgessWebApp.Tests
{
    [TestClass]
    public class TransactionsTests
    {
        [TestMethod]
        public void Test_For_TransactionAccountId()
        {
            //Log myself in using GenericPrincipal
            IPrincipal principal = new GenericPrincipal(
                new GenericIdentity("anathemus@gmail.com"),
                new string[0]
                );
            ApplicationDbContext db = new ApplicationDbContext();

            string genericUser = principal.Identity.Name;

            bool transactionsAccount = HasTransactionsAccount.HasTransactionAccount(genericUser); 

            Assert.IsFalse(transactionsAccount);
        }
    }
}