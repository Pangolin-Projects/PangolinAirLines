using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PangolimAirLines.Api.Models;
using PangolimAirLines.Api.Repositories;

namespace PangolimAirLines.Api.Controllers;
[ApiController]
public class FlightController : ControllerBase
{
   private readonly IFlightRepository _flightRepository;

   public FlightController(IFlightRepository flightRepository)
   {
       _flightRepository = flightRepository;
   }

   [HttpPut("v1/flight/{id}/{reservedSits}")]
   public async Task<ActionResult<Flights>> BookFlight(
      [FromRoute] string id,
      [FromRoute] int reservedSits
      )
   {
      var result = await _flightRepository.BookFlight(id, reservedSits);
      if (result == true)
      {
         return Ok(reservedSits + " - sits has been booked");
      }
      else 
         return NotFound("Something went wrong");
   }
   
   [HttpGet("v1/flight/{id}")]
   public async Task<ActionResult<Flights>> GetOneFlightAsync(
      [FromRoute] string id)
   {
      var result = await _flightRepository.GetOneFlightAsync(id);
      if (result != null)
      {
         return Ok(result);
      }
      else 
         return NotFound("Something went wrong or the id was not found");
   }
   
   [HttpGet("v1/flights")]
   public async Task<ActionResult<Flights>> GetAllFlightAsync()
   {
      var result = await _flightRepository.GetAllFlightsAsync();
      if (result.Count >= 1)
      {
         return Ok(result);
      }
      else 
         return NotFound("Something went wrong or the list was not found");
   }
   
   [HttpPost("v1/flight")]
   [Authorize]
   public async Task<IActionResult> CreateFlightAsync(
      [FromBody] Flights model)
   {
      var result = await _flightRepository.CreateFlightAsync(model);
      if (result == true)
      {
         return Created("One document has been inserted", model);
      }
      else 
         return BadRequest("Something went wrong");
   }
   
   [HttpPost("v1/flights")]
   [Authorize]
   public async Task<IActionResult> CreateManyFlightsAsync(
      [FromBody] List<Flights> flights)
   {
      var rows = await _flightRepository.CreateManyFlightsAsync(flights);
      if (rows != 0)
      {
         return Ok($"{rows} documents has been created");
      }
      else 
         return BadRequest("Something went wrong");
   }
   
   [HttpDelete("v1/flight/{id}")]
   [Authorize]
   public async Task<IActionResult> DeleteFlightAsync(
      [FromRoute] string id)
   {
      var result = await _flightRepository.DeleteFlightAsync(id);
      if (result == true)
      {
         return Ok("The document has been deleted");
      }
      else 
         return BadRequest("Something went wrong");
   }
   
}