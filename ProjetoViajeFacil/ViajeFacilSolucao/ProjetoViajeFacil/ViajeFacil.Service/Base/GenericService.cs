﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ViajeFacil.Dominio.EF;
using ViajeFacil.Mapping.Base;
using ViajeFacil.Repository.Base;

namespace ViajeFacil.Service.Base
{
    public class GenericService<TDominio,TPoco> 
        where TDominio : class 
        where TPoco: class
    {
        protected GenericRepository<TDominio> genrepo;

        protected GenericMap<TDominio, TPoco> genmap;

        public GenericService(ViajeFacilContexto contexto)
        {
            this.genrepo = new GenericRepository<TDominio>(contexto);
            this.genmap = new GenericMap<TDominio, TPoco>();
        }

        public List<TPoco> Listar()
        {
            return this.Consultar(null);
        }

        public virtual List<TPoco> Listar(int? take, int? skip = null)
        {
            throw new NotImplementedException();
        }

        public virtual List<TPoco> Consultar(Expression<Func<TDominio, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public virtual List<TPoco> Vasculhar(int? take, int? skip = null, Expression<Func<TDominio, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public TPoco? PesquisarPelaChave(object chave)
        {
            TDominio? lida = this.genrepo.GetById(chave);
            TPoco? lidaPoco = null;
            if (lida != null)
            {
                lidaPoco = this.ConverterPara(lida);
            }
            return lidaPoco;
        }

        public TPoco? Inserir(TPoco obj)
        {
            TDominio? nova = this.ConverterPara(obj);
            TDominio? criada = this.genrepo.Insert(nova);
            TPoco? criadaPoco = null;
            if (criada != null)
            {
                criadaPoco = this.ConverterPara(criada);
            }
            return criadaPoco;
        }

        public TPoco? Alterar(TPoco obj)
        {
            TDominio? editada = this.ConverterPara(obj);
            TDominio? alterada = this.genrepo.Update(editada);
            TPoco? alteradaPoco = null;
            if (alterada != null)
            {
                alteradaPoco = this.ConverterPara(alterada);
            }
            return alteradaPoco;
        }

        public TPoco? Excluir(object chave)
        {
            TDominio? del = this.genrepo.Delete(chave);
            TPoco? delPoco = null;
            if (del != null)
            {
                delPoco = this.ConverterPara(del);
            }
            return delPoco;
        }

        public TDominio ConverterPara(TPoco obj)
        {
            return this.genmap.Mapping.Map<TDominio>(obj);
        }

        public TPoco ConverterPara(TDominio obj)
        {
            return this.genmap.Mapping.Map<TPoco>(obj);
        }

        public virtual List<TPoco> ConverterPara(IQueryable<TDominio> query)
        {
            throw new NotImplementedException();
        }
    }
}
