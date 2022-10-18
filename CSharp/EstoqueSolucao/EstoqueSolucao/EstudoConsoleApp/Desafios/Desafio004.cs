using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    /// <summary>
    /// Desafio 004 - Crie um programa que leia um número e mostre o seu dobro, seu triplo e sua raiz
    /// quadrada.
    /// </summary>
    public static class Desafio004
    {
        public static void Executar()
        {
            int num;
            Console.Write("Informe um Número :");
            if (Int32.TryParse(Console.ReadLine(), out num) == false)
            {
                Console.WriteLine("Esse programa só aceita Números");
            }
            else if (num == 1)
            {
                int dobro = num * 2;
                int triplo = num * 3;
                double raiz = Math.Sqrt(Convert.ToDouble(num));
                Console.WriteLine("Para o número {0}:", num);
                Console.WriteLine("\tPara o número informado o seu dobro é: {0}", dobro);
                Console.WriteLine("\tPara o número informado o seu triplo é: {0}", triplo);
                Console.WriteLine("\tPara o número informado a sua raiz é: {0}", raiz);
            }
           
        }
    }
}
