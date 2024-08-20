using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;


namespace BlazorCrud.shared
{
    public class MovimientoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public decimal Monto { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; } = null!;
        public decimal TipoMov { get; set; }

        public int NumeroAutorizacion { get; set; }

        public DateOnly Fecha { get; set; }


    }
}
