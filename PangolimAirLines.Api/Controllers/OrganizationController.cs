using Microsoft.AspNetCore.Mvc;
using PangolimAirLines.Api.Models;
using PangolimAirLines.Api.Repositories;

namespace PangolimAirLines.Api.Controllers;
[ApiController]
public class OrganizationController : ControllerBase
{
    private readonly IOrganizationRepository _organizationRepository;

    public OrganizationController(IOrganizationRepository organizationRepository)
    {
        _organizationRepository = organizationRepository;
    }
    
    [HttpGet("v1/organizations")]
    public async Task<IActionResult> GetAllOrganizationAsync()
    {
        var result = await _organizationRepository.GetAllOrganizationsAsync();
        if (result.Count >= 1)
        {
            return Ok(result);
        }
        else 
            return NotFound("Something went wrong or the list was not found");
    }
    
    [HttpPost("v1/organization")]
    public async Task<IActionResult> CreateOrganizationAsync(
        [FromBody] Organizations model)
    {
        var result = await _organizationRepository.CreateOrganizationAsync(model);
        if (result == true)
        {
            return Created("One document has been inserted", model);
        }
        else 
            return BadRequest("Something went wrong");
    }
    
    [HttpDelete("v1/organization/{id}")]
    public async Task<IActionResult> DeleteOrganizationAsync(
        [FromRoute]string id)
    {
        var result = await _organizationRepository.DeleteOrganizationAsync(id);
        if (result == true)
        {
            return Ok("The document has been deleted");
        }
        else 
            return BadRequest("Something went wrong");
    }
    
    
}