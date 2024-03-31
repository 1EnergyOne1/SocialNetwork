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

        public HomeController() { }

        [HttpGet]
        public IActionResult Index()
        {
           ViewData["Index"] = "Hello, World!";
           return View("Index");
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(string login, string password)
        {
            User user = new User();
            user.Login = login;
            user.Password = password;
            var res = await _userService.GetUser(login, password);
            if (res != null && res.Isadmin == true)
            {
                return RedirectToAction("GetUser", "Users", res);
            }
            else
            {
                return View("Error");
            }    
        } 


    }
}