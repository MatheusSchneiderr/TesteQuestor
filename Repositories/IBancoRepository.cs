using TesteQuestor.Models;

namespace TesteQuestor.Repositories;

public interface IBancoRepository
{
    Task<IEnumerable<Banco>> GetAllAsync();
    Task<Banco?> GetByIdAsync(int id);
    Task<Banco?> GetByCodigoAsync(string codigoBanco);
    Task<Banco> AddAsync(Banco banco);
}
