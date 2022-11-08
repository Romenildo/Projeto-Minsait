using AutoMapper;
using ProjetoMinsait.Models;
using ProjetoMinsait.Models.Dtos;

namespace ProjetoMinsait.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Passageiro, PassageiroDto>();
            CreateMap<Motorista, MotoristaDto>();
            CreateMap<Cobrador, CobradorDto>();
            CreateMap<Passagem, PassagemDto>();
        }
    }

}
