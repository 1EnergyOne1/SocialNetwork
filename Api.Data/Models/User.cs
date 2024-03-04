﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Data.Models
{
    public class User : UserAccount
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public bool isAdmin { get; set; }
    }
}
