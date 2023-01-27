using Avaliar.Domain.EF;
using Avaliar.Envelope.Modelo;
using Avaliar.Envelope.Motor;
using Avaliar.Poco;
using Avaliar.Service.Consumir;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AvaliarApi.Controllers
{
    [Route("api/avaliacao/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private TipoUsuarioServico servico;


        public TipoUsuarioController(AvaliarContext context) : base()
        {
            this.servico = new TipoUsuarioServico(context);
        }

        /// <summary>
        /// Lista todos os registros de TipoUsuario por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<TipoUsuarioPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<TipoUsuarioPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de TipoUsuario
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<TipoUsuarioPoco> GetById(int chave)
        {
            try
            {
                TipoUsuarioPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado na tabela TipoUsuario.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<TipoUsuarioPoco> Post([FromBody] TipoUsuarioPoco poco)
        {
            try
            {
                TipoUsuarioPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente na tabela TipoUsuario.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<TipoUsuarioPoco> Put([FromBody] TipoUsuarioPoco poco)
        {
            try
            {
                TipoUsuarioPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro existente em TipoUsuario, utilizando um id.
        /// </summary>
        /// <param name="chave"> Chave para localização. </param>
        /// <returns> Dado excluido por Id. </returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<TipoUsuarioPoco> DeleteById(int chave)
        {
            try
            {
                TipoUsuarioPoco poco = this.servico.Excluir(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }








        /// <summary>
        /// Retorna todos os registros de modo envelopado para o arquivo JSON
        /// </summary>
        /// <param name="limite"></param>
        /// <param name="salto"></param>
        /// <returns></returns>
        [HttpGet("envelope/")]
        public ActionResult<EnvelopeGenerico<TipoUsuarioEnvelope>> GetAllEnvelope(int? limite = null, int? salto = null)
        {
            try
            {
                List<TipoUsuarioPoco> listaPoco = this.servico.Listar(limite, salto);
                int totalReg = listaPoco.Count;
                return Envelopamento(totalReg, limite, salto, listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private ActionResult<EnvelopeGenerico<TipoUsuarioEnvelope>> Envelopamento(int? totalReg, int? limite, int? salto, List<TipoUsuarioPoco> listaPoco)
        {
            string linkPost = "POST /tipousuario";

            ListEnvelope<TipoUsuarioEnvelope> list;

            if (limite > totalReg)
            {
                string erro = "Limite não pode ser maior que a quantidade de Registros.";
                list = new ListEnvelope<TipoUsuarioEnvelope>(null, 400, erro, linkPost, "1.0");
                return BadRequest(list.Etapa);
            }
            else
            {
                List<TipoUsuarioEnvelope> listaEnvelope = listaPoco.Select(tip => new TipoUsuarioEnvelope(tip)).ToList();
                listaEnvelope.ForEach(item => item.SetLinks());

                if (listaPoco.Count() == 0)
                {
                    list = new ListEnvelope<TipoUsuarioEnvelope>(listaEnvelope, 404, "Não existem mais registros a serem mostrados!.", linkPost, "1.0");
                    return Ok(list.Etapa);
                }

                if (salto == null)
                {
                    list = new ListEnvelope<TipoUsuarioEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
                    list.Etapa.Paginacao.TotalReg = totalReg;
                }
                else
                {
                    var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}");
                    string urlServidor = location.AbsoluteUri;
                    list = new ListEnvelope<TipoUsuarioEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0", urlServidor, salto, limite, totalReg);
                }
                return Ok(list.Etapa);
            }
        }

        /// <summary>
        /// Retorna todos os registros de modo envelopado para o arquivo JSON filtrados por Codigo de Usuario 
        /// </summary>
        /// <param name="chave"></param>
        /// <returns></returns>
        [HttpGet("envelope/{chave:int}")]
        public ActionResult<TipoUsuarioEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                TipoUsuarioPoco poco = this.servico.PesquisarPorChave(chave);
                TipoUsuarioEnvelope envelope = new TipoUsuarioEnvelope(poco);
                envelope.SetLinks();
                return Ok(envelope);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
