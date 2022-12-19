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
    public class EmprestimoServico : GenericService<Emprestimo, EmprestimoPoco>
    {
        public EmprestimoServico(LibTecContext context) : base(context)
        { }

        public override List<EmprestimoPoco> Consultar(Expression<Func<Emprestimo, bool>>? predicate = null)
        {
            IQueryable<Emprestimo> query;
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

        public override List<EmprestimoPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Emprestimo> query;
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

        public override List<EmprestimoPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<Emprestimo, bool>>? predicate = null)
        {
            IQueryable<Emprestimo> query;
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

        public override List<EmprestimoPoco> ConverterPara(IQueryable<Emprestimo> query)
        {
            return query.Select(emp =>
            new EmprestimoPoco()
            {
               Codigo = emp.Codigo,
               CodigoUsuario = emp.CodigoUsuario,
               CodigoItem = emp.CodigoItem,
               QuantidadeRenovado = emp.QuantidadeRenovado,
               DataSaida = emp.DataSaida,
               DataExpiracao = emp.DataExpiracao,
               DataRetorno = emp.DataRetorno,
               CodigoStatus = emp.CodigoStatus,
               Ativo = emp.Ativo,
               DataInclusao = emp.DataInclusao,
               DataAlteracao = emp.DataAlteracao,
               DataExclusao = emp.DataExclusao
            }
             )
             .ToList();
        }
    }
}
