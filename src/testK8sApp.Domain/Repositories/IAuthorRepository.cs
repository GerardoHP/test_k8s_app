namespace testK8sApp.Domain.Repositories;

public interface IAuthorRepository : IGenericRepository<Author>
{
    Task<List<Author>> GetAuthorsWithBooks();
    Task<List<Author>> GetByAuthorName(string name);
    Task<Author?> PatchAuthor(int id, Author author);
}