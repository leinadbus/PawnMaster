using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Coordenadas
    {
        // Qué es una coordenada?
        // Daniel: Un contrato que estipula las normas a seguir para encontrar una ubicación
        // Sergio: x, y
        // Diego: Es la notación de una posición en el espacio identificada por la posición en dos ejes (en este caso, dos dimensiones).

        // Un ejemplo de coordenada: 12,56
        // En ajedrez B4

        // Qué propiedades tiene? Cómo se define?
        // Dos posiciones, una por eje. La vertical y la horizontal

        // Tiene normas?


        public int PosicionVertical { get; set; }
        public int PosicionHorizontal { get; set; }

        public Coordenadas(int vertical, int horizontal)
        {
            this.PosicionVertical = vertical;
            this.PosicionHorizontal = horizontal;
        }
    }
}
