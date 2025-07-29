using Invoice.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Business.Interfaces
{
    public interface IRelatorioService
    {
        public Task<IEnumerable<RelatorioCliente>> TotalPorCliente();
        public Task<IEnumerable<Fatura>> TotalPorAno(int ano);
        public Task<IEnumerable<Fatura>> TotalPorMes(int mes);
        public Task<IEnumerable<Fatura>> TopDezFaturas();
        public Task<IEnumerable<FaturaItem>> TopDezItens();
    }
}
