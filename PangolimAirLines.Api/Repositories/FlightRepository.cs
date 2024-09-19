using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PangolimAirLines.Api.Data;
using PangolimAirLines.Api.Exceptions;
using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories;


public class FlightRepository : IFlightRepository
{
        private readonly IMongoCollection<Flights> _flightsCollection;
        public FlightRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _flightsCollection = database.GetCollection<Flights>(mongoDBSettings.Value.FlightsCollection);
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

        public Task<Flights> GetOneFlighAsync(string id)
        {
            try
            {
                return _flightsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                MongoDbExeptionManager.HandleException(e);
            }
            return null;
        }

        public Task<List<Flights>> GetAllFlightsAsync()
        {
            try
            {
                return _flightsCollection.Find(_ => true).ToListAsync();
            }
            catch (Exception e)
            {
                MongoDbExeptionManager.HandleException(e);
            }

            return null;
        }

        public async Task<bool> DeleteFlightAsync(string id)
        {
            try
            {
                var filter = Builders<Flights>.Filter.Eq("Id", id);
                await _flightsCollection.DeleteOneAsync(filter);
                return true;
            }
            catch (Exception e)
            {
                MongoDbExeptionManager.HandleException(e);
            }
            return false;
        }
}
