using ClinicaDocMais.Data;
using ClinicaDocMais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaDocMais.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PacienteController : ControllerBase
    {
        public static List<PacienteModel> listaPaciente = new List<PacienteModel>();

        private readonly ClinicaContext _context;

        public PacienteController(ClinicaContext context)
        {
            _context = context;
        }


        //cadastrarPaciente
        [HttpPost("cadastrarpaciente")]
        public async Task<IActionResult> CadastrarPaciente([FromBody] PacienteModel pacienteCadastrado)
        {
            try
            {
                _context.Add(pacienteCadastrado);
                await _context.SaveChangesAsync();
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado: " + ex.Message);
            }
        }

        [HttpGet("listarpacientes")]
        public async Task<IActionResult> listarPaciente()
        {
            try
            {
                var listaPaciente = await _context.Pacientes.ToListAsync();
                return Ok(listaPaciente);

            }
            catch (Exception ex)
            {
                return BadRequest("Erro. " + ex.Message);
            }
        }

        [HttpGet("buscaPaciente/{nome}")]
        public async Task<IActionResult> buscarPaciente(string nome)
        {
            try
            {
                var listaBuscaPaciente = await _context.Pacientes.Where(p => p.nome.Contains(nome)).ToListAsync();
                return Ok(listaBuscaPaciente);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro. " + ex.Message); 
            }
        }

        [HttpPut("editarPaciente/{cpf}")]
        public async Task<IActionResult> editarPaciente([FromBody] PacienteModel pacienteEditado, string cpf)
        {
            try
            {
                _context.Pacientes.Update(pacienteEditado);
                await _context.SaveChangesAsync();
                return Ok(pacienteEditado);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        
        }

        [HttpDelete("deletarPaciente/{cpf}")]
        public async Task<IActionResult> deletarPaciente(string cpf)
        {
            try
            {
                PacienteModel? pacienteEncontrado = await _context.Pacientes.FindAsync(cpf);
                if (pacienteEncontrado == null)
                {
                    _context.Pacientes.Remove(pacienteEncontrado);
                    await _context.SaveChangesAsync();
                    return NoContent();

                }
                else
                {
                    throw new Exception($"Paciente de CPF{cpf} não existe");
                }
            }
            catch (Exception ex) 
            {
                return BadRequest("Erro. " + ex.Message);
            }
        }
    }
}