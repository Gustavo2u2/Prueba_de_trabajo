
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.shared
{
    public class TransaccionDTO
    {

        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int? IdMovimiento { get; set; }
        [Required]
        [Range(1,int.MaxValue, ErrorMessage = "El campo {0} es requerido")]
        public int IdTarjeta { get; set; }

        public DateOnly Fecha { get; set; }

        public virtual MovimientoDTO? IdMovimientoNavigation { get; set; }

        public virtual TarjetaDTO IdTarjetaNavigation { get; set; } = null!;

        public MovimientoDTO? Movimiento { get; set; }

        public TarjetaDTO? Tarjeta { get; set; }
    }
}
