using System;
using System.Collections.Generic;
using NodaTime;

namespace Api.Data;

public partial class Mail
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public LocalDateTime DateSend { get; set; }

    public string? Message { get; set; }

    public virtual User User { get; set; } = null!;
}
