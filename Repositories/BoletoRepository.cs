using Microsoft.EntityFrameworkCore;
using TesteQuestor.Data;
using TesteQuestor.Models;

namespace TesteQuestor.Repositories;

public class BoletoRepository(AppDbContext db) : IBoletoRepository
{
    public async Task<Boleto?> GetByIdAsync(int id) =>
        await db.Boletos.AsNoTracking()
            .Include(b => b.Banco)
            .FirstOrDefaultAsync(b => b.Id == id);

    public async Task<Boleto> AddAsync(Boleto boleto)
    {
        db.Boletos.Add(boleto);
        await db.SaveChangesAsync();
        return boleto;
    }

    public async Task<bool> BancoExistsAsync(int bancoId) =>
        await db.Bancos.AnyAsync(b => b.Id == bancoId);
}
