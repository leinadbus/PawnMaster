using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Movimiento
    {
        //Esta clase traduce el input del usuario a datos para la acción de la partida
        public Coordenada CoordenadaInicial { get; set; }
        public Coordenada CoordenadaFinal { get; set; }
        public bool EsCaptura { get; set; }
        public char FichaAMover { get; set; }

        public Movimiento(string notacion)
        {
            EsCaptura = ComprobarSiEsCaptura(notacion);
            if (EsCaptura)
            {
                RecogerPiezaYCaptura(notacion);
            }
            else
            {
                RecogerPiezaYMovimiento(notacion);
            }
        }


        //Funciones para el caso anotación del input tipo "Pb2xd3" | "Pb2b4"
        /// <summary>
        /// Esta función devuelve un booleano si el input del usuario es de tipo "Pb2xd3" | "Pb2b4".
        /// </summary>
        public static bool ComprobarNotacionMovimientoEsValida(string inputUsuario)
        {
            if (char.IsUpper(inputUsuario[0]) && (inputUsuario.Length == 6 || inputUsuario.Length == 5))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Esta función comprueba si el input del usuario es una captura o por el contrario un movimiento asignando a la variable Escaptura del objeto Movimiento el booleano correspondiente .
        /// </summary>
        public static bool ComprobarSiEsCaptura(string movimientoUsuario)
        {
            if (movimientoUsuario.Contains('x') || movimientoUsuario.Contains('X'))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Función que recoge el primer caracter del string como ficha que ejercerá la función dada y las coordenadas de la acción de captura
        /// </summary>
        public void RecogerPiezaYCaptura(string movimientoUsuario)
        {
            FichaAMover = movimientoUsuario[0];

            string[] movimientos = movimientoUsuario.ToUpper().Split('X');
            CoordenadaInicial = new Coordenada(movimientos[0][1], movimientos[0][2] - '0');
            CoordenadaFinal = new Coordenada(movimientos[1][0], movimientos[1][1] - '0');

        }


        /// <summary>
        /// Función que recoge el primer caracter del string como ficha que ejercerá la función dada y las coordenadas de la acción de movimiento
        /// </summary>
        public void RecogerPiezaYMovimiento(string movimientoUsuario)
        {
            FichaAMover = movimientoUsuario[0];
            string movimientoSinFicha = movimientoUsuario.ToUpper().Substring(1);
            int mitad = movimientoSinFicha.Length / 2;
            string parte1 = movimientoSinFicha.Substring(0, mitad);
            string parte2 = movimientoSinFicha.Substring(mitad);
            CoordenadaInicial = new Coordenada(parte1[0], parte1[1] - '0');
            CoordenadaFinal = new Coordenada(parte2[0], parte2[1] - '0');
        }

    }
}
