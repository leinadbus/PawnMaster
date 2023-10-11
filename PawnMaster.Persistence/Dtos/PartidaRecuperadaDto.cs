using PawnMaster.Model;
using PawnMaster.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Dtos
{
    public class PartidaRecuperadaDto
    {
        public int Identificador { get; set; }

        public DateTime Date { get; set; }

        public Tablero Tablero { get; set; }

        public Usuario JugadorBlanco { get; set; }
        public int JugadorBlancoId { get; set; }
        public Usuario JugadorNegro { get; set; }
        public int JugadorNegroId { get; set; }
        public List<string> ListaDeMovimientos { get; set; }
        //public enum Turno { white, black }
        //public Turno TurnoPartida { get; set; }

        public char TurnoPartida { get; set; }

    }
}
