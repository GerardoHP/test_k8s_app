using Microsoft.EntityFrameworkCore;
using testK8sApp.Domain.Repositories;

namespace testK8sApp.Data.Repositories;

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly PublishingContext _publishingContext;

    protected GenericRepository(PublishingContext publishingContext)
    {
        _publishingContext = publishingContext;
    }
    
    public async Task<T?> GetById(int id)
    {
        return await _publishingContext
            .Set<T>()
            .FindAsync(id);
    }

    public async Task<List<T>> GetAll()
    {
        return await _publishingContext
            .Set<T>()
            .ToListAsync();
    }

    public async Task<T> Add(T entity)
    {
        var inserted = await _publishingContext
            .Set<T>()
            .AddAsync(entity);
        await _publishingContext.SaveChangesAsync();
        return inserted.Entity;
    }

    public async Task Delete(int id)
    {
        var entity = await _publishingContext
            .Set<T>()
            .FindAsync(id);
        if (entity is not null)
        {
            _publishingContext
                .Set<T>()
                .Remove(entity);
            await _publishingContext.SaveChangesAsync();
        }
    }

    public async Task<T?> Update(int id, T entity)
    {
        var exist = await _publishingContext.Set<T>().FindAsync(id);
        if (exist is null) return entity;
        _publishingContext.Set<T>().Entry(entity).State = EntityState.Modified;
        await _publishingContext.SaveChangesAsync();
        return entity;
    }
}