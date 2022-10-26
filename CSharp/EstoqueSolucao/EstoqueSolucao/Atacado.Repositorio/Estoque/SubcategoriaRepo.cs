﻿using Atacado.DB.FakeDB.Estoque;
using Atacado.Dominio.Estoque;
using Atacado.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Repositorio.Estoque
{
    public class SubcategoriaRepo : BaseRepositorio<Subcategoria>
    {
        private EstoqueContexto contexto;

        public SubcategoriaRepo() 
        {
            this.contexto = new EstoqueContexto();
        }
        public override Subcategoria Create(Subcategoria instancia)
        {
            return this.contexto.AddSubcategoria(instancia);
        }
        public override Subcategoria Read(int chave)
        {
            return this.contexto.Subcategorias.SingleOrDefault(sub => sub.Codigo == chave);
        }

        public override List<Subcategoria> Read()
        {
            return this.contexto.Subcategorias;
        }
        public override Subcategoria Delete(int chave)
        {
            Subcategoria del = this.Read(chave);
            if (this.contexto.Subcategorias.Remove(del) == false)
            {
                return null;
            }
            else
            {
                return del;
            }
        }
        public override Subcategoria Delete(Subcategoria instancia)
        {
            return this.Delete(instancia.Codigo);
        }
        public override Subcategoria Update(Subcategoria instancia)
        {
            Subcategoria up = this.Read(instancia.Codigo);
            if (up == null)
            {
                return null;
            }
            else
            {
                up.Descricao = instancia.Descricao;
                up.Ativo = instancia.Ativo;
                return up;
            }
        }
    }
}
