using Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebClientMVC.Models;
using WebClientMVC.Services;

namespace WebClientMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService = new UserService();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
           return View("Index");
        }
        [HttpPost]
        public IActionResult Index(string login, string password)
        {
            User user = new User();
            user.Login = login;
            user.Password = password;
            var res = _userService.GetUser(login, password);
            if (res != null)
            {
                return RedirectToAction("GetUser", "Users", user);
            }
            else
            {
                return View("Error");
            }    
        } 


    }
}