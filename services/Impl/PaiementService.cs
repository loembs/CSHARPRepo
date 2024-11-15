using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.services.Impl
{
    public class PaiementService
    {

        private readonly ApplicationDbContext _context;

        public PaiementService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Paiement>> GetDettePaiementsAsync(int detteId)
        {
            return await _context.Paiements.Where(paiement => paiement.DetteId == detteId).ToListAsync();
        }
    }
}
