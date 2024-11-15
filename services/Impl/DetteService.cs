using WebApplication.Data;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.services.Impl
{
    public class DetteService
    {
        private readonly ApplicationDbContext _context;

        public DetteService(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Dette>> GetDettesClientAsync(int clientId)
        {
            return await _context.Dettes
            .Where(dette => dette.ClientId == clientId)
            .ToListAsync();
        }
    }
}
