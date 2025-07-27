using System.ComponentModel.DataAnnotations;

namespace Invoice.Api.ViewModels
{
    public class FaturaViewModel
    {
        [Key]
        public int FaturaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Cliente { get; set; }

        public DateTime Data { get; set; } = DateTime.Now;

        public IEnumerable<FaturaItemViewModel>? FaturaItem { get; set; } = new List<FaturaItemViewModel>();
    }
}
