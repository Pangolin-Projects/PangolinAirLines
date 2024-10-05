using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PangolimAirLines.Api.Data;
using PangolimAirLines.Api.Exceptions;
using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories;

public class OrganizationRepository : IOrganizationRepository
{
    private readonly IMongoCollection<Organizations> _organizationCollection;
    public OrganizationRepository(MongoDbContext context)
    {
        _organizationCollection = context.OrganizationCollection;
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

    public async Task<List<Organizations>> GetAllOrganizationsAsync()
    {
        try
        {
            var flight = await _organizationCollection.FindAsync(_ => true).GetAwaiter().GetResult().ToListAsync();
            if (flight != null)
            {
                return flight;
            }
        }
        catch (Exception e)
        {
            MongoDbExeptionManager.HandleException(e);
        }
        var emptyList = new List<Organizations>();
            
        return emptyList;
    }

    public async Task<bool> CreateOrganizationAsync(Organizations organization)
    {
        try
        {
            await _organizationCollection.InsertOneAsync(organization);
            return true;
        }
        catch (Exception e)
        {
            MongoDbExeptionManager.HandleException(e);
        }
        return false;
    }

    public async Task<bool> DeleteOrganizationAsync(string id)
    {
        try
        {
            await _organizationCollection.DeleteOneAsync(x => x.Id == id);
            return true;
        }
        catch (Exception e)
        {
            MongoDbExeptionManager.HandleException(e);
        }
        return false;
    }
}