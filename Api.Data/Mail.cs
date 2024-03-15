using System;
using System.Collections.Generic;
using Api.Data.Models;
using NodaTime;

namespace Api.Data;

public partial class Mail
{
    public int Id { get; set; }

    public int Userid { get; set; }

    public LocalDateTime Datesend { get; set; }

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
                Userid = v.userid,
                Datesend = v.datesend,
                Message = v.message
            };
        }
    }
}
