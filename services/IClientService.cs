using WebApplication.Models;

namespace WebApplication.services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetClientsAsync();
        Task<Client> Create(Client client);
        
    }
}
