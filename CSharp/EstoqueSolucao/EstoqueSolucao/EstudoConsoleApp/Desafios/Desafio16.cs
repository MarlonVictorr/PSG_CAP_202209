using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstudoConsoleApp.Desafios
{
    public static class Desafio16
    {
        public static void Executar()
        {
            List<string> nomes = new List<string>();
            bool sair = false;
            while (sair == false)
            {
                Console.WriteLine("Nomes na Lista {0}.", nomes.Count);
                bool testar = true;
                while (testar == true)
                {
                    Console.WriteLine("Digite um nome de Aluno");
                    string nome = Console.ReadLine();

                    if (string.IsNullOrEmpty(nome.Trim()) == true)
                    {
                        Console.WriteLine("Nome é Obrigatario");
                        Console.WriteLine("Tente Novamente");
                        testar = true;
                    }
                    else
                    {
                        nomes.Add(nome);
                        testar = false;
                    }
                }
                Console.Write("Deseja sair <S/N>:");
                string teste = Console.ReadLine();
                if (teste.ToUpper() == "S")
                {
                    sair = true;
                }
                else
                {
                    Console.Clear();
                    sair = false;
                }
                nomes.Sort();
                Console.Clear();
                Console.WriteLine("Imprimindo nomes na lista");
                foreach (string nome in nomes)
                {
                    Console.WriteLine("\t Nome: {0}", nome);
                }

                Random rnd = new Random();

                int posicao = rnd.Next(nomes.Count);
                Console.WriteLine(" Escolhido {0} ", nomes[posicao]);
            }
        }
    }
}
