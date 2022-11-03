using Atacado.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.DB.EF.Database;
using System.Linq.Expressions;

namespace Atacado.Repositorio.Estoque
{
    public class ProdutoRepo : BaseRepositorio<Produto>
    {
        private ProjetoAcademiaContext contexto;

        public ProdutoRepo()
        {
            this.contexto = new ProjetoAcademiaContext();
        }
        public override Produto Create(Produto instancia)
        {
            this.contexto.Produtos.Add(instancia);
            this.contexto.SaveChanges();
            return instancia;
        }
        public override Produto Delete(int chave)
        {
            Produto del = this.Read(chave);
            if (del == null)
            {
                return null;
            }
            else
            {
                this.contexto.Produtos.Remove(del);
                this.contexto.SaveChanges();
                return del;
            }
        }
        public override Produto Delete(Produto instancia)
        {
            return this.Delete(instancia.Codigo);
        }
        public override List<Produto> Read()
        {
            return this.contexto.Produtos.ToList();
        }

        public override IQueryable<Produto> Read(Expression<Func<Produto, bool>> predicate = null)
        {
            if (predicate == null)
            {
                return this.contexto.Produtos.AsQueryable();
            }
            else
            {
                return this.contexto.Produtos.Where(predicate).AsQueryable();
            }
        }
        public override Produto Read(int chave)
        {
            return this.contexto.Produtos.SingleOrDefault(pro => pro.Codigo == chave);
        }
        public override Produto Update(Produto instancia)
        {
            Produto next = this.Read(instancia.Codigo);
            if (next == null)
            {
                return null;
            }
            else
            {
                next.CodigoCategoria = instancia.CodigoCategoria;
                next.CodigoSubcategoria = instancia.CodigoSubcategoria;
                next.Descricao = instancia.Descricao;
                next.Ativo = instancia.Ativo;
                this.contexto.SaveChanges();
                return next;
            }
        }
    }
}
