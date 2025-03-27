using System.Diagnostics;
using BadmintonBookingSystemAPI.Models;
using CustomerManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonBookingSystemAPI.Controllers
{
    public class FAQController : Controller
    {
        private readonly ILogger<FAQController> _logger;

        public FAQController(ILogger<FAQController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}