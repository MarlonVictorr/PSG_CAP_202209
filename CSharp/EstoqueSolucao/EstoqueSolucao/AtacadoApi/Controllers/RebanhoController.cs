using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Atacado.Poco.Pecuaria;
using Atacado.Servico.Pecuaria;
using Atacado.Poco.Estoque;

namespace AtacadoApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/pecuaria/[controller]")]
    [ApiController]
    public class RebanhoController : ControllerBase
    {
        private RebanhoServico servico;

        /// <summary>
        /// 
        /// </summary>
        public RebanhoController()
        {
            this.servico = new RebanhoServico();
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa </param>
        /// <param name="skip"> Quantos registros serão retornados </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<RebanhoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<RebanhoPoco> lista = this.servico.Listar(take, skip);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o Rebanho pelo código
        /// </summary>
        /// <param name="codigo"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{codigo:int}")]
        public ActionResult<RebanhoPoco> GetPorId(int codigo)
        {
            try
            {
                RebanhoPoco lista = this.servico.PesquisarPelaChave(codigo);
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista todos os registros de Rebanho por Municipio.
        /// </summary>
        /// <param name="muncodigo"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorMunicipio/{muncodigo:int}")]
        public ActionResult<List<RebanhoPoco>> GetPorMunicipio(int muncodigo)
        {
            try
            {
                List<RebanhoPoco> lista = this.servico.Consultar(mun => mun.CodigoMunicipio == muncodigo).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Listar todos os registros de Rebanho por Tipo Rebanho.
        /// </summary>
        /// <param name="tipcodigo"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("PorTipoRebanho/{tipcodigo:int}")]
        public ActionResult<List<RebanhoPoco>> GetPorTipoRebanho(int tipcodigo)
        {
            try
            {
                List<RebanhoPoco> lista = this.servico.Consultar(tip => tip.CodigoTipoRebanho == tipcodigo).ToList();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Lista o Rebanho pelo código de TipoRebanho e Municipio
        /// </summary>
        /// <param name="tipcodigo"></param>
        /// <param name="muncodigo"></param>
        /// <returns></returns>
        [HttpGet("PorTipoRebanho/{tipcodigo:int}/PorMunicipio/{muncodigo:int}")]
        public ActionResult<List<RebanhoPoco>> GetPorTipoRebanhoPorMunicipio (int tipcodigo, int muncodigo)
        {
            try
            {
                List<RebanhoPoco> ListPoco = this.servico.Consultar(reb => (reb.CodigoTipoRebanho == tipcodigo) && (reb.CodigoMunicipio == muncodigo)).ToList();
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
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<RebanhoPoco> Criar([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Atualiza os dados da tabela. 
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Dados alterado. </returns>
        [HttpPut]
        public ActionResult<RebanhoPoco> Atualizar([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Apaga um registro por codigo informado
        /// </summary>
        /// <param name="codigo"> Chave para localização. </param>
        /// <returns> Dado excluido por Id. </returns>
        [HttpDelete("{codigo:int}")]
        public ActionResult<RebanhoPoco> DeletePorId(int codigo)
        {
            try
            {
                RebanhoPoco delnovo = this.servico.Excluir(codigo);
                return Ok(delnovo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Apaga um registro de acordo com os dados informados 
        /// </summary>
        /// <param name="poco"> Dado que será deletado. </param>
        /// <returns> Exclui um dado. </returns>
        [HttpDelete]
        public ActionResult<RebanhoPoco> DeletePorInstancia([FromBody] RebanhoPoco poco)
        {
            try
            {
                RebanhoPoco delnovo = this.servico.Excluir(poco.CodigoRebanho);
                return Ok(delnovo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}