using ApplicationCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopMVC.Controllers
{
    public class AccountController : Controller
    {
        //showing the empty register page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // when user clicks on the Submit/CreateAnAccount button
        [HttpPost]
        public IActionResult Register(UserRegisterModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            return View();
        }
    }
}
