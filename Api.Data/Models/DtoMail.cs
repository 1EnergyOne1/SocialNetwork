using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public partial class DtoMail
    {
        public int id { get; set; }

        public int userId { get; set; }

        public LocalDateTime dateSend { get; set; }

        public string? message { get; set; }

        public virtual User user { get; set; } = null!;
    }
}
