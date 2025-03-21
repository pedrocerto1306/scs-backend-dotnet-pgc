using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sics_webapi.Data;
using sics_webapi.Models;

namespace sics_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class SicsClientesController : ControllerBase
{
    private readonly ILogger<SicsClientesController> _logger;
    private readonly DataContext _dbContext;

    public SicsClientesController(ILogger<SicsClientesController> logger, DataContext dbContext)
    {
        this._logger = logger;
        this._dbContext = dbContext;
    }

    [HttpGet]
    public IEnumerable<SicsCliente> Get()
    {
        return _dbContext.SicsClientes;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        SicsCliente? clienteBuscado = await _dbContext.SicsClientes.FirstOrDefaultAsync(c => c.Id == id);
        if(clienteBuscado == null) return NotFound(id);
        return Ok(clienteBuscado);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SicsCliente cliente)
    {
        if(!ModelState.IsValid) return BadRequest(cliente);

        _dbContext.Add<SicsCliente>(cliente);
        await _dbContext.SaveChangesAsync();

        return Ok(cliente);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] SicsCliente cliente)
    {
        SicsCliente? clienteBuscado = await _dbContext.SicsClientes.FirstOrDefaultAsync(c => c.Id == cliente.Id);
        if(clienteBuscado == null) return NotFound(cliente);

        _dbContext.Entry<SicsCliente>(clienteBuscado).CurrentValues.SetValues(cliente);
        await _dbContext.SaveChangesAsync();
        return Ok(cliente);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        SicsCliente? clienteBuscado = await _dbContext.SicsClientes.FirstOrDefaultAsync(c => c.Id == id);
        if(clienteBuscado == null) return NotFound(id);

        _dbContext.SicsClientes.Remove(clienteBuscado);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}