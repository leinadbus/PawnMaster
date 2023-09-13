using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Data
{
    public class Partidas
    {

        public int Id { get; set; }
        public enum Turno { white, black }
        public TimeSpan TiempoDeJuego { get; set; }
        public bool PartidaEnJuego { get; set; }

        public int jugadorBlancoId { get; set; }
        public Jugadores JugadorB { get; set; }

        public int jugadorNegroId { get; set; }
        public Jugadores JugadorN { get; set; }
    }
}
