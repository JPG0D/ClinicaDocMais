using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace clinicaDocMais.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        //metodo http que retorne os pacientes atendidos hoje(nome)
        [HttpGet("atendidoshoje")]
        public List<string> pacientesAtendidosHoje()
        {
            //a logiga para retorna os nomes dos pacientes (pelo menos 3 pacientes)

            {

                List<string> pacientes = new List<string>
                {
        "Robson Velozo",
        "Felipe Souza",
        "Carlos Henrq"
    };

                return pacientes;
            }
        }
    }
}
