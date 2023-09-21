using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Dtos
{
    public class UsuarioLoginDto
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string Password { get; set; }
    }
}
