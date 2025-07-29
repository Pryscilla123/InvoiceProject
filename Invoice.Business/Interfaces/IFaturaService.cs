using Invoice.Business.Models;

namespace Invoice.Business.Interfaces
{
    public interface IFaturaService
    {
        public Task<bool> AdicionarFatura(Fatura fatura);
        public Task<bool> AtualizarFatura(Fatura fatura);
        public Task<bool> RemoverFatura(int id);
    }
}
