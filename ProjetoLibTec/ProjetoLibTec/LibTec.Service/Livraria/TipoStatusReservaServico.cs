using LibTec.Domain.EF;
using LibTec.Poco;
using LibTec.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibTec.Service.Livraria
{
    public class TipoStatusReservaServico : GenericService <TipoStatusReserva,TipoStatusReservaPoco>
    {
        public TipoStatusReservaServico(LibTecContext context) : base(context)
        {}

        public override List<TipoStatusReservaPoco> Consultar(Expression<Func<TipoStatusReserva, bool>>? predicate = null)
        {
            IQueryable<TipoStatusReserva> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return this.ConverterPara(query);
        }

        public override List<TipoStatusReservaPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoStatusReserva> query;
            if (skip == null)
            {
                query = this.genrepo.GetAll();
            }
            else
            {
                query = this.genrepo.GetAll(take, skip);
            }
            return ConverterPara(query);
        }

        public override List<TipoStatusReservaPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<TipoStatusReserva, bool>>? predicate = null)
        {
            IQueryable<TipoStatusReserva> query;
            if (skip == null)
            {
                if (predicate == null)
                {
                    query = this.genrepo.Browseable(null);
                }
                else
                {
                    query = this.genrepo.Browseable(predicate);
                }
            }
            else
            {
                if (predicate == null)
                {
                    query = this.genrepo.GetAll(take, skip);
                }
                else
                {
                    query = this.genrepo.Searchable(take, skip, predicate);
                }
            }
            return this.ConverterPara(query);
        }

        public override List<TipoStatusReservaPoco> ConverterPara(IQueryable<TipoStatusReserva> query)
        {
            return query.Select(tip =>
            new TipoStatusReservaPoco()
            {
                Codigo = tip.Codigo,
                Descricao = tip.Descricao,
                Ativo = tip.Ativo,
                DataInclusao = tip.DataInclusao,
                DataAlteracao = tip.DataAlteracao,
                DataExclusao = tip.DataExclusao
            }
             )
             .ToList();
        }
    }
}
