using AhmadsBank.Models;
using Xunit;

namespace AhmadsBankTest
{
    public class BankRepositoryTest
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

        [Fact]
        public void Transfer()
        {
            var bankRepository = new BankRepository();
            var cutomer1 = new Customer { Name = "Ahmad", Id = 11 };
            var account1 = new Account { AccountName = "Account1", Customer = cutomer1, Balance = 1000 };
            var cutomer2 = new Customer { Name = "Adil", Id = 14 };
            var account2 = new Account { AccountName = "Account2", Customer = cutomer1, Balance = 100 };

            bankRepository.Accounts.Add(account1);
            bankRepository.Accounts.Add(account2);

            bankRepository.Transfer(200, "Account1", "Account2");

            Assert.Equal(300, account2.Balance);
            Assert.Equal(800, account1.Balance);
        }

        [Fact]
        public void Transfer_fail()
        {
            var bankRepository = new BankRepository();
            var cutomer1 = new Customer { Name = "Ahmad", Id = 11 };
            var account1 = new Account { AccountName = "Account1", Customer = cutomer1, Balance = 1000 };
            var cutomer2 = new Customer { Name = "Adil", Id = 14 };
            var account2 = new Account { AccountName = "Account2", Customer = cutomer1, Balance = 100 };

            bankRepository.Accounts.Add(account1);
            bankRepository.Accounts.Add(account2);

            var result = bankRepository.Transfer(2000, "Account1", "Account2");

            Assert.False(result);
            Assert.Equal(1000, account1.Balance);
        }
    }
}