using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories;

public interface IOrganizationRepository 
{
    Task<bool> Login(Organizations organization);
}