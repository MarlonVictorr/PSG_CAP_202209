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
    public class InstituicaoController : ControllerBase
    {
        private InstituicaoService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="contexto"></param>
        public InstituicaoController(ViajeFacilContexto contexto) : base()
        {
            this.servico = new InstituicaoService(contexto);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<InstituicaoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<InstituicaoPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a instituição de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:long}")]
        public ActionResult<InstituicaoPoco> GetPorId(long codigo)
        {
            try
            {
                InstituicaoPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a instituição de acordo com o código informado de endereço
        /// </summary>
        /// <param name="endcodigo"></param>
        /// <returns></returns>
        [HttpGet("PorEndereco/{endcodigo:long}")]
        public ActionResult<List<InstituicaoPoco>> GetPorEndereco(long endcodigo)
        {
            try
            {
                List<InstituicaoPoco> listaPoco = this.servico.Consultar(ins => ins.CodigoEndereco == endcodigo).ToList();
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
        public ActionResult<InstituicaoPoco> Post([FromBody] InstituicaoPoco poco)
        {
            try
            {
                InstituicaoPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<InstituicaoPoco> Put([FromBody] InstituicaoPoco poco)
        {
            try
            {
                InstituicaoPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<InstituicaoPoco> DeletePorId(long codigo)
        {
            try
            {
                InstituicaoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
