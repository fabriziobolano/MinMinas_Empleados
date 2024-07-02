using System;
using System.Collections.Generic;

namespace PruebaMME.Models;

public partial class Negoficina
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool Activo { get; set; }
}
