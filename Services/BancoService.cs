using AutoMapper;
using TesteQuestor.DTOs.Banco;
using TesteQuestor.Exceptions;
using TesteQuestor.Models;
using TesteQuestor.Repositories;

namespace TesteQuestor.Services;

public class BancoService(IBancoRepository repository, IMapper mapper) : IBancoService
{
    public async Task<IEnumerable<BancoResponse>> GetAllAsync()
    {
        var bancos = await repository.GetAllAsync();
        return bancos.Select(mapper.Map<BancoResponse>);
    }

    public async Task<BancoResponse?> GetByCodigoAsync(string codigoBanco)
    {
        var banco = await repository.GetByCodigoAsync(codigoBanco);
        return banco is null ? null : mapper.Map<BancoResponse>(banco);
    }

    public async Task<BancoResponse> CreateAsync(CreateBancoRequest request)
    {
        if (await repository.GetByCodigoAsync(request.CodigoBanco) is not null)
            throw new ConflictException($"Já existe um banco com código {request.CodigoBanco}.");

        var banco = mapper.Map<Banco>(request);
        var created = await repository.AddAsync(banco);
        return mapper.Map<BancoResponse>(created);
    }
}
