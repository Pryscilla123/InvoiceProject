using Invoice.Business.Models;

namespace Invoice.Business.Interfaces
{
    public interface IFaturaService
    {
        public Task<bool> AdicionarFatura(Fatura fatura);
        public bool AtualizarFatura(Fatura fatura);
        public void RemoverFatura(Fatura fatura);
    }
}
