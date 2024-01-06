using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Data.Repository;
using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.Application.Applications
{
    public class TipoTransacaoApplication : ITipoTransacaoApplication
    {
        private readonly ITipoTransacaoRepository _tipoTransacaoRepository;

        public TipoTransacaoApplication(ITipoTransacaoRepository tipoTransacaoRepository)
        {
            _tipoTransacaoRepository = tipoTransacaoRepository;
        }

        public async Task<ActionResult<TipoTransacao>> Add(TipoTransacao entity)
        {
            entity.SetCreateAtDate();
            return await _tipoTransacaoRepository.Add(entity);
        }

        public async Task<ActionResult<IEnumerable<TipoTransacao>>> GetAll()
        {
            var tipos = await _tipoTransacaoRepository.GetAll();
            return tipos.ToList();
        }

        public async Task<ActionResult<TipoTransacao>> GetById(Guid id)
        {
            return await _tipoTransacaoRepository.GetById(id);
        }

        public async Task Remove(Guid id)
        {
            var transacao = await _tipoTransacaoRepository.GetById(id);

            transacao.SetRemoveAtDate();

            await _tipoTransacaoRepository.Update(transacao);
        }

        public async Task<ActionResult<TipoTransacao>> Update(TipoTransacao entity)
        {
            TipoTransacao tipoUpdated = new();

            var transacao = await _tipoTransacaoRepository.GetById(entity.Id);

            if (transacao != null)
            {
                transacao.IdInterno = entity.IdInterno;
                transacao.Descricao = entity.Descricao;
                
                transacao.SetRemoveAtDate();

                tipoUpdated = await _tipoTransacaoRepository.Update(transacao);
            }

            return tipoUpdated;
        }
    }
}
