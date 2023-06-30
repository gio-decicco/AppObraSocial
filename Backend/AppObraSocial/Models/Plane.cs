using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AppObraSocial.Models;

public partial class Plane
{
    public int IdPlan { get; set; }

    public string Descripcion { get; set; } = null!;

    public double Cuota { get; set; }

    [JsonIgnore]
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
