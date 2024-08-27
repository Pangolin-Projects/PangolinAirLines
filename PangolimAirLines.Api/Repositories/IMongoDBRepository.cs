using Microsoft.Extensions.Options;
using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories
{
    public interface IMongoDBRepository
    {
        Task Login(Organizations organization);
        Task CreateFlightsAsync(Flights fly);
        Task CreateManyAsync(List<Flights> fly);
        Task<Flights> GetOneAsync(string id);
        Task<List<Flights>> GetAllAsync();
        Task<List<Flights>> GetAvailableAsync();
        Task DeleteAsync(string id);
    }
}
