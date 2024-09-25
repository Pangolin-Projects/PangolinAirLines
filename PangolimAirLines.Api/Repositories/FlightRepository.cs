using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PangolimAirLines.Api.Data;
using PangolimAirLines.Api.Exceptions;
using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories;


public class FlightRepository : IFlightRepository
{
    private readonly IMongoCollection<Flights> _flightsCollection;
    public FlightRepository(MongoDbContext context)
    {
        _flightsCollection = context.FlightsCollection;
    }

        public async Task<bool> BookFlight(string id, int reservedSits)
        {
            try
            {
                var flight = await _flightsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
                if (flight.AvailableSits > reservedSits)
                {
                    var filter = Builders<Flights>.Filter.Eq(x => x.Id, id);
                    var update = Builders<Flights>.Update.Set(x => x.AvailableSits, flight.AvailableSits - reservedSits);
                    await _flightsCollection.UpdateOneAsync(filter, update);
                }
                return true;
            }
            catch (Exception e)
            {
                MongoDbExeptionManager.HandleException(e);
            }

            return false;
        }
        
        public async Task<bool> CreateFlightAsync(Flights fly)
        {
            try
            {
                await _flightsCollection.InsertOneAsync(fly);
                return true;
            }
            catch (Exception e)
            {
                MongoDbExeptionManager.HandleException(e);
            }

            return false;
        }

        public async Task<int> CreateManyFlightsAsync(List<Flights> flights)
        {
            try
            {
                await _flightsCollection.InsertManyAsync(flights);
                
                return flights.Count;
            }
            catch (Exception e)
            {
                MongoDbExeptionManager.HandleException(e);
            }

            return 0;
        }

        public async Task<Flights?> GetOneFlightAsync(string id)
        {
            try
            {
                var flight = await _flightsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
                if (flight != null)
                {
                    return flight;
                }
            }
            catch (Exception e)
            {
                MongoDbExeptionManager.HandleException(e);
            }
            return null;
        }

        public async Task<List<Flights>> GetAllFlightsAsync()
        {
            try
            {
                var flight = await _flightsCollection.Find(_ => true).ToListAsync();
                if (flight != null)
                {
                    return flight;
                }
            }
            catch (Exception e)
            {
                MongoDbExeptionManager.HandleException(e);
            }

            var emptyReturnList = new List<Flights>();
            
            return emptyReturnList;
        }

        public async Task<bool> DeleteFlightAsync(string id)
        {
            try
            {
                await _flightsCollection.DeleteOneAsync(x => x.Id == id);
                return true;
            }
            catch (Exception e)
            {
                MongoDbExeptionManager.HandleException(e);
            }
            return false;
        }
}
