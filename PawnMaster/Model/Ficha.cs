using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PawnMaster;

namespace PawnMaster.Model
{
    public abstract class Ficha
    {
        public Color Color { get; }

        public  char Simbolo { get; set; }

        public int NumeroMovimientos { get; set; } = 0;

        public Ficha(Color color)
        {
            this.Simbolo = ' ';
            this.Color = color;
        }

        public void AumentarNumeroMovimientos()
        {
            NumeroMovimientos++;
        }

        public static bool SaberSiElMovimientoEsPositivo(int numero)
        {
            if (numero >= 0)
            {
                return true; // El número es positivo o cero
            }
            else
            {
                return false; // El número es negativo
            }
        }

        public abstract bool ValidarMovimiento(Casilla inicio, Casilla Final);

        public abstract bool validarCaptura(Casilla inicio, Casilla Final);
    }
}
