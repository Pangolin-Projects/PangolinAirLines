using Microsoft.AspNetCore.Mvc;
using PangolimAirLines.Api.Models;
using PangolimAirLines.Api.Repositories;
using PangolimAirLines.Api.Services;

namespace PangolimAirLines.Api.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMongoDbRepository _dbRepository;

        public LoginController(IMongoDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [HttpPost("v1/Login")]
        public async Task<ActionResult<dynamic>> Login(
            [FromBody] Organizations model)
        {
            var result = await _dbRepository.Login(model);
            if (result == true)
            {
                var token = TokenService.GenerateToken(model);
                return token;
            }
            else 
                return BadRequest("Your user or password is wrong");
        }
        
    }
}
