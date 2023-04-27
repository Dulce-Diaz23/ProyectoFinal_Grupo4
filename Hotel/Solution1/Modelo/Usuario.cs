using System.ComponentModel.DataAnnotations;

namespace Modelos
{
    public class Usuario
    {
        [Required(ErrorMessage = "El codigo es obligatorio")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La Contrasena es obligatoria")]
        public string Contrasena { get; set; }
        public string? Correo { get; set; }
        [Required(ErrorMessage = "El Rol es obligatorio")]
        public string Rol { get; set; }
        public bool EstaActivo { get; set; }
    }

}
