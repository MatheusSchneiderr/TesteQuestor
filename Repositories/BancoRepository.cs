using Microsoft.EntityFrameworkCore;
using TesteQuestor.Data;
using TesteQuestor.Models;

namespace TesteQuestor.Repositories;

public class BancoRepository(AppDbContext db) : IBancoRepository
{
    public async Task<IEnumerable<Banco>> GetAllAsync() =>
        await db.Bancos.AsNoTracking().ToListAsync();

    public async Task<Banco?> GetByIdAsync(int id) =>
        await db.Bancos.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);

    public async Task<Banco?> GetByCodigoAsync(string codigoBanco) =>
        await db.Bancos.AsNoTracking().FirstOrDefaultAsync(b => b.CodigoBanco == codigoBanco);

    public async Task<Banco> AddAsync(Banco banco)
    {
        db.Bancos.Add(banco);
        await db.SaveChangesAsync();
        return banco;
    }
}
