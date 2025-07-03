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
        SicsAvaliacao? transacao = await _dbContext.SicsAvaliacoes.FirstOrDefaultAsync(transacao => transacao.Id == id);
        if(transacao == null) 
            return NotFound(id);
        else
            return StatusCode(200, transacao);
    }

    /*TODO: ajustar para a entidade Avaliações

    [HttpGet("porPrestador")]
    public IEnumerable<SicsAvaliacao> GetTransacoesPrestador(
        [FromQuery] int PrestadorID
    )
    {
        return _dbContext.SicsAvaliacoes.Where(t => t.PrestadorId == PrestadorID).AsEnumerable<SicsAvaliacao>();
    }

    [HttpGet("porCliente")]
    public IEnumerable<SicsAvaliacao> GetTransacoesCliente(
        [FromQuery] int ClienteID
    )
    {
        return _dbContext.SicsAvaliacoes.Where(t => t.PrestadorId == ClienteID).AsEnumerable<SicsAvaliacao>();
    }

    [HttpGet("porData")]
    public IEnumerable<SicsAvaliacao> GetTransacoesData(
        [FromQuery] DateTime data
    )
    {
        return _dbContext.SicsAvaliacoes.Where(t => t.Data == data).AsEnumerable<SicsAvaliacao>();
    }

    [HttpPost]
    public async Task<IActionResult> PostTransacao(
        [FromBody] SicsAvaliacao transacao
    )
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        _dbContext.Add<SicsAvaliacao>(transacao);
        await _dbContext.SaveChangesAsync();
        return Ok(transacao);
    }

    [HttpPatch("efetiva")]
    public async Task<IActionResult> EfetivaTransacao([FromQuery] int id)
    {
        try
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            SicsAvaliacao? transacao = await _dbContext.SicsAvaliacoes.FirstOrDefaultAsync(s => s.Id == id);

            if(transacao == null) return NotFound(transacao);
            transacao.Efetivado = true;
            _dbContext.Entry<SicsAvaliacao>(transacao).CurrentValues.SetValues(transacao);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPatch("cancela")]
    [Authorize("Cliente")]
    public async Task<IActionResult> CancelaTransacao([FromQuery] int id, string motivoCancelamento)
    {
        try
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            SicsAvaliacao? transacao = await _dbContext.SicsAvaliacoes.FirstOrDefaultAsync(s => s.Id == id);

            if(transacao == null) return NotFound(transacao);
            transacao.Efetivado = false;
            transacao.Cancelado = true;
            transacao.MotivoCancelamento = motivoCancelamento;
            _dbContext.Entry<SicsAvaliacao>(transacao).CurrentValues.SetValues(transacao);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    */
}