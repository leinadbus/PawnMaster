﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Data
{
    public class Ficha
    {
        public int Id { get; set; }
        public char CaracterFicha { get; set; }
        public int partidaId { get; set; }
        public Partida Partida { get; set; }
        public enum TipoFicha { P, K, Q, R, N, B }
        public enum ColorFicha { White, Black }
        public ColorFicha Color { get; set; }
        public int NumeroMovimientos { get; set; }
        public char? PosiciónHorizontal { get; set; } 
        public int? PosiciónVertical { get; set; }
        public bool EnJuego { get; set; }

    }
}
