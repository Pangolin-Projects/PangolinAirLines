using Microsoft.Extensions.Options;
using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories
{
    public interface IMongoDbRepository
    {
        Task<bool> Login(Organizations organization);
        Task<bool> CreateFlightAsync(Flights fly);
        Task<int> CreateManyFlightsAsync(List<Flights> flights);
        Task<Flights> GetOneFlighAsync(string id);
        Task<List<Flights>> GetAllFlightsAsync();
        Task<bool> DeleteFlightAsync(string id);
    }
}
