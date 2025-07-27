using Invoice.Business.Interfaces;
using Invoice.Business.Models;
using Invoice.Business.Models.Validation;

namespace Invoice.Business.Services
{
    public class FaturaService : BaseService, IFaturaService
    {
        private readonly IFaturaRepository _faturaRepository;
        private readonly IFaturaItemRepository _faturaItemRepository;
        public FaturaService(INotificador notificador,
                            IFaturaRepository faturaRepository,
                            IFaturaItemRepository faturaItemRepository) : base(notificador)
        {
            _faturaRepository = faturaRepository;
            _faturaItemRepository = faturaItemRepository;
        }
        public async Task<bool> AdicionarFatura(Fatura fatura)
        {
            if (!ExecutarValidacao(new FaturaValidation(), fatura))
            {
                return false;
            }

            if (fatura.FaturaItem == null || !fatura.FaturaItem.Any())
            {
                Notificar("A fatura deve conter pelo menos um item.");
                return false;
            }

            foreach (var item in fatura.FaturaItem)
            {
                if (!ExecutarValidacao(new FaturaItemValidation(), item))
                {
                    return false;
                }
            }

            await _faturaRepository.AdicionarFatura(fatura);

            foreach (var item in fatura.FaturaItem)
            {
                item.FaturaId = fatura.FaturaId; // Associa o item à fatura
                await _faturaItemRepository.AdicionarFaturaItem(item);
            }

            return true;
        }

        public bool AtualizarFatura(Fatura fatura)
        {
            if (!ExecutarValidacao(new FaturaValidation(), fatura))
            {
                return false;
            }

            _faturaRepository.AtualizarFatura(fatura);
            return true;
        }

        public void RemoverFatura(Fatura fatura)
        {
            foreach (var item in fatura.FaturaItem)
            {
                _faturaItemRepository.RemoverFaturaItem(item.FaturaItemId);
            }
            _faturaRepository.RemoverFatura(fatura.FaturaId);
        }
    }
}
