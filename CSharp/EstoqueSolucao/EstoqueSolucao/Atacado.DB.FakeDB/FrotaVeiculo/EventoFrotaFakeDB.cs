using Atacado.Dominio.FrotaVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.DB.FakeDB.FrotaVeiculo
{
    public static class EventoFrotaFakeDB
    {
        private static List<EventoFrota> eventos;

        public static List<EventoFrota> Eventos
        {
            get
            {
                if(eventos == null)
                {
                    eventos = new List<EventoFrota>();
                    Carregar();
                }
                return eventos;
            }
        }
        private static void Carregar()
        {
            eventos.Add(new EventoFrota(1,true,DateTime.Now,"marlon",new DateOnly(2000,02,11), new DateOnly(2005, 02, 11),30,50,"Transporte"));
            eventos.Add(new EventoFrota(1,true,DateTime.Now,"bruno",new DateOnly(2002,10,17), new DateOnly(2007, 10, 17),30,50,"Transporte"));
            eventos.Add(new EventoFrota(1,true,DateTime.Now,"akira",new DateOnly(2006,11,20), new DateOnly(2011, 11, 20),30,50,"Transporte"));
            eventos.Add(new EventoFrota(1,true,DateTime.Now,"rafael",new DateOnly(2004,04,12), new DateOnly(2009, 04, 12),30,50,"Transporte"));
            eventos.Add(new EventoFrota(1,true,DateTime.Now,"thiago",new DateOnly(2003,12,09), new DateOnly(2008, 12, 09),30,50,"Transporte"));
        }
    }
}
