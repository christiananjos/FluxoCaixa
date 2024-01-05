using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Application.Applications
{
    public class ContaApplication : IContaApplication
    {
        private readonly IContaRepository _contaRepository;
        public ContaApplication(IContaRepository contaRepository)
        {
            _contaRepository = contaRepository;
        }
        public async Task<ActionResult<Conta>> Add(Conta entity)
        {
            entity.CreateAt = DateTime.Now;
            return await _contaRepository.Add(entity);
        }

        public async Task<ActionResult<IEnumerable<Conta>>> GetAll()
        {
            var contas = await _contaRepository.GetAll();

            return contas.ToList();
        }

        public async Task<ActionResult<Conta>> GetById(Guid id)
        {
            return await _contaRepository.GetById(id);
        }

        public async Task Remove(Guid id)
        {
            var conta  = await _contaRepository.GetById(id);
            conta.RemoveAt = DateTime.Now;

            await _contaRepository.Delete(conta);
        }

        public async Task<ActionResult<Conta>> Update(Conta entity)
        {
            entity.UpdateAt = DateTime.Now;
            return await _contaRepository.Update(entity);
        }
    }
}
