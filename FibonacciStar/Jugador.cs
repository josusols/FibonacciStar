//Librerías.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FibonacciStar
{
    class Jugador
    {
        //Constructor.
        public Jugador()
        { }

        //Datos del jugador.
        public string nombre;
        public Color color;
        public int punteo = 0;
        public int tiempo = 0;
        public int minutos = 0;
        public int segundos = 0;

        //Declarar la matriz.
        public int[,] Matriz;

        //Posiciones iniciales del juego.
        public int[] pos_i;
        public int[] pos_j;

        //Posicion random.
        public int[] pos_RANDOM;
    }
}
