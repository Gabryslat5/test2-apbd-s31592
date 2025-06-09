using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly IDbService _service;

    public OrdersController(IDbService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetClientOrdersAsync(string? clientLastName = null)
    {
        try
        {
            var orders = await _service.GetClientOrdersAsync(clientLastName);
            return Ok(orders);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrdersAsync(int id)
    {
        try
        {
            var order = await _service.GetOrderAsync(id);
            return Ok(order);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPut("{id}/fulfill")]
    public async Task<IActionResult> UpdateOrderAsync(int id, [FromBody] Order2Request request)
    {
        try
        {
            await _service.UpdateOrderAsync(id, request);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ConflictException e)
        {
            return Conflict(e.Message);
        }
    }
}