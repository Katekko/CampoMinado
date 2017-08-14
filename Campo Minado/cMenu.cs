using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campo_Minado
{
    class cMenu
    {
        public cMenu()
        {
            bool aux = true;
            int opcao = -1;

            while (aux)
            {
                Console.Clear();

                Console.WriteLine("Bem vindo ao Kampo Mines!");
                Console.WriteLine("-------------------------");
                Console.WriteLine("Escolha sua opção!");
                Console.WriteLine("1- Jogar");
                Console.WriteLine("2- Regras");
                Console.WriteLine("3- Ranking");
                Console.WriteLine("4- Sair");
                Console.WriteLine("-------------------------");
                Console.WriteLine("\n\n\n\n                                  K A T E K K O");

                Int32.TryParse(Console.ReadLine(), out opcao);

                switch (opcao)
                {
                    case 1:
                        cGame game = new cGame();  
                        break;
                    case 2:
                        cRules rule = new cRules();
                        break;
                    case 3:
                        aux = false;
                        break;
                    case 4:
                        aux = false;
                        break;
                    default:
                        Console.Clear();
                        Console.Beep(1500,500);
                        Console.WriteLine("Opção Invalida, escolha entre 1 e 3!\n\n");                     
                        aux = true;
                        break;
                }

            }
        }

    }
}
