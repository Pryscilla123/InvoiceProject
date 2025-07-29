using Invoice.Business.Interfaces;
using Invoice.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Business.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IFaturaRepository _faturaRepository;
        private readonly IFaturaItemRepository _faturaItemRepository;
        public RelatorioService(IFaturaRepository faturaRepository,
                                 IFaturaItemRepository faturaItemRepository)
        {
            _faturaRepository = faturaRepository;
            _faturaItemRepository = faturaItemRepository;
        }
        public async Task<IEnumerable<Fatura>> TopDezFaturas()
        {
            var faturas = await _faturaRepository.ObterFaturas();

            var topDez = faturas
                .OrderByDescending(f => f.FaturaItem.Sum(fi => fi.Valor))
                .Take(10)
                .ToList();

            return topDez;
        }

        public async Task<IEnumerable<FaturaItem>> TopDezItens()
        {
            var faturas = await _faturaRepository.ObterFaturas();

            var topDezItens = faturas
                .SelectMany(f => f.FaturaItem)
                .OrderByDescending(fi => fi.Valor)
                .Take(10);

            return topDezItens;
        }

        public async Task<IEnumerable<Fatura>> TotalPorAno(int ano)
        {
            var faturas = await _faturaRepository.ObterFaturas();

            var faturasDoAno = faturas
                .Where(f => f.Data.Year == ano)
                .ToList();

            return faturasDoAno;
        }

        public async Task<IEnumerable<RelatorioCliente>> TotalPorCliente()
        {
            var faturas = await _faturaRepository.ObterFaturas();

            IList<RelatorioCliente> clientes = new List<RelatorioCliente>();

            clientes = faturas.GroupBy(f => f.Cliente).Select(r => new RelatorioCliente
            {
                Cliente = r.Key,
                QuantidadeFaturas = r.Count()
            }).ToList() ;

            return clientes;
        }

        public async Task<IEnumerable<Fatura>> TotalPorMes(int mes)
        {
            var faturas = await _faturaRepository.ObterFaturas();

            var faturasDoMes = faturas.Where(f => f.Data.Month == mes).ToList();

            return faturasDoMes;
        }
    }
}
