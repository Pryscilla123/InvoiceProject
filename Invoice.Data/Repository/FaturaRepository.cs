using Invoice.Business.Interfaces;
using Invoice.Business.Models;
using Microsoft.EntityFrameworkCore;
using TesteDengine;

namespace Invoice.Data.Repository
{
    public class FaturaRepository : IFaturaRepository
    {
        private readonly MyDbContext Db;
        private readonly DbSet<Fatura> _faturas;
        public FaturaRepository(MyDbContext db)
        {
            Db = db;
            _faturas = db.Set<Fatura>();
        }

        public async Task<IEnumerable<Fatura>> ObterFaturas()
        {
            return await Db.Fatura.Include(f => f.FaturaItem).ToListAsync();
        }

        public async Task<Fatura> ObterFaturaPorId(int id)
        {
            return await Db.Fatura
                .Include(f => f.FaturaItem)
                .FirstOrDefaultAsync(f => f.FaturaId == id);
        }

        public async Task AdicionarFatura(Fatura fatura)
        {      
            await _faturas.AddAsync(fatura);
            await Db.SaveChangesAsync();
        }

        public async Task AtualizarFatura(Fatura fatura)
        {
            _faturas.Update(fatura);
            await Db.SaveChangesAsync();
        }
        public async Task RemoverFatura(Fatura fatura)
        {
            _faturas.Remove(fatura);
            await Db.SaveChangesAsync();
        }
    }
}
