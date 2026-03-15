using InstalledSoftwareRadarApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace InstalledSoftwareRadarApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppsController : ControllerBase
{
    private readonly SoftwareScannerService _scanner;

    public AppsController(SoftwareScannerService scanner)
    {
        _scanner = scanner;
    }

    /// <summary>
    /// Retorna todos os programas instalados no PC
    /// </summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var apps = _scanner.ScanAll();
        return Ok(apps);
    }

    /// <summary>
    /// Busca um programa pelo nome
    /// </summary>
    [HttpGet("search")]
    public IActionResult Search([FromQuery] string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return BadRequest("Informe o nome do programa.");

        var apps = _scanner.ScanAll();

        var result = apps
            .Where(a => a.Key.Contains(name, StringComparison.OrdinalIgnoreCase))
            .ToDictionary(a => a.Key, a => a.Value);

        if (!result.Any())
            return NotFound($"Nenhum programa encontrado com o nome '{name}'.");

        return Ok(result);
    }
}