using AutoMapper;
using FluxoCaixa.Domain.Entities;
using FluxoCaixa.Domain.Input;

namespace FluxoCaixa.API.Mappings
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Conta, ContaCreate>().ReverseMap();
        }
    }
}
