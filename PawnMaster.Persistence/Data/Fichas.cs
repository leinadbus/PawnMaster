using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Data
{
    public class Fichas
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("partidaId")]
        public int partidaId { get; set; }
        public Partidas Partida { get; set; }

        public enum TipoFicha { P, K, Q, R, N, B }
        public enum ColorFicha { White, Black }
        public int NumeroMovimientos { get; set; }
        public char PosiciónHorizontal { get; set; } 
        public int PosiciónVertical { get; set; }
        public bool EnJuego { get; set; }

    }
}
