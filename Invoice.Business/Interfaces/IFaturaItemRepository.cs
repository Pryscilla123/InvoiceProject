using Invoice.Business.Models;

namespace Invoice.Business.Interfaces
{
    public interface IFaturaItemRepository
    {
        Task<IEnumerable<FaturaItem>> ObterFaturaItensPorFaturaId(int faturaId);
        Task AdicionarFaturaItem(FaturaItem faturaItem);
        Task AtualizarFaturaItem(FaturaItem faturaItem);
        Task RemoverFaturaItem(int id);
    }
}
