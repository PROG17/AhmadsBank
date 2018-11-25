using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhmadsBank.Models
{
    public class BankRepository
    {
        public List<Customer> Customers;
        public List<Account> Accounts;

        public BankRepository()
        {
            Customers = new List<Customer>();
            Accounts = new List<Account>();
            Customers.Add(new Customer { Id = 1, Name = "Ahmad" });
            Customers.Add(new Customer { Id = 2, Name = "Adil" });
            Customers.Add(new Customer { Id = 3, Name = "Kerstin" });

            Accounts.Add(new Account { AccountName = "Pahmad", Customer = Customers[0], Balance = 2000 });
            Accounts.Add(new Account { AccountName = "Padil", Customer = Customers[1], Balance = 20000 });
            Accounts.Add(new Account { AccountName = "Pkerstin", Customer = Customers[2], Balance = 20000 });
        }

        public string Deposit(double depositAmount, string toAccountName)
        {
            var targetAccount = Accounts.Where(x => x.AccountName == toAccountName).FirstOrDefault();

            if (targetAccount != null)
            {
                targetAccount.Balance = targetAccount.Balance + depositAmount;
                return "Godkänd";

            }
            else
            {
                return "Konto finns ej";
            }
        }


        public string Withdraw(double withdrawAmount, string toAccountName)
        {
            var targetAccount = Accounts.Where(x => x.AccountName == toAccountName).FirstOrDefault();
            if (targetAccount != null)
            {

                if (targetAccount.Balance >= withdrawAmount)
                {
                    targetAccount.Balance = targetAccount.Balance - withdrawAmount;
                    return "Godkänd";
                }
                else
                {
                    return "Saknar täckning";
                }
            }
            else
            {
                return "Konto finns ej";
            }
        }
    }
}
