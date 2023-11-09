using Microsoft.EntityFrameworkCore;
using testK8sApp.Domain.Repositories;

namespace testK8sApp.Data.Repositories;

public class ProofOfLifeRepository: IProofOfLifeRepository
{
    private readonly PublishingContext _publishingContext;

    public ProofOfLifeRepository(PublishingContext publishingContext)
    {
        _publishingContext = publishingContext;
    }

    public async Task<bool> GetProofOfLife()
    {
        return await _publishingContext.Database.CanConnectAsync();
    }
}