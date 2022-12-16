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
    public class LojaController : ControllerBase
    {
        private LojaServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public LojaController(TecnoShopContext context) : base()
        {
            this.servico = new LojaServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"> Quantos registros deseja retornar </param>
        /// <param name="skip"> Quantos registros deseja pular </param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<LojaPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<LojaPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a loja de acordo com o código informado
        /// </summary>
        /// <param name="codigo"> Informe um Código </param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<LojaPoco> GetById(int codigo)
        {
            try
            {
                LojaPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a loja de acordo com o código informado de endereço
        /// </summary>
        /// <param name="endcodigo"> Informe um Código de Endereço </param>
        /// <returns></returns>
        [HttpGet("PorEndereco/{endcodigo:int}")]
        public ActionResult<List<LojaPoco>> GetByEndereco(int endcodigo)
        {
            try
            {
                List<LojaPoco> listaPoco = this.servico.Consultar(loj => loj.CodigoEndereco == endcodigo).ToList();
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista a loja de acordo com o nome
        /// </summary>
        /// <param name="nome"> Digite um Nome </param>
        /// <returns></returns>
        [HttpGet("PorNome/{nome}")]
        public ActionResult<List<LojaPoco>> GetByNome(string nome)
        {
            try
            {
                List<LojaPoco> listaPoco = this.servico.Consultar(loj => loj.Nome == nome).ToList();
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
        public ActionResult<LojaPoco> Post([FromBody] LojaPoco poco)
        {
            try
            {
                LojaPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<LojaPoco> Put([FromBody] LojaPoco poco)
        {
            try
            {
                LojaPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<LojaPoco> DeleteById(int codigo)
        {
            try
            {
                LojaPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
