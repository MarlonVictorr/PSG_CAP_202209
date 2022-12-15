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
    [Route("api/[controller]")]
    [ApiController]
    public class PassageiroController : ControllerBase
    {
        private PassageiroService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public PassageiroController(RevisaoContext context) : base()
        {
            this.servico = new PassageiroService(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<PassageiroPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<PassageiroPoco> listapoco = this.servico.Listar(take, skip);
                return Ok(listapoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o passageiro de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<PassageiroPoco> GetPorId(int codigo)
        {
            try
            {
                PassageiroPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o passageiro de acordo com o nome informado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("PorNome/{nome}")]
        public ActionResult<List<PassageiroPoco>> GetPorNome(string nome)
        {
            try
            {
                List<PassageiroPoco> listaPoco = this.servico.Consultar(pas => pas.Nome == nome).ToList();
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
        public ActionResult<PassageiroPoco> Post([FromBody] PassageiroPoco poco)
        {
            try
            {
                PassageiroPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<PassageiroPoco> Put([FromBody] PassageiroPoco poco)
        {
            try
            {
                PassageiroPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<PassageiroPoco> DeletePorId(int codigo)
        {
            try
            {
                PassageiroPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
