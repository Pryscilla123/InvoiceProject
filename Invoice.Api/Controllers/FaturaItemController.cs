using AutoMapper;
using Invoice.Api.ViewModels;
using Invoice.Business.Interfaces;
using Invoice.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Invoice.Api.Controllers
{
    [Route("api/fatura-item")]
    public class FaturaItemController : MainController
    {
        private readonly IFaturaItemRepository _faturaItemRepository;
        private readonly IMapper _mapper;

        public FaturaItemController(
            INotificador notificador,
            IMapper mapper,
            IFaturaItemRepository faturaItemRepository) : base(notificador)
        {
            _faturaItemRepository = faturaItemRepository;
            _mapper = mapper;
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] FaturaItemViewModel faturaItemViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var faturaItem = _mapper.Map<FaturaItem>(faturaItemViewModel);

            if (faturaItem.FaturaItemId != id)
            {
                NotificarErro("O ID do item da fatura não corresponde ao ID fornecido na URL.");
                return CustomResponse(faturaItemViewModel);
            }

            await _faturaItemRepository.AtualizarFaturaItem(faturaItem);

            return CustomResponse(faturaItemViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var faturaItem = _mapper.Map<FaturaItemViewModel>(await _faturaItemRepository.ObterFaturaItensPorId(id));

            if (faturaItem == null)
            {
                NotificarErro("Item da fatura não encontrado.");
                return NotFound();
            }

            await _faturaItemRepository.RemoverFaturaItem(id);

            return CustomResponse();
        }
    }
}
