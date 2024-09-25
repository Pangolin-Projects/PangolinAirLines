using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PangolimAirLines.Api.Models;


namespace PangolimAirLines.Api.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;
    private readonly IOptions<MongoDBSettings> _mongoDBSettings;

    public MongoDbContext(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        _database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _mongoDBSettings = mongoDBSettings;
        CreateIndexes();
    }


    public IMongoCollection<Flights> FlightsCollection => _database.GetCollection<Flights>(_mongoDBSettings.Value.FlightsCollection);
    public IMongoCollection<Organizations> OrganizationCollection => _database.GetCollection<Organizations>(_mongoDBSettings.Value.OrganizationCollection);
    
    private void CreateIndexes()
    {
        var indexKeysDefinition = Builders<Flights>.IndexKeys.Ascending(x => x.TakeOff);
        var indexModel = new CreateIndexModel<Flights>(indexKeysDefinition);
        
        // Create the index
        FlightsCollection.Indexes.CreateOne(indexModel);
    }
}