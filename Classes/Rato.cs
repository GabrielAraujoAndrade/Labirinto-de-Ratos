using System.Collections.Generic;

namespace LabirintoRatos.classes
{
    class Rato
    {
        // Cada rato possui um número de identificação, sua própria pilha e suas coordenadas:
        public int ratoIdentificador;
        public int x;
        public int y;
        private Stack<char> stack = new Stack<char>();
                
        public void IdentificarRato(int ratoIdentificador)
        {
            this.ratoIdentificador = ratoIdentificador;
        }

        /* 
         * Movimentação automatizada do rato 
         * Ordem das tentativas: W, A, S, D
         * Caso não consiga realizar essa movimentação, ele desempilhará e
         * executará o comando inverso ao topo da lista. */
        public void movimentoAutomatico(char[,] m)
        {
            char W = m[x - 1, y];
            char A = m[x, y - 1];
            char S = m[x + 1, y];
            char D = m[x, y + 1];

            if (W != '▒' && W != '█' && W != '.' && W != 'R')
            {
                stack.Push('W');
                moverParaCima(m);
            }
            else if (A != '▒' && A != '█' && A != '.' && A != '.' && A != 'R')
            {
                stack.Push('A');
                moverParaEsquerda(m);
            }
            else if (S != '▒' && S != '█' && S != '.' && S != 'R')
            {
                stack.Push('S');
                moverParaBaixo(m);
            }
            else if (D != '▒' && D != '█' && D != '.' && D != 'R')
            {
                stack.Push('D');
                moverParaDireita(m);
            }
            else
            {     
                // Verifica se possui algo na pilha:
                if (stack.Count > 1)
                {
                    if (stack.Peek() == 'W')
                    {
                        stack.Pop();
                        moverParaBaixo(m);
                    }
                    else if (stack.Peek() == 'A')
                    {
                        stack.Pop();
                        moverParaDireita(m);
                    }
                    else if (stack.Peek() == 'D')
                    {
                        stack.Pop();
                        moverParaEsquerda(m);
                    }
                    else if (stack.Peek() == 'S')
                    {
                        stack.Pop();
                        moverParaCima(m);
                    }
                }                
            }
        }


        #region Movimentos

        public void moverParaCima(char[,] m)
        {
            m[x, y] = '.';
            m[(x - 1), y] = 'R';
            this.x = x - 1;
        }

        public void moverParaBaixo(char[,] m)
        {
            m[x, y] = '.';
            m[(x + 1), y] = 'R';
            this.x = x + 1;
        }

        public void moverParaEsquerda(char[,] m)
        {
            m[x, y] = '.';
            m[x, (y - 1)] = 'R';
            this.y = y - 1;
        }

        public void moverParaDireita(char[,] m)
        {
            m[x, y] = '.';
            m[x, (y + 1)] = 'R';
            this.y = y + 1;
        }

        #endregion
    }
}
