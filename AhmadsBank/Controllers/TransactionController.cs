using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AhmadsBank.Models;
using Microsoft.AspNetCore.Mvc;

namespace AhmadsBank.Controllers
{
    public class TransactionController : Controller
    {
        private BankRepository _repo;

        public TransactionController(BankRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo);
        }

        [HttpPost]
        public IActionResult Index(string transactionType, double accountBalance, double amount, string accountName)
        {
            if(transactionType == "Uttag")
            {
                if (amount > accountBalance)
                {
                    ViewBag.Message = "Värdet är för högt!";
                    return View(_repo);
                }
                _repo.Withdraw(amount, accountName);
                double sum = accountBalance - amount;
                ViewBag.Message = $"Det har dragits {amount} från kontot {accountName}, saldo är nu {sum}";
                return View(_repo);
            }
            else
            {
                _repo.Deposit(amount, accountName);
                double sum = accountBalance + amount;
                ViewBag.Message = $"Det har lagts till {amount} till kontot {accountName}, saldo är nu {sum}";
                return View(_repo);
            }
        }
    }
}