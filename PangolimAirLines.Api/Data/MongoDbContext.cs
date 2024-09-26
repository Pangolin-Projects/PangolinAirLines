using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PangolimAirLines.Api.Exceptions;
using PangolimAirLines.Api.Models;


namespace PangolimAirLines.Api.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    private readonly IOptions<MongoDbSettings> _mongoDBSettings;

    public MongoDbContext(IOptions<MongoDbSettings> mongoDbSettings)
    {
        MongoClient client = new MongoClient(mongoDbSettings.Value.ConnectionURI);
        _database = client.GetDatabase(mongoDbSettings.Value.DatabaseName);
        _mongoDBSettings = mongoDbSettings;
        CreateIndexes();
    }


    public IMongoCollection<Flights> FlightsCollection => _database.GetCollection<Flights>(_mongoDBSettings.Value.FlightsCollection);
    public IMongoCollection<Organizations> OrganizationCollection => _database.GetCollection<Organizations>(_mongoDBSettings.Value.OrganizationCollection);

    private void CreateIndexes()
    {
        var flightIndexKeysDefinition = Builders<Flights>.IndexKeys.Ascending(x => x.TakeOff);
        var flightIndexModel = new CreateIndexModel<Flights>(flightIndexKeysDefinition);

        var organizationIndexKeysDefinition = Builders<Organizations>.IndexKeys.Ascending(x => x.Email);
        var organizationIndexModel = new CreateIndexModel<Organizations>(
            organizationIndexKeysDefinition,
            new CreateIndexOptions { Unique = true });

        try
        {
            // Create the indexes
            FlightsCollection.Indexes.CreateOne(flightIndexModel);
            OrganizationCollection.Indexes.CreateOne(organizationIndexModel);
        }
        catch (Exception e)
        {
            MongoDbExeptionManager.HandleException(e);
        }
    }
}