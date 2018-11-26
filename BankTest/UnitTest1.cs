using AhmadsBank.Models;
using System;
using System.Linq;
using Xunit;

namespace BankTest
{
    public class UnitTest1
    {
        [Fact]
        public void WithdrawTest()
        {
            BankRepository repo = new BankRepository();
            Customer cust1 = new Customer { Name = "cust1", Id = 10 };
            Account acc = new Account { AccountName = "name1", Customer = cust1, Balance = 1000 };

            repo.Accounts.Add(acc);

            var result = repo.Withdraw(200, "name1");

            Assert.Equal("Godkänd", result);
            Assert.Equal(800, acc.Balance);
        }

        [Fact]
        public void DepositTest()
        {
            BankRepository repo = new BankRepository();
            Customer cust1 = new Customer { Name = "cust1", Id = 10 };
            Account acc = new Account { AccountName = "name1", Customer = cust1, Balance = 1000 };

            repo.Accounts.Add(acc);

            var result = repo.Deposit(200, "name1");

            Assert.Equal("Godkänd", result);
            Assert.Equal(1200, acc.Balance);
        }

        [Fact]
        public void WithdrawTest_Fail()
        {
            BankRepository repo = new BankRepository();
            Customer cust1 = new Customer { Name = "cust1", Id = 10 };
            Account acc = new Account { AccountName = "name1", Customer = cust1, Balance = 1000 };

            repo.Accounts.Add(acc);

            var result = repo.Withdraw(2000, "name1");

            Assert.Equal("Saknar täckning", result);
            Assert.Equal(1000, acc.Balance);
        }
    }
}
