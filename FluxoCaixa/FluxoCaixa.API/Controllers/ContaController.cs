using FluxoCaixa.Application.Interfaces;
using FluxoCaixa.Data.Interfaces;
using FluxoCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoCaixa.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        IBaseRepository<Conta> contaRepository;

        public ContaController(IUnitOfWork unitOfWork, IBaseRepository<Conta> contaRepository)
        {
            _unitOfWork = unitOfWork;
            this.contaRepository = contaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Conta>> GetAll()
        {
            var contas = await contaRepository.GetAll();
            return contas;
        }

        [HttpPost]
        public async Task<Conta> Create(Conta conta)
        {
            var contaCreated = await contaRepository.Add(conta);
            return contaCreated;
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await contaRepository.Delete(id);
        }

        [HttpPut]
        public async Task Update(Conta conta)
        {
            await contaRepository.Update(conta);
        }
    }
}
