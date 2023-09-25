using PawnMaster.Model;
using PawnMaster.Persistence.Data;
using PawnMaster.Persistence.Dtos;
using PawnMaster.Persistence.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Persistence.Repositories
{
    public class PartidaRepository : InterfazPartidaRepository
    {
        private readonly ApplicationDbContext _bd;
        public PartidaRepository(ApplicationDbContext bd)
        {
            this._bd = bd;
        }

        public bool CrearPartida(PartidaDto Partida,int IdBlanco, int IdNegro)
        {
            //Pasarla a objeto de _Bd
            var PartidaABaseDatos = new Data.Partida() {
                JugadorBlancoId = IdBlanco,
                JugadorNegroId = IdNegro,
                PartidaEnJuego = true,
                TiempoDeJuego = DateTime.Now - Partida.Date,
                TurnoPartida = Data.Partida.Turno.white
            };

            _bd.Partidas.Add(PartidaABaseDatos);
            
            //Bucle que vaya por todas las casillas, si función TengoFicha NO es Null, metemos esa ficha a la bbdd con el id de la partida.

            //Aquí la comprobación del tablero
            for (char caracter = 'A'; caracter <= 'H'; caracter++)
            {
                for (int numero = 1; numero < 9; numero++)
                {
                    var casilla = Partida.Tablero.SeleccionarCasilla(caracter, numero);
                    if (casilla.Tengoficha())
                    {
                        var ficha = new Data.Ficha()
                        {
                            EnJuego = true,
                            NumeroMovimientos = 0,
                            PosiciónHorizontal = caracter,
                            PosiciónVertical = numero,
                            Partida = PartidaABaseDatos,
                            CaracterFicha = casilla.FichaActual.Simbolo
                            
                        };
                        _bd.Fichas.Add(ficha);
                    }
                }
            }

            _bd.SaveChanges();
            return true;
        }

        public bool GuardarEstadoPartida(PartidaDto partida)
        {
            //partida.
            throw new NotImplementedException();
        }

        public PartidaDto RecuperarEstadoPartida(int id)
        {
            throw new NotImplementedException();
        }
    }
}
