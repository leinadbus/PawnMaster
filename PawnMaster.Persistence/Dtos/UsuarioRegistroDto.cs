using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Dtos
{
    public class UsuarioRegistroDto
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
