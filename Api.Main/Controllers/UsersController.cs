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
        private readonly Users users = new Users();

        [Route("GetUser")]
        [HttpGet]
        public async Task<ActionResult<User>> GetUser([FromQuery] string login, [FromQuery] string password, CancellationToken ct)
        {
            var res =  await users.GetUsers(login, password, ct);
            return res;
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] User user, CancellationToken ct)
        {
            return await users.AddUser(user, ct);
        }
    }
}