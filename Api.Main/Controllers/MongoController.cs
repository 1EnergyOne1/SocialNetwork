using Api.Data;
using Api.Data.Models;
using Api.Main.MongoRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MongoController : ControllerBase
    {
        private readonly MongoUsersRepository _repository;

       public MongoController(MongoUsersRepository repository) => _repository = repository;

        //[HttpGet]
        //public async Task<List<MongoUsers>> Get() =>
        //await _repository.GetAsync();

        [Route("GetAll")]
        [HttpGet]
        public async Task<List<MongoUsers>> GetAll()
        {
            return await _repository.GetAsync();
        }

        [Route("GetAsync")]
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<MongoUsers>> GetAsync([FromQuery] string id)
        {
            var user = await _repository.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MongoUsers newUser)
        {
            await _repository.CreateAsync(newUser);

            return CreatedAtAction(nameof(GetAsync), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, MongoUsers updatedUser)
        {
            var user = await _repository.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedUser.Id = user.Id;

            await _repository.UpdateAsync(id, updatedUser);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _repository.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            await _repository.RemoveAsync(id);

            return NoContent();
        }
    }
}
