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
    public class FuncionarioController : ControllerBase
    {
        private FuncionarioService servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public FuncionarioController(RevisaoContext context) : base()
        {
            this.servico = new FuncionarioService(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<FuncionarioPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<FuncionarioPoco> listapoco = this.servico.Listar(take, skip);
                return Ok(listapoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o funcionario de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<FuncionarioPoco> GetPorId(int codigo)
        {
            try
            {
                FuncionarioPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o funcionario de acordo com o nome informado
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("PorNome/{nome}")]
        public ActionResult<List<FuncionarioPoco>> GetPorNome(string nome)
        {
            try
            {
                List<FuncionarioPoco> listaPoco = this.servico.Consultar(fun => fun.Nome == nome).ToList();
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
        public ActionResult<FuncionarioPoco> Post([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<FuncionarioPoco> Put([FromBody] FuncionarioPoco poco)
        {
            try
            {
                FuncionarioPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<FuncionarioPoco> DeletePorId(int codigo)
        {
            try
            {
                FuncionarioPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
