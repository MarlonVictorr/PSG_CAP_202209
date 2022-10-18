using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    /// <summary>
    /// Desafio 005 - Desenvolva um programa que leia as duas notas de um aluno, calcule e mostre a
    /// sua média.
    /// </summary>
    public static class Desafio005
    {
        public static void Executar()
        {
            double n1, n2, media;
            Console.Write("Insira a Primeira Nota: ");
            if (Double.TryParse(Console.ReadLine(), out n1) == false)
            {
                Console.WriteLine("Esse Campo só aceita números.");
            }
            Console.Write("Insira a Segunda Nota: ");
            if (Double.TryParse(Console.ReadLine(), out n2) == false)
            {
                Console.WriteLine("Esse Campo só aceita números.");
            }
            else 
            {
                media = ((n1 + n2) / 2);
                Console.WriteLine("Sua Média é: {0}", media);
            }
            
        }
    }
}
