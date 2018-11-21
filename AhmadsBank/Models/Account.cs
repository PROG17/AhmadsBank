using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AhmadsBank.Models
{
    public class Account
    {
        public string AccountName { get; set; }
        public double Balance { get; set; }
        public Customer Customer { get; set; }
    }
}
