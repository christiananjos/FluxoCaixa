using AutoMapper;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;

namespace FluxoCaixa.Application.Mappings
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Conta, ContaCreate>().ReverseMap();
        }
    }
}
