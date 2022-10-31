using Atacado.Dominio.Estoque;
using Atacado.Poco.Estoque;
using Atacado.Repositorio.Estoque;
using Atacado.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.Estoque
{
    public class ProdutoServico : BaseServico<ProdutoPoco,ProdutoPoco>
    {
        private ProdutoRepo repo;

        public ProdutoServico()
        {
            this.repo = new ProdutoRepo();
        }

        public override ProdutoPoco Add(ProdutoPoco poco)
        {
            ProdutoPoco nova = this.ConvertTo(poco);
            ProdutoPoco criada = this.repo.Create(nova);
            return this.ConvertTo(criada);
        }

        public override List<ProdutoPoco> Browse()
        {
            List<ProdutoPoco> listaPoco = this.repo.Read()
                .Select(pro =>
                    new ProdutoPoco()
                    {
                        Codigo = pro.Codigo,
                        Descricao = pro.Descricao,
                        Ativo = pro.Ativo,
                        DataInclusao = pro.DataInclusao,
                        CodigoSubcategoria = pro.CodigoSubcategoria
                    }
                )
                .ToList();
            return listaPoco;
        }

        public override ProdutoPoco ConvertTo(ProdutoPoco dominio)
        {
            return new ProdutoPoco()
            {
                Codigo = dominio.Codigo,
                Descricao = dominio.Descricao,
                Ativo = dominio.Ativo,
                DataInclusao = dominio.DataInclusao,
                CodigoSubcategoria = dominio.CodigoSubcategoria
            };
        }

        public override ProdutoPoco ConvertTo(ProdutoPoco poco)
        {
            return new Produto(poco.Codigo, poco.Descricao, poco.Ativo, poco.DataInclusao, poco.CodigoSubcategoria);
        }

        public override ProdutoPoco Delete(int chave)
        {
            ProdutoPoco del = this.repo.Delete(chave);
            ProdutoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ProdutoPoco Delete(ProdutoPoco poco)
        {
            ProdutoPoco del = this.repo.Delete(poco.Codigo);
            ProdutoPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override ProdutoPoco Edit(ProdutoPoco poco)
        {
            ProdutoPoco editada = this.ConvertTo(poco);
            ProdutoPoco alterada = this.repo.Update(editada);
            ProdutoPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override ProdutoPoco Read(int chave)
        {
            ProdutoPoco lida = this.repo.Read(chave);
            ProdutoPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
