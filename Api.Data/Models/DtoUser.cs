using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public partial class DtoUser
    {
        public int id { get; set; }

        public string name { get; set; } = null!;

        public string? lastname { get; set; }

        public string login { get; set; } = null!;

        public string password { get; set; } = null!;

        public int? age { get; set; }

        public DateTime datecreate { get; set; }

        public bool isadmin { get; set; }
    }
}
