using PawnMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Dtos
{
    public class PartidaDto
    {
        public Guid Identificador { get; set; }

        public DateTime Date { get; set; }

        public Tablero Tablero { get; set; }

        public Jugador JugadorBlanco { get; set; }
        public Jugador JugadorNegro { get; set; }

        public List<string> ListaDeMovimientos { get; set; }

        public Jugador JugadorActual { get; set; }
    }
}
