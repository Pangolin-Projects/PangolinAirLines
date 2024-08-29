using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PangolimAirLines.Api.Data;
using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories
{
    public class MongoDBRepository : IMongoDBRepository
    {
        private readonly IMongoCollection<Organizations> _organizationCollection;
        private readonly IMongoCollection<Flights> _flightsCollection;
        public MongoDBRepository(IOptions<MongoDBSettings> mongoDBSettings)
        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _organizationCollection = database.GetCollection<Organizations>(mongoDBSettings.Value.OrganizationCollection);
            _flightsCollection = database.GetCollection<Flights>(mongoDBSettings.Value.FlightsCollection);
        }

        public async Task<bool> Login(Organizations organization)
        {
            FilterDefinition<Organizations> filter = Builders<Organizations>.Filter.Eq("Email", organization.Email);
            var obj = await _organizationCollection.Find(filter).FirstOrDefaultAsync();

            if (obj.Password == organization.Password)
            {
                return true;
            }

            return false;
        }
        public async Task CreateFlightsAsync(Flights fly)
        {
            await _flightsCollection.InsertOneAsync(fly);
            return;
        }

        public Task CreateManyAsync(List<Flights> fly)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Flights>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Flights>> GetAvailableAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Flights> GetOneAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
