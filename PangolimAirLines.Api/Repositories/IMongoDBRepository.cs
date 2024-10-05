using Microsoft.Extensions.Options;
using PangolimAirLines.Api.Models;

namespace PangolimAirLines.Api.Repositories
{
    public interface IMongoDbRepository
    {
        Task<bool> Login(Organizations organization);
    }
}
