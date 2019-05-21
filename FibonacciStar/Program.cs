//Librerías.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FibonacciStar
{
    static class Program
    {
        //Espacio para inicializar los objetos.
        public static Jugador J1 = new Jugador();
        public static Jugador J2 = new Jugador();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new F_fibonacci());
        }
    }
}
