using Microsoft.EntityFrameworkCore;
using testK8sApp.Domain;
using testK8sApp.Domain.Repositories;

namespace testK8sApp.Data.Repositories;

public class AuthorRepository:IAuthorRepository
{
    private readonly PublishingContext _publishingContext;

    public AuthorRepository(PublishingContext publishingContext)
    {
        _publishingContext = publishingContext;
    }

    public async Task<Author?> GetAuthorById(int id)
    {
        return await _publishingContext.Authors.FindAsync(id);
    }

    public async Task<List<Author>> GetAuthors()
    {
        return await _publishingContext
            .Authors
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Author>> GetAuthorsWithBooks()
    {
        return await _publishingContext
            .Authors
            .AsNoTracking()
            .Include(a => a.Books)
            .ToListAsync();
    }

    public async Task<Author> Add(Author author)
    {
        var authorInserted = await _publishingContext.Authors.AddAsync(author);
        await _publishingContext.SaveChangesAsync();
        return authorInserted.Entity;
    }
}