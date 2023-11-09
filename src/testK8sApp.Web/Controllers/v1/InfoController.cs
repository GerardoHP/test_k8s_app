using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using testK8sApp.Data;
using testK8sApp.Domain.Repositories;

namespace testK8sApp.Web.Controllers.v1;

[ApiController]
// [Route("api/v{version:apiVersion}/[controller]")]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class InfoController : ControllerBase
{
    private readonly ILogger<InfoController> _logger;
    private readonly Info _info;
    private readonly IProofOfLifeRepository _proofOfLifeRepository;

    public InfoController(ILogger<InfoController> logger, Info info, IProofOfLifeRepository proofOfLifeRepository)
    {
        _logger = logger;
        _info = info;
        _proofOfLifeRepository = proofOfLifeRepository;
    }
    
    [HttpGet("Version")]
    // [MapToApiVersion("2.0")]
    public IActionResult GetVersion()
    {
        _logger.LogInformation("api version {Version} hit", 1);
        return Ok("version 1");
    }
    
    [HttpGet("Container")]
    public IActionResult GetContainerId()
    {
        _logger.LogInformation("container Id: {Container}", _info.ContainerId);
        return Ok(_info.ContainerId);
    }

    [HttpGet("proofOfLife")]
    public async Task<IActionResult> GetProofOfLife()
    {
        _logger.LogInformation("proof of life hit");
        var proofOfLife = await _proofOfLifeRepository.GetProofOfLife();
        if (proofOfLife)
        {
            return Ok();
        }

        return NotFound();
    }
}