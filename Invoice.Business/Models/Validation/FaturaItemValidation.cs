using FluentValidation;

namespace Invoice.Business.Models.Validation
{
    public class FaturaItemValidation : AbstractValidator<FaturaItem>
    {
        public FaturaItemValidation()
        {
            RuleFor(fi => fi.Valor)
            .GreaterThan(0).WithMessage("O campo {PropertyName} deve ser maior que zero.");

            RuleFor(fi => fi.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(fi => fi.Ordem)
                .Must(ordem => ordem % 10 == 0)
                .WithMessage("A ordem deve ser múltiplo de 10");

            When(fi => fi.Valor >= 1000, () =>
            {
                RuleFor(fi => fi.ValorAprovado)
                    .Equal(true).WithMessage("O campo {PropertyName} deve ser verdadeiro quando o valor for maior ou igual a 1000");
            });

        }
    }
}
