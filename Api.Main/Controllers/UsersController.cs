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

        //[Route("GetUser")]
        //[HttpGet]
        //public async Task<ActionResult<User?>> GetUser([FromQuery] string login, [FromQuery] string password, CancellationToken ct)
        //{
        //    return await users.GetUser(login, password, ct);
        //}

        //[Route("GetAllUsers")]
        //[HttpGet]
        //public async Task<IEnumerable<User>?> GetAllUsers(CancellationToken ct)
        //{
        //    return await users.GetAllUsers(ct);
        //}

        //[Route("AddUser")]
        //[HttpPost]
        //public async Task<ActionResult<User?>> AddUser([FromBody] User user, CancellationToken ct)
        //{
        //    return await users.AddUser(user, ct);
        //}

        //[Route("UpdateUser")]
        //[HttpPut]
        //public async Task<ActionResult<User>> UpdateUser([FromBody] User user, CancellationToken ct)
        //{
        //    return await users.UpdateUser(user, ct);
        //}

        //[Route("DeleteUser")]
        //[HttpDelete]
        //public async Task<ActionResult<bool?>> DeleteUser([FromQuery] int id, CancellationToken ct)
        //{
        //    return await users.DeleteUser(id, ct);
        //}
    }
}