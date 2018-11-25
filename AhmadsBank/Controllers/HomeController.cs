using AhmadsBank.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AhmadsBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankRepository _repo;

        public HomeController(BankRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View(_repo);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
