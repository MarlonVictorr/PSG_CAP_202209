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
        public List<ProdutoPoco> GetAll()
        {
            return this.servico.Browse();
        }

        /// <summary>
        /// Lista os Produtos pelo código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ProdutoPoco GetPorId(int codigo)
        {
            return this.servico.Read(codigo);
        }

        /// <summary>
        /// Lista os produtos pelo código de categoria
        /// </summary>
        /// <param name="catid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}")]
        public List<ProdutoPoco> GetPorCategoriaId(int catid)
        {
            return this.servico.Browse(prd => prd.CodigoCategoria == catid).ToList();
        }

        /// <summary>
        /// Lista os produtos pelo código de subcategoria
        /// </summary>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpGet("PorSubcategoria/{subid:int}")]
        public List<ProdutoPoco> GetPorSubcategoriaId(int subid)
        {
            return this.servico.Browse(prd => prd.CodigoSubcategoria == subid).ToList();
        }

        /// <summary>
        /// Lista os produtos pelo código de categoria e subcategoria
        /// </summary>
        /// <param name="catid"></param>
        /// <param name="subid"></param>
        /// <returns></returns>
        [HttpGet("PorCategoria/{catid:int}/PorSubcategoria/{subid:int}")]
        public List<ProdutoPoco> GetPorCategoriaPorSubcategoria(int catid, int subid)
        {
            return this.servico.Browse
                (prd => (prd.CodigoCategoria == catid) && (prd.CodigoSubcategoria == subid))
                .ToList();
        }

        /// <summary>
        /// Cria um novo registro na tabela
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPost]
        public ProdutoPoco Criar([FromBody] ProdutoPoco poco)
        {
            return this.servico.Add(poco);
        }

        /// <summary>
        /// Atualiza os dados da tabela 
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpPut]
        public ProdutoPoco Atualizar([FromBody] ProdutoPoco poco)
        {
            return this.servico.Edit(poco);
        }

        /// <summary>
        /// Apaga um registro por codigo informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ProdutoPoco DeletePorId(int codigo)
        {
            return this.servico.Delete(codigo);
        }

        /// <summary>
        /// Apaga um registro de acordo com os dados informados
        /// </summary>
        /// <param name="poco"></param>
        /// <returns></returns>
        [HttpDelete]
        public ProdutoPoco DeletePorInstancia([FromBody] ProdutoPoco poco)
        {
            return this.servico.Delete(poco);
        }
    }
}