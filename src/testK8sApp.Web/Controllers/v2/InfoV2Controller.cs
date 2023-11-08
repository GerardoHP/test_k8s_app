using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace testK8sApp.Web.Controllers.v2;

[ApiController]
// [Route("api/v{version:apiVersion}/info")]
[Route("api/info")]
[ApiVersion("2.0")]
public class InfoV2Controller : ControllerBase
{
    private readonly ILogger<InfoV2Controller> _logger;

    public InfoV2Controller(ILogger<InfoV2Controller> logger)
    {
        _logger = logger;
    }
        
    [HttpGet("Version")]
    public IActionResult GetVersion()
    {
        _logger.LogInformation("api version {Version} hit", GetVersion());
        return Ok("version 2");
    }
}