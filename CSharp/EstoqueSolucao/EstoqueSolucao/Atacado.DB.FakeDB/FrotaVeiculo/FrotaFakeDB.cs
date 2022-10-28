using Atacado.Dominio.FrotaVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaVeiculo
{
    public static class FrotaFakeDB
    {
        private static List<Frota> frotas;

        public static List<Frota> Frotas
        {
            get 
            {
                if (frotas == null)
                {
                    frotas = new List<Frota>();
                    Carregar();
                }
                return frotas;
            }
        }

        private static void Carregar()
        {
            frotas.Add(new Frota(1,true,DateTime.Now,"Transporte de carga",10));
            frotas.Add(new Frota(1,true,DateTime.Now,"Frotas comerciais",5));
            frotas.Add(new Frota(1,true,DateTime.Now,"Frotas de entrega",20));
            frotas.Add(new Frota(1,true,DateTime.Now,"Frota Terceirizada",3));
            frotas.Add(new Frota(1,true,DateTime.Now,"Frota de caminhões",15));
        }
    }
}
