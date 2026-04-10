using ClinicaDocMais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace clinicaDocMais.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        public static List<MedicoModel> listaMedicos = new List<MedicoModel>();

        [HttpPost("cadastroMedico")]
        public string cadastroMedico([FromBody] MedicoModel medico)
        {
            listaMedicos.Add(medico);
            return $"Dr. {medico.nome} cadastrado com sucesso";
        }
        [HttpGet("listaMedicos")]
        public List<MedicoModel> listarMedicos()
        {
            return listaMedicos;
        }
        [HttpDelete("deletarMedico/{crm}")]
        public string deletarPaciente(string crm)
        {
            foreach (var medico in listaMedicos)
            {
                if (medico.crm == crm)
                {
                    listaMedicos.Remove(medico);
                    return $"Medico com crm: {crm} deletado com sucesso";
                }
            }
            return "Medico não encontrado";
        }
    }
}
