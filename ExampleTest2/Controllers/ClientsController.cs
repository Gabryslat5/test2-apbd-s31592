using ExampleTest2.DTOs;
using ExampleTest2.Exceptions;
using ExampleTest2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExampleTest2.Controllers;

[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly IDbService _service;

    public ClientsController(IDbService service)
    {
        _service = service;
    }

    [HttpPost("{clientId}/orders")]
    public async Task<IActionResult> AddNewOrderAsync(int clientId, [FromBody] OrderRequest request)
    {
        try
        {
            var orders = await _service.AddNewOrderAsync(clientId, request);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}