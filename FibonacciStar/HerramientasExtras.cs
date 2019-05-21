//Librerías.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FibonacciStar
{
    class HerramientasExtras
    {
        //Constructor.
        public HerramientasExtras()
        { }

        //Crear una lista que almacena las imagenes que se usaran en el DataGridView.
        public List<Bitmap> cuadroNumeros = new List<Bitmap>();

        //Función entera porque retorna el indice de la lista de las imagenes.
        //Tiene una cadena como parametro para que se pueda concatenar la letra identificadora 'B' con el número de la serie de Fibonacci.
        public int Representa(string cadena)
        {
            switch (cadena)
            {
                case "B-1":
                    return 0;
                    break;

                case "B1":
                    return 1;
                    break;

                case "B2":
                    return 2;
                    break;

                case "B3":
                    return 3;
                    break;

                case "B5":
                    return 4;
                    break;

                case "B8":
                    return 5;
                    break;

                case "B13":
                    return 6;
                    break;

                case "B21":
                    return 7;
                    break;

                case "B34":
                    return 8;
                    break;

                case "B55":
                    return 9;
                    break;

                case "B89":
                    return 10;
                    break;

                case "B144":
                    return 11;
                    break;

                case "B233":
                    return 12;
                    break;

                case "B377":
                    return 13;
                    break;

                case "B610":
                    return 14;
                    break;

                case "B987":
                    return 15;
                    break;

                case "B1597":
                    return 16;
                    break;

                case "B2584":
                    return 17;
                    break;

                default:
                    return -1;
                    break;
            }
        }

        //Función que calcula y retorna la suma de Fibonacci.
        public int Sumar(int matriz1, int matriz2)
        {
            int resultado = matriz1 + matriz2;
            switch (resultado)
            {
                case 2:
                    return 2;
                    break;

                case 3:
                    return 3;
                    break;

                case 5:
                    return 5;
                    break;

                case 8:
                    return 8;
                    break;

                case 13:
                    return 13;
                    break;

                case 21:
                    return 21;
                    break;

                case 34:
                    return 34;
                    break;

                case 55:
                    return 55;
                    break;

                case 89:
                    return 89;
                    break;

                case 144:
                    return 144;
                    break;

                case 233:
                    return 233;
                    break;

                case 377:
                    return 377;
                    break;

                case 610:
                    return 610;
                    break;

                case 987:
                    return 987;
                    break;

                case 1597:
                    return 1597;
                    break;

                case 2584:
                    return 2584;
                    break;

                default:
                    return -2;
                    break;
            }
        }

        //Atributo.
        public Color Cola2;

        //Métodos.
        public void AveriguarColor(string color)
        {//Procedimiento que averigua el color que ingreso el usuario y colorea. Necesita 1 parámetro "color".
            switch (color)
            {
                case "Amarillo":
                    Cola2 = Color.Yellow;
                    break;
                case "Anaranjado":
                    Cola2 = Color.Orange;
                    break;
                case "Azul":
                    Cola2 = Color.Blue;
                    break;
                case "Blanco":
                    Cola2 = Color.White;
                    break;
                case "Café":
                    Cola2 = Color.Brown;
                    break;
                case "Celeste":
                    Cola2 = Color.DeepSkyBlue;
                    break;
                case "Dorado":
                    Cola2 = Color.Gold;
                    break;
                case "Gris":
                    Cola2 = Color.Gray;
                    break;
                case "Indigo":
                    Cola2 = Color.MediumSlateBlue;
                    break;
                case "Plateado":
                    Cola2 = Color.Gainsboro;
                    break;
                case "Purpura":
                    Cola2 = Color.Purple;
                    break;
                case "Rojo":
                    Cola2 = Color.Red;
                    break;
                case "Rosado":
                    Cola2 = Color.Pink;
                    break;
                case "Turquesa":
                    Cola2 = Color.Aqua;
                    break;
                case "Verde":
                    Cola2 = Color.Green;
                    break;
                case "Verde Claro":
                    Cola2 = Color.YellowGreen;
                    break;
                case "Violeta":
                    Cola2 = Color.Plum;
                    break;
            }
        }
    }
}