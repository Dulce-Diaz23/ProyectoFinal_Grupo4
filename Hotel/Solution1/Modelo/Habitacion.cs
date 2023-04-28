using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Habitacion
    {
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public int Codigo { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Descripcion es obligatoria")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Tipo de Habitacion es obligatorio")]
        public string TipoHabitacion { get; set; }
        [Required(ErrorMessage = "La Existencia es obligatoria")]
        public int Existencia { get; set; }
        [Required(ErrorMessage = "El Precio es obligatorio")]
        public decimal Precio  { get; set; }
        [Required(ErrorMessage = "La Fecha de Creacion es obligatoria")]
        public DateTime FechaCreacion { get; set; }
        public byte[]? Imagen { get; set; }

    }
}
