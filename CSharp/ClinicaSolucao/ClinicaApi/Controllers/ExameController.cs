using Clinica.Dominio.EF;
using Clinica.Poco;
using Clinica.Servico.Odonto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicaApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/clinica/[controller]")]
    [ApiController]
    public class ExameController : ControllerBase
    {
        private ProcedimentosServico servico;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public ExameController(ClinicaContext context) : base()
        {
            this.servico = new ProcedimentosServico(context);
        }

        /// <summary>
        /// Listar todos os registros da tabela.
        /// </summary>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ServicoPoco>> GetAll(int? take = null, int? skip = null)
        {
            try
            {
                List<ServicoPoco> list = this.servico.Listar(take, skip);
                return Ok(list);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
