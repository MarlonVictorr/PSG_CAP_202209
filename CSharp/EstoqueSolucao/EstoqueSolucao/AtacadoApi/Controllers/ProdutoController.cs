using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Atacado.Poco.Estoque;
using Atacado.Servico.Estoque;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/estoque/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private ProdutoServico servico;

        /// <summary>
        /// 
        /// </summary>
        public ProdutoController() : base()
        {
            this.servico = new ProdutoServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ProdutoPoco>> GetAll()
        {
            try
            {
                List<ProdutoPoco> list = this.servico.Listar();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista os Produtos pelo código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<ProdutoPoco> GetPorId(int codigo)
        {
            try
            {
                ProdutoPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista os produtos pelo código de categoria
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}")]
        public ActionResult<List<ProdutoPoco>> GetPorCategoriaId(int catid)
        {
            try
            {
                List<ProdutoPoco> ListPoco = this.servico.Consultar(pro => pro.CodigoCategoria == catid).ToList();
                return Ok(ListPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista os produtos pelo código de subcategoria
        /// </summary>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpGet("PorSubcategoria/{subid:int}")]
        public ActionResult<List<ProdutoPoco>> GetPorSubcategoriaId(int subid)
        {
            try
            {
                List<ProdutoPoco> ListPoco = this.servico.Consultar(pro => pro.CodigoSubcategoria == subid).ToList();
                return Ok(ListPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista os produtos pelo código de categoria e subcategoria
        /// </summary>
        /// <param name="catid"></param>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}/PorSubcategoria/{subid:int}")]
        public ActionResult<List<ProdutoPoco>> GetPorCategoriaPorSubcategoria(int catid, int subid)
        {
            try
            {
                List<ProdutoPoco> ListPoco = this.servico.Consultar(pro => (pro.CodigoCategoria == catid) && (pro.CodigoSubcategoria == subid)).ToList();
                return Ok(ListPoco);
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
        public ActionResult<ProdutoPoco> Criar([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<ProdutoPoco> Atualizar([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<ProdutoPoco> DeletePorId(int codigo)
        {
            try
            {
                ProdutoPoco delPoco = this.servico.Excluir(codigo);
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
        public ActionResult<ProdutoPoco> DeletePorInstancia([FromBody] ProdutoPoco poco)
        {
            try
            {
                ProdutoPoco delPoco = this.servico.Excluir(poco.Codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}