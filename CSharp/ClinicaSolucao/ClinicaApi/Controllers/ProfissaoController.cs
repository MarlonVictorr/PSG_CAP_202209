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
    public class ProfissaoController : ControllerBase
    {
        private ProfissaoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ProfissaoController(ClinicaContext context) : base()
        {
            this.servico = new ProfissaoServico(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProfissaoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ProfissaoPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch(Exception ex)
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
        public ActionResult<ProfissaoPoco> GetPorId(int codigo)
        {
            try
            {
                ProfissaoPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch(Exception ex)
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
        public ActionResult<ProfissaoPoco> Post([FromBody] ProfissaoPoco poco)
        {
            try
            {
                ProfissaoPoco nova = this.servico.Inserir(poco);
                return Ok(nova);
            }
            catch(Exception ex)
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
        public ActionResult<ProfissaoPoco> Put([FromBody] ProfissaoPoco poco)
        {
            try
            {
                ProfissaoPoco atPoco = this.servico.Alterar(poco);
                return Ok(atPoco);
            }
            catch(Exception ex)
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
        public ActionResult<ProfissaoPoco> DeletePorId(int codigo)
        {
            try
            {
                ProfissaoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
