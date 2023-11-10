using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LabirintoRatos.classes
{
    class Labirinto : Mapa
    {
        public Rato rato; 
        public bool queijoEncontrado = false;
        public List<Thread> threads = new List<Thread>();
        
        // Método construtor responsável pela execução do algorítmo:
        public Labirinto()
        {
            gerarMapa();            
            quantidadeDeRatos();
            
            // Posiciona todos os ratos na matriz:
            for (int i = 0; i < arrayDeRatos.Count; i++)
            {
                Rato r = arrayDeRatos.ElementAt(i);
                posicionarRato(r);

                // Garantindo caminho a ao menos um rato:                
                gerarCaminhoGarantido(r);
            }

            posicionarQueijo();

            // While de execução e reimpressão do programa:
            while (!queijoEncontrado)
            {
                Console.Clear(); 
                printarMapa();

                // Adicionando todos os ratos e seus movimentos ao array list de Ratos:
                for (int i = 0; i < arrayDeRatos.Count; i++)
                {                     
                    threads.Add(new Thread(MovimentarRato));
                }

                // Executando a movimentação em cada thread para cada rato no array list:
                for (int i = 0; i < arrayDeRatos.Count; i++)
                {
                    threads.ElementAt(i).Start(i);
                    Thread.Sleep(10);
                }

                threads = new List<Thread>(); 
            }
        }
      
        public void MovimentarRato(object pIndex)
        {
            // Obtendo o objeto "Rato" e executando a movimentação:
            rato = arrayDeRatos.ElementAt(Convert.ToInt32(pIndex)); 
            rato.movimentoAutomatico(labirinto);

            // Quando as coordenadas de um rato baterem com a do queijo:
            if (rato.x == queijoPosicaoX && rato.y == queijoPosicaoY)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n\nPARABÉNS AO RATO {0}, FOI O PRIMEIRO A CHEGAR AO SEU QUEIJO!!!", rato.ratoIdentificador+1);
                Console.ResetColor();
                queijoEncontrado = true;
            }
        }
    }
}