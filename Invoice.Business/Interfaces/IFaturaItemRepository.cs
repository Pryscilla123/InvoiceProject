using Invoice.Business.Models;

namespace Invoice.Business.Interfaces
{
    public interface IFaturaItemRepository
    {
        Task<IEnumerable<FaturaItem>> ObterFaturaItensPorId(int faturaItemId);
        Task AtualizarFaturaItem(FaturaItem faturaItem);
        Task RemoverFaturaItem(int id);
    }
}
