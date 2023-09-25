using Microsoft.EntityFrameworkCore;
using PawnMaster.Persistence.Data;

namespace PawnMaster.Persistence.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext(string connectionString) : base(GetDbContextOptions(connectionString))
        {
        }

        private static DbContextOptions<ApplicationDbContext> GetDbContextOptions(string connectionString)
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var partidas = builder.Entity<Partida>();
            partidas.HasKey(p => p.Id);
            partidas.HasOne(x => x.JugadorBlanco)
                .WithMany(x => x.PartidasJugadasComoBlancas)
                .HasForeignKey("JugadorBlancoId")
                .OnDelete(DeleteBehavior.Restrict).IsRequired();
            partidas.HasOne(x => x.JugadorNegro)
                .WithMany(x => x.PartidasJugadasComoNegras)
                .HasForeignKey("JugadorNegroId")
                .OnDelete(DeleteBehavior.Restrict).IsRequired();

            var jugadores = builder.Entity<Usuario>();
            jugadores.HasKey(p => p.Id);

            var fichas = builder.Entity<Ficha>();
            fichas.HasKey(p => p.Id);
            fichas.HasOne(p => p.Partida)
            .WithMany()
            .HasForeignKey(p => p.partidaId);
        }

        //Aquí agregamos los modelos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<Partida> Partidas { get; set; }



    }
}
