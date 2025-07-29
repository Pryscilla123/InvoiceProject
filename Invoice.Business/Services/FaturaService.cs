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
            var validator = new FaturaValidation();

            foreach (var item in fatura.FaturaItem)
            {
                item.Fatura = fatura;
            }

            var resultadoValidacao = validator.Validate(fatura);

            if (!resultadoValidacao.IsValid)
            {
                Notificar(resultadoValidacao);
                return false;
            }

            await _faturaRepository.AdicionarFatura(fatura);
            return true;
        }

        public async Task<bool> AtualizarFatura(Fatura fatura)
        {
            if (!ExecutarValidacao(new FaturaValidation(), fatura))
            {
                return false;
            }

            await _faturaRepository.AtualizarFatura(fatura);

            return true;
        }

        public async Task<bool> RemoverFatura(int id)
        {
            Fatura fatura = await _faturaRepository.ObterFaturaPorId(id);

            if (fatura == null) return false;

            await _faturaRepository.RemoverFatura(fatura);

            return true;
        }
    }
}
