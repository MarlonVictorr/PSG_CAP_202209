using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    /// <summary>
    /// Desafio 007 - Faça um programa que leia um número inteiro e mostre na sua tela a sua tabuada.
    /// </summary>
    public static class Desafio007
    {
        public static void Executar()
        {
            int valor;
            Console.Write("Digite um Valor: ");
            if (Int32.TryParse(Console.ReadLine(), out valor) == false)
            {
                Console.WriteLine("Só e aceito Números.");

            }
            for (int x = 1; x <= 10; x++)
            {
                Console.WriteLine(valor + " * " + x + " = " + valor * x);
            }
        }
    }
}
