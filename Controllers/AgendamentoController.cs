using ClinicaDocMais.Data;
using ClinicaDocMais.DTOs;
using ClinicaDocMais.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

namespace ClinicaDocMais.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendamentoController : ControllerBase
    {
        private ClinicaContext _context;
        public AgendamentoController(ClinicaContext context)
        {
            _context = context;
        }

        [HttpPost("agendarconsulta")]

        public async Task<IActionResult> AgendarConsulta([FromBody] AgendamentoDTO dadosAgendamento)
        {
            try
            {
                AgendamentoModel agendamento = new AgendamentoModel();

                agendamento.id = dadosAgendamento.id;
                agendamento.dataHoraAgendamento = dadosAgendamento.dataHoraAgendada;
                agendamento.crmMedico = dadosAgendamento.crmMedico;
                agendamento.cpfPaciente = dadosAgendamento.cpfPaciente;

               await _context.Agendamentos.AddAsync(agendamento);
                _context.SaveChanges();

                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest("Erro Inesperado: " + ex.Message);
            }
        }
        [HttpGet("buscarAgendamento")]
        public async Task<IActionResult> BuscarAgendamentos()
        {
            try
            {
                var listaAgendamento = await _context.Agendamentos.Include(p => p.paciente).Include(m => m.medico).ToListAsync();

                return Ok(listaAgendamento);
            }

            catch (Exception ex)
            {
                return BadRequest("Erro inesperado: " + ex.Message);
            }
        }
    }

}
