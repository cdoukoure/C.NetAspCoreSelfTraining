using Microsoft.AspNetCore.Mvc;
using WebAspCore2.Models;
using WebAspCore2.Interfaces;

namespace WebAspCore2.Controllers
{
    public class HomeController : Controller
    {
        private IService1 _service1;

        private readonly User _user;

        public HomeController(IService1 service1)
        {
            _service1 = service1;
        }

        public IActionResult Index()
        {
            int i = _service1.GetRandomValue();

            ViewData["Message"] = "Your service1 random value is: " + i;

            var user = new User()
            {
                FirstName = "Steve",
                LastName = "Blue"
            };

            return View(user);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
