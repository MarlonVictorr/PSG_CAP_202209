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
    public class SubcategoriaServico : BaseServico<SubcategoriaPoco,SubcategoriaPoco>
    {
        private SubcategoriaRepo repo;

        public SubcategoriaServico() : base()
        {
            this.repo = new SubcategoriaRepo();
        }

        public override SubcategoriaPoco Add(SubcategoriaPoco poco)
        {
            SubcategoriaPoco nova = this.ConvertTo(poco);
            SubcategoriaPoco criada = this.repo.Create(nova);
            SubcategoriaPoco criadaPoco = this.ConvertTo(criada);
            return criadaPoco;
        }

        public override List<SubcategoriaPoco> Browse()
        {
            List<SubcategoriaPoco> listaPoco = this.repo.Read()
                .Select(sub =>
                    new SubcategoriaPoco()
                    {
                        Codigo = sub.Codigo,
                        Descricao = sub.Descricao,
                        Ativo = sub.Ativo,
                        DataInclusao = sub.DataInclusao,
                        CodigoCategoria = sub.CodigoCategoria
                    }
                 )
                .ToList();
            return listaPoco;
        }
        public override SubcategoriaPoco ConvertTo(SubcategoriaPoco dominio)
        {
            return new SubcategoriaPoco()
            {
                Codigo = dominio.Codigo,
                Descricao = dominio.Descricao,
                Ativo = dominio.Ativo,
                DataInclusao = dominio.DataInclusao,
                CodigoCategoria = dominio.CodigoCategoria
            };
        }

        public override SubcategoriaPoco ConvertTo(SubcategoriaPoco poco)
        {
            return new Subcategoria(poco.Codigo, poco.Descricao, poco.Ativo, poco.DataInclusao, poco.CodigoCategoria);
        }

        public override SubcategoriaPoco Delete(int chave)
        {
            SubcategoriaPoco del = this.repo.Delete(chave);
            SubcategoriaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override SubcategoriaPoco Delete(SubcategoriaPoco poco)
        {
            SubcategoriaPoco del = this.repo.Delete(ConvertTo(poco));
            SubcategoriaPoco delPoco = this.ConvertTo(del);
            return delPoco;
        }

        public override SubcategoriaPoco Edit(SubcategoriaPoco poco)
        {
            SubcategoriaPoco editada = this.ConvertTo(poco);
            SubcategoriaPoco alterada = this.repo.Update(editada);
            SubcategoriaPoco alteradaPoco = this.ConvertTo(alterada);
            return alteradaPoco;
        }

        public override SubcategoriaPoco Read(int chave)
        {
            SubcategoriaPoco lida = this.repo.Read(chave);
            SubcategoriaPoco lidaPoco = this.ConvertTo(lida);
            return lidaPoco;
        }
    }
}
