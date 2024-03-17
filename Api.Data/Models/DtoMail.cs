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
        public int Id { get; set; }

        public int Touserid { get; set; }

        public int Fromuserid { get; set; }

        public LocalDateTime Datesend { get; set; }

        public string? Message { get; set; }
    }
}
