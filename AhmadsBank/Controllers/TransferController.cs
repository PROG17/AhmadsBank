using AhmadsBank.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdilBank.Controllers
{
    public class TransferController : Controller
    {
        private readonly BankRepository _bankRepository;

        public TransferController(BankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }

        public IActionResult Index()
        {
            return View(_bankRepository);
        }

        [HttpPost]
        public IActionResult Index(string transactionType, double amount, string fromAccount, string targetAccount)
        {
            var withdrawalAccount = _bankRepository.Accounts.FirstOrDefault(account => account.AccountName == fromAccount);

            if (withdrawalAccount != null)
            {
                var result = _bankRepository.Transfer(amount, fromAccount, targetAccount);
                if (result == false)
                {
                    ViewBag.Message = $"Konto {fromAccount} har inte tillräckligt med pengar";
                    return View(_bankRepository);
                }

                ViewBag.Message = $"{amount} har överförts från {fromAccount} till {targetAccount}";
                return View(_bankRepository);
            }

            ViewBag.Message = $"Kontot finns ej";
            return View(_bankRepository);
        }
    }
}