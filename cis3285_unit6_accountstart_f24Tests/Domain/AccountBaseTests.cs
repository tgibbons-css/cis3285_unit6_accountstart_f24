using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Tests
{

    [TestClass]
    public class AccountsUnitTest
    {
        [TestMethod]
        public void CreateAccountSetsBalanceToZero()
        {
            // Arrange    
            AccountBase testAccount = AccountBase.CreateAccount(AccountType.Silver);
            // Act
            decimal balance = testAccount.Balance;
            // Assert
            Assert.AreEqual(0.00M, balance);
        }
        [TestMethod]
        public void DepositToAccountBalance()
        {
            // Arrange    
            AccountBase testAccount = AccountBase.CreateAccount(AccountType.Silver);
            // Act
            testAccount.AddTransaction(+123.45M);
            decimal balance = testAccount.Balance;
            // Assert
            Assert.AreEqual(+123.45M, balance);
        }
        [TestMethod]
        public void WithdrawalToAccountBalance()
        {
            // Arrange    
            AccountBase testAccount = AccountBase.CreateAccount(AccountType.Silver);
            // Act
            testAccount.AddTransaction(+200M);
            testAccount.AddTransaction(-100M);
            decimal balance = testAccount.Balance;
            // Assert
            Assert.AreEqual(+100M, balance);
        }
        [TestMethod]
        public void NegativeBalanceAllowed()
        {
            // Arrange    
            AccountBase testAccount = AccountBase.CreateAccount(AccountType.Silver);
            // Act
            testAccount.AddTransaction(+200M);
            testAccount.AddTransaction(-500M);
            decimal balance = testAccount.Balance;
            // Assert
            Assert.AreEqual(-300M, balance);
        }

        ///
        ///   =================== Reward Points
        ///
        [TestMethod]
        public void RewardPoints_Silver_Deposit()
        {
            // Arrange    
            AccountBase testAccount = AccountBase.CreateAccount(AccountType.Silver);
            // Act
            testAccount.AddTransaction(1000M);
            testAccount.AddTransaction(1000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(200, points);
        }
        [TestMethod]
        public void RewardPoints_Silver_Withdrawal()
        {
            // Arrange    
            AccountBase testAccount = AccountBase.CreateAccount(AccountType.Silver);
            // Act
            testAccount.AddTransaction(1000M);
            testAccount.AddTransaction(1000M);
            testAccount.AddTransaction(-1000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(200, points);
        }
        [TestMethod]
        public void RewardPoint_Gold_Deposit()
        {
            // Arrange    
            AccountBase testAccount = AccountBase.CreateAccount(AccountType.Gold);
            // Act
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(4000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(800 + 2 + 800, points);
        }
        [TestMethod]
        public void RewardPoints_Gold_Withdrawal()
        {
            // Arrange    
            AccountBase testAccount = AccountBase.CreateAccount(AccountType.Gold);
            // Act
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(-1000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(800 + 2 + 800, points);
        }
        [TestMethod]
        public void RewardPoints_Platinum_Deposit()
        {
            // Arrange    
            AccountBase testAccount = AccountBase.CreateAccount(AccountType.Platinum);
            // Act
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(4000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(2000 + 4 + 2000, points);
        }
        [TestMethod]
        public void RewardPoints_Platinum_Withdrawal()
        {
            // Arrange    
            AccountBase testAccount = AccountBase.CreateAccount(AccountType.Platinum);
            // Act
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(4000M);
            testAccount.AddTransaction(-1000M);
            int points = testAccount.RewardPoints;
            // Assert
            Assert.AreEqual(2000 + 4 + 2000, points);
        }
    }
}