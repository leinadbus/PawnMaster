using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore;
using PawnMaster.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Data
{
    public class Partida
    {

        public int Id { get; set; }
        public enum Turno {white,black}
        public Turno TurnoPartida { get; set; }
        public TimeSpan TiempoDeJuego { get; set; }
        public bool PartidaEnJuego { get; set; }
        public int? Ganador { get; set; }
       
        public int JugadorBlancoId { get; set; }
        public Usuario JugadorBlanco { get; set; }
        
        public int JugadorNegroId { get; set; }
        public Usuario JugadorNegro { get; set; }
        public string? ListaDeMovimientos { get; set; }
    }
}
