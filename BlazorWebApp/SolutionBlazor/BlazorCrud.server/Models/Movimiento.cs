using System;
using System.Collections.Generic;

namespace BlazorCrud.server.Models;

public partial class Movimiento
{
    public int Id { get; set; }

    public decimal Monto { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal TipoMov { get; set; }
    
    public int NumeroAutorizacion { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();

}
