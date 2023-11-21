namespace testK8sApp.Domain.Repositories;

public interface IGenericRepository<T>
{
    Task<T?> GetById(int id);

    Task<List<T>> GetAll();

    Task<T> Add(T entity);

    Task Delete(int id);

    Task<T?> Update(int id, T entity);
}