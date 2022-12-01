using Clinica.Dominio.EF;
using Clinica.Poco;
using Clinica.Servico.Odonto;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/clinica/[controller]")]
    [ApiController]
    public class TipoServicoController : ControllerBase
    {
        private TipoServicoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TipoServicoController(ClinicaContext context) : base()
        {
            this.servico = new TipoServicoServico(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TipoServicoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoServicoPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o paciente de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<TipoServicoPoco> GetPorId(int codigo)
        {
            try
            {
                TipoServicoPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
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
        public ActionResult<TipoServicoPoco> Post([FromBody] TipoServicoPoco poco)
        {
            try
            {
                TipoServicoPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<TipoServicoPoco> Put([FromBody] TipoServicoPoco poco)
        {
            try
            {
                TipoServicoPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<TipoServicoPoco> DeletePorId(int codigo)
        {
            try
            {
                TipoServicoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
