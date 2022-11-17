using Atacado.Poco.Estoque;
using Atacado.Poco.Pecuaria;
using Atacado.Servico.Pecuaria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtacadoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoRebanhoController : ControllerBase
    {
        private TipoRebanhoServico servico;

        public TipoRebanhoController() : base()
        {
            this.servico = new TipoRebanhoServico();
        }

        
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
