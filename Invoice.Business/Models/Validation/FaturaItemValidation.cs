using FluentValidation;

namespace Invoice.Business.Models.Validation
{
    public class FaturaItemValidation : AbstractValidator<FaturaItem>
    {
        public FaturaItemValidation()
        {
            RuleFor(fi => fi.Valor)
                .GreaterThan(-1).WithMessage("O campo {PropertyName} não pode ser negativo");

            RuleFor(fi => fi.Descricao)
                .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(fi => ItemValidation.ValidarItem(fi.Ordem))
                .Equal(false).WithMessage("O campo {PropertyName} deve ser um número múltiplo de 10")
                .When(fi => fi.Fatura != null && fi.Fatura.FaturaItem != null);

            RuleFor(fi => ItemValidation.ValidarSeTemOrdem(fi.Ordem, fi.Fatura.FaturaItem))
                .Equal(true).WithMessage("Já existe um item com a ordem {PropertyValue} na fatura")
                .When(fi => fi.Fatura != null && fi.Fatura.FaturaItem != null);

            RuleFor(fi => ItemValidation.ValidarSequenciaOrdem(fi.Fatura.FaturaItem))
                .Equal(true).WithMessage("A sequência de ordens dos itens da fatura deve ser múltiplos de 10 e sequenciais")
                .When(fi => fi.Fatura != null && fi.Fatura.FaturaItem != null);

            RuleFor(fi => fi.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 20).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

            When(fi => fi.Valor >= 1000, () =>{
                RuleFor(fi => fi.ValorAprovado)
                    .Equal(true).WithMessage("O campo {PropertyName} deve ser verdadeiro quando o valor for maior ou igual a 1000");
            });

        }
    }
}
