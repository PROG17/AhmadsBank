using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhmadsBank.Models
{
    public class BankRepository
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Account> Accounts { get; set; } = new List<Account>();

        public BankRepository()
        {
            Customers.Add(new Customer { Id = 1, Name = "Ahmad" });
            Customers.Add(new Customer { Id = 2, Name = "Adil" });
            Customers.Add(new Customer { Id = 3, Name = "Kerstin" });

            Accounts.Add(new Account { AccountName = "Personkonto", Customer = Customers[0], Balance = 2000 });
            //Accounts.Add(new Account { AccountName = "Kapitalkonto", Customer = Customers[0], Balance = 30000 });

            Accounts.Add(new Account { AccountName = "Personkonto", Customer = Customers[1], Balance = 20000 });
            //Accounts.Add(new Account { AccountName = "Kapitalkonto", Customer = Customers[1], Balance = 100000 });

            Accounts.Add(new Account { AccountName = "Personkonto", Customer = Customers[2], Balance = 20000 });
            //Accounts.Add(new Account { AccountName = "Kapitalkonto", Customer = Customers[2], Balance = 5000000 });
        }
    }
}
