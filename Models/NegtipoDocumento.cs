using System;
using System.Collections.Generic;

namespace PruebaMME.Models;

public partial class NegtipoDocumento
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int Orden { get; set; }

    public bool Activo { get; set; }
}
