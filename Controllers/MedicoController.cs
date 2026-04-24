using ClinicaDocMais.Data;
using ClinicaDocMais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace clinicaDocMais.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        public static List<MedicoModel> listaMedicos = new List<MedicoModel>();

        private readonly ClinicaContext _context;

        public MedicoController(ClinicaContext context)
        {
            _context = context;
        }
        

        [HttpPost("cadastroMedico")]
        public async Task<IActionResult> CadastrarPaciente([FromBody] MedicoModel medicoCadastrado)
        {
            try
            {
                _context.Add(medicoCadastrado);
                await _context.SaveChangesAsync();
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado: " + ex.Message);
            }
        }
        [HttpGet("listaMedicos")]
        public List<MedicoModel> listarMedicos()
        {
            return listaMedicos;
        }
        [HttpDelete("deletarMedico/{crm}")]
        public async Task<IActionResult> deletarMedico(string crm)
        {
            try
            {
                MedicoModel? medicoEncontrado = await _context.Medicos.FindAsync(crm);
                if (medicoEncontrado == null)
                {
                    _context.Medicos.Remove(medicoEncontrado);
                    await _context.SaveChangesAsync();
                    return NoContent();

                }
                else
                {
                    throw new Exception($"Paciente de CPF{crm} não existe");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Erro. " + ex.Message);
            }
        }
    }
}
