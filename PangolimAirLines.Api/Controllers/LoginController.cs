using Microsoft.AspNetCore.Mvc;
using PangolimAirLines.Api.Models;
using PangolimAirLines.Api.Repositories;
using PangolimAirLines.Api.Services;

namespace PangolimAirLines.Api.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMongoDBRepository _dbRepository;

        public LoginController(IMongoDBRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        [HttpGet("v1/Login")]
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
