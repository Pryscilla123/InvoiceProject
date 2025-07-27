using Invoice.Business.Interfaces;
using Invoice.Business.Models;
using Microsoft.EntityFrameworkCore;
using TesteDengine;

namespace Invoice.Data.Repository
{
    public class FaturaItemRepository : IFaturaItemRepository
    {
        private readonly MyDbContext _context;
        private readonly DbSet<FaturaItem> _faturaItems;
        public FaturaItemRepository(MyDbContext context)
        {
            _context = context;
            _faturaItems = context.Set<FaturaItem>();
        }

        public async Task AdicionarFaturaItem(FaturaItem faturaItem)
        {
            await _faturaItems.AddAsync(faturaItem);
            await _context.SaveChangesAsync();
        }
        public async Task AtualizarFaturaItem(FaturaItem faturaItem)
        {
            _faturaItems.Update(faturaItem);
            await _context.SaveChangesAsync();
        }
        public async Task RemoverFaturaItem(int id)
        {
            var faturaItem = await _faturaItems.FindAsync(id);
            if (faturaItem == null) return;
            _faturaItems.Remove(faturaItem);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FaturaItem>> ObterFaturaItensPorFaturaId(int faturaId)
        {
            return await _faturaItems
                .Where(fi => fi.FaturaId == faturaId)
                .ToListAsync();
        }
    }
}
