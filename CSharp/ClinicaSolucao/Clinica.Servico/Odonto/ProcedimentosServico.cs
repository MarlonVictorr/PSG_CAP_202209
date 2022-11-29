using Clinica.Dominio.EF;
using Clinica.Poco;
using Clinica.Servico.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Servico.Odonto
{
    public class ProcedimentosServico : GenericService<Clinica.Dominio.EF.Servico,ServicoPoco>
    {
        public ProcedimentosServico(ClinicaContext context) : base(context) { }

        public override List<ServicoPoco> Listar(int? take, int? skip = null)
        {
            IQueryable<Clinica.Dominio.EF.Servico> query;
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

        public override List<ServicoPoco> ConverterPara(IQueryable<Clinica.Dominio.EF.Servico> query)
        {
            return query.Select(ser =>
            new ServicoPoco()
            {
                CodigoServico = ser.CodigoServico,
                Descricao = ser.Descricao,
                Preco = ser.Preco,
                TipoServico = ser.TipoServico,
                Situacao = ser.Situacao,
                DataInclusao = ser.DataInclusao,
                DataAlteracao = ser.DataAlteracao,
                MedidaPreventiva = ser.MedidaPreventiva,
                TipoExame = ser.TipoExame,
                DenteTratado = ser.DenteTratado,
                MaterialUsado = ser.MaterialUsado
            }
            )
            .ToList();
        }
    }
}
