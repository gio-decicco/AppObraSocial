using System;
using System.Collections.Generic;

namespace AppObraSocial.Models;

public partial class Log
{
    public int Id { get; set; }

    public string Evento { get; set; } = null!;

    public DateOnly Date { get; set; }
}
