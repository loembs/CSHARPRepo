using Microsoft.EntityFrameworkCore;
using WebApplication.Data;
using WebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication.services.Impl
{
    public class ClientService
    {
        private readonly ApplicationDbContext _context;

        public ClientService(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Client> Create(Client client)
        {

            _context.Clients.Add(client);

            await _context.SaveChangesAsync();

            return client;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            // Your implementation to fetch clients from your data source
            return await _context.Clients.ToListAsync();
        }
    }
}
