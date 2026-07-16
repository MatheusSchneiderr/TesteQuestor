using TesteQuestor.Models;

namespace TesteQuestor.Repositories;

public interface IBoletoRepository
{
    Task<Boleto?> GetByIdAsync(int id);
    Task<Boleto> AddAsync(Boleto boleto);
    Task<bool> BancoExistsAsync(int bancoId);
}
