using Api.Main.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Main.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        Users users = new Users();

        [Route("GetUser")]
        [HttpGet]
        public string GetUser()
        {
            return users.GetUsers();
        }

        [Route("GetUserWithId")]
        [HttpGet]
        public string GetUserWithId()
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
    }
}