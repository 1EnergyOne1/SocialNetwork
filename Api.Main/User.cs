using System;
using System.Collections.Generic;
using NodaTime;

namespace Api.Main;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Lastname { get; set; }

    public int? Age { get; set; }

    public LocalDateTime? Datecreate { get; set; }

    public bool? Isadmin { get; set; }
}
