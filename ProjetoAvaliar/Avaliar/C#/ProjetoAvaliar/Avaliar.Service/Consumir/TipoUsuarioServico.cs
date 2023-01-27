using Avaliar.Domain.EF;
using Avaliar.Poco;
using Avaliar.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Avaliar.Service.Consumir
{
    public class TipoUsuarioServico : ServicoGenerico<TipoUsuario, TipoUsuarioPoco>
    {
        public TipoUsuarioServico(AvaliarContext contexto) : base(contexto)
        { }

        public override List<TipoUsuarioPoco> Consultar(Expression<Func<TipoUsuario, bool>>? predicate = null)
        {
            IQueryable<TipoUsuario> query;
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

        public override List<TipoUsuarioPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<TipoUsuario> query;
            if (skip == null)
            {
                query = this.genrepo.GetAll();
            }
            else
            {
                query = this.genrepo.GetAll(take, skip);
            }
            return this.ConverterPara(query);
        }

        public override List<TipoUsuarioPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<TipoUsuario, bool>>? predicate = null)
        {
            IQueryable<TipoUsuario> query;
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

        public override List<TipoUsuarioPoco> ConverterPara(IQueryable<TipoUsuario> query)
        {
            return query.Select(tip =>
                new TipoUsuarioPoco()
                {
                    CodigoTipoUsuario = tip.CodigoTipoUsuario,
                    Descricao = tip.Descricao,
                    Ativo = tip.Ativo,
                    DataInclusao = tip.DataInclusao

                }).ToList();
        }

        public override int ContarTotalRegistros(Expression<Func<TipoUsuario, bool>>? predicate)
        {
            IQueryable<TipoUsuario> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            return query.Count();
        }
    }
}
