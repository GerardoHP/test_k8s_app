using Microsoft.AspNetCore.Mvc;

namespace testK8sApp.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class VersionController : ControllerBase
{
    private readonly ILogger<VersionController> _logger;
    private readonly Info _info;

    public VersionController(ILogger<VersionController> logger, Info info)
    {
        _logger = logger;
        _info = info;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("api versioning hit");
        return Ok("version");
    }

    [HttpGet("Container")]
    public IActionResult GetContainerId()
    {
        _logger.LogInformation("container Id: {container}", _info.ContainerId);
        return Ok(_info.ContainerId);
    }
}