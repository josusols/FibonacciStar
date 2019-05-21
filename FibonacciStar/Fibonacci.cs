//Librerías.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FibonacciStar
{
    public partial class F_fibonacci : Form
    {
        //Espacio para inicializar clases.
        HerramientasExtras Tools = new HerramientasExtras();
        Random NumeroAleatorio = new Random();

        //Espacio para crear variables.
        bool banderaSalvacion; //Sirve para generar un random si realizo un corrimiento. (Función Desactivable)

        //Espacio para inicializar y definir las propiedades de todos los objetos.
        public F_fibonacci()
        {
            InitializeComponent();

            //Define el tamaño del tablero del J1 y J2.
            Program.J1.Matriz = new int[4, 4];
            Program.J2.Matriz = new int[4, 4];

            //Define el tamaño del vector "pos_i" del J1 y J2.
            Program.J1.pos_i = new int[2];
            Program.J2.pos_i = new int[2];

            //Define el tamaño del vector "pos_j" del J1 y J2.
            Program.J1.pos_j = new int[2];
            Program.J2.pos_j = new int[2];

            //Define el tamaño del random del J1 y J2.
            Program.J1.pos_RANDOM = new int[2];
            Program.J2.pos_RANDOM = new int[2];

            //**ELIMINA LOS HEADERS DE LAS FILAS Y LAS COLUMNAS DE LOS TABLEROS DEL J1 Y J2**
            DGV_tablero1.ColumnHeadersVisible = false;
            DGV_tablero1.RowHeadersVisible = false;
            DGV_tablero2.ColumnHeadersVisible = false;
            DGV_tablero2.RowHeadersVisible = false;

            //**AGREGAR LAS IMAGENES A LA LISTA**
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/Blanco.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/1.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/2.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/3.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/5.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/8.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/13.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/21.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/34.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/55.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/89.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/144.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/233.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/377.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/610.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/987.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/1597.png"));
            Tools.cuadroNumeros.Add(new Bitmap("../../Resources/2584.png"));
        }

        //Método que inicia el tablero del J1.
        public void IniciarTablero1()
        {
            //Limpia el DataGridView.
            DGV_tablero1.Rows.Clear();

            //Agregar las filas que hacen falta.
            for (int i = 0; i < 4; i++)
            {
                DGV_tablero1.Rows.Add(); //Agrega la fila.
                DGV_tablero1.Rows[i].Height = 76; //Cambia el tamaño.
            }

            //Llena el tablero con cuadros blancos.
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Program.J1.Matriz[i, j] = -1;
                    DGV_tablero1.Rows[i].Cells[j].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J1.Matriz[i, j])];
                }
            }

            //Inicia el tablero con 2 números 1.
            bool banderaRepetido = true; //Bandera para que los números no queden en la misma posición.
            while (banderaRepetido == true) //Ciclo While con la condición.
            {
                //Posiciones del primer número 1.
                Program.J1.pos_i[0] = NumeroAleatorio.Next(0, 4);
                Program.J1.pos_j[0] = NumeroAleatorio.Next(0, 4);
                //Posiciones del segundo número 1.
                Program.J1.pos_i[1] = NumeroAleatorio.Next(0, 4);
                Program.J1.pos_j[1] = NumeroAleatorio.Next(0, 4);
                //Condicional que evalua las posiciones y cambia el valor de la bandera.
                if (Program.J1.pos_i[0] == Program.J1.pos_i[1] && Program.J1.pos_j[0] == Program.J1.pos_j[1])
                {
                    banderaRepetido = true;
                }
                else //Si las posiciones son distintas las imprime en el DataGridView.
                {
                    banderaRepetido = false;
                    //Guarda en el tablero virtual los 2 números 1.
                    Program.J1.Matriz[Program.J1.pos_i[0], Program.J1.pos_j[0]] = 1; //Primer número 1.
                    Program.J1.Matriz[Program.J1.pos_i[1], Program.J1.pos_j[1]] = 1; //Segundo número 1.
                    //Imprime en la DataGridView los 2 números 1 pero en imágenes.
                    DGV_tablero1.Rows[Program.J1.pos_i[0]].Cells[Program.J1.pos_j[0]].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J1.Matriz[Program.J1.pos_i[0], Program.J1.pos_j[0]])]; //Primer número 1.
                    DGV_tablero1.Rows[Program.J1.pos_i[1]].Cells[Program.J1.pos_j[1]].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J1.Matriz[Program.J1.pos_i[1], Program.J1.pos_j[1]])]; //Segundo número 1.
                }
            }
        }

        //Método que inicia el tablero del J2.
        public void IniciarTablero2()
        {
            //Limpia el DataGridView.
            DGV_tablero2.Rows.Clear();

            //Agregar las filas que hacen falta.
            for (int i = 0; i < 4; i++)
            {
                DGV_tablero2.Rows.Add(); //Agrega la fila.
                DGV_tablero2.Rows[i].Height = 76; //Cambia el tamaño.
            }

            //Llena el tablero con cuadros blancos.
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Program.J2.Matriz[i, j] = -1;
                    DGV_tablero2.Rows[i].Cells[j].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J2.Matriz[i, j])];
                }
            }

            //Inicia el tablero con 2 números 1.
            bool banderaRepetido = true; //Bandera para que los números no queden en la misma posición.
            while (banderaRepetido == true) //Ciclo While con la condición.
            {
                //Posiciones del primer número 1.
                Program.J2.pos_i[0] = NumeroAleatorio.Next(0, 4);
                Program.J2.pos_j[0] = NumeroAleatorio.Next(0, 4);
                //Posiciones del segundo número 1.
                Program.J2.pos_i[1] = NumeroAleatorio.Next(0, 4);
                Program.J2.pos_j[1] = NumeroAleatorio.Next(0, 4);
                //Condicional que evalua las posiciones y cambia el valor de la bandera. ASDFDFGDF
                if ((Program.J2.pos_i[0] == Program.J2.pos_i[1]) && (Program.J2.pos_j[0] == Program.J2.pos_j[1]))
                {
                    banderaRepetido = true;
                }
                else //Si las posiciones son distintas las imprime en el DataGridView.
                {
                    banderaRepetido = false;
                    //Guarda en el tablero virtual los 2 números 1.
                    Program.J2.Matriz[Program.J2.pos_i[0], Program.J2.pos_j[0]] = 1; //Primer número 1.
                    Program.J2.Matriz[Program.J2.pos_i[1], Program.J2.pos_j[1]] = 1; //Segundo número 1.
                    //Imprime en la DataGridView los 2 números 1 pero en imágenes.
                    DGV_tablero2.Rows[Program.J2.pos_i[0]].Cells[Program.J2.pos_j[0]].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J2.Matriz[Program.J2.pos_i[0], Program.J2.pos_j[0]])]; //Primer número 1.
                    DGV_tablero2.Rows[Program.J2.pos_i[1]].Cells[Program.J2.pos_j[1]].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J2.Matriz[Program.J2.pos_i[1], Program.J2.pos_j[1]])]; //Segundo número 1.
                }
            }
        }

        //Método que genera un nuevo #1 random para el J1.
        public void NuevoNumeroRandom1()
        {
            //Bandera que determina si el espacio donde se va a colocar el #1 random esta vacio.
            bool banderaVacio = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Program.J1.Matriz[i, j] == -1) 
                    {
                        //Nota 1: Funciona perfectamente sin los 2 for y la condicional pero con la diferencia que los random salen muy desordenados.
                        //Nota 2: Con los 2 for y la condicional se ve más estético.
                        while (banderaVacio == false)
                        {
                            Program.J1.pos_RANDOM[0] = NumeroAleatorio.Next(0, 4);
                            Program.J1.pos_RANDOM[1] = NumeroAleatorio.Next(0, 4);
                            //Verifica si las posiciones random generadas estan ocupadas o vacias.
                            if (Program.J1.Matriz[Program.J1.pos_RANDOM[0], Program.J1.pos_RANDOM[1]] != -1)
                            {
                                banderaVacio = false;
                            }
                            else
                            {
                                banderaVacio = true;
                                Program.J1.Matriz[Program.J1.pos_RANDOM[0], Program.J1.pos_RANDOM[1]] = 1;
                            }
                        }
                    }
                }
            }
        }

        //Método que genera un nuevo #1 random para el J2.
        public void NuevoNumeroRandom2()
        {
            //Bandera que determina si el espacio donde se va a colocar el #1 random esta vacio.
            bool banderaVacio = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (Program.J2.Matriz[i, j] == -1)
                    {
                        //Nota 1: Funciona perfectamente sin los 2 for y la condicional pero con la diferencia que los random salen muy desordenados.
                        //Nota 2: Con los 2 for y la condicional se ve más estético.
                        while (banderaVacio == false)
                        {
                            Program.J2.pos_RANDOM[0] = NumeroAleatorio.Next(0, 4);
                            Program.J2.pos_RANDOM[1] = NumeroAleatorio.Next(0, 4);
                            //Verifica si las posiciones random generadas estan ocupadas o vacias.
                            if (Program.J2.Matriz[Program.J2.pos_RANDOM[0], Program.J2.pos_RANDOM[1]] != -1)
                            {
                                banderaVacio = false;
                            }
                            else
                            {
                                banderaVacio = true;
                                Program.J2.Matriz[Program.J2.pos_RANDOM[0], Program.J2.pos_RANDOM[1]] = 1;
                            }
                        }
                    }
                }
            }
        }

        //Método que mueve los números del J1 para abajo.
        public void ParaAbajoJ1()
        {
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaFILA; //Contador de las sumas consecutivas que va haciendo en una fila, el máximo es 1.
            int coordenadaA; //Guarda la coordenada "a" sirve dentro de los movimientos consecutivos del While.

            for (int b = 0; b < 4; b++) //*EVALUA DE IZQUIERDA A DERECHA*
            {
                sumasMismaFILA = 0; //Reinicia.
                for (int a = 2; a >= 0; a--) //*COMIENZA EN 2 PARA QUE EVALUE DE ABAJO PARA ARRIBA*    
                {
                    if (Program.J1.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaA = a; //Guarda la coordenada "a".
                        while (coordenadaA < 3) //Movimientos consecutivos del While, menor a 3 para evitar que se salga del indice.
                        {
                            if (Program.J1.Matriz[coordenadaA + 1, b] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Re-asigna.
                                Program.J1.Matriz[coordenadaA + 1, b] = Program.J1.Matriz[coordenadaA, b];
                                //Elimina.
                                Program.J1.Matriz[coordenadaA, b] = -1;
                                //Salvacion.
                                banderaSalvacion = true;
                                //Sube de casilla.
                                coordenadaA++;
                            }
                            else if (Program.J1.Matriz[coordenadaA + 1, b] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J1.Matriz[coordenadaA + 1, b], Program.J1.Matriz[coordenadaA, b]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaFILA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaFILA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        Program.J1.punteo += SUMA; //Puntaje.
                                        //Re-asigna con nuevo valor.
                                        Program.J1.Matriz[coordenadaA + 1, b] = SUMA;
                                        //Elimina.
                                        Program.J1.Matriz[coordenadaA, b] = -1;
                                        //Salvacion.
                                        banderaSalvacion = true;
                                    }
                                    //Sube de casilla.
                                    coordenadaA++;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Método que mueve los números del J2 para abajo.
        public void ParaAbajoJ2()
        {
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaFILA; //Contador de las sumas consecutivas que va haciendo en una fila, el máximo es 1.
            int coordenadaA; //Guarda la coordenada "a" sirve dentro de los movimientos consecutivos del While.

            for (int b = 0; b < 4; b++) //*EVALUA DE IZQUIERDA A DERECHA*
            {
                sumasMismaFILA = 0; //Reinicia.
                for (int a = 2; a >= 0; a--) //*COMIENZA EN 2 PARA QUE EVALUE DE ABAJO PARA ARRIBA*    
                {
                    if (Program.J2.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaA = a; //Guarda la coordenada "a".
                        while (coordenadaA < 3) //Movimientos consecutivos del While, menor a 3 para evitar que se salga del indice.
                        {
                            if (Program.J2.Matriz[coordenadaA + 1, b] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Re-asigna.
                                Program.J2.Matriz[coordenadaA + 1, b] = Program.J2.Matriz[coordenadaA, b];
                                //Elimina.
                                Program.J2.Matriz[coordenadaA, b] = -1;
                                //Salvacion.
                                banderaSalvacion = true;
                                //Sube de casilla.
                                coordenadaA++;
                            }
                            else if (Program.J2.Matriz[coordenadaA + 1, b] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J2.Matriz[coordenadaA + 1, b], Program.J2.Matriz[coordenadaA, b]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaFILA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaFILA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        Program.J2.punteo += SUMA; //Puntaje.
                                        //Re-asigna con nuevo valor.
                                        Program.J2.Matriz[coordenadaA + 1, b] = SUMA;
                                        //Elimina.
                                        Program.J2.Matriz[coordenadaA, b] = -1;
                                        //Salvacion.
                                        banderaSalvacion = true;
                                    }
                                    //Sube de casilla.
                                    coordenadaA++;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Método que mueve los números del J1 para arriba.
        public void ParaArribaJ1()
        {
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaFILA; //Contador de las sumas consecutivas que va haciendo en una fila, el máximo es 1.
            int coordenadaA; //Guarda la coordenada "a" sirve dentro de los movimientos consecutivos del While.

            for (int b = 0; b < 4; b++) //*EVALUA DE IZQUIERDA A DERECHA*
            {
                sumasMismaFILA = 0; //Reinicia.
                for (int a = 1; a < 4; a++) //*COMIENZA EN 1 PARA QUE EVALUE DE ARRIBA PARA ABAJO*    
                {
                    if (Program.J1.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaA = a; //Guarda la coordenada "a".
                        while (coordenadaA > 0) //Movimientos consecutivos del While, mayor a 0 para evitar que se salga del indice.
                        {
                            if (Program.J1.Matriz[coordenadaA - 1, b] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Re-asigna.
                                Program.J1.Matriz[coordenadaA - 1, b] = Program.J1.Matriz[coordenadaA, b];
                                //Elimina.
                                Program.J1.Matriz[coordenadaA, b] = -1;
                                //Salvacion.
                                banderaSalvacion = true;
                                //Baja de casilla.
                                coordenadaA--;
                            }
                            else if (Program.J1.Matriz[coordenadaA - 1, b] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J1.Matriz[coordenadaA - 1, b], Program.J1.Matriz[coordenadaA, b]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaFILA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaFILA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        Program.J1.punteo += SUMA; //Puntaje.
                                        //Re-asigna con nuevo valor.
                                        Program.J1.Matriz[coordenadaA - 1, b] = SUMA;
                                        //Elimina.
                                        Program.J1.Matriz[coordenadaA, b] = -1;
                                        //Salvacion.
                                        banderaSalvacion = true;
                                    }
                                    //Baja de casilla.
                                    coordenadaA--;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Método que mueve los números del J2 para arriba.
        public void ParaArribaJ2()
        {
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaFILA; //Contador de las sumas consecutivas que va haciendo en una fila, el máximo es 1.
            int coordenadaA; //Guarda la coordenada "a" sirve dentro de los movimientos consecutivos del While.

            for (int b = 0; b < 4; b++) //*EVALUA DE IZQUIERDA A DERECHA*
            {
                sumasMismaFILA = 0; //Reinicia.
                for (int a = 1; a < 4; a++) //*COMIENZA EN 1 PARA QUE EVALUE DE ARRIBA PARA ABAJO*    
                {
                    if (Program.J2.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaA = a; //Guarda la coordenada "a".
                        while (coordenadaA > 0) //Movimientos consecutivos del While, mayor a 0 para evitar que se salga del indice.
                        {
                            if (Program.J2.Matriz[coordenadaA - 1, b] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Re-asigna.
                                Program.J2.Matriz[coordenadaA - 1, b] = Program.J2.Matriz[coordenadaA, b];
                                //Elimina.
                                Program.J2.Matriz[coordenadaA, b] = -1;
                                //Salvacion.
                                banderaSalvacion = true;
                                //Baja de casilla.
                                coordenadaA--;
                            }
                            else if (Program.J2.Matriz[coordenadaA - 1, b] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J2.Matriz[coordenadaA - 1, b], Program.J2.Matriz[coordenadaA, b]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaFILA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaFILA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        Program.J2.punteo += SUMA; //Puntaje.
                                        //Re-asigna con nuevo valor.
                                        Program.J2.Matriz[coordenadaA - 1, b] = SUMA;
                                        //Elimina.
                                        Program.J2.Matriz[coordenadaA, b] = -1;
                                        //Salvacion.
                                        banderaSalvacion = true;
                                    }
                                    //Baja de casilla.
                                    coordenadaA--;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Método que mueve los números del J1 para la izquierda.
        public void ParaIzquierdaJ1()
        {
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaCOLUMNA; //Contador de las sumas consecutivas que va haciendo en una fila, el máximo es 1.
            int coordenadaB; //Guarda la coordenada "b" sirve dentro de los movimientos consecutivos del While.

            for (int a = 0; a < 4; a++) //*EVALUA DE ARRIBA PARA ABAJO*    
            {
                sumasMismaCOLUMNA = 0; //Reinicia.
                for (int b = 1; b < 4; b++) //*COMIENZA EN 1 PARA QUE EVALUE DE IZQUIERDA A DERECHA*    
                {
                    if (Program.J1.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaB = b; //Guarda la coordenada "b".
                        while (coordenadaB > 0) //Movimientos consecutivos del While, mayor a 0 para evitar que se salga del indice.
                        {
                            if (Program.J1.Matriz[a, coordenadaB - 1] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Re-asigna.
                                Program.J1.Matriz[a, coordenadaB - 1] = Program.J1.Matriz[a, coordenadaB];
                                //Elimina.
                                Program.J1.Matriz[a, coordenadaB] = -1;
                                //Salvacion.
                                banderaSalvacion = true;
                                //Baja de casilla.
                                coordenadaB--;
                            }
                            else if (Program.J1.Matriz[a, coordenadaB - 1] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J1.Matriz[a, coordenadaB - 1], Program.J1.Matriz[a, coordenadaB]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaCOLUMNA++; //Aumenta el contador de sumas consecutivas de la columna.
                                    if (sumasMismaCOLUMNA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        Program.J1.punteo += SUMA; //Puntaje.
                                        //Re-asigna con nuevo valor.
                                        Program.J1.Matriz[a, coordenadaB - 1] = SUMA;
                                        //Elimina.
                                        Program.J1.Matriz[a, coordenadaB] = -1;
                                        //Salvacion.
                                        banderaSalvacion = true;
                                    }
                                    //Baja de casilla.
                                    coordenadaB--;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Método que mueve los números del J2 para la izquierda.
        public void ParaIzquierdaJ2()
        {
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaCOLUMNA; //Contador de las sumas consecutivas que va haciendo en una fila, el máximo es 1.
            int coordenadaB; //Guarda la coordenada "b" sirve dentro de los movimientos consecutivos del While.

            for (int a = 0; a < 4; a++) //*EVALUA DE ARRIBA PARA ABAJO*    
            {
                sumasMismaCOLUMNA = 0; //Reinicia.
                for (int b = 1; b < 4; b++) //*COMIENZA EN 1 PARA QUE EVALUE DE IZQUIERDA A DERECHA*    
                {
                    if (Program.J2.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaB = b; //Guarda la coordenada "b".
                        while (coordenadaB > 0) //Movimientos consecutivos del While, mayor a 0 para evitar que se salga del indice.
                        {
                            if (Program.J2.Matriz[a, coordenadaB - 1] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Re-asigna.
                                Program.J2.Matriz[a, coordenadaB - 1] = Program.J2.Matriz[a, coordenadaB];
                                //Elimina.
                                Program.J2.Matriz[a, coordenadaB] = -1;
                                //Salvacion.
                                banderaSalvacion = true;
                                //Baja de casilla.
                                coordenadaB--;
                            }
                            else if (Program.J2.Matriz[a, coordenadaB - 1] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J2.Matriz[a, coordenadaB - 1], Program.J2.Matriz[a, coordenadaB]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaCOLUMNA++; //Aumenta el contador de sumas consecutivas de la columna.
                                    if (sumasMismaCOLUMNA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        Program.J2.punteo += SUMA; //Puntaje.
                                        //Re-asigna con nuevo valor.
                                        Program.J2.Matriz[a, coordenadaB - 1] = SUMA;
                                        //Elimina.
                                        Program.J2.Matriz[a, coordenadaB] = -1;
                                        //Salvacion.
                                        banderaSalvacion = true;
                                    }
                                    //Baja de casilla.
                                    coordenadaB--;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Método que mueve los números del J1 para la derecha.
        public void ParaDerechaJ1()
        {
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaCOLUMNA; //Contador de las sumas consecutivas que va haciendo en una columna, el máximo es 1.
            int coordenadaB; //Guarda la coordenada "b" sirve dentro de los movimientos consecutivos del While.

            for (int a = 0; a < 4; a++) //*EVALUA DE ARRIBA PARA ABAJO*    
            {
                sumasMismaCOLUMNA = 0; //Reinicia.
                for (int b = 2; b >= 0; b--) //*COMIENZA EN 2 PARA QUE EVALUE DE DERECHA A IZQUIERDA*    
                {
                    if (Program.J1.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaB = b; //Guarda la coordenada "b".
                        while (coordenadaB < 3) //Movimientos consecutivos del While, menor a 3 para evitar que se salga del indice.
                        {
                            if (Program.J1.Matriz[a, coordenadaB + 1] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Re-asigna.
                                Program.J1.Matriz[a, coordenadaB + 1] = Program.J1.Matriz[a, coordenadaB];
                                //Elimina.
                                Program.J1.Matriz[a, coordenadaB] = -1;
                                //Salvacion.
                                banderaSalvacion = true;
                                //Sube de casilla.
                                coordenadaB++;
                            }
                            else if (Program.J1.Matriz[a, coordenadaB + 1] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J1.Matriz[a, coordenadaB + 1], Program.J1.Matriz[a, coordenadaB]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaCOLUMNA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaCOLUMNA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        Program.J1.punteo += SUMA; //Puntaje.
                                        //Re-asigna con nuevo valor.
                                        Program.J1.Matriz[a, coordenadaB + 1] = SUMA;
                                        //Elimina.
                                        Program.J1.Matriz[a, coordenadaB] = -1;
                                        //Salvacion.
                                        banderaSalvacion = true;
                                    }
                                    //Sube de casilla.
                                    coordenadaB++;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Método que mueve los números del J2 para la derecha.
        public void ParaDerechaJ2()
        {
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaCOLUMNA; //Contador de las sumas consecutivas que va haciendo en una columna, el máximo es 1.
            int coordenadaB; //Guarda la coordenada "b" sirve dentro de los movimientos consecutivos del While.

            for (int a = 0; a < 4; a++) //*EVALUA DE ARRIBA PARA ABAJO*    
            {
                sumasMismaCOLUMNA = 0; //Reinicia.
                for (int b = 2; b >= 0; b--) //*COMIENZA EN 2 PARA QUE EVALUE DE DERECHA A IZQUIERDA*
                {
                    if (Program.J2.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaB = b; //Guarda la coordenada "b".
                        while (coordenadaB < 3) //Movimientos consecutivos del While, menor a 3 para evitar que se salga del indice.
                        {
                            if (Program.J2.Matriz[a, coordenadaB + 1] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Re-asigna.
                                Program.J2.Matriz[a, coordenadaB + 1] = Program.J2.Matriz[a, coordenadaB];
                                //Elimina.
                                Program.J2.Matriz[a, coordenadaB] = -1;
                                //Salvacion.
                                banderaSalvacion = true;
                                //Sube de casilla.
                                coordenadaB++;
                            }
                            else if (Program.J2.Matriz[a, coordenadaB + 1] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J2.Matriz[a, coordenadaB + 1], Program.J2.Matriz[a, coordenadaB]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaCOLUMNA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaCOLUMNA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        Program.J2.punteo += SUMA; //Puntaje.
                                        //Re-asigna con nuevo valor.
                                        Program.J2.Matriz[a, coordenadaB + 1] = SUMA;
                                        //Elimina.
                                        Program.J2.Matriz[a, coordenadaB] = -1;
                                        //Salvacion.
                                        banderaSalvacion = true;
                                    }
                                    //Sube de casilla.
                                    coordenadaB++;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //MOVIMIENTO = Los números se fueron al extremo, se apilaron o se sumaron.
        //Sirve para saber si uno de los jugadores lleno su tablero.
        bool MOVIMIENTO; 

        //Método 1 que determina si quedan o no posibles movimientos para el tablero del J1.
        public void posible1J1()
        {
            //Arriba & Izquierda.
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaFILA;
            int sumasMismaCOLUMNA;
            int coordenadaA; //Guarda la coordenada "a" sirve dentro de los movimientos consecutivos del While.
            int coordenadaB; //Guarda la coordenada "b" sirve dentro de los movimientos consecutivos del While.
            for (int b = 0; b < 4; b++)
            {
                sumasMismaFILA = 0;
                for (int a = 0; a < 4; a++)
                {
                    sumasMismaCOLUMNA = 0;
                    if (Program.J1.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaA = a; //Guarda la coordenada "a".
                        while (coordenadaA > 0 && MOVIMIENTO == false)
                        {
                            if (Program.J1.Matriz[coordenadaA - 1, b] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Movimiento.
                                MOVIMIENTO = true;
                                //Baja de casilla.
                                coordenadaA--;
                            }
                            else if (Program.J1.Matriz[coordenadaA - 1, b] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J1.Matriz[coordenadaA - 1, b], Program.J1.Matriz[coordenadaA, b]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaFILA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaFILA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        //Movimiento.
                                        MOVIMIENTO = true;
                                    }
                                    //Baja de casilla.
                                    coordenadaA--;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.

                        coordenadaB = b; //Guarda la coordenada "b".
                        while (coordenadaB > 0 && MOVIMIENTO == false) //Movimientos consecutivos del While, mayor a 0 para evitar que se salga del indice.
                        {
                            if (Program.J1.Matriz[a, coordenadaB - 1] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Movimiento.
                                MOVIMIENTO = true;
                                //Baja de casilla.
                                coordenadaB--;
                            }
                            else if (Program.J1.Matriz[a, coordenadaB - 1] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J1.Matriz[a, coordenadaB - 1], Program.J1.Matriz[a, coordenadaB]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaCOLUMNA++; //Aumenta el contador de sumas consecutivas de la columna.
                                    if (sumasMismaCOLUMNA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        //Movimiento.
                                        MOVIMIENTO = true;
                                    }
                                    //Baja de casilla.
                                    coordenadaB--;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Método 2 que determina si quedan o no posibles movimientos para el tablero del J1.
        public void posible2J1()
        {
            //Abajo & Derecha.
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaFILA; //Contador de las sumas consecutivas que va haciendo en una fila, el máximo es 1.
            int sumasMismaCOLUMNA; //Contador de las sumas consecutivas que va haciendo en una columna, el máximo es 1.
            int coordenadaA; //Guarda la coordenada "a" sirve dentro de los movimientos consecutivos del While.
            int coordenadaB; //Guarda la coordenada "b" sirve dentro de los movimientos consecutivos del While.
            for (int b = 3; b >= 0; b--)
            {
                sumasMismaFILA = 0;
                for (int a = 3; a >= 0; a--)
                {
                    sumasMismaCOLUMNA = 0; //Reinicia.
                    if (Program.J1.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaA = a; //Guarda la coordenada "a".
                        while (coordenadaA < 3 && MOVIMIENTO == false) //Movimientos consecutivos del While, menor a 3 para evitar que se salga del indice.
                        {
                            if (Program.J1.Matriz[coordenadaA + 1, b] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Movimiento.
                                MOVIMIENTO = true;
                                //Sube de casilla.
                                coordenadaA++;
                            }
                            else if (Program.J1.Matriz[coordenadaA + 1, b] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J1.Matriz[coordenadaA + 1, b], Program.J1.Matriz[coordenadaA, b]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaFILA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaFILA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        //Movimiento.
                                        MOVIMIENTO = true;
                                    }
                                    //Sube de casilla.
                                    coordenadaA++;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.

                        coordenadaB = b; //Guarda la coordenada "b".
                        while (coordenadaB < 3 && MOVIMIENTO == true) //Movimientos consecutivos del While, menor a 3 para evitar que se salga del indice.
                        {
                            if (Program.J1.Matriz[a, coordenadaB + 1] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Movimiento.
                                MOVIMIENTO = true;
                                //Sube de casilla.
                                coordenadaB++;
                            }
                            else if (Program.J1.Matriz[a, coordenadaB + 1] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J1.Matriz[a, coordenadaB + 1], Program.J1.Matriz[a, coordenadaB]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaCOLUMNA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaCOLUMNA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        //Movimiento.
                                        MOVIMIENTO = true;
                                    }
                                    //Sube de casilla.
                                    coordenadaB++;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Método 1 que determina si quedan o no posibles movimientos para el tablero del J2.
        public void posible1J2()
        {
            //Arriba & Izquierda.
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaFILA;
            int sumasMismaCOLUMNA;
            int coordenadaA; //Guarda la coordenada "a" sirve dentro de los movimientos consecutivos del While.
            int coordenadaB; //Guarda la coordenada "b" sirve dentro de los movimientos consecutivos del While.
            for (int b = 0; b < 4; b++)
            {
                sumasMismaFILA = 0;
                for (int a = 0; a < 4; a++)
                {
                    sumasMismaCOLUMNA = 0;
                    if (Program.J2.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaA = a; //Guarda la coordenada "a".
                        while (coordenadaA > 0 && MOVIMIENTO == false)
                        {
                            if (Program.J2.Matriz[coordenadaA - 1, b] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Movimiento.
                                MOVIMIENTO = true;
                                //Baja de casilla.
                                coordenadaA--;
                            }
                            else if (Program.J2.Matriz[coordenadaA - 1, b] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J2.Matriz[coordenadaA - 1, b], Program.J2.Matriz[coordenadaA, b]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaFILA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaFILA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        //Movimiento.
                                        MOVIMIENTO = true;
                                    }
                                    //Baja de casilla.
                                    coordenadaA--;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.

                        coordenadaB = b; //Guarda la coordenada "b".
                        while (coordenadaB > 0 && MOVIMIENTO == false) //Movimientos consecutivos del While, mayor a 0 para evitar que se salga del indice.
                        {
                            if (Program.J2.Matriz[a, coordenadaB - 1] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Movimiento.
                                MOVIMIENTO = true;
                                //Baja de casilla.
                                coordenadaB--;
                            }
                            else if (Program.J2.Matriz[a, coordenadaB - 1] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J2.Matriz[a, coordenadaB - 1], Program.J2.Matriz[a, coordenadaB]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaCOLUMNA++; //Aumenta el contador de sumas consecutivas de la columna.
                                    if (sumasMismaCOLUMNA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        //Movimiento.
                                        MOVIMIENTO = true;
                                    }
                                    //Baja de casilla.
                                    coordenadaB--;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Método 2 que determina si quedan o no posibles movimientos para el tablero del J2.
        public void posible2J2()
        {
            //Abajo & Derecha.
            int SUMA; //Almacena la suma de 2 números.
            int sumasMismaFILA; //Contador de las sumas consecutivas que va haciendo en una fila, el máximo es 1.
            int sumasMismaCOLUMNA; //Contador de las sumas consecutivas que va haciendo en una columna, el máximo es 1.
            int coordenadaA; //Guarda la coordenada "a" sirve dentro de los movimientos consecutivos del While.
            int coordenadaB; //Guarda la coordenada "b" sirve dentro de los movimientos consecutivos del While.
            for (int b = 3; b >= 0; b--)
            {
                sumasMismaFILA = 0;
                for (int a = 3; a >= 0; a--)
                {
                    sumasMismaCOLUMNA = 0; //Reinicia.
                    if (Program.J2.Matriz[a, b] != -1) //Si la casilla no esta vacia.
                    {
                        coordenadaA = a; //Guarda la coordenada "a".
                        while (coordenadaA < 3 && MOVIMIENTO == false) //Movimientos consecutivos del While, menor a 3 para evitar que se salga del indice.
                        {
                            if (Program.J2.Matriz[coordenadaA + 1, b] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Movimiento.
                                MOVIMIENTO = true;
                                //Sube de casilla.
                                coordenadaA++;
                            }
                            else if (Program.J2.Matriz[coordenadaA + 1, b] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J2.Matriz[coordenadaA + 1, b], Program.J2.Matriz[coordenadaA, b]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaFILA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaFILA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        //Movimiento.
                                        MOVIMIENTO = true;
                                    }
                                    //Sube de casilla.
                                    coordenadaA++;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.

                        coordenadaB = b; //Guarda la coordenada "b".
                        while (coordenadaB < 3 && MOVIMIENTO == true) //Movimientos consecutivos del While, menor a 3 para evitar que se salga del indice.
                        {
                            if (Program.J2.Matriz[a, coordenadaB + 1] == -1) //Si la casilla anterior de la posición actual esta vacia.
                            {
                                //Movimiento.
                                MOVIMIENTO = true;
                                //Sube de casilla.
                                coordenadaB++;
                            }
                            else if (Program.J2.Matriz[a, coordenadaB + 1] != -1) //Si la casilla anterior de la posición actual no esta vacia.
                            {
                                //Suma la casilla actual con la casilla anterior.
                                SUMA = Tools.Sumar(Program.J2.Matriz[a, coordenadaB + 1], Program.J2.Matriz[a, coordenadaB]);
                                if (SUMA != -2) //Si la suma da un resultado de la serie de Fibonacci.
                                {
                                    sumasMismaCOLUMNA++; //Aumenta el contador de sumas consecutivas de la fila.
                                    if (sumasMismaCOLUMNA < 2) //Si no ha llegado al máximo permite que se combinen.
                                    {
                                        //Movimiento.
                                        MOVIMIENTO = true;
                                    }
                                    //Sube de casilla.
                                    coordenadaB++;
                                }
                                else //Si la suma no da un resultado de la serie de Fibonacci.
                                {
                                    break; //No hace nada.
                                }
                            }
                        } //Fin del While.
                    }
                } //Fin del For.
            } //Fin del For.
        }

        //Terminaron los turnos del J1.
        public bool TerminoJ1()
        {
            MOVIMIENTO = false;
            posible1J1();
            posible2J1();

            if (MOVIMIENTO == false)
            {
                MessageBox.Show("No existen más movimientos posibles para el jugador 1", ".::TERMINO::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Terminaron los turnos del J2.
        public bool TerminoJ2()
        {
            MOVIMIENTO = false;
            posible1J2();
            posible2J2();

            if (MOVIMIENTO == false)
            {
                MessageBox.Show("No existen más movimientos posibles para el jugador 2", ".::TERMINO::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                return false;
            }
        }

        //<----------------------------------->
        public void AbajoTablero1()
        {
            ParaAbajoJ1();
            if (banderaSalvacion == true)
            {
                NuevoNumeroRandom1();
            }
            //Pasar al DataGridView.
            for (int q = 0; q < 4; q++)
            {
                for (int w = 0; w < 4; w++)
                {
                    DGV_tablero1.Rows[q].Cells[w].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J1.Matriz[q, w])];
                }
            }
            //Punteo.
            LB_puntaje1.Items.Clear();
            LB_puntaje1.Items.Add("Puntaje:");
            LB_puntaje1.Items.Add(Program.J1.punteo + "");
        }

        public void AbajoTablero2()
        {
            ParaAbajoJ2();
            if (banderaSalvacion == true)
            {
                NuevoNumeroRandom2();
            }
            //Pasar al DataGridView.
            for (int q = 0; q < 4; q++)
            {
                for (int w = 0; w < 4; w++)
                {
                    DGV_tablero2.Rows[q].Cells[w].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J2.Matriz[q, w])];
                }
            }
            //Punteo.
            LB_puntaje2.Items.Clear();
            LB_puntaje2.Items.Add("Puntaje:");
            LB_puntaje2.Items.Add(Program.J2.punteo + "");
        }

        public void ArribaTablero1()
        {
            ParaArribaJ1();
            if (banderaSalvacion == true)
            {
                NuevoNumeroRandom1();
            }
            //Pasar al DataGridView.
            for (int q = 0; q < 4; q++)
            {
                for (int w = 0; w < 4; w++)
                {
                    DGV_tablero1.Rows[q].Cells[w].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J1.Matriz[q, w])];
                }
            }
            //Punteo.
            LB_puntaje1.Items.Clear();
            LB_puntaje1.Items.Add("Puntaje:");
            LB_puntaje1.Items.Add(Program.J1.punteo + "");
        }

        public void ArribaTablero2()
        {
            ParaArribaJ2();
            if (banderaSalvacion == true)
            {
                NuevoNumeroRandom2();
            }
            //Pasar al DataGridView.
            for (int q = 0; q < 4; q++)
            {
                for (int w = 0; w < 4; w++)
                {
                    DGV_tablero2.Rows[q].Cells[w].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J2.Matriz[q, w])];
                }
            }
            //Punteo.
            LB_puntaje2.Items.Clear();
            LB_puntaje2.Items.Add("Puntaje:");
            LB_puntaje2.Items.Add(Program.J2.punteo + "");
        }

        public void IzquierdaTablero1()
        {
            ParaIzquierdaJ1();
            if (banderaSalvacion == true)
            {
                NuevoNumeroRandom1();
            }
            //Pasar al DataGridView.
            for (int q = 0; q < 4; q++)
            {
                for (int w = 0; w < 4; w++)
                {
                    DGV_tablero1.Rows[q].Cells[w].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J1.Matriz[q, w])];
                }
            }
            //Punteo.
            LB_puntaje1.Items.Clear();
            LB_puntaje1.Items.Add("Puntaje:");
            LB_puntaje1.Items.Add(Program.J1.punteo + "");
        }

        public void IzquierdaTablero2()
        {
            ParaIzquierdaJ2();
            if (banderaSalvacion == true)
            {
                NuevoNumeroRandom2();
            }
            //Pasar al DataGridView.
            for (int q = 0; q < 4; q++)
            {
                for (int w = 0; w < 4; w++)
                {
                    DGV_tablero2.Rows[q].Cells[w].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J2.Matriz[q, w])];
                }
            }
            //Punteo.
            LB_puntaje2.Items.Clear();
            LB_puntaje2.Items.Add("Puntaje:");
            LB_puntaje2.Items.Add(Program.J2.punteo + "");
        }

        public void DerechaTablero1()
        {
            ParaDerechaJ1();
            if (banderaSalvacion == true)
            {
                NuevoNumeroRandom1();
            }
            //Pasar al DataGridView.
            for (int q = 0; q < 4; q++)
            {
                for (int w = 0; w < 4; w++)
                {
                    DGV_tablero1.Rows[q].Cells[w].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J1.Matriz[q, w])];
                }
            }
            //Punteo.
            LB_puntaje1.Items.Clear();
            LB_puntaje1.Items.Add("Puntaje:");
            LB_puntaje1.Items.Add(Program.J1.punteo + "");
        }

        public void DerechaTablero2()
        {
            ParaDerechaJ2();
            if (banderaSalvacion == true)
            {
                NuevoNumeroRandom2();
            }
            //Pasar al DataGridView.
            for (int q = 0; q < 4; q++)
            {
                for (int w = 0; w < 4; w++)
                {
                    DGV_tablero2.Rows[q].Cells[w].Value = Tools.cuadroNumeros[Tools.Representa("B" + Program.J2.Matriz[q, w])];
                }
            }
            //Punteo.
            LB_puntaje2.Items.Clear();
            LB_puntaje2.Items.Add("Puntaje:");
            LB_puntaje2.Items.Add(Program.J2.punteo + "");
        }
        //<----------------------------------->
        //Reinicio.
        private void BTN_reiniciar_Click(object sender, EventArgs e)
        {
            //Paneles Reset.
            PAN_jugador1.Visible = false;
            PAN_jugador2.Visible = true;
            IniciarTablero1();
            IniciarTablero2();
            //Reset del punteo y del tiempo.
            Program.J1.punteo = 0; //Puntaje.
            Program.J2.punteo = 0; //Puntaje.
            TiempoJ1.Stop(); //Detiene el Timer del J1.
            Program.J1.tiempo = 0; //Reinicia el Tiempo del J1.
            L_tiempo1.Text = "0::00";
            TiempoJ2.Stop(); //Detiene el Timer del J2.
            Program.J2.tiempo = 0; //Reinicia el Tiempo del J2.
            L_tiempo2.Text = "0::00";
            //Punteo 1.
            LB_puntaje1.Items.Clear();
            LB_puntaje1.Items.Add("Puntaje:");
            LB_puntaje1.Items.Add(Program.J1.punteo + "");
            //Punteo 2.
            LB_puntaje2.Items.Clear();
            LB_puntaje2.Items.Add("Puntaje:");
            LB_puntaje2.Items.Add(Program.J2.punteo + "");
            //Botones del control.
            BTN_arriba.BackColor = Color.SkyBlue;
            BTN_abajo.BackColor = Color.SkyBlue;
            BTN_izquierda.BackColor = Color.SkyBlue;
            BTN_derecha.BackColor = Color.SkyBlue;
            //Enfocar.
            contadorCambio = 0; //Reinicia la bandera de cambio de jugador.
            DGV_tablero1.Focus(); //Enfoca el tablero del J1.
            //Inicia el Timer del J1.
            TiempoJ1.Start();
        }
        //<*************************************************************************************>
        //||**<<DISEÑO>>**||
        private void TB_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BTN_aceptar_Click(sender, e);
            }
        }

        private void CB_color_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BTN_aceptar_Click(sender, e);
            }
        }

        private void CB_color_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Asigna el color.
            Tools.AveriguarColor(CB_color.SelectedItem.ToString());
            TB_col.BackColor = Tools.Cola2;
        }

        private void CB_color_TextUpdate(object sender, EventArgs e)
        {
            MessageBox.Show("¡Seleccione 1 Color de la Lista!", ".::INFORMACIÓN::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TB_col.BackColor = Color.WhiteSmoke;
        }   

        int contadorJugadores = 0;
        private void BTN_aceptar_Click(object sender, EventArgs e)
        {
            contadorJugadores++;
            switch (contadorJugadores)
            {
                case 1: //Jugador 1.
                    if (TB_nombre.Text == "" && CB_color.Text == "") //Por defecto.
                    {
                        //Asigna el nombre.
                        Program.J1.nombre = "Jugador 1";
                        //Asigna el color.
                        Program.J1.color = Color.SlateBlue;
                        //Colorea e identifica todo lo relacionado al J1.
                        PAN_jugador1.BackColor = Program.J1.color;
                        PAN_estado1.BackColor = Program.J1.color;
                        L_j1.Text = Program.J1.nombre;
                        L_j11.Text = Program.J1.nombre;
                    }
                    else //Asignado por el usuario.
                    {
                        try
                        {
                            //Asigna el nombre.
                            Program.J1.nombre = TB_nombre.Text;
                            //Asigna el color.
                            Tools.AveriguarColor(CB_color.SelectedItem.ToString());
                            Program.J1.color = Tools.Cola2;
                            //Colorea e identifica todo lo relacionado al J1.
                            PAN_jugador1.BackColor = Program.J1.color;
                            PAN_estado1.BackColor = Program.J1.color;
                            L_j1.Text = Program.J1.nombre;
                            L_j11.Text = Program.J1.nombre;
                        }
                        catch
                        {
                            MessageBox.Show("¡Ambos datos son obligatorios!", ".::ERROR::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            contadorJugadores--;
                        }
                    }
                    break;

                case 2: //Jugador 2.
                    if (TB_nombre.Text == "" && CB_color.Text == "") //Por defecto.
                    {
                        //Asigna el nombre.
                        Program.J2.nombre = "Jugador 2";
                        //Asigna el color.
                        Program.J2.color = Color.SpringGreen;
                        //Colorea e identifica todo lo relacionado al J2.
                        PAN_jugador2.BackColor = Program.J2.color;
                        PAN_estado2.BackColor = Program.J2.color;
                        L_j2.Text = Program.J2.nombre;
                        L_j22.Text = Program.J2.nombre;
                    }
                    else //Asignado por el usuario.
                    {
                        try
                        {
                            //Asigna el nombre.
                            Program.J2.nombre = TB_nombre.Text;
                            //Asigna el color.
                            Tools.AveriguarColor(CB_color.SelectedItem.ToString());
                            Program.J2.color = Tools.Cola2;
                            //Colorea e identifica todo lo relacionado al J2.
                            PAN_jugador2.BackColor = Program.J2.color;
                            PAN_estado2.BackColor = Program.J2.color;
                            L_j2.Text = Program.J2.nombre;
                            L_j22.Text = Program.J2.nombre;
                        }
                        catch
                        {
                            MessageBox.Show("¡Ambos datos son obligatorios!", ".::ERROR::.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            contadorJugadores--;
                        }
                    }

                    //Apaga el registro.
                    L_nombre.ForeColor = Color.White;
                    L_color.ForeColor = Color.White;
                    PAN_registro.BackColor = Color.Black;
                    TB_nombre.BackColor = Color.Black;
                    TB_nombre.Enabled = false;
                    CB_color.BackColor = Color.Black;
                    CB_color.Enabled = false;
                    TB_col.BackColor = Color.Black;
                    BTN_aceptar.Text = "<<OFF>>";
                    BTN_aceptar.Enabled = false;

                    //Inicia el juego.
                    PAN_jugador1.Visible = false;
                    BTN_reiniciar_Click(sender,e);
                    break;

                default: 
                    break;
            }
            //Limpia.
            TB_nombre.Clear();
            CB_color.Items.Remove(CB_color.SelectedItem);
            TB_col.BackColor = Color.WhiteSmoke;
        }
        
        bool banderaIntercalados = false;
        bool banderaContinuar1;
        bool banderaContinuar2;
        private void DGV_tablero1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    banderaContinuar1 = TerminoJ1();
                    if (banderaContinuar1 == false)
                    {
                        ArribaTablero1();
                        //Botones del control.
                        BTN_arriba.BackColor = Color.Red;
                        BTN_abajo.BackColor = Color.SkyBlue;
                        BTN_izquierda.BackColor = Color.SkyBlue;
                        BTN_derecha.BackColor = Color.SkyBlue;
                        //Intercalado
                        if (banderaIntercalados == true)
                        {
                            TiempoJ1.Stop();
                            TiempoJ2.Start();
                            DGV_tablero2.Focus();
                            PAN_jugador1.Visible = true;
                            PAN_jugador2.Visible = false;
                        }
                    }
                    else if (banderaContinuar2 == false) //Termino.
                    {
                        TiempoJ1.Stop();
                        TiempoJ2.Start();
                        DGV_tablero2.Focus();
                        PAN_jugador1.Visible = true;
                        PAN_jugador2.Visible = false;
                        BTN_cambio.Enabled = false;
                        CHEB_intercalados.Enabled = false;
                    }
                    else if (banderaContinuar2 == true) //Resultados.
                    {
                        MessageBox.Show("Fin del Juego!");
                        TiempoJ1.Stop();
                        PAN_jugador1.Visible = true;
                    }
                    break;
                case Keys.Down:
                    banderaContinuar1 = TerminoJ1();
                    if (banderaContinuar1 == false)
                    {
                        AbajoTablero1();
                        //Botones del control.
                        BTN_arriba.BackColor = Color.SkyBlue;
                        BTN_abajo.BackColor = Color.Red;
                        BTN_izquierda.BackColor = Color.SkyBlue;
                        BTN_derecha.BackColor = Color.SkyBlue;
                        //Intercalado
                        if (banderaIntercalados == true)
                        {
                            TiempoJ1.Stop();
                            TiempoJ2.Start();
                            DGV_tablero2.Focus();
                            PAN_jugador1.Visible = true;
                            PAN_jugador2.Visible = false;
                        }
                    }
                    else if (banderaContinuar2 == false)
                    {
                        TiempoJ1.Stop();
                        TiempoJ2.Start();
                        DGV_tablero2.Focus();
                        PAN_jugador1.Visible = true;
                        PAN_jugador2.Visible = false;
                        BTN_cambio.Enabled = false;
                        CHEB_intercalados.Enabled = false;
                    }
                    else if (banderaContinuar2 == true) //Resultados.
                    {
                        MessageBox.Show("Fin del Juego!");
                        TiempoJ1.Stop();
                        PAN_jugador1.Visible = true;
                    }
                    break;
                case Keys.Left:
                    banderaContinuar1 = TerminoJ1();
                    if (banderaContinuar1 == false)
                    {
                        IzquierdaTablero1();
                        //Botones del control.
                        BTN_arriba.BackColor = Color.SkyBlue;
                        BTN_abajo.BackColor = Color.SkyBlue;
                        BTN_izquierda.BackColor = Color.Red;
                        BTN_derecha.BackColor = Color.SkyBlue;
                        //Intercalado
                        if (banderaIntercalados == true)
                        {
                            TiempoJ1.Stop();
                            TiempoJ2.Start();
                            DGV_tablero2.Focus();
                            PAN_jugador1.Visible = true;
                            PAN_jugador2.Visible = false;
                        }
                    }
                    else if (banderaContinuar2 == false)
                    {
                        TiempoJ1.Stop();
                        TiempoJ2.Start();
                        DGV_tablero2.Focus();
                        PAN_jugador1.Visible = true;
                        PAN_jugador2.Visible = false;
                        BTN_cambio.Enabled = false;
                        CHEB_intercalados.Enabled = false;
                    }
                    else if (banderaContinuar2 == true) //Resultados.
                    {
                        MessageBox.Show("Fin del Juego!");
                        TiempoJ1.Stop();
                        PAN_jugador1.Visible = true;
                    }
                    break;
                case Keys.Right:
                    banderaContinuar1 = TerminoJ1();
                    if (banderaContinuar1 == false)
                    {
                        DerechaTablero1();
                        //Botones del control.
                        BTN_arriba.BackColor = Color.SkyBlue;
                        BTN_abajo.BackColor = Color.SkyBlue;
                        BTN_izquierda.BackColor = Color.SkyBlue;
                        BTN_derecha.BackColor = Color.Red;
                        //Intercalado
                        if (banderaIntercalados == true)
                        {
                            TiempoJ1.Stop();
                            TiempoJ2.Start();
                            DGV_tablero2.Focus();
                            PAN_jugador1.Visible = true;
                            PAN_jugador2.Visible = false;
                        }
                    }
                    else if (banderaContinuar2 == false)
                    {
                        TiempoJ1.Stop();
                        TiempoJ2.Start();
                        DGV_tablero2.Focus();
                        PAN_jugador1.Visible = true;
                        PAN_jugador2.Visible = false;
                        BTN_cambio.Enabled = false;
                        CHEB_intercalados.Enabled = false;
                    }
                    else if (banderaContinuar2 == true) //Resultados.
                    {
                        MessageBox.Show("Fin del Juego!");
                        TiempoJ1.Stop();
                        PAN_jugador1.Visible = true;
                    }
                    break;
            }
        }

        private void DGV_tablero2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    banderaContinuar2 = TerminoJ2();
                    if (banderaContinuar2 == false)
                    {
                        ArribaTablero2();
                        //Botones del control.
                        BTN_arriba.BackColor = Color.Red;
                        BTN_abajo.BackColor = Color.SkyBlue;
                        BTN_izquierda.BackColor = Color.SkyBlue;
                        BTN_derecha.BackColor = Color.SkyBlue;
                        //Intercalado
                        if (banderaIntercalados == true)
                        {
                            TiempoJ1.Start();
                            TiempoJ2.Stop();
                            DGV_tablero1.Focus();
                            PAN_jugador1.Visible = false;
                            PAN_jugador2.Visible = true;
                        }
                    }
                    else if (banderaContinuar1 == false)
                    {
                        TiempoJ1.Start();
                        TiempoJ2.Stop();
                        DGV_tablero1.Focus();
                        PAN_jugador1.Visible = false;
                        PAN_jugador2.Visible = true;
                        BTN_cambio.Enabled = false;
                        CHEB_intercalados.Enabled = false;
                    }
                    else if (banderaContinuar1 == true) //Resultados.
                    {
                        MessageBox.Show("Fin del Juego!");
                        TiempoJ2.Stop();
                        PAN_jugador2.Visible = true;
                    }
                    break;
                case Keys.Down:
                    banderaContinuar2 = TerminoJ2();
                    if (banderaContinuar2 == false)
                    {
                        AbajoTablero2();
                        //Botones del control.
                        BTN_arriba.BackColor = Color.SkyBlue;
                        BTN_abajo.BackColor = Color.Red;
                        BTN_izquierda.BackColor = Color.SkyBlue;
                        BTN_derecha.BackColor = Color.SkyBlue;
                        //Intercalado
                        if (banderaIntercalados == true)
                        {
                            TiempoJ1.Start();
                            TiempoJ2.Stop();
                            DGV_tablero1.Focus();
                            PAN_jugador1.Visible = false;
                            PAN_jugador2.Visible = true;
                        }
                    }
                    else if (banderaContinuar1 == false)
                    {
                        TiempoJ1.Start();
                        TiempoJ2.Stop();
                        DGV_tablero1.Focus();
                        PAN_jugador1.Visible = false;
                        PAN_jugador2.Visible = true;
                        BTN_cambio.Enabled = false;
                        CHEB_intercalados.Enabled = false;
                    }
                    else if (banderaContinuar1 == true) //Resultados.
                    {
                        MessageBox.Show("Fin del Juego!");
                        TiempoJ2.Stop();
                        PAN_jugador2.Visible = true;
                    }
                    break;
                case Keys.Left:
                    banderaContinuar2 = TerminoJ2();
                    if (banderaContinuar2 == false)
                    {
                        IzquierdaTablero2();
                        //Botones del control.
                        BTN_arriba.BackColor = Color.SkyBlue;
                        BTN_abajo.BackColor = Color.SkyBlue;
                        BTN_izquierda.BackColor = Color.Red;
                        BTN_derecha.BackColor = Color.SkyBlue;
                        //Intercalado
                        if (banderaIntercalados == true)
                        {
                            TiempoJ1.Start();
                            TiempoJ2.Stop();
                            DGV_tablero1.Focus();
                            PAN_jugador1.Visible = false;
                            PAN_jugador2.Visible = true;
                        }
                    }
                    else if (banderaContinuar1 == false)
                    {
                        TiempoJ1.Start();
                        TiempoJ2.Stop();
                        DGV_tablero1.Focus();
                        PAN_jugador1.Visible = false;
                        PAN_jugador2.Visible = true;
                        BTN_cambio.Enabled = false;
                        CHEB_intercalados.Enabled = false;
                    }
                    else if (banderaContinuar1 == true) //Resultados.
                    {
                        MessageBox.Show("Fin del Juego!");
                        TiempoJ2.Stop();
                        PAN_jugador2.Visible = true;
                    }
                    break;
                case Keys.Right:
                    banderaContinuar2 = TerminoJ2();
                    if (banderaContinuar2 == false)
                    {
                        DerechaTablero2();
                        //Botones del control.
                        BTN_arriba.BackColor = Color.SkyBlue;
                        BTN_abajo.BackColor = Color.SkyBlue;
                        BTN_izquierda.BackColor = Color.SkyBlue;
                        BTN_derecha.BackColor = Color.Red;
                        //Intercalado
                        if (banderaIntercalados == true)
                        {
                            TiempoJ1.Start();
                            TiempoJ2.Stop();
                            DGV_tablero1.Focus();
                            PAN_jugador1.Visible = false;
                            PAN_jugador2.Visible = true;
                        }
                    }
                    else if (banderaContinuar1 == false)
                    {
                        TiempoJ1.Start();
                        TiempoJ2.Stop();
                        DGV_tablero1.Focus();
                        PAN_jugador1.Visible = false;
                        PAN_jugador2.Visible = true;
                        BTN_cambio.Enabled = false;
                        CHEB_intercalados.Enabled = false;
                    }
                    else if (banderaContinuar1 == true) //Resultados.
                    {
                        MessageBox.Show("Fin del Juego!");
                        TiempoJ2.Stop();
                        PAN_jugador2.Visible = true;
                    }
                    break;
            }
        }
        
        int contadorCambio = 0;
        private void BTN_cambio_Click(object sender, EventArgs e)
        {
            contadorCambio++;
            if (contadorCambio % 2 == 0) //Es par. Pasa al tablero 1.
            {
                banderaContinuar1 = TerminoJ1();
                if (banderaContinuar1 == false)
                {
                    TiempoJ1.Start();
                    TiempoJ2.Stop();
                    DGV_tablero1.Focus();
                    PAN_jugador1.Visible = false;
                    PAN_jugador2.Visible = true;
                }
                else
                {
                    BTN_cambio.Enabled = false;
                }
            }
            else //Es impar. Pasa al tablero 2.
            {
                banderaContinuar2 = TerminoJ2();
                if (banderaContinuar2 == false)
                {
                    TiempoJ1.Stop();
                    TiempoJ2.Start();
                    DGV_tablero2.Focus();
                    PAN_jugador1.Visible = true;
                    PAN_jugador2.Visible = false;
                }
                else
                {
                    BTN_cambio.Enabled = false;
                }
            }
        }

        private void CHEB_intercalados_CheckedChanged(object sender, EventArgs e)
        {
            if (CHEB_intercalados.Checked == true)
            {
                banderaIntercalados = true;
            }
            else
            {
                banderaIntercalados = false;
            }
            //Para enfocar al jugador actual.
            if(PAN_jugador1.Visible == true)
            {
                DGV_tablero2.Focus();
            }
            else //PAN_jugador1.Visible == false
            {
                DGV_tablero1.Focus();
            }
        }

        private void TiempoJ1_Tick(object sender, EventArgs e)
        {
            Program.J1.tiempo++;
            Program.J1.minutos = Program.J1.tiempo / 60;
            Program.J1.segundos = Program.J1.tiempo - (Program.J1.minutos * 60);
            L_tiempo1.Text = Program.J1.minutos + "::" + Program.J1.segundos;
        }

        private void TiempoJ2_Tick(object sender, EventArgs e)
        {
            Program.J2.tiempo++;
            Program.J2.minutos = Program.J2.tiempo / 60;
            Program.J2.segundos = Program.J2.tiempo - (Program.J2.minutos * 60);
            L_tiempo2.Text = Program.J2.minutos + "::" + Program.J2.segundos;
        }
    }
}