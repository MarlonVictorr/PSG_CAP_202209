using LinqKit;
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
    public class EstadoController : ControllerBase
    {
        private EstadoService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public EstadoController(ViajeFacilContexto contexto) : base()
        {
            this.servico = new EstadoService(contexto);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<EstadoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<EstadoPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o estado de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:long}")]
        public ActionResult<EstadoPoco> GetPorId(long codigo)
        {
            try
            {
                EstadoPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o estado de acordo com o código informado de regiao
        /// </summary>
        /// <param name="regcodigo"></param>
        /// <returns></returns>
        [HttpGet("PorRegiao/{regcodigo:long}")]
        public ActionResult<List<EstadoPoco>> GetPorRegiao(long regcodigo)
        {
            try
            {
                List<EstadoPoco> listaPoco = this.servico.Consultar(est => est.CodigoRegiao == regcodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o estado de acordo com a sigla informada
        /// </summary>
        /// <param name="siglauf"></param>
        /// <returns></returns>
        [HttpGet("PorSiglaUf/{siglauf}")]
        public ActionResult<List<EstadoPoco>> GetPorSiglaUf(string siglauf)
        {
            try
            {
                List<EstadoPoco> listaPoco = this.servico.Consultar(est => est.SiglaUf == siglauf).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o estado de acordo com o nome de estado informado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("PorNome/{nome}")]
        public ActionResult<List<EstadoPoco>> GetPorNome(string nome)
        {
            try
            {
                List<EstadoPoco> listaPoco = this.servico.Consultar(est => est.Nome == nome).ToList();
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
        public ActionResult<EstadoPoco> Post([FromBody] EstadoPoco poco)
        {
            try
            {
                EstadoPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<EstadoPoco> Put([FromBody] EstadoPoco poco)
        {
            try
            {
                EstadoPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<EstadoPoco> DeletePorId(long codigo)
        {
            try
            {
                EstadoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
