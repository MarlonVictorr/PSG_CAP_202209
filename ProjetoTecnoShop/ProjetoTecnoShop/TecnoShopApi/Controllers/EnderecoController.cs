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
    public class EnderecoController : ControllerBase
    {
        private EnderecoServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EnderecoController(TecnoShopContext context) : base()
        {
            this.servico = new EnderecoServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"> Quantos registros deseja retornar </param>
        /// <param name="skip"> Quantos registros deseja pular </param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<EnderecoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<EnderecoPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o endereço de acordo com o código informado
        /// </summary>
        /// <param name="codigo"> Informe um Código </param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<EnderecoPoco> GetById(int codigo)
        {
            try
            {
                EnderecoPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o endereço de acordo com o código informado de cidade
        /// </summary>
        /// <param name="cidcodigo"> Informe um Código de Cidade </param>
        /// <returns></returns>
        [HttpGet("PorCidade/{cidcodigo:int}")]
        public ActionResult<List<EnderecoPoco>> GetByCidade(int cidcodigo)
        {
            try
            {
                List<EnderecoPoco> listaPoco = this.servico.Consultar(end => end.CodigoCidade == cidcodigo).ToList();
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
        public ActionResult<EnderecoPoco> Post([FromBody] EnderecoPoco poco)
        {
            try
            {
                EnderecoPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<EnderecoPoco> Put([FromBody] EnderecoPoco poco)
        {
            try
            {
                EnderecoPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<EnderecoPoco> DeleteById(int codigo)
        {
            try
            {
                EnderecoPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
