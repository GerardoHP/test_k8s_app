using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using testk8sApp.Data;

namespace testK8sApp.Web.Controllers.v2;

[ApiController]
// [Route("api/v{version:apiVersion}/info")]
[Route("api/info")]
[ApiVersion("2.0")]
public class InfoV2Controller : ControllerBase
{
    private readonly ILogger<InfoV2Controller> _logger;
    private readonly Info _info;
    private readonly BloggingContext _bloggingContext;

    public InfoV2Controller(ILogger<InfoV2Controller> logger, 
        Info info,
        BloggingContext bloggingContext)
    {
        _logger = logger;
        _info = info;
        _bloggingContext = bloggingContext;
    }
    
    [HttpGet("Version")]
    public IActionResult GetVersion()
    {
        _logger.LogInformation("api versioning hit");
        return Ok("version 2");
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