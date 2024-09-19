using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories;

public interface IFlightRepository
{
    Task<bool> CreateFlightAsync(Flights fly);
    Task<int> CreateManyFlightsAsync(List<Flights> flights);
    Task<Flights> GetOneFlighAsync(string id);
    Task<List<Flights>> GetAllFlightsAsync();
    Task<bool> DeleteFlightAsync(string id);
}