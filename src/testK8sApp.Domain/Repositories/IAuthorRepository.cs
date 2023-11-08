namespace testK8sApp.Domain.Repositories;

public interface IAuthorRepository
{
    Task<Author?> GetAuthorById(int id);

    Task<List<Author>> GetAuthors();

    Task<List<Author>> GetAuthorsWithBooks();

    Task<Author> Add(Author author);
}