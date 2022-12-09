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
    public class EventoController : ControllerBase
    {
        private EventoService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public EventoController(ViajeFacilContexto contexto) : base()
        {
            this.servico = new EventoService(contexto);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<EventoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<EventoPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o evento de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:long}")]
        public ActionResult<EventoPoco> GetPorId(long codigo)
        {
            try
            {
                EventoPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o evento de acordo com o código informado de instituição
        /// </summary>
        /// <param name="inscodigo"></param>
        /// <returns></returns>
        [HttpGet("PorInstituicao/{inscodigo:long}")]
        public ActionResult<List<EventoPoco>> GetPorInstituicao(long inscodigo)
        {
            try
            {
                List<EventoPoco> listaPoco = this.servico.Consultar(eve => eve.CodigoInstituicao == inscodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o evento de acordo com o código informado de endereço
        /// </summary>
        /// <param name="endcodigo"></param>
        /// <returns></returns>
        [HttpGet("PorEndereco/{endcodigo:long}")]
        public ActionResult<List<EventoPoco>> GetPorEndereco(long endcodigo)
        {
            try
            {
                List<EventoPoco> listaPoco = this.servico.Consultar(eve => eve.CodigoEndereco == endcodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o evento pelo Código de Rota (ida e volta)
        /// </summary>
        /// <param name="idaid"></param>
        /// <param name="voltaid"></param>
        /// <returns></returns>
        [HttpGet("PorRotaIda/{idaid:long}/PorRotaVolta/{voltaid:long}")]
        public ActionResult<List<EventoPoco>> GetPorRotaIdaPorRotaVolta(long idaid, long voltaid)
        {
            try
            {
                List<EventoPoco> ListPoco = this.servico.Consultar(eve => (eve.CodigoRotaIda == idaid) && (eve.CodigoRotaVolta == voltaid)).ToList();
                return Ok(ListPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o evento de acordo com o código informado de Usuario
        /// </summary>
        /// <param name="usucodigo"></param>
        /// <returns></returns>
        [HttpGet("PorUsuario/{usucodigo:long}")]
        public ActionResult<List<EventoPoco>> GetPorUsuario(long usucodigo)
        {
            try
            {
                List<EventoPoco> listaPoco = this.servico.Consultar(eve => eve.CodigoUsuarioResponsavel == usucodigo).ToList();
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
        public ActionResult<EventoPoco> Post([FromBody] EventoPoco poco)
        {
            try
            {
                EventoPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<EventoPoco> Put([FromBody] EventoPoco poco)
        {
            try
            {
                EventoPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<EventoPoco> DeletePorId(long codigo)
        {
            try
            {
                EventoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
