using AutoMapper;
using Invoice.Api.ViewModels;
using Invoice.Business.Interfaces;
using Invoice.Business.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace Invoice.Api.Controllers
{
    [Route("api/fatura")]
    public class FaturaController : MainController
    {
        private readonly IFaturaService _faturaService;
        private readonly IFaturaRepository _faturaRepository;
        private readonly IMapper _mapper;

        public FaturaController(
            IFaturaService faturaService,
            IFaturaRepository faturaRepository,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _faturaService = faturaService;
            _faturaRepository = faturaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var faturasViewModel = _mapper.Map<IEnumerable<FaturaViewModel>>(await _faturaRepository.ObterFaturas());

            return CustomResponse(faturasViewModel);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var faturaViewModel = _mapper.Map<FaturaViewModel>(await _faturaRepository.ObterFaturaPorId(id));

            if (faturaViewModel == null) return NotFound();

            return CustomResponse(faturaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FaturaViewModel faturaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var fatura = _mapper.Map<Fatura>(faturaViewModel);

            await _faturaService.AdicionarFatura(fatura);

            return CustomResponse(faturaViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<FaturaViewModel>> Put(int id, [FromBody] FaturaViewModel faturaViewModel)
        {
            if (id != faturaViewModel.FaturaId)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query.");
                return CustomResponse(faturaViewModel);
            }
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var fatura = _mapper.Map<Fatura>(faturaViewModel);

            _faturaService.AtualizarFatura(fatura);

            return CustomResponse(faturaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var fatura = await _faturaRepository.ObterFaturaPorId(id);

            if (fatura == null) return NotFound();

            _faturaService.RemoverFatura(fatura);

            return CustomResponse();
        }
    }
}
