using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PangolimAirLines.Api.Data;
using PangolimAirLines.Api.Exceptions;
using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly IMongoCollection<Organizations> _organizationCollection;
    public OrganizationRepository(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _organizationCollection = database.GetCollection<Organizations>(mongoDBSettings.Value.OrganizationCollection);
    }


    public async Task<bool> Login(Organizations organization)
    {
        try
        {
            FilterDefinition<Organizations> filter = Builders<Organizations>.Filter.Eq("Email", organization.Email);
            var obj = await _organizationCollection.Find(filter).FirstOrDefaultAsync();

            if (obj.Password == organization.Password)
            {
                return true;
            }
        }
        catch (Exception e)
        {
            MongoDbExeptionManager.HandleException(e);
        }
            
        return false;
    }
}