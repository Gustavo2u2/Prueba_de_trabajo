using System;
using System.Collections.Generic;

namespace BlazorCrud.server.Models;

public partial class Transaccione
{
    public int Id { get; set; }

    public int? IdMovimiento { get; set; }

    public int IdTarjeta { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual Movimiento IdMovimientoNavigation { get; set; } = null!;

    public virtual Tarjeta IdTarjetaNavigation { get; set; } = null!;
}
