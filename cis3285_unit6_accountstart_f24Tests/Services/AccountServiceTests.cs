using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass]
    public class AccountServiceUnitTest
    {
        [TestMethod]
        public void CreateAccountSetsBalanceToZero()
        {
            // Arrange    
            AccountService acctService = new AccountService();
            // Act
            string accountName = "Test1";
            acctService.CreateAccount(accountName, AccountType.Silver);
            decimal balance = acctService.GetAccountBalance(accountName);
            // Assert
            Assert.AreEqual(0.00M, balance);
        }

        [TestMethod]
        public void DepositAddsFundsToAccountBalance()
        {
            // Arrange    
            AccountService acctService = new AccountService();
            // Act
            string accountName = "Test2";
            acctService.CreateAccount(accountName, AccountType.Silver);
            acctService.Deposit(accountName, 100M);
            acctService.Deposit(accountName, 25M);
            decimal balance = acctService.GetAccountBalance(accountName);
            // Assert
            Assert.AreEqual(125M, balance);
        }

        [TestMethod]
        public void WithdrawalRemovesFundsFromAccountBalance()
        {
            // Arrange    
            AccountService acctService = new AccountService();
            // Act
            string accountName = "Test2";
            acctService.CreateAccount(accountName, AccountType.Silver);
            acctService.Deposit(accountName, 100M);
            acctService.Withdrawal(accountName, 25M);
            decimal balance = acctService.GetAccountBalance(accountName);
            // Assert
            Assert.AreEqual(75M, balance);
        }

        [TestMethod]
        public void WithdrawalCanCreateNegativeBalance()
        {
            // Arrange    
            AccountService acctService = new AccountService();
            // Act
            string accountName = "Test2";
            acctService.CreateAccount(accountName, AccountType.Silver);
            acctService.Withdrawal(accountName, 100M);
            decimal balance = acctService.GetAccountBalance(accountName);
            // Assert
            Assert.AreEqual(-100M, balance);
        }

        [TestMethod]
        public void RewardPoints_Silver_Deposit()
        {
            // Arrange    
            AccountService acctService = new AccountService();
            // Act
            string accountName = "Test3";
            acctService.CreateAccount(accountName, AccountType.Silver);
            acctService.Deposit(accountName, 1000M);
            acctService.Deposit(accountName, 1000M);
            int points = acctService.GetRewardPoints(accountName);
            // Assert
            Assert.AreEqual(200, points);
        }
        [TestMethod]
        public void RewardPoints_Silver_Withdrawal()
        {
            // Arrange    
            AccountService acctService = new AccountService();
            // Act
            string accountName = "Test3";
            acctService.CreateAccount(accountName, AccountType.Silver);
            acctService.Deposit(accountName, 1000M);
            acctService.Deposit(accountName, 1000M);
            acctService.Withdrawal(accountName, 1000M);
            int points = acctService.GetRewardPoints(accountName);
            // Assert
            Assert.AreEqual(200, points);
        }
        [TestMethod]
        public void RewardPoints_Gold_Deposit()
        {
            // Arrange    
            AccountService acctService = new AccountService();
            // Act
            string accountName = "Test3";
            acctService.CreateAccount(accountName, AccountType.Gold);
            acctService.Deposit(accountName, 4000M);
            acctService.Deposit(accountName, 4000M);
            int points = acctService.GetRewardPoints(accountName);
            // Assert
            Assert.AreEqual(800 + 2 + 800, points);
        }
        [TestMethod]
        public void RewardPoints_Gold_Withdrawal()
        {
            // Arrange    
            AccountService acctService = new AccountService();
            // Act
            string accountName = "Test3";
            acctService.CreateAccount(accountName, AccountType.Gold);
            acctService.Deposit(accountName, 4000M);
            acctService.Deposit(accountName, 4000M);
            acctService.Withdrawal(accountName, 4000M);
            int points = acctService.GetRewardPoints(accountName);
            // Assert
            Assert.AreEqual(800 + 2 + 800, points);
        }
        [TestMethod]
        public void RewardPoints_Platinum_Deposit()
        {
            // Arrange    
            AccountService acctService = new AccountService();
            // Act
            string accountName = "Test3";
            acctService.CreateAccount(accountName, AccountType.Platinum);
            acctService.Deposit(accountName, 4000M);
            acctService.Deposit(accountName, 4000M);
            int points = acctService.GetRewardPoints(accountName);
            // Assert
            Assert.AreEqual(2000 + 4 + 2000, points);
        }
        [TestMethod]
        public void RewardPoints_Platinum_Withdrawal()
        {
            // Arrange    
            AccountService acctService = new AccountService();
            // Act
            string accountName = "Test3";
            acctService.CreateAccount(accountName, AccountType.Platinum);
            acctService.Deposit(accountName, 4000M);
            acctService.Deposit(accountName, 4000M);
            acctService.Withdrawal(accountName, 4000M);
            int points = acctService.GetRewardPoints(accountName);
            // Assert
            Assert.AreEqual(2000 + 4 + 2000, points);
        }
    }
}