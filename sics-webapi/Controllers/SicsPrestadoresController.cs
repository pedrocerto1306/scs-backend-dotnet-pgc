using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sics_webapi.Data;
using sics_webapi.Models;

namespace sics_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class SicsPrestadoresController : ControllerBase
{
    private readonly ILogger<SicsPrestadoresController> _logger;
    private readonly DataContext _dbContext;

    public SicsPrestadoresController(ILogger<SicsPrestadoresController> logger, DataContext dbContext)
    {
        this._logger = logger;
        this._dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SicsPrestador prestador)
    {
        if(!ModelState.IsValid) return BadRequest(prestador);

        _dbContext.Add<SicsPrestador>(prestador);
        await _dbContext.SaveChangesAsync();
        return Ok(prestador);
    }

    [HttpGet]
    public IEnumerable<SicsPrestador> Get()
    {
        return _dbContext.SicsPrestadores;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        SicsPrestador? prestadorBuscado = await _dbContext.SicsPrestadores.FirstOrDefaultAsync(c => c.Id == id);
        if(prestadorBuscado == null) return NotFound(id);
        return Ok(prestadorBuscado);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] SicsPrestador prestador)
    {
        SicsPrestador? prestadorBuscado = await _dbContext.SicsPrestadores.FirstOrDefaultAsync(c => c.Id == prestador.Id);
        if(prestadorBuscado == null) return NotFound(prestador);

        _dbContext.Entry<SicsPrestador>(prestadorBuscado).CurrentValues.SetValues(prestador);
        await _dbContext.SaveChangesAsync();
        return Ok(prestador);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        SicsPrestador? prestadorBuscado = await _dbContext.SicsPrestadores.FirstOrDefaultAsync(c => c.Id == id);
        if(prestadorBuscado == null) return NotFound(id);

        _dbContext.SicsPrestadores.Remove(prestadorBuscado);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}