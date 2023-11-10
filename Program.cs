using LabirintoRatos.classes;
using System;

namespace LabirintoRatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(75, 30);
            Console.Title = "Labirinto dos Ratos";

            Mapa mapa = new Mapa();  
            Labirinto labirinto = new Labirinto();

            Console.ReadKey();
        }
    }
}