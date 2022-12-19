using LibTec.Domain.EF;
using LibTec.Poco;
using LibTec.Service.Livraria;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibTecApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/libtec/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private ItemServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ItemController(LibTecContext context) : base()
        {
            this.servico = new ItemServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ItemPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ItemPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o item de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<ItemPoco> GetPorId(int codigo)
        {
            try
            {
                ItemPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o item de acordo com o código informado do tipo
        /// </summary>
        /// <param name="autcodigo"></param>
        /// <returns></returns>
        [HttpGet("PorTipo/{tipcodigo:int}")]
        public ActionResult<List<ItemPoco>> GetPorTipoItem(int autcodigo)
        {
            try
            {
                List<ItemPoco> listaPoco = this.servico.Consultar(ite => ite.CodigoTipoItem == autcodigo).ToList();
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
        public ActionResult<ItemPoco> Post([FromBody] ItemPoco poco)
        {
            try
            {
                ItemPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<ItemPoco> Put([FromBody] ItemPoco poco)
        {
            try
            {
                ItemPoco atPoco = this.servico.Alterar(poco);
                return Ok(atPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Apaga um registro por código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<ItemPoco> DeletePorId(int codigo)
        {
            try
            {
                ItemPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
