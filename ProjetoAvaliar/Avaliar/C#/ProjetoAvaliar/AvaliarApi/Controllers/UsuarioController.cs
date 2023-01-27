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
    public class UsuarioController : ControllerBase
    {
        private UsuarioServico servico;

        public UsuarioController(AvaliarContext context) : base()
        {
            this.servico = new UsuarioServico(context);
        }

        /// <summary>
        /// Lista todos os registros de Usuario por Paginação.
        /// </summary>
        /// <param name="take"> Onde inicia os resultados da pesquisa. </param>
        /// <param name="skip"> Quantos registros serão retornados. </param>
        /// <returns> Todos os registros. </returns>
        [HttpGet]
        public ActionResult<List<UsuarioPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<UsuarioPoco> listaPoco = this.servico.Listar(take, skip);
                return Ok(listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        ///  Lista os registro usando a chave de Usuario.
        /// </summary>
        /// <param name="chave"> Chave de pesquisa. </param>
        /// <returns> Registro localizado. </returns>
        [HttpGet("{chave:int}")]
        public ActionResult<UsuarioPoco> GetById(int chave)
        {
            try
            {
                UsuarioPoco poco = this.servico.PesquisarPorChave(chave);
                return Ok(poco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Inclui um novo dado na tabela Usuario.
        /// </summary>
        /// <param name="poco"> Dados que será incluido. </param>
        /// <returns> Dados incluido. </returns>
        [HttpPost]
        public ActionResult<UsuarioPoco> Post([FromBody] UsuarioPoco poco)
        {
            try
            {
                UsuarioPoco novoPoco = this.servico.Inserir(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Altera um dado existente na tabela Usuario.
        /// </summary>
        /// <param name="poco"> Altera o dado selecionado. </param>
        /// <returns> Altera o dado selecionado. </returns>
        [HttpPut]
        public ActionResult<UsuarioPoco> Put([FromBody] UsuarioPoco poco)
        {
            try
            {
                UsuarioPoco novoPoco = this.servico.Alterar(poco);
                return Ok(novoPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Exclui um registro existente em Usuario, utilizando um id.
        /// </summary>
        /// <param name="chave"> Chave para localização. </param>
        /// <returns> Dado excluido por Id. </returns>
        [HttpDelete("{chave:int}")]
        public ActionResult<UsuarioPoco> DeleteById(int chave)
        {
            try
            {
                UsuarioPoco poco = this.servico.Excluir(chave);
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
        public ActionResult<EnvelopeGenerico<UsuarioEnvelope>> GetAllEnvelope(int? limite = null, int? salto = null)
        {
            try
            {
                List<UsuarioPoco> listaPoco = this.servico.Listar(limite, salto);
                int totalReg = listaPoco.Count;
                return Envelopamento(totalReg, limite, salto, listaPoco);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Retorna todos os registros de modo envelopado para o arquivo JSON filtrados por TipoUsuario
        /// </summary>
        /// <param name="tipcod"></param>
        /// <param name="limite"></param>
        /// <param name="salto"></param>
        /// <returns></returns>
        [HttpGet("envelope/PorTipoUsuario/{tipcod:int}")]
        public ActionResult<EnvelopeGenerico<UsuarioEnvelope>> GetPorTipoUsuarioEnvelope(int tipcod, int? limite = null, int? salto = null)
        {
            try
            {
                List<UsuarioPoco> listaPoco;
                var predicado = PredicateBuilder.New<Usuario>(true);
                int totalReg = 0;
                if (limite == null)
                {
                    if (salto != null)
                    {
                        return BadRequest("Informe os parâmetros Take e Skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.CodigoTipoUsuario == tipcod);
                        listaPoco = this.servico.Consultar(predicado);
                        totalReg = listaPoco.Count;
                        return Envelopamento(totalReg, limite, salto, listaPoco);
                    }
                }
                else
                {
                    if (salto == null)
                    {
                        return BadRequest("Informe os parâmetros Take e Skip.");
                    }
                    else
                    {
                        predicado = predicado.And(s => s.CodigoTipoUsuario == tipcod);
                        totalReg = this.servico.ContarTotalRegistros(predicado);
                        listaPoco = this.servico.Vasculhar(limite, salto, predicado);
                        return Envelopamento(totalReg, limite, salto, listaPoco);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        private ActionResult<EnvelopeGenerico<UsuarioEnvelope>> Envelopamento(int? totalReg, int? limite, int? salto, List<UsuarioPoco> listaPoco)
        {
            string linkPost = "POST /usuario";

            ListEnvelope<UsuarioEnvelope> list;

            if (limite > totalReg)
            {
                string erro = "Limite não pode ser maior que a quantidade de Registros.";
                list = new ListEnvelope<UsuarioEnvelope>(null, 400, erro, linkPost, "1.0");
                return BadRequest(list.Etapa);
            }
            else
            {
                List<UsuarioEnvelope> listaEnvelope = listaPoco.Select(usu => new UsuarioEnvelope(usu)).ToList();
                listaEnvelope.ForEach(item => item.SetLinks());

                if (listaPoco.Count() == 0)
                {
                    list = new ListEnvelope<UsuarioEnvelope>(listaEnvelope, 404, "Não existem mais registros a serem mostrados!.", linkPost, "1.0");
                    return Ok(list.Etapa);
                }

                if (salto == null)
                {
                    list = new ListEnvelope<UsuarioEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0");
                    list.Etapa.Paginacao.TotalReg = totalReg;
                }
                else
                {
                    var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}");
                    string urlServidor = location.AbsoluteUri;
                    list = new ListEnvelope<UsuarioEnvelope>(listaEnvelope, 200, "OK", linkPost, "1.0", urlServidor, salto, limite, totalReg);
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
        public ActionResult<UsuarioEnvelope> GetByIdEnvelope(int chave)
        {
            try
            {
                UsuarioPoco poco = this.servico.PesquisarPorChave(chave);
                UsuarioEnvelope envelope = new UsuarioEnvelope(poco);
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
