using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_1__Luciano_Poblete_
{
    internal class Program
    {
        static Boolean ganar = false;

        private static void Juego()
        {
            Console.Clear();
            Console.WriteLine("ingrese el tamaño del tablero, solo se permiten tableros de 5x5 hasta 8x8");

            Console.Write("Filas: ");
            String aux = Console.ReadLine().Trim();

            Console.Write("Columnas: ");
            String aux2 = Console.ReadLine().Trim();

            int elementosA = 0;
            int elementosB = 0;

            if (int.TryParse(aux, out elementosA) && int.TryParse(aux2, out elementosB))
            {
                if ((elementosA >= 5 && elementosB >= 5) && (elementosA <= 8 && elementosB <= 8))
                {
                    String[,] matriz = new String[elementosA, elementosB];

                    PoblarTablero(ref matriz, elementosA, elementosB);

                    while (ganar != true)
                    {
                        //MoverJugador();

                        PintarPantalla(ref matriz);
                    }


                    BuscarEnVector(ref matriz, elementosA, elementosB);

                }
                else
                {
                    Console.WriteLine("el numero de elementos debe ser mayor o igual a 5 o menor o igual que 8");
                }
            }
            else
            {
                Console.WriteLine("Debe ingresar una unidad numerica entera");
            }

        }


        private static void PoblarTablero(ref String[,] matriz, int elementosA, int elementosB)
        {

            Random valor = new Random();

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                   
                    matriz[i, j] = "P";
                    matriz[i, j] = "W";
                    matriz[i, j] = "V";
                    matriz[i, j] = "O";
                    matriz[i, j] = " ";
                

                }
            }

        }

        private static void MoverPersonaje(ref String[,] matriz)
        {
            //leer las teclas y utilizar un if para remplazar la posiciones de la  matriz
            //detectar si el personaje consigue el oro, cambiar variable global



        }


        private static void PintarPantalla(ref String[,] matriz)
        {
            Console.WriteLine();
            Console.WriteLine("Elementos del arreglo");
            //limpiar pantalla
            

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write("[{0}] ", matriz[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static void BuscarEnVector(ref String[,] matriz, int elementosA, int elementosB)
        {
            Console.WriteLine("");
            Console.WriteLine("Ingrese un valor para buscar: ");
            String aux = Console.ReadLine().Trim();

            int valor = 0;
            int posicionA = -1;
            int posicionB = -1;

            if (int.TryParse(aux, out valor))
            {
                for (int i = 0; i < elementosA; i++)
                {
                    for (int j = 0; j < elementosB; j++)
                    {
                      /* 
                       if (matriz[i, j] == valor)
                        {
                            posicionA = i;
                            posicionB = j;
                            break;
                        }
                      */
                    }
                }

                if (posicionA != -1 && posicionB != -1)
                {
                    Console.WriteLine("El valor ingresado se encuentra en la posción {0},{1}", posicionA, posicionB);
                }
                else
                {
                    Console.WriteLine("Valor no encontrado");
                }
            }
            else
            {
                Console.WriteLine("Debe ingresar una cantidad númerica entera");
            }


        }

        static void Main(string[] args)
        {

            Juego();

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para finalizar...");

            Console.ReadKey();

        }
    }
}
