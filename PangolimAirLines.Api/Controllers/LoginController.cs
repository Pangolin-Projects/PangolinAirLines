using Microsoft.AspNetCore.Mvc;
using PangolimAirLines.Api.Models;
using PangolimAirLines.Api.Repositories;

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
        public async Task<IActionResult> Login(
            [FromBody] Organizations model)
        {
            var result = await _dbRepository.Login(model);
            if (result == true)
                 return Ok("You are logged");//add feature - return the jwt token
            else 
                return BadRequest("Your user or password is wrong");     
        }
    }
}
