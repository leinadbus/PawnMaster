﻿using PawnMaster.Model;
using PawnMaster.Persistence.Data;
using PawnMaster.Persistence.Dtos;
using PawnMaster.Persistence.Repositories.InterfaceRepository;

namespace PawnMaster.Persistence.Repositories
{
    public class PartidaRepository : InterfazPartidaRepository
    {
        private readonly ApplicationDbContext _bd;
        public PartidaRepository(ApplicationDbContext bd)
        {
            this._bd = bd;
        }

        public int CrearPartida(PartidaDto Partida,int IdBlanco, int IdNegro)
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
 


            foreach(var casilla in Partida.Tablero.TableroJuego)
            {
                //------------------------------------------------------
            }


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
                            ColorFicha = casilla.FichaActual.Color.LetraRepresentante ,
                            
                            
                        };
                        _bd.Fichas.Add(ficha);
                    }
                }
            }

            _bd.SaveChanges();
            return PartidaABaseDatos.Id;
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
                var FichaAEliminar = _bd.Fichas.First(f => f.PosiciónVertical == Destino.Coordenadas.PosicionVertical && f.PosiciónHorizontal == Destino.Coordenadas.PosicionHorizontal && f.partidaId == partidaId);
                FichaAEliminar.EnJuego= false;
            }
            if (PartidaRecuperada.TurnoPartida == Data.Partida.Turno.white)
            {
                PartidaRecuperada.TurnoPartida++;

            }
            else
            {
                PartidaRecuperada.TurnoPartida--;
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
                TurnoPartida = (PartidaRecuperadaDto.Turno)PartidaRecuperada.TurnoPartida,
                JugadorBlancoId = PartidaRecuperada.JugadorBlancoId,
                JugadorNegroId = PartidaRecuperada.JugadorNegroId
            };
           
            //Recogemos las Fichas de la BD
            var Listafichas = _bd.Fichas.Where(f => f.partidaId == PartidaRecuperada.Id).ToList();
            var ListaFichasEnJuego = _bd.Fichas.Where(f => f.partidaId == PartidaRecuperada.Id && f.EnJuego == true).ToList();
            //Colocamos las Fichas
            var TableroBase = ColocarFichasEnTablero(ListaFichasEnJuego);
            //Asignamos el tablero al ObjetoDto
            PartidaDto.Tablero = TableroBase;
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
