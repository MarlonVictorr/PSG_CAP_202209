using Atacado.DB.FakeDB.Estoque;
using Atacado.Dominio.Estoque;
using Atacado.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repositorio.Estoque
{
    public class ProdutoRepo : BaseRepositorio<Produto>
    {
        private EstoqueContexto contexto;

        public ProdutoRepo()
        {
            this.contexto = new EstoqueContexto();
        }
        public override Produto Create(Produto instancia)
        {
            return this.contexto.AddProduto(instancia);
        }
        public override Produto Delete(int chave)
        {
            Produto del = this.Read(chave);
            if (this.contexto.Produtos.Remove(del) == false)
            {
                return null;
            }
            else
            {
                return del;
            }
        }
        public override Produto Delete(Produto instancia)
        {
            return this.Delete(instancia.Codigo);
        }
        public override List<Produto> Read()
        {
            return this.contexto.Produtos;
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
                next.Descricao = instancia.Descricao;
                next.Ativo = instancia.Ativo;
                return next;
            }
        }
    }
}
