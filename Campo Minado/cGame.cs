using System;

namespace Campo_Minado
{
    class cGame
    {
        bool jogadaInvalida;
        char[,] matrizTable = new char[4, 9];
        bool[,] matrizConfig = configTable();

        public cGame()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Beep(2100, 250);
                int[] jogada = getPlay();
                continuar = verificaMina(jogada);
            }

            Console.Clear();
        }

        private void createTable(int[] jogada = null)
        {
            Console.Clear();

            bool aux = true;

            for (int i = 0; i < 9; i++)
            {
                if (aux)
                {
                    Console.Write("   ");
                    aux = false;
                }
                Console.Write(i + 1);
            }

            Console.WriteLine();

            aux = true;

            int b = -1;
            int c = -1;

            if (jogada != null)
            {
                b = jogada[0] - 1;
                c = jogada[1] - 1;
            }

            for (int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 9; j++)
                {
                    if (aux)
                    {
                        Console.Write(i+1 + "  ");
                        aux = false;
                    }

                    
                    if (!(i == b && j == c))
                    {
                        if (matrizTable[i, j] != 'x')
                        {
                            matrizTable[i, j] = '#';
                        }
                    }

                    if(jogada != null)
                    {
                        matrizTable[b, c] = 'x';
                        jogada = null;
                    }

                    Console.Write(matrizTable[i, j]);
                }

                aux = true;
                Console.WriteLine("");
            }

            Console.WriteLine("");

            if (jogadaInvalida) { Console.WriteLine("Jogada inválida!"); }
        }

        private static bool[,] configTable()
        {
            Random nRan = new Random();

            bool[,] matrizMinas = new bool[4,9];
            for (int i = 0; i < 10; i++)
            {
                matrizMinas[nRan.Next(0, 3), nRan.Next(0, 8)] = true;
            }
            return matrizMinas;
        }

        private void resetTable()
        {
            bool aux = true;

            for (int i = 0; i < 9; i++)
            {
                if (aux)
                {
                    Console.Write("   ");
                    aux = false;
                }
                Console.Write(i + 1);
            }

            Console.WriteLine();

            aux = true;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (aux)
                    {
                        Console.Write(i + 1 + "  ");
                        aux = false;
                    }

                    matrizTable[i, j] = '#';

                    Console.Write(matrizTable[i, j]);
                }
            }
        }

        private int[] getPlay(int[] play = null)
        {
            bool aux = true;
            int[] splitJogada = new int[2];

            while (aux)
            {
                createTable(play);

                Console.Write("Sua Jogada: ");
                string jogada = Console.ReadLine();

                if (testePlay(jogada))
                {
                    splitJogada[0] = Int32.Parse(jogada[0].ToString());
                    splitJogada[1] = Int32.Parse(jogada[1].ToString());
                    jogadaInvalida = false;
                    aux = false;
                }
                else
                {
                    jogadaInvalida = true;
                    Console.Beep(1500, 500);
                    aux = true;
                }
            }

            return splitJogada;
        }

        private bool testePlay(string jogada)
        {
            if (jogada.Length < 2 || jogada.Length > 2)
            {
                return false;
            }

            if (!char.IsNumber(jogada[0]) || !char.IsNumber(jogada[1]))
            {
                return false;
            }

            if (!(Int32.Parse(jogada[0].ToString()) > 0 && Int32.Parse(jogada[0].ToString()) < 5))
            {
                return false;
            }

            return true;
        }

        private bool verificaMina(int[] jogada)
        {
            bool aux = false;
            bool conti = true;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if(i == jogada[0]-1 && j == jogada[1] - 1)
                    {
                        if(matrizConfig[i,j] == true)
                        {
                            Console.Clear();
                            Console.Beep(1200, 500);
                            Console.WriteLine("Você foi explodido por uma mina, deseja jogar outra? Y/N");
                            string continuar = Console.ReadLine();
                            if(continuar == "y" || continuar == "Y")
                            {
                                resetTable();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            aux = true;
                            conti = verificaMina(getPlay(jogada));
                            break;
                        }
                    }
                }
                if (aux)
                {
                    break;
                }
            }
            if (conti)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

    }
}
