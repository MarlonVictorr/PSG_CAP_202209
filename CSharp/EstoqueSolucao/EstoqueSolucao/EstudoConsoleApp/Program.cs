namespace EstudoConsoleApp;

using System;
using EstudoConsoleApp.Aulas;
using EstudoConsoleApp.Desafios;

public class Program
{
    public static void Main(string[] args)
    {
        //ExecutarExemplo001();
        //ExecutarExemplo002();
        //ExecutarExemplo003();
        //ExecutarExemplo004();
        //ExecutarExemplo005();
        //Desafio001.Executar();
        //Desafio002.Executar();
        //Desafio003.Executar();
        //Desafio004.Executar();
        //Desafio005.Executar();
        //Desafio006.Executar();
        //Desafio007.Executar();
        //Desafio008.Executar();
        //Desafio009.Executar();
        //Desafio10.Executar();
        //Desafio011.Executar();
        //Desafio12.Executar();
        //Desafio13.Executar();
        //Desafio14.Executar();
        //Desafio15.Executar();
        //Desafio16.Executar();
        //Desafio17.Executar();
        //Desafio18.Executar();
        //Desafio19.Executar();
        //Desafio20.Executar();

    }

    private static void ExecutarExemplo001()
    {
        Console.WriteLine("Operacoes Matematicas");
        Console.WriteLine();
        Console.Write("Informe o primeiro número:");
        int n1 = int.Parse(Console.ReadLine());
        Console.Write("Informe o segundo número:");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Somar: {0}", OperacoesMatematicas.Somar(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Subtrair: {0}", OperacoesMatematicas.Subtrair(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Multiplicar: {0}", OperacoesMatematicas.Multiplicar(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Dividir: {0}", OperacoesMatematicas.Dividir(n1, n2));


        Console.ReadLine();
    }

    private static void ExecutarExemplo002()
    {
        Console.WriteLine("Comparações Lógicas");
        Console.WriteLine();
        Console.Write("Informe o primeiro número:");
        int n1 = int.Parse(Console.ReadLine());
        Console.Write("Informe o segundo número:");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine();
        ComparacoesLogicas.MaiorQue(n1, n2);
        Console.WriteLine();
        ComparacoesLogicas.MenorQue(n1, n2);
        Console.ReadLine();
    }

    private static void ExecutarExemplo003()
    {
        Console.WriteLine("Comparações Lógicas");
        Console.WriteLine();
        Console.Write("Informe o primeiro número:");
        int n1 = int.Parse(Console.ReadLine());
        Console.Write("Informe o segundo número:");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine();
        ComparacoesLogicasV2.MaiorQue(n1, n2);
        Console.WriteLine();
        ComparacoesLogicasV2.MenorQue(n1, n2);
        Console.ReadLine();
    }

    private static void ExecutarExemplo004()
    {
        TrabalhandoComDatas.ExibirDataAtual();
        Console.WriteLine();
        TrabalhandoComDatas.ExibirDataAtualFormatada();
        Console.ReadLine();
    }

    private static void ExecutarExemplo005()
    {
        Console.WriteLine("Operacoes Matematicas V2");
        Console.WriteLine();
        Console.Write("Informe o primeiro número:");
        int n1 = int.Parse(Console.ReadLine());
        Console.Write("Informe o segundo número:");
        int n2 = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Somar: {0}", OperacoesMatematicas.Somar(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Subtrair: {0}", OperacoesMatematicas.Subtrair(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Multiplicar: {0}", OperacoesMatematicas.Multiplicar(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Dividir: {0}", OperacoesMatematicas.Dividir(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Potenciacao (x^y): {0}", OperacoesMatematicasV2.Potenciacao(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Potenciacao (y^x): {0}", OperacoesMatematicasV2.Potenciacao(n1, n2));
        Console.WriteLine();
        Console.WriteLine("Radiciacao (Raiz Quadrada de N1): {0}", OperacoesMatematicasV2.Radiciacao(n1));
        Console.WriteLine();
        Console.WriteLine("Radiciacao (Raiz Quadrada de N2): {0}", OperacoesMatematicasV2.Radiciacao(n2));
        Console.ReadLine();
    }

}

