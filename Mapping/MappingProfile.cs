using AutoMapper;
using TesteQuestor.DTOs.Banco;
using TesteQuestor.DTOs.Boleto;
using TesteQuestor.Models;

namespace TesteQuestor.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateBancoRequest, Banco>();
        CreateMap<Banco, BancoResponse>();

        CreateMap<CreateBoletoRequest, Boleto>();
        CreateMap<Boleto, BoletoResponse>()
            .ForMember(dest => dest.ValorAtualizado, opt => opt.Ignore())
            .ForMember(dest => dest.Vencido, opt => opt.Ignore());
    }
}
