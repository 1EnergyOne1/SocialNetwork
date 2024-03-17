using System;
using System.Collections.Generic;
using Api.Data.Models;
using NodaTime;

namespace Api.Data;

public partial class Mail
{
    public int Id { get; set; }

    public int ToUserId { get; set; }

    public int FromUserId { get; set; }

    public LocalDateTime DateSend { get; set; }

    public string? Message { get; set; }

    public static explicit operator Mail(DtoMail? v)
    {
        if (v is null) return null;
        else
        {
            return new Mail
            {
                Id = v.Id,
                ToUserId = v.Touserid,
                FromUserId = v.Fromuserud,
                DateSend = v.Datesend,
                Message = v.Message,
            };
        }
    }
}
