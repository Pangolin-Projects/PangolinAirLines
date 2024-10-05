using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories;

public interface IOrganizationRepository 
{
    Task<bool> Login(Organizations organization);
    Task<List<Organizations>> GetAllOrganizationsAsync();
    Task<bool> CreateOrganizationAsync(Organizations organization);
    Task<bool> DeleteOrganizationAsync(string id);
}