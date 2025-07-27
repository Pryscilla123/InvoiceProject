using System.ComponentModel.DataAnnotations;

namespace Invoice.Api.ViewModels
{
    public class FaturaItemViewModel
    {
        [Key]
        public int FaturaItemId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int FaturaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Ordem { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Descricao { get; set; }

        public bool ValorAprovado { get; set; }

        
    }
}
