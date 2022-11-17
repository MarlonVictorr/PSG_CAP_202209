﻿using Atacado.DB.EF.Database;
using Atacado.Poco.Pecuaria;
using Atacado.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Atacado.Servico.Pecuaria
{
    public class TipoRebanhoServico : GenericService<TipoRebanho,TipoRebanhoPoco>
    {
        public override List<TipoRebanhoPoco> Consultar(Expression<Func<TipoRebanho, bool>>? predicate = null)
        {
            IQueryable<TipoRebanho> query;
            if (predicate == null)
            {
                query = this.genrepo.Browseable(null);
            }
            else
            {
                query = this.genrepo.Browseable(predicate);
            }
            List<TipoRebanhoPoco> listaPoco = query.Select(tip =>
            new TipoRebanhoPoco()
            {
                CodigoTipo = tip.CodigoTipo,
                Descricao = tip.Descricao,
                Situacao = tip.Situacao,
                DataInclusao = tip.DataInclusao,
                DataAlteracao = tip.DataAlteracao,
                DataExclusao = tip.DataExclusao
            }
            )
                .ToList();
            return listaPoco;
        }
    }
}
