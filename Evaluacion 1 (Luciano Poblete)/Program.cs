using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion_1__Luciano_Poblete_
{
    internal class Program
    {

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
                if (elementosA > 0 && elementosB > 0)
                {
                    int[,] matriz = new int[elementosA, elementosB];

                    PoblarTablero(ref matriz);

                    //bucle del juego, break al detectar la variable global

                    //MoverJugador();

                    PintarPantalla(ref matriz);

                    BuscarEnVector(ref matriz, elementosA, elementosB);

                }
                else
                {
                    Console.WriteLine("el numero de elementos debe ser mayor a 0");
                }
            }
            else
            {
                Console.WriteLine("Debe ingresar una unidad numerica entera");
            }

        }


        private static void PoblarTablero(ref int[,] matriz)
        {
            Random valor = new Random();

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    matriz[i, j] = valor.Next(0, 10);
                }
            }

        }

        private static void MoverPersonaje(ref int[,] matriz)
        {
            //leer las teclas y utilizar un if para remplazar la posiciones de la  matriz
            //detectar si el personaje consigue el oro, cambiar variable global

            //codigo de referencia abajo

            Console.WriteLine("ingrese una posicion para mostrar el arreglo original");
            String aux = Console.ReadLine().Trim();
            String aux2 = Console.ReadLine().Trim();
            int posicionA = 0;
            int posicionB = 0;

            if (int.TryParse(aux, out posicionA) && int.TryParse(aux2, out posicionB))
            {

                if ((posicionA >= 0 && posicionB >= 0) && (posicionA < matriz.Length && posicionB < matriz.Length))
                {
                    Console.WriteLine("El elemento solicitado es {0}", matriz[posicionA, posicionB]);

                    Console.WriteLine("Ingrese un nuevo valor para esta posición");
                    aux = Console.ReadLine().Trim();
                    int nuevoValor = 0;

                    if (int.TryParse(aux, out nuevoValor))
                    {
                        matriz[posicionA, posicionB] = nuevoValor;
                        PintarPantalla(ref matriz);
                    }
                    else
                    {
                        Console.WriteLine("Debe ingresar una unidad numerica entera");
                    }

                }
                else
                {
                    Console.WriteLine("La posición solicitada está fuera de rango");
                }
            }
            else
            {
                Console.WriteLine("La posición no es numerica");
            }
        }


        private static void PintarPantalla(ref int[,] matriz)
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

        private static void BuscarEnVector(ref int[,] matriz, int elementosA, int elementosB)
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
                        if (matriz[i, j] == valor)
                        {
                            posicionA = i;
                            posicionB = j;
                            break;
                        }
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
