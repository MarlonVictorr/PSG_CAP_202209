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
    public class GerenteController : ControllerBase
    {
        private GerenteServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public GerenteController(TecnoShopContext context) : base()
        {
            this.servico = new GerenteServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"> Quantos registros deseja retornar </param>
        /// <param name="skip"> Quantos registros deseja pular </param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<GerentePoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<GerentePoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o gerente de acordo com o código informado
        /// </summary>
        /// <param name="codigo"> Informe um Código </param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<GerentePoco> GetById(int codigo)
        {
            try
            {
                GerentePoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o gerente de acordo com o código informado de loja
        /// </summary>
        /// <param name="lojcodigo"> Informe um Código de Loja </param>
        /// <returns></returns>
        [HttpGet("PorLoja/{lojcodigo:int}")]
        public ActionResult<List<GerentePoco>> GetByLoja(int lojcodigo)
        {
            try
            {
                List<GerentePoco> listaPoco = this.servico.Consultar(ger => ger.CodigoLoja == lojcodigo).ToList();
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
        public ActionResult<GerentePoco> Post([FromBody] GerentePoco poco)
        {
            try
            {
                GerentePoco nova = this.servico.Inserir(poco);
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
        public ActionResult<GerentePoco> Put([FromBody] GerentePoco poco)
        {
            try
            {
                GerentePoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<GerentePoco> DeleteById(int codigo)
        {
            try
            {
                GerentePoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
