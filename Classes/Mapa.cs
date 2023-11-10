using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace LabirintoRatos.classes
{
    class Mapa
    {
        public static char[,] labirinto;
        public List<Rato> arrayDeRatos = new List<Rato>();
        public static int queijoPosicaoX;
        public static int queijoPosicaoY;

        // Pergunta quantos ratos o usuário deseja e os adiciona em um array list:        
        public void quantidadeDeRatos()
        {
            // Esse array de ratos, sem nenhum
            int numRats;
            Console.Write("Quantos ratos você deseja?\nSua resposta: ");
            numRats = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numRats; i++)
            {
                arrayDeRatos.Add(new Rato());
                arrayDeRatos.ElementAt(i).IdentificarRato(i);
            }
        }

        // Gera coordenadas aleatórias e posiciona o rato na matriz (mapa):
        public void posicionarRato(Rato r)
        {
            Random random = new Random();
            r.x = random.Next(1, 24);
            r.y = random.Next(1, 74);
            labirinto[r.x, r.y] = 'R';
        }

        // Gera um mapa aleatóriamente imprimindo paredes e espaços em branco:
        public void gerarMapa()
        {
            Random random = new Random();
            labirinto = new char[25, 75]; //Matriz do labirinto

            for (int i = 0; i < labirinto.GetLength(0); i++)
            {
                for (int j = 0; j < labirinto.GetLength(1); j++)
                {
                    if (i == 0 || i == 24 || j == 0 || j == 74)
                        labirinto[i, j] = '█'; // As bordas tem um ícone sólido
                    else
                    {
                        if (random.Next(0, 3) % 2 == 0)
                        {
                            labirinto[i, j] = ' '; // Se for par imprime vazio
                        }
                        else
                        {
                            labirinto[i, j] = '▒'; // Se for ímpar imprime parede
                        }
                    }
                }
            }
        }

        // Garante que o rato sempre tenha um caminho até o queijo:
        public void gerarCaminhoGarantido(Rato r)
        { 
            int i = 0;

            for (i = 1; i < (r.x + 1); i++)
            {
                labirinto[i, 1] = ' ';
            }
            for (int j = 1; j < (r.y + 1); j++)
            {
                labirinto[(i - 1), j] = ' ';
            }
        }

        // Posiciona o queijo em um local pré-definido no mapa (coordenadas (1,1)):
        public void posicionarQueijo()
        {
            // Posição do queijo estático nos quadrantes (1,1):
            queijoPosicaoX = 1;
            queijoPosicaoY = 1;
            labirinto[1, 1] = '■';
        }


        #region Métodos de impressão:

        // Responsável pela impressão da matriz e das cores dos elementos:
        public void printarMapa()
        {
            for (int i = 0; i < labirinto.GetLength(0); i++)
            {
                Console.WriteLine();

                for (int j = 0; j < labirinto.GetLength(1); j++)
                {
                    if (labirinto[i, j] == 'R') // Caso seja o rato
                    {
                        printarRato(i, j);
                    }
                    else if (labirinto[i, j] == '■') // Caso seja o queijo
                    {
                        printarQueijo(i, j);
                    }
                    else if (labirinto[i, j] == '.')
                    {
                        printarCaminhoPercorrido(i, j); // Caso seja o caminho percorrido pelo rato
                    }
                    else
                    {
                        Console.Write(labirinto[i, j]);
                    }
                }
            }
        }

        // Imprime o rato:
        public void printarRato(int i, int j)
        {
            Console.ForegroundColor = CordoRato(i,j);
            Console.Write(labirinto[i, j]);
            Console.ResetColor();
        }

        // Imprime o queijo:
        public void printarQueijo(int i, int j)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(labirinto[i, j]);
            Console.ResetColor();
        }

        // Imprime o caminho percorrido:
        public void printarCaminhoPercorrido(int i, int j)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(labirinto[i, j]);
            Console.ResetColor();
        }

        public ConsoleColor CordoRato(int i, int j)
        {
            int index = arrayDeRatos.FindIndex(r => r.x == i && r.y == j);
            switch (index)
            {
                case 0:
                    return ConsoleColor.Blue;
                case 1:
                    return ConsoleColor.Green;
                case 2:
                    return ConsoleColor.Yellow;
                case 3:
                    return ConsoleColor.Cyan;
                case 4:
                    return ConsoleColor.Magenta;
                case 5:
                    return ConsoleColor.Red;
                case 6:
                    return ConsoleColor.DarkBlue;
                case 7:
                    return ConsoleColor.White;
                case 8:
                    return ConsoleColor.Gray;
                case 9:
                    return ConsoleColor.DarkYellow;
                case 10:
                    return ConsoleColor.DarkGray;

                default:
                    return ConsoleColor.Red;
            }
        }


        #endregion
    }
}

