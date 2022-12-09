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
    public class RegiaoController : ControllerBase
    {
        private RegiaoService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public RegiaoController(ViajeFacilContexto contexto) : base()
        {
            this.servico = new RegiaoService(contexto);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<RegiaoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<RegiaoPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a região de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:long}")]
        public ActionResult<RegiaoPoco> GetPorId(long codigo)
        {
            try
            {
                RegiaoPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a região de acordo com o código informado de país
        /// </summary>
        /// <param name="paicodigo"></param>
        /// <returns></returns>
        [HttpGet("PorPais/{paicodigo:long}")]
        public ActionResult<List<RegiaoPoco>> GetPorPais(long paicodigo)
        {
            try
            {
                List<RegiaoPoco> listaPoco = this.servico.Consultar(reg => reg.CodigoPais == paicodigo).ToList();
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
        public ActionResult<RegiaoPoco> Post([FromBody] RegiaoPoco poco)
        {
            try
            {
                RegiaoPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<RegiaoPoco> Put([FromBody] RegiaoPoco poco)
        {
            try
            {
                RegiaoPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<RegiaoPoco> DeletePorId(long codigo)
        {
            try
            {
                RegiaoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
