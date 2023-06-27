using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppObraSocial.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Document { get; set; }

    public int IdPlan { get; set; }

    [JsonIgnore]
    public virtual Planes IdPlanNavigation { get; set; } = null!;
}
