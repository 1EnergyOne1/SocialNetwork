using Api.Data.Models;
using Api.Main.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Main.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Users users;

        [Route("GetUser")]
        [HttpPost]
        public User GetUser([FromBody] string user)
        {
            return users.GetUsers(user);
        }

        [Route("GetUserWithId")]
        [HttpGet]
        public string GetUserWithId()
        {
            return "Заглушка. Информация о пользователе с id";
        }

        [Route("GetUserWitDateBirth")]
        [HttpGet]
        public string GetUserWitDateBirth([FromQuery]string dateBirth)
        {
            return "Заглушка. Информация о пользователе с id";
        }

        [Route("AddUser")]
        [HttpPost]
        public bool AddUser([FromQuery] string name, [FromQuery] string lastName, [FromQuery] int age, [FromBody]int[] jsonContent)
        {
            if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(lastName) && age != null)
            {
                return true;//$"Пользователь с именем {name}, фамилией {lastName} и возврастом {age} добавлен";
            }
            else
                return false;
        }

        [Route("AddUserWithModel")]
        [HttpPost]
        public User AddUserWithModel([FromBody] User user)
        {
            return user;
        }
    }
}