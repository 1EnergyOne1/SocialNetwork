using Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace WebClientMVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult GetUser(string login, string password, User user)
        {
            ViewBag.Login = login;
            ViewBag.Password = password;
            return View();
        }
    }
}
