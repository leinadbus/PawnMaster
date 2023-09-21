using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.API.Dtos
{
    public class UsuarioRegistroAPIDto
    {
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Email { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio")]
        public string Contraseña { get; set; }
        public string Role { get; set; }
    }
}
