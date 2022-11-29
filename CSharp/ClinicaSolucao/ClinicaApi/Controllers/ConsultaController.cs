using Clinica.Dominio.EF;
using Clinica.Poco;
using Clinica.Servico.Odonto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/clinica/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private ConsultaServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ConsultaController(ClinicaContext context) : base()
        {
            this.servico = new ConsultaServico(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ConsultaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ConsultaPoco> list = this.servico.Listar(take, skip);
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
        public ActionResult<ConsultaPoco> GetPorId(int codigo)
        {
            try
            {
                ConsultaPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Cria um novo registro na tabela
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<ConsultaPoco> Post([FromBody] ConsultaPoco poco)
        {
            try
            {
                ConsultaPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<ConsultaPoco> Put([FromBody] ConsultaPoco poco)
        {
            try
            {
                ConsultaPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<ConsultaPoco> DeletePorId(int codigo)
        {
            try
            {
                ConsultaPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
