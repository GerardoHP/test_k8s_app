namespace testK8sApp.Domain.Repositories;

public interface IProofOfLifeRepository
{
    Task<bool> GetProofOfLife();
}