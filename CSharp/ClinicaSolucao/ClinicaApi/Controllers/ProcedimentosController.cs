using Clinica.Dominio.EF;
using Clinica.Poco;
using Clinica.Servico.Odonto;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    [Route("api/clinica/[controller]")]
    [ApiController]
    public class ProcedimentosController : ControllerBase
    {
        private ProcedimentosServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ProcedimentosController(ClinicaContext context) : base()
        {
            this.servico = new ProcedimentosServico(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet("tipoServico")]
        public ActionResult<List<ServicoPoco>> GetAll(string tipoServico, int? take = null, int? skip = null)
        {
            try
            {
                List<ServicoPoco> listPoco;
                var predicado = PredicateBuilder.New<Clinica.Dominio.EF.Servico>(true);
                if (take == null) //Opcional
                {
                    if (skip != null)
                    {
                        return BadRequest("Informe os parâmetro take e skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.TipoServico == tipoServico);
                        listPoco = this.servico.Vasculhar(take, skip, predicado);
                        return Ok(listPoco);
                    }
                }
                else
                {
                    if (skip == null) //Opcional
                    {
                        return BadRequest("Informe os parâmetro take e skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.TipoServico == tipoServico);
                        listPoco = this.servico.Vasculhar(take, skip, predicado);
                        return Ok(listPoco);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o serviço de acordo com o código informado
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{tipoServico}/{id:int}")]
        public ActionResult<ServicoPoco> GetPorId(string tipoServico,int id)
        {
            try
            {
                List<ServicoPoco> listPoco = this.servico.Consultar(s => (s.TipoServico == tipoServico) && (s.CodigoServico == id));
                return Ok(listPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Cria um novo registro na tabela
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ServicoPoco> Post([FromBody] ServicoPoco poco)
        {
            try
            {
                ServicoPoco nova = this.servico.Inserir(poco);
                return Ok(nova);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza os dados da tabela 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<ServicoPoco> Put([FromBody] ServicoPoco poco)
        {
            try
            {
                ServicoPoco atPoco = this.servico.Alterar(poco);
                return Ok(atPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Apaga um registro por codigo informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<ServicoPoco> DeletePorId(int codigo)
        {
            try
            {
                ServicoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
