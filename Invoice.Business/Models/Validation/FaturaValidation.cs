using FluentValidation;

namespace Invoice.Business.Models.Validation
{
    public class FaturaValidation : AbstractValidator<Fatura>
    {
        public FaturaValidation()
        {
            RuleFor(f => f.Cliente)
            .NotEmpty().WithMessage("O campo Cliente precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo Cliente precisa ter entre 2 e 100 caracteres");

            RuleFor(f => f.FaturaItem)
                .NotNull().WithMessage("A fatura deve conter ao menos um item.")
                .Must(f => f.Any()).WithMessage("A fatura deve conter ao menos um item.");

            // Valida se existem ordens duplicadas
            RuleFor(f => f.FaturaItem)
                .Must(itens => itens.Select(i => i.Ordem).Distinct().Count() == itens.Count())
                .WithMessage("Existem itens com ordens duplicadas na fatura.");

            // Valida se a sequência está correta
            RuleFor(f => f.FaturaItem)
                .Must(ItemValidation.ValidarSequenciaOrdem)
                .WithMessage("A sequência de ordens dos itens da fatura deve ser múltiplos de 10 e sequenciais: 10, 20, 30...");

            RuleForEach(f => f.FaturaItem)
                .SetValidator(new FaturaItemValidation());
        }
    }
}
