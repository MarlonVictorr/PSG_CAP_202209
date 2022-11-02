﻿using Atacado.Repositorio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atacado.DB.EF.Database;


namespace Atacado.Repositorio.Estoque
{
    public class SubcategoriaRepo : BaseRepositorio<Subcategoria>
    {
        private ProjetoAcademiaContext contexto;

        public SubcategoriaRepo() 
        {
            this.contexto = new ProjetoAcademiaContext();
        }
        public override Subcategoria Create(Subcategoria instancia)
        {
            this.contexto.Subcategorias.Add(instancia);
            this.contexto.SaveChanges();
            return instancia;
        }
        public override Subcategoria Read(int chave)
        {
            return this.contexto.Subcategorias.SingleOrDefault(sub => sub.Codigo == chave);
        }

        public override List<Subcategoria> Read()
        {
            return this.contexto.Subcategorias.ToList();
        }
        public override Subcategoria Delete(int chave)
        {
            Subcategoria del = this.Read(chave);
            if (del == null)
            {
                return null;
            }
            else
            {
                this.contexto.Subcategorias.Remove(del);
                this.contexto.SaveChanges();
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
                up.CodigoCategoria = instancia.CodigoCategoria;
                up.Descricao = instancia.Descricao;
                up.Ativo = instancia.Ativo;
                this.contexto.SaveChanges();
                return up;
            }
        }
    }
}
