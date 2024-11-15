using WebApplication.Models;

namespace WebApplication.services
{
    public interface IDetteService
    {
        Task<IEnumerable<Dette>> GetDettesClientAsync(int clientId);
    }
}
