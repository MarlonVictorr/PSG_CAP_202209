using Atacado.DB.FakeDB.FrotaVeiculo;
using Atacado.Repositorio.Base;
using Base.Dominio.FrotaVeiculo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repositorio.FrotaVeiculo
{
    public class EventoFrotaRepo : BaseRepositorio<EventoFrota>
    {
        private FrotaContexto contexto;

        public EventoFrotaRepo()
        {
            this.contexto = new FrotaContexto();
        }

        public override EventoFrota Create(EventoFrota instancia)
        {
            return this.contexto.AddEvento(instancia);
        }

        public override EventoFrota Delete(int chave)
        {
            EventoFrota del = this.Read(chave);
            if (this.contexto.Evento.Remove(del) == false)
            {
                return null;
            }
            else
            {
                return del;
            }
        }

        public override EventoFrota Delete(EventoFrota instancia)
        {
            return this.Delete(instancia.Codigo);
        }

        public override EventoFrota Read(int chave)
        {
            return this.contexto.Eventos.SingleOrDefault(eve => eve.Codigo == chave);
        }

        public override List<EventoFrota> Read()
        {
            return this.contexto.Eventos;
        }

        public override EventoFrota Update(EventoFrota instancia)
        {
            EventoFrota atu = this.Read(instancia.Codigo);
            if (atu == null)
            {
                return null;
            }
            else
            {
                atu.Ativo = instancia.Ativo;
                atu.DataInclusao = instancia.DataInclusao;
                atu.DataInicial = instancia.DataInicial;
                atu.DataFinal = instancia.DataFinal;
                atu.KmInicial = instancia.KmInicial;
                atu.MotivoEvento = instancia.MotivoEvento;
                return atu;
            }
        }
    }
}
