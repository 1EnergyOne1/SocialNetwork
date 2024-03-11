using Api.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly Services.Mail mails = new Services.Mail();

        [Route("GetAllMails")]
        [HttpGet]
        public async Task<IEnumerable<Mail>?> GetAllMails(CancellationToken ct)
        {
            return await mails.GetAllMails(ct);
        }

        [Route("GetAllMailsForUser")]
        [HttpGet]
        public async Task<IEnumerable<Mail>?> GetAllMailsForUser([FromQuery] int userId, CancellationToken ct)
        {
            return await mails.GetAllMailsForUser(userId, ct);
        }

        [Route("GetMail")]
        [HttpGet]
        public async Task<Mail?> GetMail([FromQuery] int mailId, CancellationToken ct)
        {
            return await mails.GetMail(mailId, ct);
        }

        [Route("AddMail")]
        [HttpPost]
        public async Task<ActionResult<Mail?>> AddMail([FromBody] Mail mail, CancellationToken ct)
        {
            return await mails.AddMail(mail, ct);
        }

        [Route("UpdateMail")]
        [HttpPut]
        public async Task<ActionResult<Mail?>> UpdateMail([FromBody] Mail mail, CancellationToken ct)
        {
            return await mails.UpdateMail(mail, ct);
        }

        [Route("DeleteMail")]
        [HttpDelete]
        public async Task<ActionResult<bool?>> DeleteMail([FromQuery] int mailId, CancellationToken ct)
        {
            return await mails.DeleteMail(mailId, ct);
        }
    }
}
