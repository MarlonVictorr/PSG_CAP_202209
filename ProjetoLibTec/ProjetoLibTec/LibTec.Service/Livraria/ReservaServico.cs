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
    public class ReservaServico : GenericService<Reserva,ReservaPoco>
    {
        public ReservaServico(LibTecContext context ) : base(context)
        { }

        public override List<ReservaPoco> Consultar(Expression<Func<Reserva, bool>>? predicate = null)
        {
            IQueryable<Reserva> query;
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

        public override List<ReservaPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Reserva> query;
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

        public override List<ReservaPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<Reserva, bool>>? predicate = null)
        {
            IQueryable<Reserva> query;
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

        public override List<ReservaPoco> ConverterPara(IQueryable<Reserva> query)
        {
            return query.Select(res =>
            new ReservaPoco()
            {
                Codigo = res.Codigo,
                CodigoUsuario = res.CodigoUsuario,
                CodigoItem = res.CodigoItem,
                CodigoStatus = res.CodigoStatus,
                Ativo = res.Ativo,
                DataInclusao = res.DataInclusao,
                DataAlteracao = res.DataAlteracao,
                DataExclusao = res.DataExclusao
            }
             )
             .ToList();
        }
    }
}
