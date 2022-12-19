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
    public class ItemServico : GenericService<Item, ItemPoco>
    {
        public ItemServico(LibTecContext context) : base(context) 
        { }

        public override List<ItemPoco> Consultar(Expression<Func<Item, bool>>? predicate = null)
        {
            IQueryable<Item> query;
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

        public override List<ItemPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Item> query;
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

        public override List<ItemPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<Item, bool>>? predicate = null)
        {
            IQueryable<Item> query;
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

        public override List<ItemPoco> ConverterPara(IQueryable<Item> query)
        {
            return query.Select(ite =>
            new ItemPoco()
            {
                Codigo = ite.Codigo,
                Descricao = ite.Descricao,
                ISBN = ite.ISBN,
                Observacoes = ite.Observacoes,
                CodigoTipoItem = ite.CodigoTipoItem,
                Ativo = ite.Ativo,
                DataInclusao = ite.DataInclusao,
                DataAlteracao = ite.DataAlteracao,
                DataExclusao = ite.DataExclusao
            }
             )
             .ToList();
        }
    }
}
