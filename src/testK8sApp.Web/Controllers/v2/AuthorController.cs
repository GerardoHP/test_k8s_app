using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using testK8sApp.Domain.Repositories;

namespace testK8sApp.Web.Controllers.v2;

[Route("api/[controller]")]
[ApiController]
[ApiVersion("2.0")]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly IAuthorRepository _authorRepository;
    private readonly IMapper _mapper;

    public AuthorController(ILogger<AuthorController> logger, IAuthorRepository authorRepository, IMapper mapper)
    {
        _logger = logger;
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthorById(int id)
    {
        _logger.LogInformation("getting author by id {Id} ", id);
        var author = await _authorRepository.GetAuthorById(id);
        var authorDto = _mapper.Map<Dto.Author>(author);
        return Ok(authorDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAuthors()
    {
        _logger.LogInformation("getting authors");
        var authors = await _authorRepository.GetAuthors();
        var authorsDto = _mapper.Map<List<Dto.Author>>(authors);
        return Ok(authorsDto);
    }

    [HttpGet("WithBooks")]
    public async Task<IActionResult> GetAuthorsWithBooks()
    {
        _logger.LogInformation("getting authors");
        var authors = await _authorRepository.GetAuthorsWithBooks();
        var authorsDto = _mapper.Map<List<Dto.AuthorWithBooks>>(authors);
        return Ok(authorsDto);
    }

    [HttpPost]
    public async Task<IActionResult> PostAuthor(Dto.AuthorWithBooks authorDto)
    {
        var author = _mapper.Map<Domain.Author>(authorDto);
        author = await _authorRepository.Add(author);
        _logger.LogInformation("posting author {Id} generated", author.AuthorId);
        authorDto = _mapper.Map<Dto.AuthorWithBooks>(author);
        return Ok(authorDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        _logger.LogInformation("deleting author {Id} ", id);
        await _authorRepository.Delete(id);
        return NoContent();
    }

    [HttpGet("GeAuthorsByName")]
    public async Task<IActionResult> GetAuthors([FromQuery] string name)
    {
        _logger.LogInformation("getting authors by name {Name} ", name);
        var authors = await _authorRepository.GetByAuthorName(name);
        var authorsDto = _mapper.Map<List<Dto.Author>>(authors);
        return Ok(authorsDto);
    }
}