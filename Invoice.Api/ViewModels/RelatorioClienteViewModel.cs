using System.ComponentModel.DataAnnotations;

namespace Invoice.Api.ViewModels
{
    public class RelatorioClienteViewModel
    {
        [Key]
        public string Cliente { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int QuantidadeFaturas { get; set; }
    }
}
