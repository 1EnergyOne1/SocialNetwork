using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public partial class Mail
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public Instant DateSend { get; set; }

        public string? Message { get; set; }

        public virtual User User { get; set; } = null!;

        public static explicit operator Mail(DtoMail? v)
        {
            if (v is null) return null;
            else
            {
                return new Mail
                {
                    Id = v.id,
                    UserId = v.userId,
                    DateSend = v.dateSend,
                    Message = v.message
                };
            }
        }
    }
}
