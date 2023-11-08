using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using testk8sApp.Data;

namespace testK8sApp.Web.Controllers.v2;

[Route("api/[controller]")]
[ApiController]
[ApiVersion("2.0")]
public class AuthorController : ControllerBase
{
    private readonly ILogger<AuthorController> _logger;
    private readonly BloggingContext _bloggingContext;

    public AuthorController(ILogger<AuthorController> logger, BloggingContext bloggingContext)
    {
        _logger = logger;
        _bloggingContext = bloggingContext;
    }

    [HttpGet]
    public IActionResult GetAuthors()
    {
        _logger.LogInformation("getting authors");
        var authors = _bloggingContext.Authors.ToList();
        return Ok(authors);
    }

    [HttpGet("WithBooks")]
    public IActionResult GetAuthorsWithBooks()
    {
            _logger.LogInformation("getting authors");
                    var authors = _bloggingContext
            .Authors
            .Include(a => a.Books)
                .ToList();
        
        return Ok(authors);
    }

    [HttpPost]
    public IActionResult PostAuthor(Author author)
    {
        _logger.LogInformation("posting author ", author);
        _bloggingContext.Authors.Add(author);
        _bloggingContext.SaveChanges();
        return Ok(author);
    }
}