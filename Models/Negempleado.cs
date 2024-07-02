using System;
using System.Collections.Generic;

namespace PruebaMME.Models;

public partial class Negempleado
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public int? Idtipodocumento { get; set; }

    public decimal? Numerodocumento { get; set; }

    public string Tipoempleado { get; set; } = null!;

    public int? Idoficina { get; set; }

    public bool Activo { get; set; }
}
