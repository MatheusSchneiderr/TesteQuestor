using TesteQuestor.DTOs.Boleto;

namespace TesteQuestor.Services;

public interface IBoletoService
{
    Task<BoletoResponse> CreateAsync(CreateBoletoRequest request);
    Task<BoletoResponse?> GetByIdAsync(int id);
}
