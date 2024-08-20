using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlazorCrud.shared
{
    public class TarjetaDTO
    {
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int IdTitular { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string NumeroTarjeta { get; set; } = null!;

        public decimal? SaldoTotal { get; set; }

        public decimal? SaldoMin { get; set; }

        public decimal? Interes { get; set; }

        public decimal? PagoMin { get; set; }

        public decimal? TotalAPagar { get; set; }

        public decimal? InteresBono { get; set; }

        public TitularDTO? Titular { get; set; }
    }
}
