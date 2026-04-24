using System.ComponentModel.DataAnnotations;

namespace ClinicaDocMais.Models
{
    public class PacienteModel
    {
        [Key]public string? cpf { get; set; }
        public string? nome { get; set; }
        public string? dataNascimento { get; set; }
        public string? prioridade { get; set; }
        public string? telefone { get; set; }
        public string? idade { get; set; }
       



        public PacienteModel(string? cpf, string? nome, string? dataNascimento, string? prioridade)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.dataNascimento = dataNascimento;
            this.prioridade = prioridade;
        }
    }
   
}

