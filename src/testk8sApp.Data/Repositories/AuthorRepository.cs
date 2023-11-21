using Microsoft.EntityFrameworkCore;
using testK8sApp.Domain;
using testK8sApp.Domain.Repositories;

namespace testK8sApp.Data.Repositories;

public class AuthorRepository : GenericRepository<Author>, IAuthorRepository 
{
    private readonly PublishingContext _publishingContext;

    public AuthorRepository(PublishingContext publishingContext)
        :base(publishingContext)
    {
        _publishingContext = publishingContext;
    }
    
    public async Task<List<Author>> GetAuthorsWithBooks()
    {
        return await _publishingContext
            .Authors
            .Include(a => a.Books)
            .ToListAsync();
    }

    public async Task<List<Author>> GetByAuthorName(string name)
    {
        return await _publishingContext
            .Authors
            .Where(a => a.FirstName.ToLower().Contains(name) || a.LastName.ToLower().Contains(name))
            .ToListAsync();
    }

    public async Task<Author?> PatchAuthor(int id, Author author)
    {
        var entity = await GetById(id);
        if (entity is null) return entity;
        entity.FirstName = string.IsNullOrEmpty(author.FirstName) ? entity.FirstName : author.FirstName;
        entity.LastName = string.IsNullOrEmpty(author.LastName) ? entity.LastName : author.LastName;
        return await Update(id, entity);
    }
}