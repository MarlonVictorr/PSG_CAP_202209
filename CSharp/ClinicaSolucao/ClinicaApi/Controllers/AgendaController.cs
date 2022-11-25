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
    public class AgendaController : ControllerBase
    {
        private AgendaServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AgendaController(ClinicaContext context) : base()
        {
            this.servico = new AgendaServico(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<AgendaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<AgendaPoco> list = this.servico.Listar(take, skip);
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
        public ActionResult<AgendaPoco> GetPorId(int codigo)
        {
            try
            {
                AgendaPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o paciente de acordo com o código informado de paciente
        /// </summary>
        /// <param name="paccodigo"></param>
        /// <returns></returns>
        [HttpGet("PorPaciente/{paccodigo:int}")]
        public ActionResult<List<AgendaPoco>> GetPorPaciente(int paccodigo)
        {
            try
            {
                List<AgendaPoco> listaPoco = this.servico.Consultar(age => age.CodigoPaciente == paccodigo).ToList();
                return Ok(listaPoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista os registros da Agenda por código de Consulta e Ano.
        /// </summary>
        /// <param name="concodigo"></param>
        /// <param name="ano"></param>
        /// <returns></returns>
        [HttpGet("PorConsulta/{concodigo:int}/PorAno/{ano:int}")]
        public ActionResult<List<AgendaPoco>> GetPorConsultaPorAno(int concodigo, int ano)
        {
            try
            {
                List<AgendaPoco> listaPoco = this.servico.Consultar(age => (age.CodigoConsulta == concodigo) && (age.Ano == ano)).ToList();
                return Ok(listaPoco);
            }
            catch(Exception ex)
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
        public ActionResult<AgendaPoco> Post([FromBody] AgendaPoco poco)
        {
            try
            {
                AgendaPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<AgendaPoco> Put([FromBody] AgendaPoco poco)
        {
            try
            {
                AgendaPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<AgendaPoco> DeletePorId(int codigo)
        {
            try
            {
                AgendaPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
