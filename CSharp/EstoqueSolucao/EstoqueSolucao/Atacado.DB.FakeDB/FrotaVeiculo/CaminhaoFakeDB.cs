using Base.Dominio.Veiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaVeiculo
{
    public static class CaminhaoFakeDB
    {
        private static List<Caminhao> caminhaos;

        public static List<Caminhao> Caminhaos
        {
            get
            {
                if(caminhaos == null)
                {
                    caminhaos = new List<Caminhao>();
                    Carregar();
                }
                return caminhaos;
            }
        }
        private static void Carregar()
        {
            caminhaos.Add(new Caminhao(1,true,DateTime.Now, "1hu 3LrKnJ w7 5z0202","Preto","Mercedes","arocs","brk 2k20",23,10,33));
            caminhaos.Add(new Caminhao(2,true,DateTime.Now, "2rt 2artsj v8 6i4902","Amarelo", "Hyundai", "caoa","wtx 9h32",15,10,25));
            caminhaos.Add(new Caminhao(3,true,DateTime.Now, "8qs 4shamd q1 7r3142","Roxo", "Iveco", "tector","wqt 0g21",20,19,39));
            caminhaos.Add(new Caminhao(4,true,DateTime.Now, "6rd 2awqvc e3 2e7564","Branco", "Scania", "112","fvt 4r23",26,18,44));
            caminhaos.Add(new Caminhao(5,true,DateTime.Now, "9ps 9dhaki 8u 4s9654","Azul", "Volvo", "vm 330","rqa 6t43",22,10,32));
        }
    }
}
