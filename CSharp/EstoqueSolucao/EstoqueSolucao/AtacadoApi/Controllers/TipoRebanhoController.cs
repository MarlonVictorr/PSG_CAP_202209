using Atacado.Poco.Estoque;
using Atacado.Poco.Pecuaria;
using Atacado.Servico.Pecuaria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/pecuaria[controller]")]
    [ApiController]
    public class TipoRebanhoController : ControllerBase
    {
        private TipoRebanhoServico servico;

        /// <summary>
        /// 
        /// </summary>
        public TipoRebanhoController() : base()
        {
            this.servico = new TipoRebanhoServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TipoRebanhoPoco>> GetAll()
        {
            try
            {
                List<TipoRebanhoPoco> list = this.servico.Listar();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o Tipo Rebanho pelo código
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<TipoRebanhoPoco> GetPorId(int codigo)
        {
            try
            {
                TipoRebanhoPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
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
        public ActionResult<TipoRebanhoPoco> Criar([FromBody] TipoRebanhoPoco poco)
        {
            try
            {
                TipoRebanhoPoco nova = this.servico.Inserir(poco);
                return Ok(poco);
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
        public ActionResult<TipoRebanhoPoco> Atualizar([FromBody] TipoRebanhoPoco poco)
        {
            try
            {
                TipoRebanhoPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<TipoRebanhoPoco> DeletePorId(int codigo)
        {
            try
            {
                TipoRebanhoPoco delPoco = this.servico.Excluir(codigo);
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
        public ActionResult<TipoRebanhoPoco> DeletePorInstancia([FromBody] TipoRebanhoPoco poco)
        {
            try
            {
                TipoRebanhoPoco delPoco = this.servico.Excluir(poco.CodigoTipo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
