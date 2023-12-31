﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawnMaster.Model
{
    public class Casilla
    {
        // Qué es una casilla? (de ajedrez)

        // Es un espacio donde puede haber una ficha o no

        // Cómo es una casilla?
        // Qué propiedades tiene una casilla? Cómo la puedo definir?

        /*
        Tienen coordenadas, que son como un identificador único
        Las casillas tienen colores (los colores dan igual para el juego [más o menos])
        Son cuadradas
        Limitan con otras casillas normalmente
         */

        public Coordenada Coordenadas { get; init; }
        public Color Color { get; init; }

        // La forma no es útil en este progama
        //public int Forma { get; set; }

        public Ficha? FichaActual { get; private set; } = null;


        public Casilla(Coordenada coordenadas, Color color)
        {
            this.Coordenadas = coordenadas;
            this.Color = color;
        }

        public void EliminarFicha()
        {
            this.FichaActual = null;
        }

        public void SetFichaActual(Ficha ficha)
        {
            this.FichaActual = ficha;
        }

        public bool Tengoficha()
        {
            bool tieneficha = false;
            if (this.FichaActual != null){ tieneficha = true; }
            return tieneficha;
        }

        public bool SonLasFichasDelMismoColor (Casilla casillaAComparar)
        {
            if (FichaActual == null || casillaAComparar.FichaActual == null)
            {
                return false;
            }

            if(FichaActual.Color == casillaAComparar.FichaActual.Color)
            {
                return true;
            }
            else return false;
        }
    }
}
