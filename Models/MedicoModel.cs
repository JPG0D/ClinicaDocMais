using System.ComponentModel.DataAnnotations;

namespace ClinicaDocMais.Models
{
    public class MedicoModel
    {
        public string? nome { get; set; }
        [Key]public string? crm { get; set; }
        public string? telefone { get; set; }
        public string? email { get; set; }
        public string? especialidade { get; set; }

        public MedicoModel(string? crm, string? nome, string? telefone, string? email)
        {
            this.crm = crm;
            this.nome = nome;
            this.telefone = telefone;
            this.email = email;
        }
    }
}
