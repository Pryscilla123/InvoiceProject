using AutoMapper;
using Invoice.Api.ViewModels;
using Invoice.Business.Interfaces;
using Invoice.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Api.Controllers
{
    [Route("api/relatorio")]
    public class RelatorioController : MainController
    {
        private readonly IRelatorioService _relatorioService;
        private readonly IMapper _mapper;
        public RelatorioController(IRelatorioService relatorioService,
                                   IMapper mapper,
                                   INotificador notificador) : base(notificador)
        {
            _relatorioService = relatorioService;
            _mapper = mapper;
        }

        [HttpGet("quantidade-faturas-cliente")]
        public async Task<IActionResult> QuantidadeFaturasPorCliente()
        {
            var relatorio = await _relatorioService.TotalPorCliente();

            if (relatorio == null || !relatorio.Any())
            {
                return NotFound("Nenhum dado encontrado para o relatório.");
            }
            return CustomResponse(relatorio);
        }

        [HttpGet("quantidade-faturas-por-mes/{mes:int}")]
        public async Task<IActionResult> QuantidadeFaturasPorMes(int mes)
        {
            var relatorio = await _relatorioService.TotalPorMes(mes);

            if (relatorio == null || !relatorio.Any())
            {
                return NotFound("Nenhum dado encontrado para o relatório.");
            }
            return CustomResponse(relatorio);
        }

        [HttpGet("quantidade-faturas-por-ano/{ano:int}")]
        public async Task<IActionResult> QuantidadeFaturasPorAno(int ano)
        {
            var relatorio = await _relatorioService.TotalPorAno(ano);
            if (relatorio == null || !relatorio.Any())
            {
                return NotFound("Nenhum dado encontrado para o relatório.");
            }
            return CustomResponse(relatorio);
        }

        [HttpGet("top-dez-faturas")]
        public async Task<IActionResult> TopDezFaturas()
        {
            var relatorio = _mapper.Map<IEnumerable<FaturaViewModel>>(await _relatorioService.TopDezFaturas());
            if (relatorio == null || !relatorio.Any())
            {
                return NotFound("Nenhum dado encontrado para o relatório.");
            }
            return CustomResponse(relatorio);
        }

        [HttpGet("top-dez-itens")]
        public async Task<IActionResult> TopDezItens()
        {
            var relatorio = _mapper.Map<IEnumerable<FaturaItemViewModel>>(await _relatorioService.TopDezItens());
            if (relatorio == null || !relatorio.Any())
            {
                return NotFound("Nenhum dado encontrado para o relatório.");
            }
            return CustomResponse(relatorio);
        }
    }
}
