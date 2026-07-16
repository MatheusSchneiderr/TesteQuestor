using TesteQuestor.DTOs.Banco;

namespace TesteQuestor.Services;

public interface IBancoService
{
    Task<IEnumerable<BancoResponse>> GetAllAsync();
    Task<BancoResponse?> GetByCodigoAsync(string codigoBanco);
    Task<BancoResponse> CreateAsync(CreateBancoRequest request);
}
