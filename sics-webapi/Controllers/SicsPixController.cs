using Gerencianet.NETCore.SDK;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using sics_webapi.Models;

namespace sics_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SicsPixController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> EnviaPix([FromBody] PixPayment pix)
        {
            if (!ModelState.IsValid || pix == null) return BadRequest(ModelState);

            dynamic endpoints =  new Endpoints(JObject.Parse (System.IO.File.ReadAllText ("credentials.json")));

            var param = new
            {
                idEnvio = pix.Id
            };    
                
            var body = new
            {
                valor = pix.Valor.ToString(),
                pagador = new {
                    chave = pix.ChaveOrigem,
                },
                favorecido = new {
                    chave = pix.ChaveDestino
                }
            };

            try
            {
                var response = await endpoints.PixSend(param, body);
                return response;
            }
            catch (GnException ex)
            {
                return StatusCode(500, $"{ex.ErrorType} - {ex.Message}");
            }
        }
    }
}
