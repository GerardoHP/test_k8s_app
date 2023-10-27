using Grpc.Net.Client;
using testK8sApp.Web.Protos;

namespace testK8sApp.Web;

public class Client 
{
    private readonly ILogger<Client> _logger;
    private readonly Info _info;

    public Client(ILogger<Client> logger, Info info)
    {
        _logger = logger;
        _info = info;
    }
    
    public async Task<string> ExecuteAsync(string name, CancellationToken stoppingToken)
    {
        using var channel = GrpcChannel.ForAddress(_info.GrpcServiceUrl);
        var client = new MyService.MyServiceClient(channel);
        var reply = await client.SayHelloAsync(new HelloRequest()
        {
            Name = name,
        }, cancellationToken: stoppingToken);

        _logger.LogInformation("{0} replied {1} ", _info.GrpcServiceUrl, reply.Message);
        return reply.Message;
    }
}