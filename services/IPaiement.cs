using WebApplication.Models;

namespace WebApplication.services
{
    public interface IPaiement
    {
        Task<IEnumerable<Paiement>> GetDettePaiementsAsync(int detteId);
    }
}
