using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Revisao.Dominio.EF;
using Revisao.Poco;
using Revisao.Service.Estudar;

namespace RevisaoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/revisao/[controller]")]
    [ApiController]
    public class BilheteController : ControllerBase
    {
        private BilheteService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public BilheteController(RevisaoContext context) : base()
        {
            this.servico = new BilheteService(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<BilhetePoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<BilhetePoco> listapoco = this.servico.Listar(take, skip);
                return Ok(listapoco);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o bilhete de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<BilhetePoco> GetPorId(int codigo)
        {
            try
            {
                BilhetePoco poco = this.servico.PesquisarPelaChave(codigo);
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
        public ActionResult<BilhetePoco> Post([FromBody] BilhetePoco poco)
        {
            try
            {
                BilhetePoco nova = this.servico.Inserir(poco);
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
        public ActionResult<BilhetePoco> Put([FromBody] BilhetePoco poco)
        {
            try
            {
                BilhetePoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<BilhetePoco> DeletePorId(int codigo)
        {
            try
            {
                BilhetePoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}

