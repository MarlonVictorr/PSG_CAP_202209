using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TecnoShop.Domain.EF;
using TecnoShop.Poco;
using TecnoShop.Service.Shop;

namespace TecnoShopApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/tecnoshop/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private FuncionarioServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public FuncionarioController(TecnoShopContext context) : base()
        {
            this.servico = new FuncionarioServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"> Quantos registros deseja retornar </param>
        /// <param name="skip"> Quantos registros deseja pular </param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<FuncionarioPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<FuncionarioPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o funcionario de acordo com o código informado
        /// </summary>
        /// <param name="codigo"> Informe um Código </param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<FuncionarioPoco> GetById(int codigo)
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
        /// <param name="codigo"> Informe um código que deseja apagar </param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<FuncionarioPoco> DeleteById(int codigo)
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
