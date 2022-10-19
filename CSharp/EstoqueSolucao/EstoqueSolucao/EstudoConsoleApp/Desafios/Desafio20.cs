using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio20
    {
        public static void Executar()
        {
            Console.Write("Digite seu Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Olá meu nome é: {0}",nome);
            Console.WriteLine();
            Console.WriteLine("Seu Nome Maiusculo é: {0}", nome.ToUpper());
            Console.WriteLine();
            Console.WriteLine("Seu Nome Minusculo é: {0}", nome.ToLower());
            Console.WriteLine();
            Console.WriteLine("Quantidade de letras no nome: {0}", nome.Replace(" ", "").Length);
            Console.WriteLine();
            Console.WriteLine("O primeiro nome contém {0} letras.", nome.IndexOf(" "));
        }
    }
}
