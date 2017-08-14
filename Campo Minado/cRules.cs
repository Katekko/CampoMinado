using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campo_Minado
{
    class cRules
    {
        public cRules()
        {
            Console.Beep(1800, 250);
            Console.Clear();
            Console.WriteLine("----------Como Jogar-----------");
            Console.WriteLine("Para fazer sua jogada escreva");
            Console.WriteLine("o número da Linha e o numero");
            Console.WriteLine("da Coluna respectivamente.");
            Console.WriteLine("Não coloque nada entre os ");
            Console.WriteLine("números, antes ou depois.");
            Console.WriteLine("Exemplo de jogada: 12");
            Console.WriteLine("Linha 1 e coluna 2 ^^");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
            Console.WriteLine("----------Como Ganhar----------");
            Console.WriteLine("Encontre todos os espaços e");
            Console.WriteLine("tente não encontrar nenhuma");
            Console.WriteLine("mina no seu caminho!");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Clique qualquer tecla para voltar ao menu!");
            Console.ReadKey();
        }

    }
}
