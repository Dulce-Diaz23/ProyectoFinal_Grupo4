using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Cliente
    {
        [Required(ErrorMessage = "La identidad es obligatoria")]
        public string Identidad { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La direccion es obligatoria")]
        public string Direccion { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "El Telefono es obligatorio")]
        public string Telefono { get; set; }
    }
}
