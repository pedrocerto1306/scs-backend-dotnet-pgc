using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sics_webapi.Data;
using sics_webapi.Models;
using sics_webapi.Models.Enums;

namespace sics_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class SicsAvaliacoesController : ControllerBase
{
    private readonly ILogger<SicsAvaliacoesController> _logger;
    private readonly DataContext _dbContext;

    public SicsAvaliacoesController(ILogger<SicsAvaliacoesController> logger, DataContext dbContext)
    {
        this._logger = logger;
        this._dbContext = dbContext;
    }

    [HttpGet]
    public IEnumerable<SicsAvaliacao> Get()
    {
        return _dbContext.SicsAvaliacoes;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        SicsAvaliacao? avaliacao = await _dbContext.SicsAvaliacoes.FirstOrDefaultAsync(avaliacao => avaliacao.Id == id);
        if (avaliacao == null)
            return NotFound(id);
        else
            return StatusCode(200, avaliacao);
    }

    [HttpGet("cliente/{clienteId}")]
    public IEnumerable<SicsAvaliacao> getByClienteId([FromRoute] int clienteId)
    {
        IEnumerable<SicsAvaliacao> avaliacoes = _dbContext.SicsAvaliacoes.Where(avaliacao => avaliacao.ClienteID == clienteId);
        if (avaliacoes == null)
            return (IEnumerable<SicsAvaliacao>)NotFound(clienteId);
        else
            return avaliacoes;
    }

    [HttpGet("prestador/{prestadorId}")]
    public IEnumerable<SicsAvaliacao> getByPrestadorId([FromRoute] int prestadorId)
    {
        IEnumerable<SicsAvaliacao> avaliacoes = _dbContext.SicsAvaliacoes.Where<SicsAvaliacao>(avaliacao => avaliacao.PrestadorID == prestadorId);
        if (avaliacoes == null)
            return (IEnumerable<SicsAvaliacao>)NotFound(prestadorId);
        else
            return avaliacoes;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] SicsAvaliacao avaliacao)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        _dbContext.Add<SicsAvaliacao>(avaliacao);
        await _dbContext.SaveChangesAsync();
        return Ok(avaliacao);
    }
}