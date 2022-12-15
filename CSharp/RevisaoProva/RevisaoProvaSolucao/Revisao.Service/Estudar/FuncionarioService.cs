using Revisao.Dominio.EF;
using Revisao.Poco;
using Revisao.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Revisao.Service.Estudar
{
    public class FuncionarioService : GenericService<Funcionario,FuncionarioPoco>
    {
        public FuncionarioService(RevisaoContext context) : base(context)
        { }

        public override List<FuncionarioPoco> Listar(int? take, int? skip = null)
        {
            IQueryable<Funcionario> query;
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

        public override List<FuncionarioPoco> Consultar(Expression<Func<Funcionario, bool>>? predicate = null)
        {
            IQueryable<Funcionario> query;
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

        public override List<FuncionarioPoco> Vasculhar(int? take, int? skip = null, Expression<Func<Funcionario, bool>>? predicate = null)
        {
            IQueryable<Funcionario> query;
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

        public override List<FuncionarioPoco> ConverterPara(IQueryable<Funcionario> query)
        {
            return query.Select(fun =>
            new FuncionarioPoco()
            {
                CodigoFuncionario = fun.CodigoFuncionario,
                Nome = fun.Nome,
                Email = fun.Email,
                Telefone = fun.Telefone,
                Usuario = fun.Usuario,
                Senha = fun.Senha,
                DataNascimento = fun.DataNascimento,
                Matricula = fun.Matricula,
                ContaCorrente = fun.ContaCorrente
            }
            )
                .ToList();
        }
    }
}
