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
    public class PontoParadaController : ControllerBase
    {
        private PontoParadaService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public PontoParadaController(ViajeFacilContexto contexto) : base()
        {
            this.servico = new PontoParadaService(contexto);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<PontoParadaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<PontoParadaPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o Ponto Parada de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:long}")]
        public ActionResult<PontoParadaPoco> GetPorId(long codigo)
        {
            try
            {
                PontoParadaPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o Ponto Parada de acordo com o código informado de rota
        /// </summary>
        /// <param name="rotcodigo"></param>
        /// <returns></returns>
        [HttpGet("PorRota/{rotcodigo:long}")]
        public ActionResult<List<PontoParadaPoco>> GetPorRota(long rotcodigo)
        {
            try
            {
                List<PontoParadaPoco> listaPoco = this.servico.Consultar(pon => pon.CodigoRota == rotcodigo).ToList();
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
        public ActionResult<PontoParadaPoco> Post([FromBody] PontoParadaPoco poco)
        {
            try
            {
                PontoParadaPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<PontoParadaPoco> Put([FromBody] PontoParadaPoco poco)
        {
            try
            {
                PontoParadaPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<PontoParadaPoco> DeletePorId(long codigo)
        {
            try
            {
                PontoParadaPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
