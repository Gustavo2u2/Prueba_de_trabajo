using System;
using System.Collections.Generic;

namespace BlazorCrud.server.Models;

public partial class Titulare
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public virtual ICollection<Tarjeta> Tarjeta { get; set; } = new List<Tarjeta>();
}
