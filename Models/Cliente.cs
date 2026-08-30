using System.ComponentModel.DataAnnotations;

namespace GestorOS.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é Obrigatório")]
        [StringLength(120)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um Email Valido")]
        [StringLength(150)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Informe um Telefone válido.")]
        [StringLength(120)]
        [Display(Name = "Telefone")]
        public string? Telefone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public ICollection<OrdemServico> Ordens { get; set; } = new List<OrdemServico>();
    }
}
