using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sics_webapi.Data;
using sics_webapi.Models;
using sics_webapi.Models.Enums;

namespace sics_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class SicsTransacoesController : ControllerBase
{
    private readonly ILogger<SicsTransacoesController> _logger;
    private readonly DataContext _dbContext;

    public SicsTransacoesController(ILogger<SicsTransacoesController> logger, DataContext dbContext)
    {
        this._logger = logger;
        this._dbContext = dbContext;
    }

    [HttpGet]
    public IEnumerable<SicsTransacao> Get()
    {
        return _dbContext.SicsTransacoes;
    }

    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        SicsTransacao? transacao = await _dbContext.SicsTransacoes.FirstOrDefaultAsync(transacao => transacao.Id == id);
        if(transacao == null) 
            return NotFound(id);
        else
            return StatusCode(200, transacao);
    }

    [HttpGet("porPrestador")]
    public IEnumerable<SicsTransacao> GetTransacoesPrestador(
        [FromQuery] int PrestadorID
    )
    {
        return _dbContext.SicsTransacoes.Where(t => t.PrestadorId == PrestadorID).AsEnumerable<SicsTransacao>();
    }

    [HttpGet("porCliente")]
    public IEnumerable<SicsTransacao> GetTransacoesCliente(
        [FromQuery] int ClienteID
    )
    {
        return _dbContext.SicsTransacoes.Where(t => t.PrestadorId == ClienteID).AsEnumerable<SicsTransacao>();
    }

    [HttpGet("porData")]
    public IEnumerable<SicsTransacao> GetTransacoesData(
        [FromQuery] DateTime data
    )
    {
        return _dbContext.SicsTransacoes.Where(t => t.Data == data).AsEnumerable<SicsTransacao>();
    }

    [HttpPost]
    public async Task<IActionResult> PostTransacao(
        [FromBody] SicsTransacao transacao
    )
    {
        if(!ModelState.IsValid) return BadRequest(ModelState);
        _dbContext.Add<SicsTransacao>(transacao);
        await _dbContext.SaveChangesAsync();
        return Ok(transacao);
    }

    [HttpPatch("efetiva")]
    public async Task<IActionResult> EfetivaTransacao([FromQuery] int id)
    {
        try
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);

            SicsTransacao? transacao = await _dbContext.SicsTransacoes.FirstOrDefaultAsync(s => s.Id == id);

            if(transacao == null) return NotFound(transacao);
            transacao.Efetivado = true;
            _dbContext.Entry<SicsTransacao>(transacao).CurrentValues.SetValues(transacao);

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

            SicsTransacao? transacao = await _dbContext.SicsTransacoes.FirstOrDefaultAsync(s => s.Id == id);

            if(transacao == null) return NotFound(transacao);
            transacao.Efetivado = false;
            transacao.Cancelado = true;
            transacao.MotivoCancelamento = motivoCancelamento;
            _dbContext.Entry<SicsTransacao>(transacao).CurrentValues.SetValues(transacao);

            await _dbContext.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}