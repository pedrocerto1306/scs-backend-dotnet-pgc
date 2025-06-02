using Microsoft.AspNetCore.Mvc;
using sics_webapi.Data;
using sics_webapi.Models.Interfaces;

namespace sics_webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class SicsFilesController : ControllerBase
{
    private readonly ILogger<SicsClientesController> _logger;
    private readonly DataContext _dbContext;
    private readonly IS3StorageService _s3StorageService;

    public SicsFilesController(ILogger<SicsClientesController> logger, DataContext dbContext, IS3StorageService s3StorageService)
    {
        this._logger = logger;
        this._dbContext = dbContext;
        this._s3StorageService = s3StorageService;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Nenhum arquivo enviado.");
        }

        try
        {
            var key = $"uploads/{Guid.NewGuid().ToString()}_{file.FileName}";

            using (var stream = file.OpenReadStream())
            {
                var fileUrl = await _s3StorageService.UploadFileAsync(key, stream, file.ContentType);
                return Ok(new { Message = "Arquivo enviado com sucesso!", Url = fileUrl });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao fazer upload do arquivo: {ex.Message}");
        }
    }
}