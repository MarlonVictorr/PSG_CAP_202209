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
    public class TipoItemController : ControllerBase
    {
        private TipoItemServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public TipoItemController(LibTecContext context) : base()
        {
            this.servico = new TipoItemServico(context);
        }

        /// <summary>
        /// Lista todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<TipoItemPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoItemPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o tipo de item de acordo com o código informado
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<TipoItemPoco> GetPorId(int codigo)
        {
            try
            {
                TipoItemPoco poco = this.servico.PesquisarPelaChave(codigo);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o tipo de item de acordo com o nome 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("PorNome/{nome}")]
        public ActionResult<List<TipoItemPoco>> GetPorNome(string nome)
        {
            try
            {
                List<TipoItemPoco> listaPoco = this.servico.Consultar(tip => tip.Descricao == nome).ToList();
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
        public ActionResult<TipoItemPoco> Post([FromBody] TipoItemPoco poco)
        {
            try
            {
                TipoItemPoco nova = this.servico.Inserir(poco);
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
        public ActionResult<TipoItemPoco> Put([FromBody] TipoItemPoco poco)
        {
            try
            {
                TipoItemPoco atPoco = this.servico.Alterar(poco);
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
        public ActionResult<TipoItemPoco> DeletePorId(int codigo)
        {
            try
            {
                TipoItemPoco delPoco = this.servico.Excluir(codigo);
                return Ok(delPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
