using Atacado.Dominio.FrotaVeiculo;
using Atacado.Poco.FrotaVeiculo;
using Atacado.Repositorio.FrotaVeiculo;
using Atacado.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.FrotaVeiculo
{
    public class EventoFrotaServico : BaseServico<EventoFrotaPoco, EventoFrota>
    {
        private EventoFrotaRepo repo;

        public EventoFrotaServico()
        {
            this.repo = new EventoFrotaRepo();
        }

        public override EventoFrotaPoco Add(EventoFrotaPoco poco)
        {
            EventoFrota nova = this.ConvertTo(poco);
            EventoFrota criada = this.repo.Create(nova);
            EventoFrotaPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;
        }

        public override List<EventoFrotaPoco> Browse()
        {
            List<EventoFrotaPoco> listpoco = this.repo.Read()
                .Select(ev =>
                new EventoFrotaPoco()
                {
                    Codigo = ev.Codigo,
                    Ativo = ev.Ativo,
                    DataInclusao = ev.DataInclusao,
                    Condutor = ev.Condutor,
                    DataInicial = ev.DataInicial,
                    DataFinal = ev.DataFinal,
                    KmInicial = ev.KmInicial,
                    KmFinal = ev.KmFinal,
                    MotivoEvento = ev.MotivoEvento
                }
            )
            .ToList();
            return listpoco;
        
        }

        public override EventoFrotaPoco ConvertTo(EventoFrota dominio)
        {
            return new EventoFrotaPoco()
            {
                Codigo = dominio.Codigo,
                Ativo = dominio.Ativo,
                DataInclusao = dominio.DataInclusao,
                Condutor = dominio.Condutor,
                DataInicial = dominio.DataInicial,
                DataFinal = dominio.DataFinal,
                KmInicial = dominio.KmInicial,
                KmFinal = dominio.KmFinal,
                MotivoEvento = dominio.MotivoEvento
            };
        }

        public override EventoFrota ConvertTo(EventoFrotaPoco poco)
        {
            return new EventoFrota(poco.Codigo, poco.Ativo, poco.DataInclusao, poco.Condutor, poco.DataInicial, poco.DataFinal, poco.KmInicial, poco.KmFinal, poco.MotivoEvento);
        }

        public override EventoFrotaPoco Delete(int chave)
        {
            EventoFrota del = this.repo.Delete(chave);
            EventoFrotaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override EventoFrotaPoco Delete(EventoFrotaPoco poco)
        {
            EventoFrota del = this.repo.Delete(poco.Codigo);
            EventoFrotaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override EventoFrotaPoco Edit(EventoFrotaPoco poco)
        {
            EventoFrota editada = this.ConvertTo(poco);
            EventoFrota alterada = this.repo.Update(editada);
            EventoFrotaPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override EventoFrotaPoco Read(int chave)
        {
            EventoFrota lida = this.repo.Read(chave);
            EventoFrotaPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
