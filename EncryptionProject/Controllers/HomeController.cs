using Microsoft.AspNetCore.Mvc;
using Utilities.Extentions;

namespace EncryptionProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly string EncryptionKey;
        public HomeController(IConfiguration config)
        {
            EncryptionKey = config.GetSection("EncryptionKey").Get<string>();
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(string plainText)
        {
            ViewBag.PalinText = plainText;
            var encryptedText = plainText.EncryptString(EncryptionKey);
            return View("index",encryptedText);
        }
    }
}