using Invoice.Business.Models;

namespace Invoice.Business.Interfaces
{
    public interface IFaturaRepository
    {
        Task<IEnumerable<Fatura>> ObterFaturas();
        Task<Fatura> ObterFaturaPorId(int id);
        Task AdicionarFatura(Fatura fatura);
        Task AtualizarFatura(Fatura fatura);
        Task RemoverFatura(int id);
    }
}
