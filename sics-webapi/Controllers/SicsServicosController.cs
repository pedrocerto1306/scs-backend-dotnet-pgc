using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sics_webapi.Data;
using sics_webapi.Models;

namespace sics_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class SicsServicosController : ControllerBase
{


    private readonly ILogger<SicsServicosController> _logger;
    private readonly DataContext _dbContext;

    public SicsServicosController(ILogger<SicsServicosController> logger, DataContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    [HttpGet(Name = "GetSicsServicos")]
    public IEnumerable<SicsServico> Get()
    {
        return _dbContext.SicsServicos;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        SicsServico? servico = await _dbContext.SicsServicos.FirstOrDefaultAsync(servico => servico.Id == id);
        if(servico == null) 
            return NotFound(id);
        else
            return StatusCode(200, servico);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SicsServico servico)
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        _dbContext.Add<SicsServico>(servico);
        await _dbContext.SaveChangesAsync();
        return Ok(servico);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] SicsServico servico)
    {
        try
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            SicsServico? servicoAntigo = await _dbContext.SicsServicos.FirstOrDefaultAsync(s => s.Id == id);

            if(servicoAntigo == null) return NotFound(servico);

            _dbContext.Entry<SicsServico>(servicoAntigo).CurrentValues.SetValues(servico);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        SicsServico? servico = await _dbContext.SicsServicos.FirstOrDefaultAsync(s => s.Id == id);
        if(servico == null) return NotFound(id);

        _dbContext.SicsServicos.Remove(servico);
        await _dbContext.SaveChangesAsync();

        return NoContent();
    }
}
