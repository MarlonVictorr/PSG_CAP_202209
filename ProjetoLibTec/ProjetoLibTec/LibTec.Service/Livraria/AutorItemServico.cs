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
    public class AutorItemServico : GenericService<AutorItem, AutorItemPoco>
    {
        public AutorItemServico(LibTecContext context) : base(context)
        { }

        public override List<AutorItemPoco> Consultar(Expression<Func<AutorItem, bool>>? predicate = null)
        {
            IQueryable<AutorItem> query;
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

        public override List<AutorItemPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<AutorItem> query;
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

        public override List<AutorItemPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<AutorItem, bool>>? predicate = null)
        {
            IQueryable<AutorItem> query;
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

        public override List<AutorItemPoco> ConverterPara(IQueryable<AutorItem> query)
        {
            return query.Select(aut =>
            new AutorItemPoco()
            {
                Codigo = aut.Codigo,
                CodigoAutor = aut.CodigoAutor,
                CodigoItem = aut.CodigoItem,
                Ativo = aut.Ativo,
                DataInclusao = aut.DataInclusao,
                DataAlteracao = aut.DataAlteracao,
                DataExclusao = aut.DataExclusao
            }
             )
             .ToList();
        }
    }
}
