using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using testK8sApp.Web.Data;

namespace testK8sApp.Web.Controllers.v1;

[ApiController]
// [Route("api/v{version:apiVersion}/[controller]")]
[Route("api/[controller]")]
[ApiVersion("1.0")]
public class InfoController : ControllerBase
{
    private readonly ILogger<InfoController> _logger;
    private readonly Info _info;
    private readonly BloggingContext _bloggingContext;

    public InfoController(ILogger<InfoController> logger, 
        Info info,
        BloggingContext bloggingContext)
    {
        _logger = logger;
        _info = info;
        _bloggingContext = bloggingContext;
    }
    
    [HttpGet("Version")]
    // [MapToApiVersion("2.0")]
    public IActionResult GetVersion()
    {
        _logger.LogInformation("api versioning hit");
        return Ok("version 1");
    }
    
    [HttpGet("Container")]
    public IActionResult GetContainerId()
    {
        _logger.LogInformation("container Id: {container}", _info.ContainerId);
        return Ok(_info.ContainerId);
    }

    [HttpGet("proofOfLife")]
    public IActionResult GetProofOfLife()
    {
        _logger.LogInformation("proof of life hit");
        var id = _bloggingContext.ProofOfLives?.First().Id;
        if (id.HasValue)
        {
            return Ok(id.Value);
        }
        else
        {
            return NotFound();
        }
    }
}