using Clinica.Dominio.EF;
using Clinica.Poco;
using Clinica.Servico.Clinica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/clinica/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private PacienteServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public PacienteController(ClinicaContext context) : base()
        {
            this.servico = new PacienteServico(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<PacientePoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<PacientePoco> list = this.servico.Listar(take, skip);
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
        public ActionResult<PacientePoco> GetPorId(int codigo)
        {
            try
            {
                PacientePoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o paciente de acordo com o código informado de profissão
        /// </summary>
        /// <param name="proid"></param>
        /// <returns></returns>
        [HttpGet("PorProfissao/{proid:int}")]
        public ActionResult<List<PacientePoco>> GetPorProfissaoId(int proid)
        {
            try
            {
                List<PacientePoco> listPoco = this.servico.Consultar(pac => pac.CodigoProfissao == proid).ToList();
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
        public ActionResult<PacientePoco> Post([FromBody] PacientePoco poco)
        {
            try
            {
                PacientePoco nova = this.servico.Inserir(poco);
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
        public ActionResult<PacientePoco> Put([FromBody] PacientePoco poco)
        {
            try
            {
                PacientePoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<PacientePoco> DeletePorId(int codigo)
        {
            try
            {
                PacientePoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Apaga um registro de acordo com os dados informados
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ActionResult<PacientePoco> DeletePorInstancia([FromBody] PacientePoco poco)
        {
            try
            {
                PacientePoco delPoco = this.servico.Excluir(poco.CodigoPaciente);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
