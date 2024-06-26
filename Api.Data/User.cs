﻿using System;
using System.Collections.Generic;
using Api.Data.Models;
using NodaTime;

namespace Api.Data;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Lastname { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? Age { get; set; }

    public DateTime Datecreate { get; set; }

    public bool Isadmin { get; set; }

    public static explicit operator User(DtoUser? v)
    {
        if (v is null) return null;
        else
        {
            return new User
            {
                Id = v.id,
                Name = v.name,
                Lastname = v.lastname,
                Login = v.login,
                Password = v.password,
                Age = v.age,
                Datecreate = v.datecreate,
                Isadmin = v.isadmin
            };
        }
    }
}
