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
    public class UsuarioServico : GenericService<Usuario, UsuarioPoco>
    {
        public UsuarioServico(LibTecContext context) : base(context)
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
            return ConverterPara(query);
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
                Codigo = usu.Codigo,
                Nome = usu.Nome,
                Sobrenome = usu.Sobrenome,
                Senha = usu.Senha,
                Email = usu.Email,
                MaxEmprestimos = usu.MaxEmprestimos,
                CodigoTipoUsuario = usu.CodigoTipoUsuario,
                Ativo = usu.Ativo,
                DataInclusao = usu.DataInclusao,
                DataAlteracao = usu.DataAlteracao,
                DataExclusao = usu.DataExclusao
            }
             )
             .ToList();
        }
    }
}
