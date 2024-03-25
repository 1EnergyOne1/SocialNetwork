using Api.Data;
using Microsoft.AspNetCore.Mvc;
using WebClientMVC.Services;

namespace WebClientMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService _userService = new UserService();
        [HttpGet]
        public IActionResult GetUser(User user)
        {   
            return View(user);
        }

        [HttpPost]
        public IActionResult GetUser()
        {
            return RedirectToAction("AllUsers");
        }

        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            var res = await _userService.GetAllUsers();
            var admins = res.Where(x => x.Isadmin == true);
            return View(admins);
        }

        [HttpPost]
        public async Task<IActionResult> AllUsers(string login, string password)
        {
            User user = new User();
            user.Login = login;
            user.Password = password;
            return RedirectToAction("AddAdmin", user);
        }

        public async Task<IActionResult> AddAdmin(User user)
        {
            user.Name = user.Login;
            user.Isadmin = true;
            var res = await _userService.AddAdmin(user);
            return View(res);
        }
    }
}
