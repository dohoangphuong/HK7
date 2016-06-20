using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

// This sample was copied from http://msdn.microsoft.com/en-us/library/ms182532.aspx

namespace BankTest
{
    [TestClass]
    public class BankTests
    {
	    private BankAccount _bankAccount;
		private static BankAccount _staticBankAccount;
		
		[ClassInitialize]
		public static void MyClassInitialize(TestContext testContext)
		{
			XmlDocument doc = new XmlDocument();
			doc.Load("XMLFile1.xml");

			string customerName = doc.SelectSingleNode("/BankAccount/CustomerName").InnerText;
			double amount = Convert.ToDouble(doc.SelectSingleNode("/BankAccount/Amount").InnerText);

			_staticBankAccount = new BankAccount(customerName, amount);
		}

		[ClassCleanup]
		public static void MyClassCleanUp()
		{
			// clean-up and release memory for next test
			_staticBankAccount = null;
		}

	    [TestInitialize]
		public void MyTestInitialize()
		{
			//double beginningBalance = 11.99;

			// this value was got from xml file. See more information from MyClassInitialize() method
			double beginningBalance = _staticBankAccount.Balance;

			_bankAccount = new BankAccount("Mr. Bryan Walton", beginningBalance);
		}

		[TestCleanup]
		public void MyTestCleanUp()
		{
			// clean-up and release memory for next test
			_bankAccount = null;
		}

	    /// <summary>
	    /// Debit with valid amount
	    /// </summary>
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalanceTest()
        {
            double debitAmount = 4.55;
            double expected = 7.44;

			// double beginningBalance = 11.99;

			// ****************************************************************************
			// MyTestInitialize() method will run before this method and BankAccount 
			// object will create
            // BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // debit amount
            _bankAccount.Debit(debitAmount);

            // assert
            double actual = _bankAccount.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRangeTest()
        {
			double debitAmount = -100.00;

			//double beginningBalance = 11.99;

			// ****************************************************************************
			// MyTestInitialize() method will run before this method and BankAccount 
			// object will create
            // BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // debit amount
            _bankAccount.Debit(debitAmount);

            // assert is handled by ExpectedException
        }

        [TestMethod]
        public void Debit_WhenAmountIsGreaterThanBalance_ShouldThrowArgumentOutOfRangeTest()
        {
            double debitAmount = 20.0;

			//double beginningBalance = 11.99;

			// ****************************************************************************
			// MyTestInitialize() method will run before this method and BankAccount 
			// object will create
            // BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // debit amount
            try
            {
                _bankAccount.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException e)
            {
                // assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }
            Assert.Fail("No exception was thrown.");
         }
    }
}
