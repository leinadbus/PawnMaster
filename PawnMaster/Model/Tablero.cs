using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Tablero
    {
        //public string identificador { get; set; }

        //public DateTime date { get; set; }

        public string estado { get; set; }

        public Tablero()
        {
            //identificador = string.Empty;
            //date = DateTime.Now;
            estado = "En curso";
        }

        //This function create a new game with the pieces in their positions
        public List<Casilla> crearNuevoTablero ()
        {
            var tablero = new List<Casilla>();

            for (int fila = 0; fila < 8; fila++)
            {
                for (int columna = 0; columna < 8; columna++)
                {
                    if (columna % 2 == 0 && fila % 2 == 0)
                    {
                        tablero.Add(new Casilla(new Coordenadas(fila, columna), Color.Blanco));
                    }
                    else if(columna % 2 == 0 && fila % 2 != 0)
                    {

                        tablero.Add(new Casilla(new Coordenadas(fila, columna), Color.Negro));
                    }
                    else if (columna % 2 != 0 && fila % 2 != 0)
                    {

                        tablero.Add(new Casilla(new Coordenadas(fila, columna), Color.Blanco));
                    }
                    else if (columna % 2 != 0 && fila % 2 == 0)
                    {

                        tablero.Add(new Casilla(new Coordenadas(fila, columna), Color.Negro));
                    }
                }
            }
           
            return tablero;
        }

        //A function that shows the state of the game
        public void MostrarTableroEnColorDeCasillas(List<Casilla> tablero)
        {
            foreach (Casilla c in tablero)
            {
                Console.Write(c.Color  +" | ");
                if(c.Coordenadas.PosicionHorizontal == 7)
                {
                    Console.WriteLine();
                    Console.WriteLine("-- --- --- --- --- --- --- ---");

                }
            }
            
        }

        public void MostrarTableroEnCoordenadas(List<Casilla> tablero)
        {
            foreach (Casilla c in tablero)
            {
                Console.Write(c.Coordenadas.PosicionHorizontal + " " + c.Coordenadas.PosicionVertical + " | ");
                if (c.Coordenadas.PosicionHorizontal == 7)
                {
                    Console.WriteLine();
                    Console.WriteLine("---- ----- ----- ----- ----- ----- ----- -----");

                }
            }
        }

        

    }
}
