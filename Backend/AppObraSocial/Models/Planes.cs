using System;
using System.Collections.Generic;

namespace AppObraSocial.Models;

public partial class Planes
{
    public int IdPlan { get; set; }

    public string Descripcion { get; set; } = null!;

    public double Cuota { get; set; }

    public virtual Cliente? Cliente { get; set; }
}
