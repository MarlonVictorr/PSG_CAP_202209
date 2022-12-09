using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViajeFacil.Dominio.EF;
using ViajeFacil.Poco;
using ViajeFacil.Service.Viajar;

namespace ViajeFacilApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/viajefacil/[controller]")]
    [ApiController]
    public class ParticipanteEventoController : ControllerBase
    {
        private ParticipanteEventoService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public ParticipanteEventoController(ViajeFacilContexto contexto) : base()
        {
            this.servico = new ParticipanteEventoService(contexto);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ParticipanteEventoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ParticipanteEventoPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o Participante de evento de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:long}")]
        public ActionResult<ParticipanteEventoPoco> GetPorId(long codigo)
        {
            try
            {
                ParticipanteEventoPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o Participante de evento de acordo com o código informado de evento
        /// </summary>
        /// <param name="evecodigo"></param>
        /// <returns></returns>
        [HttpGet("PorEvento/{evecodigo:long}")]
        public ActionResult<List<ParticipanteEventoPoco>> GetPorEvento(long evecodigo)
        {
            try
            {
                List<ParticipanteEventoPoco> listaPoco = this.servico.Consultar(par => par.CodigoEvento == evecodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o Participante de evento de acordo com o código informado de usúario
        /// </summary>
        /// <param name="usucodigo"></param>
        /// <returns></returns>
        [HttpGet("PorUsuario/{usucodigo:long}")]
        public ActionResult<List<ParticipanteEventoPoco>> GetPorUsuario(long usucodigo)
        {
            try
            {
                List<ParticipanteEventoPoco> listaPoco = this.servico.Consultar(par => par.CodigoUsuario == usucodigo).ToList();
                return Ok(listaPoco);
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
        public ActionResult<ParticipanteEventoPoco> Post([FromBody] ParticipanteEventoPoco poco)
        {
            try
            {
                ParticipanteEventoPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<ParticipanteEventoPoco> Put([FromBody] ParticipanteEventoPoco poco)
        {
            try
            {
                ParticipanteEventoPoco atPoco = this.servico.Alterar(poco);
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
        [HttpDelete("{codigo:long}")]
        public ActionResult<ParticipanteEventoPoco> DeletePorId(long codigo)
        {
            try
            {
                ParticipanteEventoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
