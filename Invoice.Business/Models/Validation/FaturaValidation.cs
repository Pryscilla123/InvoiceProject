using FluentValidation;

namespace Invoice.Business.Models.Validation
{
    public class FaturaValidation : AbstractValidator<Fatura>
    {
        public FaturaValidation()
        {
            RuleFor(f => f.Cliente)
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
