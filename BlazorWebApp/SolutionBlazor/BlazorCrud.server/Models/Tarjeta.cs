using System;
using System.Collections.Generic;

namespace BlazorCrud.server.Models;

public partial class Tarjeta
{
    public int Id { get; set; }

    public int IdTitular { get; set; }

    public string NumeroTarjeta { get; set; } = null!;

    public decimal? SaldoTotal { get; set; }

    public decimal? SaldoMin { get; set; }

    public decimal? Interes { get; set; }

    public decimal? PagoMin { get; set; }

    public decimal? TotalAPagar { get; set; }

    public decimal? InteresBono { get; set; }

    public virtual Titulare IdTitularNavigation { get; set; } = null!;

    public virtual ICollection<Transaccione> Transacciones { get; set; } = new List<Transaccione>();
}
