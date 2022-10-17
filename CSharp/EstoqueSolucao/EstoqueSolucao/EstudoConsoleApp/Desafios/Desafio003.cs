using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio003
    {
        public static void Executar()
        {
            int n1, n2;
            Console.WriteLine("Informe o Primeiro Número");
            if(Int32.TryParse(Console.ReadLine(), out n1) == false)
            {
                Console.WriteLine("Mensagem de Erro.");
                return;
            }
            Console.Write("Informe o Segundo Número");
            if(Int32.TryParse(Console.ReadLine(), out n2) == false)
            {
                Console.WriteLine("Mensagem de Erro.");
                return;
            }
            int soma = n1 + n2;
            Console.WriteLine("A soma de {0} com {1} é igual a {2}.", n1, n2, soma);
        }
    }
}
