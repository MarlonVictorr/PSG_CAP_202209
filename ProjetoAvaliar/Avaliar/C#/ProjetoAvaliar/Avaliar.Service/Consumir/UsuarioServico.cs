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
    public class UsuarioServico : ServicoGenerico<Usuario,UsuarioPoco>
    {
        public UsuarioServico(AvaliarContext contexto) : base(contexto)
        { }

        public override List<UsuarioPoco> Consultar(Expression<Func<Usuario, bool>>? predicate = null)
        {
            IQueryable<Usuario> query;
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

        public override List<UsuarioPoco> Listar(int? take = null, int? skip = null)
        {
            IQueryable<Usuario> query;
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

        public override List<UsuarioPoco> Vasculhar(int? take = null, int? skip = null, Expression<Func<Usuario, bool>>? predicate = null)
        {
            IQueryable<Usuario> query;
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

        public override List<UsuarioPoco> ConverterPara(IQueryable<Usuario> query)
        {
            return query.Select(usu =>
                new UsuarioPoco()
                {
                  CodigoUsuario = usu.CodigoUsuario,
                  CodigoTipoUsuario = usu.CodigoTipoUsuario,
                  Nome = usu.Nome,
                  Sobrenome = usu.Sobrenome,
                  Email = usu.Email,
                  Ativo = usu.Ativo,
                  DataInclusao = usu.DataInclusao

                }).ToList();
        }

        public override int ContarTotalRegistros(Expression<Func<Usuario, bool>>? predicate)
        {
            IQueryable<Usuario> query;
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
