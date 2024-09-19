﻿using Microsoft.AspNetCore.Mvc;
using PangolimAirLines.Api.Models;
using PangolimAirLines.Api.Repositories;

namespace PangolimAirLines.Api.Controllers;
[ApiController]
public class FlightController : ControllerBase
{
   public readonly IFlightRepository _flightRepository;

   public FlightController(IFlightRepository flightRepository)
   {
       _flightRepository = flightRepository;
   }

   [HttpGet("v1/Flight/{id}")]
   public async Task<ActionResult<Flights>> GetOneFlightAsync(
      [FromHeader] string id)
   {
      var result = await _flightRepository.GetOneFlighAsync(id);
      if (result != null)
      {
         return Ok(result);
      }
      else 
         return NotFound("Something went wrong");
   }
   
   [HttpGet("v1/Flights")]
   public async Task<ActionResult<Flights>> GetAllFlightAsync()
   {
      var result = await _flightRepository.GetAllFlightsAsync();
      if (result != null)
      {
         return Ok(result);
      }
      else 
         return NotFound("Something went wrong");
   }
   
   [HttpPost("v1/Flight")]
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
   
   [HttpPost("v1/Flights")]
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
   
   [HttpDelete("v1/Flight/{id}")]
   public async Task<IActionResult> DeleteFlightAsync(
      [FromHeader] string id)
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