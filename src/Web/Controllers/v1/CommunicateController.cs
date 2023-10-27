using Microsoft.AspNetCore.Mvc;

namespace testK8sApp.Web.Controllers.v1;

[ApiController]
[Route("api/[controller]")]
public class CommunicateController : ControllerBase
{
    private readonly ILogger<CommunicateController> _logger;
    private readonly Client _client;

    public CommunicateController(ILogger<CommunicateController> logger, Client client)
    {
        _logger = logger;
        _client = client;
    }

    [HttpGet]
    public async Task<IActionResult> Get(string name)
    {
        _logger.LogInformation("post to gRpc");
        try
        {
            var result = await _client.ExecuteAsync(name, CancellationToken.None);
            return Ok(result);
        }
        catch
        {
            return BadRequest();
        }
    }
}