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
    public class PassageiroService : GenericService<Passageiro, PassageiroPoco>
    {
        public PassageiroService(RevisaoContext context) : base(context)
        { }

        public override List<PassageiroPoco> Listar(int? take, int? skip = null)
        {
            IQueryable<Passageiro> query;
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

        public override List<PassageiroPoco> Consultar(Expression<Func<Passageiro, bool>>? predicate = null)
        {
            IQueryable<Passageiro> query;
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

        public override List<PassageiroPoco> Vasculhar(int? take, int? skip = null, Expression<Func<Passageiro, bool>>? predicate = null)
        {
            IQueryable<Passageiro> query;
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

        public override List<PassageiroPoco> ConverterPara(IQueryable<Passageiro> query)
        {
            return query.Select(pas =>
            new PassageiroPoco()
            {
                CodigoPassageiro = pas.CodigoPassageiro,
                Nome = pas.Nome,
                Email = pas.Email,
                Telefone = pas.Telefone,
                Usuario = pas.Usuario,
                Senha = pas.Senha,
                DataNascimento = pas.DataNascimento,
                Documento = pas.Documento,
                NumeroCartao = pas.NumeroCartao
               
            }
            )
                .ToList();
        }
    }
}
