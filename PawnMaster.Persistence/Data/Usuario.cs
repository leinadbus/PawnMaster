using NHibernate.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Data
{
    public class Usuario 
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }
        public byte[]? RutaImagen { get; set; }
        public ICollection<Partida> PartidasJugadasComoBlancas { get; set; } 
        public ICollection<Partida> PartidasJugadasComoNegras { get; set; }
        public DateTime CreacionCuenta { get; set; } = DateTime.Now;
        public string Role { get; set; }

    }
}
