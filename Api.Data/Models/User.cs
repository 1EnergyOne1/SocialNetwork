﻿using System;
using System.Collections.Generic;
using NodaTime;

namespace Api.Data.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Lastname { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Age { get; set; }

    public LocalDateTime Datecreate { get; set; }

    public bool Isadmin { get; set; }
}
