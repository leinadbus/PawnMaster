using PawnMaster.Model;
using PawnMaster.Persistence.Data;
using PawnMaster.Persistence.Dtos;
using PawnMaster.Persistence.Repositories.InterfaceRepository;
using Partida = PawnMaster.Persistence.Data.Partida;

namespace PawnMaster.Persistence.Repositories
{
    public class PartidaRepository : InterfazPartidaRepository
    {
        private readonly ApplicationDbContext _bd;
        public PartidaRepository(ApplicationDbContext bd)
        {
            this._bd = bd;
        }

        public ICollection<Partida> GetPartidasJugadas(int jugadorId)
        {
            return _bd.Partidas.Where(u => u.JugadorBlancoId == jugadorId || u.JugadorNegroId == jugadorId).ToList(); ;
        }

        public int CrearPartida(PartidaDataDto PartidaOrigen)
        {
            //Mapeado del objeto partida
            var Partida = new Data.Partida()
            {
                FechaCreaciónPartida = PartidaOrigen.Date,
                PartidaEnJuego = PartidaOrigen.EnJuego,
                JugadorBlancoId = PartidaOrigen.JugadorBlancoId,
                JugadorNegroId = PartidaOrigen.JugadorNegroId,
                TurnoPartida = PartidaOrigen.JugadorActual,

            };

            _bd.Partidas.Add(Partida);

            foreach (var f in PartidaOrigen.ListaDeFichas)
            {
                var ficha = new Data.Ficha()
                {
                    EnJuego = true,
                    NumeroMovimientos = 0,
                    PosiciónHorizontal = f.PosicionHorizontal,
                    PosiciónVertical = f.PosicionVertical,
                    Partida = Partida,
                    CaracterFicha = f.Simbolo,
                    ColorFicha = f.LetraRepresentante,
                };
                _bd.Fichas.Add(ficha);
            }

            _bd.SaveChanges();
            return Partida.Id;
        }

        public void GuardarEstadoPartidaDespuesDeUnMovimiento(Casilla Origen, Casilla Destino, int partidaId)
        {
            var PartidaRecuperada = _bd.Partidas.FirstOrDefault(p => p.Id == partidaId);

            var FichaAMover = _bd.Fichas.First(f => f.PosiciónVertical == Origen.Coordenadas.PosicionVertical && f.PosiciónHorizontal == Origen.Coordenadas.PosicionHorizontal && f.partidaId == partidaId);

            FichaAMover.PosiciónHorizontal = Destino.Coordenadas.PosicionHorizontal;
            FichaAMover.PosiciónVertical = Destino.Coordenadas.PosicionVertical;
            FichaAMover.NumeroMovimientos++;

            if (Destino.Tengoficha())
            {
                var FichaAEliminar = _bd.Fichas.First(f => f.PosiciónVertical == Destino.Coordenadas.PosicionVertical && f.PosiciónHorizontal == Destino.Coordenadas.PosicionHorizontal && f.partidaId == partidaId && f.EnJuego == true);
                FichaAEliminar.EnJuego= false;
            }
            if (PartidaRecuperada.TurnoPartida == Color.Blanco.LetraRepresentante)
            {
                PartidaRecuperada.TurnoPartida = Color.Negro.LetraRepresentante;

            }
            else
            {
                PartidaRecuperada.TurnoPartida = Color.Blanco.LetraRepresentante;
            }
            _bd.SaveChanges(); 

        }

        public PartidaRecuperadaDto RecuperarEstadoPartida(int id)
        {
            var PartidaRecuperada = _bd.Partidas.FirstOrDefault( p => p.Id  == id );

            if ( PartidaRecuperada == null ) { throw new NotImplementedException(); }

            var PartidaDto = new PartidaRecuperadaDto()
            {
                Date = PartidaRecuperada.FechaCreaciónPartida,
                Identificador = PartidaRecuperada.Id,
                TurnoPartida = PartidaRecuperada.TurnoPartida,
                JugadorBlancoId = PartidaRecuperada.JugadorBlancoId,
                JugadorNegroId = PartidaRecuperada.JugadorNegroId,
                ListaFichasFueraJuego = _bd.Fichas.Where(f => f.partidaId == PartidaRecuperada.Id && f.EnJuego == false).ToList(),
                ListaFichasEnJuego = _bd.Fichas.Where(f => f.partidaId == PartidaRecuperada.Id && f.EnJuego == true).ToList()
        };

            //PARA REPRESENTACIÓN GRÁFICA EN CONSOLA ---------------------------------------------------------------------------------------------->
            //Colocamos las Fichas Asignamos el tablero al ObjetoDto
            PartidaDto.Tablero = ColocarFichasEnTablero(PartidaDto.ListaFichasEnJuego);
            //REPRESENTACIÓN GRÁFICA EN CONSOLA ---------------------------------------------------------------------------------------------->
            return PartidaDto;
        }


        public Tablero ColocarFichasEnTablero(List<Data.Ficha> Listafichas)
        {
            var TableroBase = new Tablero();
            foreach (var f in Listafichas)
            {
                var Coordenada = new Coordenada((char)f.PosiciónHorizontal, (int)f.PosiciónVertical);

                if (f.ColorFicha == Color.Blanco.LetraRepresentante)
                {
                    if (f.CaracterFicha == 'p')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Peon(Color.Blanco));
                    }
                    else if (f.CaracterFicha == 'R')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Torre(Color.Blanco));
                    }
                    else if (f.CaracterFicha == 'N')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Caballo(Color.Blanco));
                    }
                    else if (f.CaracterFicha == 'B')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Alfil(Color.Blanco));
                    }
                    else if (f.CaracterFicha == 'Q')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Reina(Color.Blanco));
                    }
                    else if (f.CaracterFicha == 'K')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Rey(Color.Blanco));
                    }
                }
                else
                {
                    if (f.CaracterFicha == 'p')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Peon(Color.Negro));
                    }
                    else if (f.CaracterFicha == 'R')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Torre(Color.Negro));
                    }
                    else if (f.CaracterFicha == 'N')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Caballo(Color.Negro));
                    }
                    else if (f.CaracterFicha == 'B')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Alfil(Color.Negro));
                    }
                    else if (f.CaracterFicha == 'Q')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Reina(Color.Negro));
                    }
                    else if (f.CaracterFicha == 'K')
                    {
                        TableroBase.AñadirFichaAlTablero(Coordenada, new Rey(Color.Negro));
                    }
                }
            }
            return TableroBase;
        }

    }
}
