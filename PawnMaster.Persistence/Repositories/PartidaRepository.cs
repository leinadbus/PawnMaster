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
                FechaCreaciónPartida = DateTime.Now,
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
                            CaracterFicha = casilla.FichaActual.Simbolo,
                            Color = casilla.FichaActual.Color == Color.Negro? Data.Ficha.ColorFicha.Black : Data.Ficha.ColorFicha.White
                            
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

        public PartidaRecuperadaDto RecuperarEstadoPartida(int id)
        {
            

            var PartidaRecuperada = _bd.Partidas.FirstOrDefault( p => p.Id  == id );

            if ( PartidaRecuperada == null ) { throw new NotImplementedException(); }

            var PartidaDto = new PartidaRecuperadaDto()
            {
                Date = PartidaRecuperada.FechaCreaciónPartida,
                Identificador = PartidaRecuperada.Id,
                TurnoPartida = (PartidaRecuperadaDto.Turno)PartidaRecuperada.TurnoPartida,
                JugadorBlanco = PartidaRecuperada.JugadorBlanco,
                JugadorNegro = PartidaRecuperada.JugadorNegro
            };
            
            //Recogemos a los jugadores de la BD

            var UsuarioBlanco = _bd.Usuarios.FirstOrDefault(u => u.Id == PartidaRecuperada.JugadorBlancoId);
            var UsuarioNegro = _bd.Usuarios.FirstOrDefault(u => u.Id == PartidaRecuperada.JugadorNegroId);

            var JugadorBlancoModelo = new Jugador()
            {
                Nombre = UsuarioBlanco.Nombre

            };

            var JugadorNegroModelo = new Jugador()
            {
                Nombre = UsuarioNegro.Nombre

            };


            //Partida Modelo
            var PartidaModelo = new Model.Partida(JugadorBlancoModelo, JugadorNegroModelo);
            var TableroModelo = PartidaModelo.RetornarTablero();
            

           
            
                
            //Borrar las fichas del tablero
            for (char caracter = 'A'; caracter <= 'H'; caracter++)
            {
                for (int numero = 1; numero < 9; numero++)
                {
                    Coordenada origen = new Coordenada(caracter, numero);
                    if (TableroModelo.TableroJuego.TryGetValue(origen, out var casillaOrigen))
                        {
                        if (casillaOrigen.Tengoficha())
                        {
                            casillaOrigen.EliminarFicha();
                        }
                    }
                }
            }

            //Recogemos las coordenadas
            var Listafichas = _bd.Fichas.Where(f => f.partidaId == PartidaRecuperada.Id).ToList();

            foreach (var f in Listafichas)
            {
                var Coordenada = new Coordenada((char)f.PosiciónHorizontal, (int)f.PosiciónVertical);

                //CÓMO DIFERENCIO LAS FICHAS???---------------------------------------------------------------------------

                //Prueba de tablero
                TableroModelo.AñadirFichaAlTablero(Coordenada, new Peon(Color.Blanco));
            }

            TableroModelo.MostrarEstadoDelTablero();

            //PartidaDto.Tablero = TableroModelo;
            return PartidaDto;
            //throw new NotImplementedException();
        }
    }
}
