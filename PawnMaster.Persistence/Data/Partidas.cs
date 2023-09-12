using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Data
{
    internal class Partidas
    {
        [Key]
        public int Id { get; set; }

        public enum Turno { blancas, negras }

        public TimeOnly TiempoDeJuego { get; set; }

        [ForeignKey("jugadorBlancoId")]
        public int jugadorBlancoId { get; set; }
        public Jugadores JugadorB { get; set; }

        [ForeignKey("jugadorNegroId")]
        public int jugadorNegroId { get; set; }
        public Jugadores JugadorN { get; set; }
    }
}
