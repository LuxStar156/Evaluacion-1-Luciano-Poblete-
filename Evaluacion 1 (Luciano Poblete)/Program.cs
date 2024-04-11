using System;

namespace Evaluacion_1__Luciano_Poblete_
{
    internal class Program
    {
        static Boolean ganar = false;
        static int jugadorFila;
        static int jugadorColumna;

        private static void Juego()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el tamaño del tablero. Solo se permiten tableros de 5x5 hasta 8x8");

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

                    Console.WriteLine("Presiona ENTER para comenzar");

                    while (!ganar)
                    {
                        MoverPersonaje(ref matriz);
                        PintarPantalla(ref matriz);
                        Interactuar(ref matriz, jugadorFila, jugadorColumna, ref ganar);
                
                    }
                }
                else
                {
                    Console.WriteLine("El número de elementos debe ser mayor o igual a 5 y menor o igual que 8");
                }
            }
            else
            {
                Console.WriteLine("Debe ingresar una unidad numérica entera");
            }

        }

        private static void PoblarTablero(ref String[,] matriz, int elementosA, int elementosB)
        {
            Random rand = new Random();

            int oroFila = rand.Next(0, elementosA);
            int oroColumna = rand.Next(0, elementosB);
            matriz[oroFila, oroColumna] = "O";

            int wumpusFila = rand.Next(0, elementosA);
            int wumpusColumna = rand.Next(0, elementosB);
            matriz[wumpusFila, wumpusColumna] = "W";

            int numPozos = rand.Next(1, 5);
            for (int i = 0; i < numPozos; i++)
            {
                int pozoFila = rand.Next(0, elementosA);
                int pozoColumna = rand.Next(0, elementosB);
                matriz[pozoFila, pozoColumna] = "P";
            }

            jugadorFila = rand.Next(0, elementosA);
            jugadorColumna = rand.Next(0, elementosB);

            if (oroFila == jugadorFila && oroColumna == jugadorColumna)
            {
                jugadorFila = rand.Next(0, elementosA);
                jugadorColumna = rand.Next(0, elementosB);
            }



        }

        private static void MoverPersonaje(ref String[,] matriz)
        {
            ConsoleKeyInfo tecla = Console.ReadKey();

            matriz[jugadorFila, jugadorColumna] = " ";

            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    if (jugadorFila > 0) 
                        
                        jugadorFila--;

                        break;

                case ConsoleKey.DownArrow:
                    if (jugadorFila < matriz.GetLength(0) - 1) 
                        
                        jugadorFila++;

                        break;

                case ConsoleKey.LeftArrow:
                    if (jugadorColumna > 0)
                        
                        jugadorColumna--;

                        break;

                case ConsoleKey.RightArrow:
                    if (jugadorColumna < matriz.GetLength(1) - 1) 

                        jugadorColumna++;

                        break;
            }

            if (matriz[jugadorFila,jugadorColumna] == null || matriz[jugadorFila, jugadorColumna] == " ")
            {
                matriz[jugadorFila, jugadorColumna] = "J";
            }
            

        }

        private static void PintarPantalla(ref String[,] matriz)
        {
            Console.Clear();
            Console.WriteLine("El mundo de Wampus");

            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Console.Write("[{0}] ", matriz[i, j]);
                }
                Console.WriteLine();
            }

            for (int i = jugadorFila - 1; i <= jugadorFila + 1; i++)
            {
                for (int j = jugadorColumna - 1; j <= jugadorColumna + 1; j++)
                {
                    if (i >= 0 && i < matriz.GetLength(0) && j >= 0 && j < matriz.GetLength(1))
                    {
                        string contenido = matriz[i, j];

                        switch (contenido)
                        {
                            case "O":
                                Console.WriteLine("Se puede ver un resplandor cerca.");
                              
                                break;
                            case "W":
                                Console.WriteLine("Se siente mal olor.");
                           
                                break;
                            case "P":
                                Console.WriteLine("Se siente la brisa.");
                              
                                break;
                        }
                    }
                }
            }

            Console.WriteLine();
        }

        private static void Interactuar(ref String[,] matriz, int jugadorFila, int jugadorColumna, ref Boolean ganar)
        {

            string elemento = matriz[jugadorFila, jugadorColumna];
    
            switch (elemento)
            {
                case "O":
                    Console.WriteLine("¡Has encontrado el oro! ¡Has ganado!");
                    ganar = true;
                    break;
                case "W":
                    Console.WriteLine("¡Has encontrado al Wumpus! ¡Has perdido!");
                    ganar = true; 
                    break;
                case "P":
                    Console.WriteLine("¡Has caído en un pozo! ¡Has perdido!");
                    ganar = true; 
                    break;
                default:
          
                    break;
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